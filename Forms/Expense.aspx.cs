using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using Telerik.Web.UI;

namespace ElectronicsMS.Forms
{
    public partial class Expense : Page
    {
        SqlConnection con;
        SqlCommand cmd;

        public DataTable dtExpenseGrid
        {
            get
            {
                object obj = this.Session["dtExpenseGrid"];
                if (obj != null)
                {
                    return (DataTable)obj;
                }
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("rowid", typeof(Int32));
                dt1.Columns.Add("Id", typeof(Int32));
                dt1.Columns.Add("CostHead", typeof(string));
                dt1.Columns.Add("CostElement", typeof(string));
                dt1.Columns.Add("Date", typeof(DateTime));
                dt1.Columns.Add("CostCenterName", typeof(string));
                dt1.Columns.Add("CostElementName", typeof(string));
                dt1.Columns.Add("HandedTo", typeof(string));
                dt1.Columns.Add("Amount", typeof(string));
                dt1.Columns.Add("Remarks", typeof(string));
                dt1.PrimaryKey = new DataColumn[] { dt1.Columns["rowid"] };
                this.Session["dtExpenseGrid"] = dt1;
                return dtExpenseGrid;
            }
        }
        public string GetAutoNumber(string fieldName, string tableName)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                string ss = "Select  convert(int,Max(" + fieldName + ")) from " + tableName + "";
                SqlCommand cmd = new SqlCommand(ss, con);

                con.Open();
                int x = (int)cmd.ExecuteScalar() + 1;
                return x.ToString();
            }
            catch (Exception)
            {
                return "201";
            }
            finally
            {
                con.Close();
            }
        }
        private void SaveData()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();
            try
            {
                if (lblOperationMode.Text == "Save Mode")
                {
                    cmd = new SqlCommand("Sp_Expense", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 1;
                    cmd.Parameters.Add("@ExId", SqlDbType.Int).Value = Convert.ToInt32(txtExpenseId.Text);
                    cmd.Parameters.Add("@ExHead", SqlDbType.Int).Value = Convert.ToInt32(cmCostHead.SelectedValue);
                    cmd.Parameters.Add("@ExElement", SqlDbType.Int).Value = Convert.ToInt32(cmExpenseHead.SelectedValue);
                    cmd.Parameters.Add("@ExDate", SqlDbType.DateTime).Value = dpExpenseDt.SelectedDate;
                    cmd.Parameters.Add("@ExHandedTo", SqlDbType.VarChar).Value = txtHandedTo.Text;
                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = txtAmount.Text;
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = txtRemarks.Text;
                    cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = AppEnv.Current.p_UserName;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    EnableControl(false);
                    ReloadMainGrid();
                    ButtonControl("L");
                    lblMessage.Text = "Cost Element " + cmExpenseHead.Text + " Saved Successfully.";
                    ClearControl();
                }
                else if (lblOperationMode.Text == "Edit Mode")
                {
                    cmd = new SqlCommand("Sp_Expense", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 2;
                    cmd.Parameters.Add("@ExHead", SqlDbType.Int).Value = Convert.ToInt32(cmCostHead.SelectedValue);
                    cmd.Parameters.Add("@ExElement", SqlDbType.Int).Value = Convert.ToInt32(cmExpenseHead.SelectedValue);
                    cmd.Parameters.Add("@ExHandedTo", SqlDbType.NVarChar).Value = txtHandedTo.Text;
                    cmd.Parameters.Add("@ExDate", SqlDbType.DateTime).Value = dpExpenseDt.SelectedDate;
                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = txtAmount.Text;
                    cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = txtRemarks.Text;
                    cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = AppEnv.Current.p_UserName;
                    cmd.Parameters.Add("@ExId", SqlDbType.Int).Value = Convert.ToInt32(txtExpenseId.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    EnableControl(false);
                    ReloadMainGrid();
                    ButtonControl("L");
                    lblMessage.Text = "Cost Element " + cmExpenseHead.Text + " Updated Successfully.";
                    ClearControl();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
            }
        }
        private void ReloadMainGrid()
        {
            try
            {
                dtExpenseGrid.Clear();
                rgMain.Rebind();

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_Expense", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 4;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adpt.Fill(ds);
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow newRow = this.dtExpenseGrid.NewRow();
                    newRow["rowid"] = i + 1;
                    newRow["Id"] = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                    newRow["CostHead"] = dt.Rows[i]["CostHead"].ToString();
                    newRow["CostElement"] = dt.Rows[i]["CostElement"].ToString();
                    newRow["Date"] = dt.Rows[i]["Date"].ToString();
                    newRow["CostCenterName"] = dt.Rows[i]["CostHeadName"].ToString();
                    newRow["CostElementName"] = dt.Rows[i]["CostElementName"].ToString();
                    newRow["HandedTo"] = dt.Rows[i]["HandedTo"].ToString();
                    newRow["Amount"] = dt.Rows[i]["Amount"].ToString();
                    newRow["Remarks"] = dt.Rows[i]["Remarks"].ToString();
                    this.dtExpenseGrid.Rows.Add(newRow);
                    this.dtExpenseGrid.AcceptChanges();
                }
                //rgMain.DataSource = this.dtExpenseGrid;
                rgMain.Rebind();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        public void EnableControl(bool ec)
        {
            txtAmount.Enabled = ec;
            //txtExpenseId.Enabled = ec;
            //txtHeadName.Enabled = ec;
            txtRemarks.Enabled = ec;
            cmExpenseHead.Enabled = ec;
            cmCostHead.Enabled = ec;
            txtHandedTo.Enabled = ec;
            dpExpenseDt.Enabled = ec;
        }
        public void ClearControl()
        {
            txtAmount.Text = "";
            txtExpenseId.Text = "";
            txtRemarks.Text = "";
            cmExpenseHead.Text = "";
            cmExpenseHead.SelectedValue = "";
            cmCostHead.Text = "";
            cmCostHead.SelectedValue = "";
            txtHandedTo.Text = "";
            txtHandedTo.Text = "";
            dpExpenseDt.SelectedDate = null;
        }
        public void ButtonControl(string bc)
        {
            if (bc == "L")
            {
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnSearch.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = false;
                lblOperationMode.Text = "";
                lblMessage.Text = "";
            }
            else if (bc == "N")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnSearch.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                lblOperationMode.Text = "Save Mode";
                lblMessage.Text = "";
            }
            else if (bc == "F")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = false;
                btnSearch.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = true;
                lblOperationMode.Text = "";
                lblMessage.Text = "";
            }
            else if (bc == "E")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                lblOperationMode.Text = "Edit Mode";
                lblMessage.Text = "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReloadMainGrid();
                EnableControl(false);
                ClearControl();
                ButtonControl("L");
            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                int max = Convert.ToInt32(GetAutoNumber("Id", "tblExpense"));
                txtExpenseId.Text = max.ToString();
                EnableControl(true);
                lblOperationMode.Text = "Save Mode";
                lblMessage.Text = "";
                ButtonControl("N");
                dpExpenseDt.SelectedDate = DateTime.Now;
                cmCostHead.Focus();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmCostHead.SelectedValue == "")
                {
                    lblMessage.Text = "Select Cost Center.";
                }
                else if (cmExpenseHead.SelectedValue == "")
                {
                    lblMessage.Text = "Select Cost Element.";
                }
                else if (dpExpenseDt.SelectedDate == null)
                {
                    lblMessage.Text = "Select Expense Date.";
                }
                else if (txtHandedTo.Text == "")
                {
                    lblMessage.Text = "Pay to can not be blank.";
                }
                else if (txtAmount.Text=="")
                {
                    lblMessage.Text = "Amount can not be blank.";
                }
                else
                {
                    if (lblOperationMode.Text == "Save Mode")
                    {
                        SaveData();
                    }
                    else if (lblOperationMode.Text == "Edit Mode")
                    {
                        SaveData();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtExpenseId.Text == "")
                {
                    lblMessage.Text = "Expense Id Can not be Blank.";
                }
                else
                {
                    lblMessage.Text = "";
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("Sp_Expense", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 5;
                    cmd.Parameters.Add("@ExId", SqlDbType.Int).Value = txtExpenseId.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cmCostHead.SelectedValue = dr["ExHead"].ToString();
                        cmExpenseHead.SelectedValue = dr["ExElement"].ToString();
                        if (dr["ExDate"].ToString()!="")
                            dpExpenseDt.SelectedDate = Convert.ToDateTime(dr["ExDate"].ToString());
                        txtHandedTo.Text = dr["ExHandedTo"].ToString();
                        txtAmount.Text = dr["Amount"].ToString();
                        txtRemarks.Text = dr["Remarks"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EnableControl(true);
            ButtonControl("E");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
            EnableControl(false);
            ButtonControl("L");
        }
        protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControl();
            ButtonControl("F");
            EnableControl(false);
        }
        protected void rgMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ButtonControl("F");
                GridDataItem selectedItem = (GridDataItem)rgMain.SelectedItems[0];
                ViewState["Id"] = selectedItem["Id"].Text;
                ViewState["rowid"] = selectedItem["rowid"].Text;

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_Expense", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 5;
                cmd.Parameters.Add("@ExId", SqlDbType.VarChar).Value = selectedItem["Id"].Text;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt1 = new DataTable();
                adpt.Fill(ds);
                dt1 = ds.Tables[0];
                txtExpenseId.Text = dt1.Rows[0]["Id"].ToString();
                if (dt1.Rows[0]["Date"].ToString()!="")
                    dpExpenseDt.SelectedDate = Convert.ToDateTime(dt1.Rows[0]["Date"].ToString());
                cmCostHead.SelectedValue = dt1.Rows[0]["CostHead"].ToString();
                cmCostHead.Text = dt1.Rows[0]["CostCenterName"].ToString();
                cmExpenseHead.SelectedValue = dt1.Rows[0]["CostElement"].ToString();
                cmExpenseHead.Text = dt1.Rows[0]["CostElementName"].ToString();
                txtHandedTo.Text = dt1.Rows[0]["HandedTo"].ToString();
                txtAmount.Text = dt1.Rows[0]["Amount"].ToString();
                txtRemarks.Text = dt1.Rows[0]["Remarks"].ToString();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void btnFind_Click(object sender, EventArgs e)
        {

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void cmCostHead_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cmExpenseHead.Text = "";
            cmExpenseHead.SelectedValue = "";
            cmExpenseHead.Focus();
        }
        protected void cmCostHead_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_Expense", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 6;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dataRow in dt.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = (string)dataRow["Name"].ToString();
                    item.Value = dataRow["Id"].ToString();

                    //string ItemCode = (string)dataRow["Alias"].ToString();
                    //item.Attributes.Add("Alias", ItemCode.ToString());

                    cmCostHead.Items.Add(item);
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
        protected void cmExpenseHead_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_Expense", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 7;
                cmd.Parameters.Add("@ExHead", SqlDbType.VarChar).Value = cmCostHead.SelectedValue;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dataRow in dt.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = (string)dataRow["Name"].ToString();
                    item.Value = dataRow["Id"].ToString();

                    //string Alias = (string)dataRow["Alias"].ToString();
                    //item.Attributes.Add("Alias", Alias.ToString());

                    string ItemCode = (string)dataRow["CostCenter"].ToString();
                    item.Attributes.Add("CostCenter", ItemCode.ToString());

                    cmExpenseHead.Items.Add(item);
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("Sp_Expense", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 3;
            cmd.Parameters.Add("@ExId", SqlDbType.Int).Value = Convert.ToInt32(txtExpenseId.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            ClearControl();

            ReloadMainGrid();
        }
        protected void rgMain_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgMain.DataSource = dtExpenseGrid;
        }
    }
}