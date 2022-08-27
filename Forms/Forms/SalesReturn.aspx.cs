using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ElectronicsMS.Forms.Forms
{
    public partial class SalesReturn : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand Cmd;
        public DataTable dtItemReturn
        {
            get
            {
                object obj = this.Session["dtItemReturn"];
                if (obj != null)
                {
                    return (DataTable)obj;
                }
                DataTable dt1 = new DataTable();

                dt1.Columns.Add("rowid", typeof(Int16));
                dt1.Columns.Add("SalesId", typeof(string));
                dt1.Columns.Add("ItemCode", typeof(string));
                dt1.Columns.Add("Barcode", typeof(string));
                dt1.Columns.Add("ItemName", typeof(string));
                dt1.Columns.Add("ItemSize", typeof(string));
                dt1.Columns.Add("Pack", typeof(string));
                dt1.Columns.Add("Category", typeof(string));
                dt1.Columns.Add("Qty", typeof(decimal));
                dt1.Columns.Add("UnitPrice", typeof(decimal));
                dt1.Columns.Add("Amount", typeof(decimal));

                dt1.PrimaryKey = new DataColumn[] { dt1.Columns["Barcode"] };

                this.Session["dtItemReturn"] = dt1;
                return dtItemReturn;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EnableControl(false);
                dtItemReturn.Clear();
            }
        }
        public void EnableControl(bool ec)
        {
            txtRemarks.Enabled = ec;
            cmInvoice.Enabled = ec;
            RadDatePicker1.Enabled = ec;
        }
        public void ClearControl()
        {
            cmCustomer.Text = "";
            cmCustomer.SelectedValue = "";
            cmInvoice.Text = "";
            cmInvoice.SelectedValue = "";
            txtRemarks.Text = "";
            RadDatePicker1.SelectedDate = null;
            dtItemReturn.Clear();
            rgMain.Rebind();
        }

        private void ReloadMainGrid()
        {
            dtItemReturn.Clear();
            rgMain.Rebind();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();
            Cmd = new SqlCommand("Sp_SalesReturn", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 5;
            Cmd.Parameters.Add("@SalesId", SqlDbType.Int).Value = cmInvoice.SelectedValue;
            SqlDataAdapter adpt = new SqlDataAdapter(Cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            adpt.Fill(ds);
            dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow newRow = this.dtItemReturn.NewRow();
                newRow["rowid"] = this.dtItemReturn.Rows.Count + 1;
                newRow["SalesId"] = dt.Rows[i]["SalesId"].ToString();
                newRow["ItemCode"] = dt.Rows[i]["ItemCode"].ToString();
                newRow["Barcode"] = dt.Rows[i]["Barcode"].ToString();
                newRow["ItemName"] = dt.Rows[i]["ItemName"].ToString();
                newRow["ItemSize"] = dt.Rows[i]["ItemSize"].ToString();
                newRow["Category"] = dt.Rows[i]["Category"].ToString();
                newRow["Qty"] = dt.Rows[i]["Qty"].ToString();
                newRow["Pack"] = dt.Rows[i]["Pack"].ToString();
                newRow["UnitPrice"] = dt.Rows[i]["UnitPrice"].ToString();
                newRow["Amount"] = dt.Rows[i]["Amount"].ToString();
                this.dtItemReturn.Rows.Add(newRow);
                this.dtItemReturn.AcceptChanges();
            }
            rgMain.Rebind();
        }
        private void SaveData()
        {
            //con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            //con.Open();

            //try
            //{
            //    if (this.dtItemReturn.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < this.dtItemReturn.Rows.Count; i++)
            //        {
            //            Cmd = new SqlCommand("Sp_SalesReturn", con); // if return then need to increase stock
            //            Cmd.CommandType = CommandType.StoredProcedure;
            //            Cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 111;
            //            Cmd.Parameters.Add("@CustCode", SqlDbType.NVarChar).Value = cmCustomer.SelectedValue;
            //            Cmd.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = cmInvoice.SelectedValue;
            //            Cmd.Parameters.Add("@Itemcode", SqlDbType.Int).Value = this.dtItemReturn.Rows[i]["ItemCode"].ToString();
            //            Cmd.Parameters.Add("@BarCode", SqlDbType.NVarChar).Value = this.dtItemReturn.Rows[i]["BarCode"].ToString();
            //            Cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = this.dtItemReturn.Rows[i]["Qty"].ToString();
            //            Cmd.ExecuteNonQuery();
            //            Cmd.Dispose();
            //        }
            //    }
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    lblMessage.Text = ex.Message.ToString();
            //}
        }
        private void DataRefillForGrid()
        {
            //GridDataItem selectedItem = (GridDataItem)rgMain.SelectedItems[0];
            //ViewState["ItemCode"] = selectedItem["ItemCode"].Text;
            //ViewState["rowid"] = selectedItem["rowid"].Text;

            //con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            //con.Open();
            //Cmd = new SqlCommand("ItemInfo", con);
            //Cmd.CommandType = CommandType.StoredProcedure;
            //Cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = "";
            //Cmd.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = selectedItem["ItemCode"].Text;
            //SqlDataAdapter adpt = new SqlDataAdapter(Cmd);
            //DataSet ds = new DataSet();
            //DataTable dt1 = new DataTable();
            //adpt.Fill(ds);
            //dt1 = ds.Tables[0];
            ////txtItemCode.Text = dt1.Rows[0]["ItemCode"].ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (RadDatePicker1.SelectedDate == null)
            {
                lblMessage.Text = "Select Date.";
            }
            else if (cmCustomer.SelectedValue == "")
            {
                lblMessage.Text = "Select Customer.";
            }
            else if (cmInvoice.SelectedValue == "")
            {
                lblMessage.Text = "Select Invoice.";
            }
            else
            {
                //if (lblOperationMode.Text == "Save Mode")
                //{
                try
                {
                    SaveData();
                    ClearControl();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
                //}
                //else if (lblOperationMode.Text == "Edit Mode")
                //{
                //    try
                //    {
                //        EditData();
                //    }
                //    catch (Exception ex)
                //    {
                //        lblMessage.Text = ex.Message;
                //    }
                //}
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
            EnableControl(false);
        }
        protected void rgMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControl();
            DataRefillForGrid();
            EnableControl(true);
        }
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                if (AppEnv.Current.p_rptSource != null)
                {
                    AppEnv.Current.p_rptSource.Close();
                    AppEnv.Current.p_rptSource.Dispose();
                }
                AppEnv.Current.p_rptSource = new ReportDocument();
                Cmd = new SqlCommand("ItemInfo", con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = "7";
                SqlDataAdapter Dap = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                Dap.Fill(dt);
                Cmd.Dispose();
                string tempPath = "";
                string reportName = "";
                reportName = "Item List";
                AppEnv.Current.p_rptObject = "~/Reports/Inventory/ItemList.rpt";
                tempPath = @System.IO.Path.GetTempPath() + "Item List";
                AppEnv.Current.p_rptSource.Load(Server.MapPath(AppEnv.Current.p_rptObject.ToString()));
                AppEnv.Current.p_rptSource.SetDataSource(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    ExportFormatType format = ExportFormatType.PortableDocFormat;
                    try
                    {
                        AppEnv.Current.p_rptSource.ExportToHttpResponse(format, Response, true, reportName);
                    }
                    finally
                    {
                        AppEnv.Current.p_rptSource.Close();
                        AppEnv.Current.p_rptSource.Dispose();
                        GC.Collect();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data is not Available.');", true);
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void cmCustomer_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                Cmd = new SqlCommand("Sp_SalesReturn", con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 8;
                SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dataRow in dt.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = (string)dataRow["Name"].ToString();
                    item.Value = dataRow["CustId"].ToString();

                    string Id = (string)dataRow["CustId"].ToString();
                    item.Attributes.Add("CustId", Id.ToString());

                    cmCustomer.Items.Add(item);
                    item.DataBind();
                }
                con.Close();
                //ReloadMainGrid();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void cmInvoice_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                Cmd = new SqlCommand("Sp_SalesReturn", con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 7;
                Cmd.Parameters.Add("@CustCode", SqlDbType.VarChar).Value = cmCustomer.SelectedValue;
                SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dataRow in dt.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = (string)dataRow["SalesId"].ToString();
                    item.Value = dataRow["SalesId"].ToString();
                    cmInvoice.Items.Add(item);
                    item.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void cmInvoice_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                //con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                //con.Open();
                //Cmd = new SqlCommand("Sp_SalesReturn", con);
                //Cmd.CommandType = CommandType.StoredProcedure;
                //Cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 5;
                //Cmd.Parameters.Add("@SalesId", SqlDbType.VarChar).Value = cmInvoice.SelectedValue;
                //SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
                //DataTable dt = new DataTable();
                //adapter.Fill(dt);
                //a.Itemcode,b.ItemName,c.Name as ,e.Name as Category, d.Name as ,b.,b.ExpiryDate,a.,a.,a.Amount 
                //txtAmount.Text = dt.Rows[0]["Amount"].ToString();
                //txtQty.Text = dt.Rows[0]["Qty"].ToString();
                //txtRate.Text = dt.Rows[0]["UnitPrice"].ToString();
                //lblLotNumber.Text = "Lot Number : " + dt.Rows[0]["LotNumber"].ToString();
                //lblPack.Text = "Pack : " + dt.Rows[0]["Pack"].ToString();
                //lblSize.Text = "Item Size: " + dt.Rows[0]["ItemSize"].ToString();

                //con.Close();

                if (cmInvoice.SelectedValue != "")
                {
                    ReloadMainGrid();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void cmCustomer_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmCustomer.SelectedValue == "")
            {
                lblMessage.Text = "Select Customer";
            }
            else
            {
                EnableControl(true);
                RadDatePicker1.SelectedDate = DateTime.Now;
            }
        }

        protected void rgMain_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgMain.DataSource = dtItemReturn;
        }
        protected void rgMain_ItemCommand(object sender, GridCommandEventArgs e)
        {
            //try
            //{

            if (e.CommandName == "GridDelete")
            {
                if (dtItemReturn.Rows.Count >= 1) // 
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    Label Rowid = item.FindControl("rowidLabel") as Label;
                    DataRow[] Drow = this.dtItemReturn.Select("rowid='" + Rowid.Text + "'");
                    if (Drow.Length > 0)
                    {
                        //ScriptManager.RegisterStartupScript(this, GetType(), "confirm", "confirm('Are you sure to return the Product?.');", true);
                        //ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "if(confirm('Sorry?')){alert('OK');}else{alert('cancel');}", true);

                        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                        con.Open();

                        string itemCode = this.dtItemReturn.Rows[0]["ItemCode"].ToString();
                        string barCode = this.dtItemReturn.Rows[0]["BarCode"].ToString();
                        string qty = this.dtItemReturn.Rows[0]["Qty"].ToString();

                        Cmd = new SqlCommand("Sp_SalesReturn", con); // if return then need to increase stock
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 111;
                        Cmd.Parameters.Add("@CustCode", SqlDbType.NVarChar).Value = cmCustomer.SelectedValue;
                        Cmd.Parameters.Add("@SalesId", SqlDbType.NVarChar).Value = cmInvoice.SelectedValue;
                        Cmd.Parameters.Add("@Itemcode", SqlDbType.Int).Value = this.dtItemReturn.Rows[0]["ItemCode"].ToString();
                        Cmd.Parameters.Add("@BarCode", SqlDbType.NVarChar).Value = this.dtItemReturn.Rows[0]["BarCode"].ToString();
                        Cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = this.dtItemReturn.Rows[0]["Qty"].ToString();
                        Cmd.ExecuteNonQuery();
                        Cmd.Dispose();

                        con.Close();

                        Drow[0].Delete();
                        this.dtItemReturn.AcceptChanges();
                        rgMain.Rebind();
                    }
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You Need At Least One Item to Edit.');", true);
                }
            }

            //}
            //catch (Exception ex)
            //{
            //    lblMessage.Text = ex.Message;
            //}
        }
        protected void rgMain_EditCommand(object sender, GridCommandEventArgs e)
        {
            int index = e.Item.ItemIndex + 1;
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
        protected void rgMain_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            //try
            //{
            GridEditableItem EditItem1 = (GridEditableItem)e.Item;
            GridEditableItem editedItem = e.Item as GridEditableItem;
            GridEditManager editMan = editedItem.EditManager;

            TextBox txtRpwId = EditItem1.FindControl("rowidTextBox") as TextBox;

            int x = e.Item.ItemIndex;
            String id = this.dtItemReturn.Rows[x]["rowid"].ToString();
            DataRow[] changedRows = this.dtItemReturn.Select("rowid=" + id);

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

                        //if (editor is GridTextColumnEditor)
                        //{
                        //    editorText = (editor as GridTextColumnEditor).Text;
                        //    editorValue = (editor as GridTextColumnEditor).Text;
                        //}

                        //if (editor is GridBoundColumn)
                        //{
                        //    editorText = (editor as GridTextColumnEditor).Text;
                        //    editorValue = (editor as GridTextColumnEditor).Text;
                        //}
                        //if (editor is GridBoolColumnEditor)
                        //{
                        //    editorText = (editor as GridBoolColumnEditor).Value.ToString();
                        //    editorValue = (editor as GridBoolColumnEditor).Value;
                        //}

                        //if (editor is GridDropDownColumnEditor)
                        //{
                        //    editorText = (editor as GridDropDownColumnEditor).SelectedText + "; " +
                        //        (editor as GridDropDownColumnEditor).SelectedValue;
                        //    editorValue = (editor as GridDropDownColumnEditor).SelectedValue;
                        //}
                        //if (editor is GridDateTimeColumnEditor)
                        //{
                        //    editorText = (editor as GridDateTimeColumnEditor).Text;
                        //    editorValue = (editor as GridDateTimeColumnEditor).Text;
                        //}

                        //changedRows[0][column.UniqueName] = editorValue;

                        this.dtItemReturn.AcceptChanges();

                        rgMain.DataSource = this.dtItemReturn;
                        rgMain.Rebind();
                    }
                }
            }
            rgMain.Rebind();
            //}
            //catch (Exception ex)
            //{
            //    lblMessage.Text = ex.Message;
            //}
        }
    }
}