using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ElectronicsMS.Forms.Forms
{
    public partial class PriceSetup : Page
    {
        SqlConnection con;
        SqlCommand Cmd;
        public DataTable dtPriceSetup
        {
            get
            {
                object obj = this.Session["dtPriceSetup"];
                if (obj != null)
                {
                    return (DataTable)obj;
                }
                DataTable dt1 = new DataTable();

                dt1.Columns.Add("rowid", typeof(Int32));
                dt1.Columns.Add("CustId", typeof(string));
                dt1.Columns.Add("CustName", typeof(string));
                dt1.Columns.Add("ItemCode", typeof(string));
                dt1.Columns.Add("ItemAlias", typeof(string));
                dt1.Columns.Add("ItemName", typeof(string));
                dt1.Columns.Add("Price", typeof(decimal));
                dt1.Columns.Add("Remarks", typeof(string));

                dt1.PrimaryKey = new DataColumn[] {dt1.Columns["ItemCode"],
                                         dt1.Columns["CustId"]};

                this.Session["dtPriceSetup"] = dt1;
                return dtPriceSetup;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtPriceSetup.Clear();
            }
        }
        public void ClearControl()
        {
            dtPriceSetup.Clear();
            rgMain.Rebind();
        }
        private void ReloadMainGrid()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();
            Cmd = new SqlCommand("Sp_CustomerWisePriceSetup", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 6;
            Cmd.Parameters.Add("@CustId", SqlDbType.NVarChar).Value = cmCustomerName.SelectedValue;
            SqlDataAdapter adpt = new SqlDataAdapter(Cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            adpt.Fill(ds);
            dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow newRow = this.dtPriceSetup.NewRow();
                newRow["rowid"] = this.dtPriceSetup.Rows.Count + 1;
                newRow["CustId"] = dt.Rows[i]["CustId"].ToString();
                newRow["CustName"] = dt.Rows[i]["CustName"].ToString();
                newRow["ItemCode"] = dt.Rows[i]["ItemCode"].ToString();
                newRow["ItemAlias"] = dt.Rows[i]["ItemAlias"].ToString();
                newRow["ItemName"] = dt.Rows[i]["ItemName"].ToString();
                newRow["Price"] = dt.Rows[i]["Price"].ToString();
                newRow["Remarks"] = dt.Rows[i]["Remarks"].ToString();
                this.dtPriceSetup.Rows.Add(newRow);
                this.dtPriceSetup.AcceptChanges();
            }
            rgMain.Rebind();
        }
        private void SaveData()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();

            SqlTransaction myTran;
            SqlCommand Cmd = con.CreateCommand();
            myTran = con.BeginTransaction();
            Cmd.Connection = con;
            Cmd.Transaction = myTran;
            Cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                Cmd = new SqlCommand("Sp_CustomerWisePriceSetup", con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 3;
                Cmd.Parameters.Add("@CustId", SqlDbType.Int).Value = cmCustomerName.SelectedValue;
                Cmd.Transaction = myTran;
                Cmd.ExecuteNonQuery();
                Cmd.Dispose();

                for (int i = 0; i < dtPriceSetup.Rows.Count; i++)
                {
                    Cmd = new SqlCommand("Sp_CustomerWisePriceSetup", con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 1;
                    Cmd.Parameters.Add("@CustId", SqlDbType.VarChar).Value = cmCustomerName.SelectedValue;
                    Cmd.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = dtPriceSetup.Rows[i]["ItemCode"].ToString();
                    Cmd.Parameters.Add("@Price", SqlDbType.VarChar).Value = dtPriceSetup.Rows[i]["Price"].ToString();
                    Cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = AppEnv.Current.p_UserName.ToString();
                    Cmd.Transaction = myTran;
                    Cmd.ExecuteNonQuery();
                    lblMessage.Text = "Price Set Successfull.";
                }
                Cmd.Dispose();
                myTran.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
            }
        }
        private void DataRefillForGrid()
        {
            GridDataItem selectedItem = (GridDataItem)rgMain.SelectedItems[0];
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();
            Cmd = new SqlCommand("Sp_CustomerWisePriceSetup", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = "";
            Cmd.Parameters.Add("@CustId", SqlDbType.VarChar).Value = selectedItem["CustId"].Text;
            Cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = selectedItem["Category"].Text;
            SqlDataAdapter adpt = new SqlDataAdapter(Cmd);
            DataSet ds = new DataSet();
            DataTable dt1 = new DataTable();
            adpt.Fill(ds);
            dt1 = ds.Tables[0];
            cmItemName.Text = dt1.Rows[0]["ItemCode"].ToString();
            cmItemName.Text = dt1.Rows[0]["ItemName"].ToString();
            //cmCategory.Text = dt1.Rows[0][""].ToString();
            //cmCategory.Text = dt1.Rows[0][""].ToString();
            cmCustomerName.Text = dt1.Rows[0]["CustId"].ToString();
            cmCustomerName.Text = dt1.Rows[0]["CustName"].ToString();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cmCustomerName.SelectedValue == "")
            {
                lblMessage.Text = "Select Customer.";
            }
            else
            {
                try
                {
                    SaveData();
                    ClearControl();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
        }

        protected void cmCustomerName_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                Cmd = new SqlCommand("Sp_Sales", con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 8;
                SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dataRow in dt.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = (string)dataRow["Name"];
                    item.Value = dataRow["CustId"].ToString();

                    string Id = (string)dataRow["CustId"].ToString();
                    item.Attributes.Add("CustId", Id.ToString());

                    string Address = (string)dataRow["Address"].ToString();
                    item.Attributes.Add("Address", Address.ToString());

                    cmCustomerName.Items.Add(item);
                    item.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void cmItemName_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            if (cmCategory.SelectedValue != "")
            {
                cmItemName.Items.Clear();
                cmItemName.Text = "";
                cmItemName.SelectedValue = "";
                try
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                    con.Open();
                    Cmd = new SqlCommand("Sp_Sales", con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 12;
                    Cmd.Parameters.Add("@ItemCatId", SqlDbType.Int).Value = cmCategory.SelectedValue;
                    SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        RadComboBoxItem item = new RadComboBoxItem();
                        item.Text = (string)dataRow["ItemName"];
                        item.Value = dataRow["ItemCode"].ToString();

                        string ItemCode = (string)dataRow["ItemCode"].ToString();
                        item.Attributes.Add("ItemCode", ItemCode.ToString());

                        string ItemAlias = (string)dataRow["ItemAlias"].ToString();
                        item.Attributes.Add("ItemAlias", ItemAlias.ToString());

                        cmItemName.Items.Add(item);
                        item.DataBind();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
        }
        protected void cmItemName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
        protected void cmCategory_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cmItemName.Items.Clear();
            cmItemName.Text = "";
            cmItemName.SelectedValue = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                Cmd = new SqlCommand("Sp_Sales", con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 12;
                Cmd.Parameters.Add("@ItemCatId", SqlDbType.Int).Value = cmCategory.SelectedValue;
                SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dataRow in dt.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = (string)dataRow["ItemName"];
                    item.Value = dataRow["ItemCode"].ToString();

                    string ItemCode = (string)dataRow["ItemCode"].ToString();
                    item.Attributes.Add("ItemCode", ItemCode.ToString());

                    string ItemAlias = (string)dataRow["ItemAlias"].ToString();
                    item.Attributes.Add("ItemAlias", ItemAlias.ToString());

                    cmItemName.Items.Add(item);
                    item.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            dtPriceSetup.Clear();
            rgMain.Rebind();
            ReloadMainGrid();
        }

        protected void rgMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ClearControl();
            //DataRefillForGrid();
            //ButtonControl("E");
            //EnableControl(true);
        }
        protected void rgMain_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgMain.DataSource = this.dtPriceSetup;
        }
        protected void rgMain_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridFooterItem)
            {
                //decimal total1 = 0;

                if (this.dtPriceSetup.Rows.Count > 0)
                {
                    for (int i = 0; i < this.dtPriceSetup.Rows.Count; i++)
                    {
                        //total1 += Convert.ToDecimal(this.dtMeasureQty.Rows[i]["itemqty"]);
                    }
                }

                GridFooterItem footerItem = e.Item as GridFooterItem;
                //footerItem["ItemQty"].Text = total1.ToString();
                //footerItem["Item"].Text = "Total : ";
                footerItem.BackColor = System.Drawing.Color.LightGray;
            }

            if (e.Item.IsInEditMode && e.Item is GridEditableItem)
            {
                int Index = e.Item.ItemIndex;
                GridEditableItem item = e.Item as GridEditableItem;

                //TextBox rowid = item.FindControl("rowidTextBox") as TextBox;
                TextBox ItemCode = item.FindControl("ItemCodeTextBox") as TextBox;
                TextBox ItemName = item.FindControl("ItemNameTextBox") as TextBox;
                TextBox Price = item.FindControl("PriceTextBox") as TextBox;

                ItemCode.Enabled = false;
                ItemName.Enabled = false;
                //rowid.Text = this.dtMeasureQty.Rows[Index]["rowid"].ToString();
                ItemCode.Text = this.dtPriceSetup.Rows[Index]["ItemCode"].ToString();
                ItemName.Text = this.dtPriceSetup.Rows[Index]["ItemName"].ToString();
                Price.Text = this.dtPriceSetup.Rows[Index]["Price"].ToString();
            }
        }
        protected void rgMain_ItemUpdated(object sender, GridUpdatedEventArgs e)
        {
            GridEditableItem item = (GridEditableItem)e.Item;
            String id = item.GetDataKeyValue("Item").ToString();
            if (e.Exception != null)
            {
                e.KeepInEditMode = true;
                e.ExceptionHandled = true;
            }
            else
            {

            }
        }
        protected void rgMain_EditCommand(object sender, GridCommandEventArgs e)
        {
            int index = e.Item.ItemIndex + 1;
        }
        protected void rgMain_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridEditableItem EditItem1 = (GridEditableItem)e.Item;
                GridEditableItem editedItem = e.Item as GridEditableItem;
                GridEditManager editMan = editedItem.EditManager;

                //TextBox rowid = EditItem1.FindControl("rowidTextBox") as TextBox;
                TextBox TechID = EditItem1.FindControl("ItemCodeTextBox") as TextBox;
                TextBox FloorD = EditItem1.FindControl("ItemNameTextBox") as TextBox;
                TextBox FloorH = EditItem1.FindControl("PriceTextBox") as TextBox;

                string im = TechID.Text;
                string iq = FloorD.Text;
                string qy = FloorH.Text;

                int x = e.Item.ItemIndex;
                String id = this.dtPriceSetup.Rows[x]["rowid"].ToString();
                DataRow[] changedRows = this.dtPriceSetup.Select("rowid=" + id);

                foreach (GridColumn column in e.Item.OwnerTableView.RenderColumns)
                {
                    if (column is IGridEditableColumn)
                    {
                        IGridEditableColumn editableCol = (column as IGridEditableColumn);
                        if (editableCol.IsEditable)
                        {
                            IGridColumnEditor editor = editMan.GetColumnEditor(editableCol);

                            string editorType = editor.ToString();
                            string editorText = "unknown";
                            object editorValue = null;

                            if (editor is GridTextColumnEditor)
                            {
                                editorText = (editor as GridTextColumnEditor).Text;
                                editorValue = (editor as GridTextColumnEditor).Text;
                            }

                            if (editor is GridBoundColumn)
                            {
                                editorText = (editor as GridTextColumnEditor).Text;
                                editorValue = (editor as GridTextColumnEditor).Text;
                            }
                            if (editor is GridBoolColumnEditor)
                            {
                                editorText = (editor as GridBoolColumnEditor).Value.ToString();
                                editorValue = (editor as GridBoolColumnEditor).Value;
                            }

                            if (editor is GridDropDownColumnEditor)
                            {
                                editorText = (editor as GridDropDownColumnEditor).SelectedText + "; " +
                                    (editor as GridDropDownColumnEditor).SelectedValue;
                                editorValue = (editor as GridDropDownColumnEditor).SelectedValue;
                            }
                            if (editor is GridDateTimeColumnEditor)
                            {
                                editorText = (editor as GridDateTimeColumnEditor).Text;
                                editorValue = (editor as GridDateTimeColumnEditor).Text;
                            }

                            changedRows[0][column.UniqueName] = editorValue;

                            //changedRows[0]["rowid"] = rowid.Text;
                            changedRows[0]["ItemCode"] = TechID.Text;
                            changedRows[0]["ItemName"] = FloorD.Text;
                            changedRows[0]["Price"] = FloorH.Text;

                            this.dtPriceSetup.AcceptChanges();

                            rgMain.DataSource = this.dtPriceSetup;
                            rgMain.Rebind();
                        }
                    }
                }
                rgMain.Rebind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void cmCustomerName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            dtPriceSetup.Clear();
            rgMain.Rebind();
            ReloadMainGrid();
        }
    }
}