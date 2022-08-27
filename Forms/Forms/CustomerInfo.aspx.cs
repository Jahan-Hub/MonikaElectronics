using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using Telerik.Web.UI;

namespace ElectronicsMS.Forms.Forms
{
    public partial class CustomerInfo : Page
    {
        ElectronicsMSDBEntities db = new ElectronicsMSDBEntities();
        SqlConnection con;
        SqlCommand cmd;
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        public DataTable dtCustomer
        {
            get
            {
                object obj = this.Session["dtCustomer"];
                if (obj != null)
                {
                    return (DataTable)obj;
                }
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("rowid", typeof(Int32));
                dt1.Columns.Add("CustId", typeof(Int32));
                dt1.Columns.Add("Name", typeof(string));
                dt1.Columns.Add("FatherName", typeof(string));
                dt1.Columns.Add("Mobile", typeof(string));
                dt1.PrimaryKey = new DataColumn[] { dt1.Columns["rowid"] };
                this.Session["dtCustomer"] = dt1;
                return dtCustomer;
            }
        }
        public string GetAutoNumber(string fieldName, string tableName)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                string ss = "Select convert(int,Max(" + fieldName + ")) from " + tableName;
                SqlCommand cmd = new SqlCommand(ss, con);

                con.Open();
                int x = (int)cmd.ExecuteScalar() + 1;
                return x.ToString();
            }
            catch (Exception)
            {
                return "10001";
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
                cmd = new SqlCommand("Sp_CustomerInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@CustId", SqlDbType.NVarChar).Value = txtCustCode.Text;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = textInfo.ToTitleCase(txtName.Text);
                cmd.Parameters.Add("@FatherHusband", SqlDbType.NVarChar).Value = cmFather.SelectedValue;
                cmd.Parameters.Add("@FatherName", SqlDbType.NVarChar).Value = textInfo.ToTitleCase(txtFatherName.Text);
                cmd.Parameters.Add("@AccountNo", SqlDbType.NVarChar).Value = txtAccountNo.Text;
                if (txtMobile.Text != "")
                    cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = txtMobile.Text;
                if (cmThana.SelectedValue != "")
                    cmd.Parameters.Add("@ThanaId", SqlDbType.Int).Value = cmThana.SelectedValue;
                if (cmVillage.SelectedValue != "")
                    cmd.Parameters.Add("@ViId", SqlDbType.Int).Value = cmVillage.SelectedValue;
                if (ckSpecial.Checked == true)
                    cmd.Parameters.Add("@IsSpecial", SqlDbType.Bit).Value = 1;
                else
                    cmd.Parameters.Add("@IsSpecial", SqlDbType.Bit).Value = 0;
                if (ckDealer.Checked == true)
                    cmd.Parameters.Add("@IsDealer", SqlDbType.Bit).Value = 1;
                else
                    cmd.Parameters.Add("@IsDealer", SqlDbType.Bit).Value = 0;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txtAddress.Text;
                cmd.Parameters.Add("@userid", SqlDbType.NVarChar).Value = AppEnv.Current.p_UserName;
                cmd.ExecuteNonQuery();
                con.Close();

                EnableControl(false);
                ReloadMainGrid();
                ButtonControl("L");
                lblMessage.Text = "Customer " + txtName.Text + " Saved Successfully.";
                ClearControl();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
            }
        }
        private void DataRefill()
        {
            GridDataItem selectedItem = (GridDataItem)RadGrid1.SelectedItems[0];
            ViewState["CustId"] = selectedItem["CustId"].Text;
            string RowId = selectedItem["rowid"].Text;
            ViewState["rowid"] = selectedItem["rowid"].Text;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("Sp_CustomerInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 5;
            cmd.Parameters.Add("@CustId", SqlDbType.VarChar).Value = selectedItem["CustId"].Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtCustCode.Text = dr["CustId"].ToString();
                txtName.Text = dr["Name"].ToString();
                txtMobile.Text = dr["Mobile"].ToString();
                cmThana.SelectedValue = dr["ThanaId"].ToString();
                cmVillage.SelectedValue = dr["ViId"].ToString();
                txtAddress.Text = dr["Address"].ToString();
                txtFatherName.Text = dr["FatherName"].ToString();
                cmFather.Text = dr["FatherHusband"].ToString();
                cmFather.SelectedValue = dr["FatherHusband"].ToString();
                txtAccountNo.Text = dr["AccountNo"].ToString();
                if (dr["IsSpecial"].Equals(true))
                    ckSpecial.Checked = true;
                else
                    ckSpecial.Checked = false;
                if (dr["IsDealer"].Equals(true))
                    ckDealer.Checked = true;
                else
                    ckDealer.Checked = false;
            }
        }
        private void ReloadMainGrid()
        {
            this.dtCustomer.Clear();
            RadGrid1.Rebind();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("Sp_CustomerInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 4;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            adpt.Fill(ds);
            dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow newRow = this.dtCustomer.NewRow();
                newRow["rowid"] = i + 1;
                newRow["CustId"] = Convert.ToInt32(dt.Rows[i]["CustId"].ToString());
                newRow["Name"] = dt.Rows[i]["Name"].ToString();
                newRow["Mobile"] = dt.Rows[i]["Mobile"].ToString();
                this.dtCustomer.Rows.Add(newRow);
                this.dtCustomer.AcceptChanges();
            }
            RadGrid1.Rebind();
            cmd.Dispose();
            con.Close();
        }
        public void EnableControl(bool ec)
        {
            txtAddress.Enabled = ec;
            txtMobile.Enabled = ec;
            txtName.Enabled = ec;
            txtFatherName.Enabled = ec;
            cmFather.Enabled = ec;
            txtAccountNo.Enabled = ec;
            cmThana.Enabled = ec;
            cmVillage.Enabled = ec;
            ckSpecial.Enabled = ec;
            ckDealer.Enabled = ec;
        }
        public void ClearControl()
        {
            txtAddress.Text = "";
            txtCustCode.Text = "";
            txtMobile.Text = "";
            txtName.Text = "";
            txtFatherName.Text = "";
            txtAccountNo.Text = "";
            cmFather.Text = "";
            cmFather.SelectedValue = "";
            cmThana.Text = "";
            cmThana.SelectedValue = "";
            cmVillage.Text = "";
            cmVillage.SelectedValue = "";
            ckSpecial.Checked = false;
            ckDealer.Checked = false;
        }
        public void ButtonControl(string bc)
        {
            if (bc == "L")
            {
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = false;
                lblMessage.Text = "";
            }
            else if (bc == "N")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                lblMessage.Text = "";
            }
            else if (bc == "F")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = false;
                lblMessage.Text = "";
            }
            else if (bc == "E")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                lblMessage.Text = "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EnableControl(false);
                ClearControl();
                ButtonControl("L");
                ReloadMainGrid();
                RadGrid1.Rebind();
            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                int max = Convert.ToInt32(GetAutoNumber("CustId", "tblCustomers"));
                txtCustCode.Text = max.ToString();
                EnableControl(true);
                lblMessage.Text = "";
                ButtonControl("N");
                txtName.Focus();
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
                if (txtName.Text == "")
                {
                    lblMessage.Text = "Customer Name can not be blank.";
                }
                else if (txtMobile.Text == "")
                {
                    lblMessage.Text = "Mobile can not be blank.";
                }
                else
                {
                    SaveData();
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
            txtCustCode.Enabled = true;
            ButtonControl("L");
        }
        protected void cmDistrict_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cmThana.SelectedValue = "";
            cmThana.Text = "";
            cmThana.Items.Clear();
            cmVillage.SelectedValue = "";
            cmVillage.Text = "";
            cmVillage.Items.Clear();
        }
        protected void cmThana_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cmVillage.SelectedValue = "";
            cmVillage.Text = "";
            cmVillage.Items.Clear();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_CustomerInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@CustId", SqlDbType.VarChar).Value = txtCustCode.Text;
                cmd.ExecuteNonQuery();
                con.Close();

                ReloadMainGrid();
                ButtonControl("L");
                lblMessage.Text = "Customer Name \"" + txtName.Text + "\" Deleted Successfully.";
                ClearControl();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = this.dtCustomer;
        }
        protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                DataRefill();
                ButtonControl("F");
                EnableControl(false);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void btnThana_Click(object sender, EventArgs e)
        {
            lblMessagePopup.Text = "";
            lblInsertType.Text = "Insert Thana";
            lblTypeName.Text = "District";
            ViewState["btnType"] = "Thana";
            int max = Convert.ToInt32(GetAutoNumber("ThanaId", "tblThanas"));
            txtCodeMaster.Text = max.ToString();
            txtNameMaster.Text = "";
            cmCommon.Visible = false;
            lblTypeName.Visible = false;
            lblTypeName.Text = "District";
            RadWindow1.VisibleOnPageLoad = true;
        }
        protected void btnVillage_Click(object sender, EventArgs e)
        {
            lblMessagePopup.Text = "";
            lblInsertType.Text = "Insert Village";
            ViewState["btnType"] = "Village";
            int max = Convert.ToInt32(GetAutoNumber("ViId", "tblVillages"));
            txtCodeMaster.Text = max.ToString();
            txtNameMaster.Text = "";
            cmCommon.Visible = true;
            lblTypeName.Visible = true;
            lblTypeName.Text = "Thana";
            RadWindow1.VisibleOnPageLoad = true;
        }
        protected void btnSaveMaster_Click(object sender, EventArgs e)
        {
            if (ViewState["btnType"].ToString() == "Thana")
            {
                tblThana tbl = new tblThana();
                tbl.ThanaId = Convert.ToInt32(txtCodeMaster.Text);
                tbl.Name = txtNameMaster.Text;
                db.tblThanas.Add(tbl);
                db.SaveChanges();
                cmThana.DataBind();

                lblMessagePopup.Text = txtNameMaster.Text + " Saved Successfully.";
                txtNameMaster.Text = "";
                txtCodeMaster.Text = "";
                int max = Convert.ToInt32(GetAutoNumber("ThanaId", "tblThanas"));
                txtCodeMaster.Text = max.ToString();
            }
            if (ViewState["btnType"].ToString() == "Village")
            {
                tblVillage tbl = new tblVillage();
                tbl.ViId = Convert.ToInt32(txtCodeMaster.Text);
                tbl.Name = txtNameMaster.Text;
                tbl.ThanaId = Convert.ToInt32(cmThana.SelectedValue);
                db.tblVillages.Add(tbl);
                db.SaveChanges();
                cmVillage.DataBind();

                lblMessagePopup.Text = txtNameMaster.Text + " Saved Successfully.";
                txtNameMaster.Text = "";
                txtCodeMaster.Text = "";
                int max = Convert.ToInt32(GetAutoNumber("ViId", "tblVillages"));
                txtCodeMaster.Text = max.ToString();
            }
        }
        protected void btnCancelMaster_Click(object sender, EventArgs e)
        {
            txtNameMaster.Text = "";
            txtCodeMaster.Text = "";
            RadWindow1.VisibleOnPageLoad = false;
        }
        protected void cmCommon_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            if (ViewState["btnType"].ToString() == "Village")
            {
                try
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("select * from tblThanas where isnull(ThanaId,'')<>''", con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        RadComboBoxItem item = new RadComboBoxItem();
                        item.Text = (string)dataRow["Name"];
                        item.Value = dataRow["ThanaId"].ToString();
                        cmCommon.Items.Add(item);
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
    }
}