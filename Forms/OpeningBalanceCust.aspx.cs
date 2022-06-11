using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using Telerik.Web.UI;

namespace ElectronicsMS.Forms
{
    public partial class OpeningBalanceCust : Page
    {
        SqlConnection con;
        SqlCommand cmd;
        public DataTable dtItemDetails
        {
            get
            {
                object obj = this.Session["dtItemDetails"];
                if (obj != null)
                {
                    return (DataTable)obj;
                }
                DataTable dt1 = new DataTable();

                dt1.Columns.Add("rowid", typeof(Int16));
                dt1.Columns.Add("ItemCode", typeof(string));
                dt1.Columns.Add("ItemName", typeof(string));
                dt1.Columns.Add("BundleQty", typeof(decimal));
                dt1.Columns.Add("YardQty", typeof(decimal));
                dt1.Columns.Add("UnitRate", typeof(decimal));
                dt1.Columns.Add("Amount", typeof(decimal));

                dt1.PrimaryKey = new DataColumn[] { dt1.Columns["ItemCode"] };

                this.Session["dtItemDetails"] = dt1;
                return dtItemDetails;
            }
        }
        public string GetAutoNumber(string fieldName, string tableName)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                string ss = "Select convert(int,isnull(Max(" + fieldName + "),0)) from " + tableName;
                SqlCommand cmd = new SqlCommand(ss, con);

                con.Open();
                int x = (int)cmd.ExecuteScalar() + 1;
                return x.ToString();
            }
            catch (Exception)
            {
                return "5001";
            }
            finally
            {
                con.Close();
            }
        }
        public void EnableControl(bool ec)
        {
            txtInvoiceNo.Enabled = ec;
            txtRemarks.Enabled = ec;
        }
        public void ClearControl()
        {
            txtRemarks.Text = "";
            txtDueAmt.Text = "0";
            txtInvoiceNo.Text = "";
            txtRemarks.Text = "";
        }
        public void ButtonControl(string bc)
        {
            if (bc == "L")
            {
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                lblMessage.Text = "";
            }
            else if (bc == "N")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                lblMessage.Text = "";
            }
            
        }
        private void SaveData()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();
            try
            {
                cmd = new SqlCommand("Sp_OpeningBalanceCust", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@SalesId", SqlDbType.VarChar).Value = txtInvoiceNo.Text;
                cmd.Parameters.Add("@CustId", SqlDbType.VarChar).Value = cmPartyName.SelectedValue;
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.Int).Value = txtInvoiceNo.Text;
                cmd.Parameters.Add("@ReceivedDate", SqlDbType.DateTime).Value = dpVoucherDate.SelectedDate;
                cmd.Parameters.Add("@DueAmount", SqlDbType.Decimal).Value = txtDueAmt.Text;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = txtRemarks.Text;
                cmd.Parameters.Add("@userid", SqlDbType.VarChar).Value = AppEnv.Current.p_UserName;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();

                ReloadMainGrid();
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
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_OpeningBalanceCust", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = "9";
                cmd.Parameters.Add("@custcode", SqlDbType.VarChar).Value = cmPartyName.SelectedValue;
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = txtInvoiceNo.Text;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adpt.Fill(ds);
                dt = ds.Tables[0];
                RadGrid1.DataSource = dt;
                RadGrid1.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //EnableControl(false);
                ClearControl();
                ButtonControl("L");
                EnableControl(false);
                this.dtItemDetails.Clear();
            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmPartyName.SelectedValue == "")
                {
                    lblMessage.Text = "Select Customer.";
                }
                else
                {
                    EnableControl(true);
                    ClearControl();
                    ButtonControl("N");
                    cmPartyName.Enabled = false;
                    lblMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cmPartyName.SelectedValue == "")
            {
                lblMessage.Text = "Select Party Name.";
            }
            else if (txtInvoiceNo.Text == "")
            {
                lblMessage.Text = "Invoice No can not be Blank.";
            }
            else if (dpVoucherDate.SelectedDate == null)
            {
                lblMessage.Text = "Select Voucher Date.";
            }
            //else if (txtTotalAmt.Text == "" || Convert.ToDecimal(txtTotalAmt.Text) <= 0)
            //{
            //    lblMessage.Text = "Total Amount can not be Blank or Zero or Less than Zero";
            //}
            //else if (txtPaidAmt.Text=="" || Convert.ToDecimal(txtPaidAmt.Text) <= 0)
            //{
            //    lblMessage.Text = "Paid Amount can not be Blank or Zero or Less than Zero";
            //}
            //else if (Convert.ToDecimal(txtDueAmt.Text) <= 0)
            //{
            //    lblMessage.Text = "Due Amount can not be Zero or Less than Zero";
            //}
            else
            {
                try
                {
                    SaveData();
                    ButtonControl("L");
                    ClearControl();
                    cmPartyName.SelectedValue = "";
                    cmPartyName.Text = "";
                    EnableControl(false);
                    cmPartyName.Enabled = true;
                    txtDueAmt.Text = "0.00";    
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ButtonControl("L");
            EnableControl(false);
            ClearControl();
            cmPartyName.Enabled = true;
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = this.dtItemDetails;
        }
        protected void cmPartyName_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_OpeningBalanceCust", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 8;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dataRow in dt.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = (string)dataRow["Name"].ToString();
                    item.Value = dataRow["CustId"].ToString();

                    string Id = (string)dataRow["CustId"].ToString();
                    item.Attributes.Add("CustId", Id.ToString());

                    string AccountNo = (string)dataRow["AccountNo"].ToString();
                    item.Attributes.Add("AccountNo", AccountNo.ToString()); 

                    string Mobile = (string)dataRow["Mobile"].ToString();
                    item.Attributes.Add("Mobile", Mobile.ToString());

                    cmPartyName.Items.Add(item);
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
        protected void cmPartyName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                ClearControl();
                ButtonControl("N");
                cmPartyName.Enabled = false;
                lblMessage.Text = "";

                int max = Convert.ToInt32(GetAutoNumber("SalesId", "tblSalesHDR"));
                txtInvoiceNo.Text = max.ToString();
                EnableControl(true);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }
}