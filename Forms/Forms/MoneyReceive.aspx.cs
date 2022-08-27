using ElectronicsMS;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using Telerik.Web.UI;
namespace ElectronicsMS.Forms.Forms
{
    public partial class MoneyReceive : System.Web.UI.Page
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
                return "1";
            }
            finally
            {
                con.Close();
            }
        }
        public void EnableControl(bool ec)
        {
            txtRemarks.Enabled = ec;
            txtReceiveAmt.Enabled = ec;
            cmReceiveMode.Enabled = ec;
            cmSalesNo.Enabled = ec;
            dpReceiveDate.Enabled = ec;
            ckDiscount.Enabled = ec;

            //txtIssueBank.Enabled = ec;
            //txtDepositBank.Enabled = ec;
            //txtChequeNo.Enabled = ec;
            //txtCheckDetails.Enabled = ec;
            //dpCheckDate.Enabled = ec;
        }
        public void EnableControlPartial(bool ec)
        {
            txtChequeNo.Enabled = ec;
            txtIssueBank.Enabled = ec;
            txtDepositBank.Enabled = ec;
            dpCheckDate.Enabled = ec;
            txtCheckDetails.Enabled = ec;
        }
        public void ClearControl()
        {
            txtRemarks.Text = "";
            txtReceiveAmt.Text = "";
            //txtNeedToReceive.Text = "";
            cmReceiveMode.Text = "";
            cmReceiveMode.SelectedValue = "";
            dpReceiveDate.SelectedDate = null;
            //lblDue.Text = "0.00";
            hfTrackId.Value = null;
            ckDiscount.Checked = null;
        }
        public void ClearControlPartial()
        {
            txtIssueBank.Text = "";
            txtDepositBank.Text = "";
            txtChequeNo.Text = "";
            txtCheckDetails.Text = "";
            dpCheckDate.SelectedDate = null;
        }
        public void ButtonControl(string bc)
        {
            //// Which button you click control according by button
            if (bc == "L")
            {
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnEdit.Enabled = false;
                btnCancel.Enabled = false;
                lblMessage.Text = "";
            }
            else if (bc == "N")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
                btnCancel.Enabled = true;
                lblMessage.Text = "";
            }
            else if (bc == "F")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnCancel.Enabled = true;
                lblMessage.Text = "";
            }
            else if (bc == "E")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
                btnEdit.Enabled = false;
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
                cmd = new SqlCommand("Sp_MoneyReceived", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@custcode", SqlDbType.VarChar).Value = cmPartyName.SelectedValue;
                cmd.Parameters.Add("@SalesId", SqlDbType.Int).Value = cmSalesNo.SelectedValue;
                cmd.Parameters.Add("@receivedmode", SqlDbType.VarChar).Value = cmReceiveMode.SelectedValue;
                cmd.Parameters.Add("@receiveddate", SqlDbType.DateTime).Value = dpReceiveDate.SelectedDate;
                cmd.Parameters.Add("@ReceiveAmount", SqlDbType.Decimal).Value = txtReceiveAmt.Text;
                cmd.Parameters.Add("@PayMode", SqlDbType.VarChar).Value = cmReceiveMode.SelectedValue;
                if (cmReceiveMode.SelectedValue != "Cash")
                {
                    cmd.Parameters.Add("@cheqno", SqlDbType.VarChar).Value = txtChequeNo.Text;
                    if (dpCheckDate.SelectedDate != null)
                        cmd.Parameters.Add("@cheqdate", SqlDbType.DateTime).Value = dpCheckDate.SelectedDate;
                    cmd.Parameters.Add("@IssueBank", SqlDbType.VarChar).Value = txtIssueBank.Text;
                    cmd.Parameters.Add("@DepositBank", SqlDbType.VarChar).Value = txtDepositBank.Text;
                    cmd.Parameters.Add("@ChequeDetails", SqlDbType.VarChar).Value = txtCheckDetails.Text;
                }
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = txtRemarks.Text;
                cmd.Parameters.Add("@userid", SqlDbType.VarChar).Value = AppEnv.Current.p_UserName;
                cmd.Parameters.Add("@isDiscount", SqlDbType.VarChar).Value = (ckDiscount.Checked == true) ? 1 : 0;

                if (hfTrackId.Value != "")
                    cmd.Parameters.Add("@track_id", SqlDbType.Int).Value = hfTrackId.Value;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();

                ReloadMainGrid();
                ButtonControl("L");
                cmPartyName.SelectedValue = "";
                cmPartyName.Text = "";
                EnableControl(false);
                cmPartyName.Enabled = true;
                lblDue.Text = "0.00";
                lblMessage.Text = "The Amount of " + txtReceiveAmt.Text + " has Received Successfully...";
                ClearControl();
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
                cmd = new SqlCommand("Sp_MoneyReceived", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = "9";
                cmd.Parameters.Add("@custcode", SqlDbType.VarChar).Value = cmPartyName.SelectedValue;
                cmd.Parameters.Add("@SalesId", SqlDbType.VarChar).Value = cmSalesNo.SelectedValue;
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
        private void DataRefillForGrid()
        {
            GridDataItem selectedItem = (GridDataItem)RadGrid1.SelectedItems[0];
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("Sp_MoneyReceived", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 13;
            cmd.Parameters.Add("@track_id", SqlDbType.VarChar).Value = selectedItem["track_id"].Text;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt1 = new DataTable();
            adpt.Fill(ds);
            dt1 = ds.Tables[0];

            txtDepositBank.Text = dt1.Rows[0]["DepositBank"].ToString();
            txtCheckDetails.Text = dt1.Rows[0]["ChequeDetails"].ToString();
            txtChequeNo.Text = dt1.Rows[0]["ChequeNo"].ToString();
            txtReceiveAmt.Text = dt1.Rows[0]["ReceiveAmount"].ToString();
            txtRemarks.Text = dt1.Rows[0]["Remarks"].ToString();
            if (dt1.Rows[0]["isDiscount"].ToString() == "1")
            {
                ckDiscount.Checked = true;
            }
            else
            {
                ckDiscount.Checked = false;
            }
            cmPartyName.SelectedValue = dt1.Rows[0]["CustId"].ToString();
            cmPartyName.Text = dt1.Rows[0]["CustomerName"].ToString();
            cmReceiveMode.SelectedValue = dt1.Rows[0]["PayMode"].ToString();
            if (dt1.Rows[0]["ChequeDt"].ToString() != "")
                dpCheckDate.SelectedDate = Convert.ToDateTime(dt1.Rows[0]["ChequeDt"].ToString());
            if (dt1.Rows[0]["ReceivedDate"].ToString() != null)
                dpReceiveDate.SelectedDate = Convert.ToDateTime(dt1.Rows[0]["ReceivedDate"].ToString());
            hfTrackId.Value = dt1.Rows[0]["track_id"].ToString();
            hfPreviousDue.Value = selectedItem["ReceiveAmount"].Text;
            cmSalesNo.SelectedValue = dt1.Rows[0]["SalesId"].ToString();
            cmSalesNo.Text = dt1.Rows[0]["SalesId"].ToString();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //EnableControl(false);
                ClearControl();
                ButtonControl("L");
                EnableControl(false);
                EnableControlPartial(false);
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

                    dpReceiveDate.SelectedDate = System.DateTime.Now;
                    lblMessage.Text = "";
                    cmSalesNo.Focus();
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
            else if (cmSalesNo.SelectedValue == "")
            {
                lblMessage.Text = "Select Sales No.";
            }
            else if (cmReceiveMode.SelectedValue == "")
            {
                lblMessage.Text = "Select Receive Mode.";
            }
            else if (dpReceiveDate.SelectedDate == null)
            {
                lblMessage.Text = "Select Receive Date.";
            }
            else if (txtReceiveAmt.Text == "")
            {
                lblMessage.Text = "Receive Amount can not be Blank.";
            }
            else if (Convert.ToDecimal(txtReceiveAmt.Text) == 0)
            {
                lblMessage.Text = "Receive Amount can not be Zero.";
            }
            else if (Convert.ToDecimal(lblDue.Text) < 0)
            {
                lblMessage.Text = "Receive Amount can not be greater than Need to Receive.";
            }
            else
            {
                try
                {
                    SaveData();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
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
        protected void cmReceiveMode_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmReceiveMode.SelectedValue == "Cash")
            {
                EnableControlPartial(false);
                ClearControlPartial();
            }
            else
            {
                EnableControlPartial(true);
                ClearControlPartial();
            }
        }
        protected void cmPartyName_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_MoneyReceived", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 8;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dataRow in dt.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = (string)dataRow["Name"].ToString();
                    item.Value = dataRow["CustCode"].ToString();

                    string Id = (string)dataRow["CustCode"].ToString();
                    item.Attributes.Add("CustCode", Id.ToString());

                    string Mobile = (string)dataRow["Mobile"].ToString();
                    item.Attributes.Add("Mobile", Mobile.ToString());

                    string Address = (string)dataRow["Address"].ToString();
                    item.Attributes.Add("Address", Address.ToString());

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
        protected void txtReceiveAmt_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtNeedToReceive.Text != "" && txtReceiveAmt.Text != "")
            //    {
            //        decimal NeedToReceive = Convert.ToDecimal(txtNeedToReceive.Text);
            //        decimal ReceiveAmt = Convert.ToDecimal(txtReceiveAmt.Text);
            //        decimal Due = (NeedToReceive - ReceiveAmt);
            //        lblDue.Text = Due.ToString("#,##0.00");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lblMessage.Text = ex.Message;
            //}
            try
            {
                if (hfPreviousDue.Value == "")
                    hfPreviousDue.Value = "0";
                if (txtNeedToReceive.Text != "" && txtReceiveAmt.Text != "" && hfPreviousDue.Value != "")
                {
                    decimal NeedToReceive = Convert.ToDecimal(txtNeedToReceive.Text);
                    decimal ReceiveAmt = Convert.ToDecimal(txtReceiveAmt.Text);
                    decimal PreviousDue = Convert.ToDecimal(hfPreviousDue.Value);
                    decimal Due = (NeedToReceive - ReceiveAmt + PreviousDue);
                    lblDue.Text = Due.ToString();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void cmSalesNo_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_MoneyReceived", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 7;
                cmd.Parameters.Add("@CustId", SqlDbType.VarChar).Value = cmPartyName.SelectedValue;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dataRow in dt.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = (string)dataRow["SalesId"].ToString();
                    item.Value = dataRow["SalesId"].ToString();
                    cmSalesNo.Items.Add(item);
                    item.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void cmSalesNo_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_MoneyReceived", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 5;
                cmd.Parameters.Add("@SalesId", SqlDbType.VarChar).Value = cmSalesNo.SelectedValue;
                cmd.Parameters.Add("@CustId", SqlDbType.VarChar).Value = cmPartyName.SelectedValue;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                txtNeedToReceive.Text = dt.Rows[0]["Due"].ToString();
                con.Close();
                txtReceiveAmt.Text = "";
                lblDue.Text = "0.00";
                txtReceiveAmt.Focus();

                ReloadMainGrid();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControl();
            ButtonControl("E");
            EnableControl(true);
            cmPartyName.Enabled = false;
            DataRefillForGrid();
        }
    }
}