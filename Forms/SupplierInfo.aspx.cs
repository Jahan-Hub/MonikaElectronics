using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;

namespace ElectronicsMS.Forms
{
    public partial class SupplierInfo : Page
    {
        SqlConnection con;
        SqlCommand cmd;
        public DataTable dtSupplier
        {
            get
            {
                object obj = this.Session["dtSupplier"];
                if (obj != null)
                {
                    return (DataTable)obj;
                }
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("rowid", typeof(Int32));
                dt1.Columns.Add("SupplierId", typeof(Int32));
                dt1.Columns.Add("Name", typeof(string));
                dt1.Columns.Add("Mobile", typeof(string));
                dt1.PrimaryKey = new DataColumn[] { dt1.Columns["rowid"] };
                this.Session["dtSupplier"] = dt1;
                return dtSupplier;
            }
        }
        public string GetAutoNumber(string fieldName, string tableName)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                string ss = "Select  convert(int,isnull(Max(" + fieldName + "),0)) from " + tableName + "";
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
        private void SaveData()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();
            try
            {
                cmd = new SqlCommand("Sp_SupplierInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@SupplierId", SqlDbType.NVarChar).Value = txtCustCode.Text;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = txtName.Text;
                if (txtMobile.Text != "")
                    cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = txtMobile.Text;
                if (cmThana.SelectedValue != "")
                    cmd.Parameters.Add("@ThanaId", SqlDbType.Int).Value = cmThana.SelectedValue;
                if (cmVillage.SelectedValue != "")
                    cmd.Parameters.Add("@ViId", SqlDbType.Int).Value = cmVillage.SelectedValue;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txtAddress.Text;
                cmd.Parameters.Add("@userid", SqlDbType.NVarChar).Value = AppEnv.Current.p_UserName;
                cmd.ExecuteNonQuery();
                con.Close();

                EnableControl(false);
                ReloadMainGrid();
                ButtonControl("L");
                lblMessage.Text = "Supplier " + txtName.Text + " Saved Successfully.";
                ClearControl();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
            }
        }
        private void DataRefill()
        {
            try
            {
                GridDataItem selectedItem = (GridDataItem)RadGrid1.SelectedItems[0];
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_SupplierInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 5;
                cmd.Parameters.Add("@SupplierId", SqlDbType.VarChar).Value = selectedItem["SupplierId"].Text;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtCustCode.Text = dr["SupplierId"].ToString();
                    txtName.Text = dr["Name"].ToString();
                    txtMobile.Text = dr["Mobile"].ToString();
                    cmThana.SelectedValue = dr["ThanaId"].ToString();
                    cmVillage.SelectedValue = dr["ViId"].ToString();
                    txtAddress.Text = dr["Address"].ToString();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        private void ReloadMainGrid()
        {
            try
            {
                this.dtSupplier.Clear();
                RadGrid1.Rebind();

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_SupplierInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 4;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adpt.Fill(ds);
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow newRow = this.dtSupplier.NewRow();
                    newRow["rowid"] = i + 1;
                    newRow["SupplierId"] = Convert.ToInt32(dt.Rows[i]["SupplierId"].ToString());
                    newRow["Name"] = dt.Rows[i]["Name"].ToString();
                    newRow["Mobile"] = dt.Rows[i]["Mobile"].ToString();
                    this.dtSupplier.Rows.Add(newRow);
                    this.dtSupplier.AcceptChanges();
                }
                RadGrid1.Rebind();
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
            txtAddress.Enabled = ec;
            txtName.Enabled = ec;
            txtMobile.Enabled = ec;
            cmThana.Enabled = ec;
            cmVillage.Enabled = ec;
        }
        public void ClearControl()
        {
            txtAddress.Text = "";
            txtCustCode.Text = "";
            txtMobile.Text = "";
            txtName.Text = "";
            cmThana.Text = "";
            cmThana.SelectedValue = "";
            cmVillage.Text = "";
            cmVillage.SelectedValue = "";
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
            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                int max = Convert.ToInt32(GetAutoNumber("SupplierId", "tblSuppliers"));
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
                    lblMessage.Text = "Supplier Name can not be blank.";
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
                cmd = new SqlCommand("Sp_SupplierInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@SupplierId", SqlDbType.VarChar).Value = txtCustCode.Text;
                cmd.ExecuteNonQuery();
                con.Close();

                ReloadMainGrid();
                ButtonControl("L");
                lblMessage.Text = "Supplier Name \"" + txtName.Text + "\" Deleted Successfully.";
                ClearControl();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = this.dtSupplier;
        }
    }
}