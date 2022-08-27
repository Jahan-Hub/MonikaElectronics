using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using Telerik.Web.UI;

namespace ElectronicsMS.Forms.Forms
{
    public partial class StockAdjustments : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        public void EnableControl(bool ec)
        {
            txtCauses.Enabled = ec;
            cmItemName.Enabled = ec;
            cmCategory.Enabled = ec;
            dpAdjDate.Enabled = ec;
            txtAdjQty.Enabled = ec;
            txtLotNumber.Enabled = ec;
            cmAdjType.Enabled = ec;
            txtAdjValue.Enabled = ec;
        }
        public void ClearControl()
        {
            txtLotNumber.Text = "";
            txtCauses.Text = "";
            txtAdjQty.Text = "";
            cmItemName.SelectedValue = "";
            cmItemName.Text = "";
            cmAdjType.SelectedValue = "";
            cmAdjType.Text = "";
            txtAdjValue.Text = "";
        }
        public void ButtonControl(string bc)
        {
            if (bc == "L")
            {
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                lblOperationMode.Text = "";
                lblMessage.Text = "";
            }
            else if (bc == "N")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                lblOperationMode.Text = "Save Mode";
                lblMessage.Text = "";
            }
            else if (bc == "F")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = true;
                lblOperationMode.Text = "";
                lblMessage.Text = "";
            }
            else if (bc == "E")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                lblOperationMode.Text = "Edit Mode";
                lblMessage.Text = "";
            }
        }
        private void ReloadMainGrid()
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_StockAdjustments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 4;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adpt.Fill(ds);
                dt = ds.Tables[0];
                rgMain.DataSource = dt;
                rgMain.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        private void DataRefill()
        {
            try
            {
                GridDataItem selectedItem = (GridDataItem)rgMain.SelectedItems[0];
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_StockAdjustments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 5;
                cmd.Parameters.Add("@SrlNo", SqlDbType.VarChar).Value = selectedItem["SrlNo"].Text;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt1 = new DataTable();
                adpt.Fill(ds);
                dt1 = ds.Tables[0];
                txtLotNumber.Text = dt1.Rows[0]["LotNumber"].ToString();
                cmItemName.SelectedValue = dt1.Rows[0]["ItemCode"].ToString();
                cmItemName.Text = dt1.Rows[0]["ItemName"].ToString();
                txtCauses.Text = dt1.Rows[0]["Causes"].ToString();
                txtAdjQty.Text = dt1.Rows[0]["AdjStockQty"].ToString();
                txtAdjValue.Text = dt1.Rows[0]["AdjValue"].ToString();
                cmAdjType.SelectedValue = dt1.Rows[0]["AdjType"].ToString();
                cmAdjType.Text = dt1.Rows[0]["AdjType"].ToString();
                if (dt1.Rows[0]["AdjDate"].ToString() != "")
                    dpAdjDate.SelectedDate = Convert.ToDateTime(dt1.Rows[0]["AdjDate"].ToString());
                cmCategory.Text = dt1.Rows[0]["Name"].ToString();
                cmCategory.SelectedValue = dt1.Rows[0]["CatId"].ToString();
                hfTrackId.Value = dt1.Rows[0]["SrlNo"].ToString();
                EnableControl(true);
                ButtonControl("E");
                cmCategory.Enabled = false;
                cmItemName.Enabled = false;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }
        private void SaveData()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();

            SqlTransaction myTran;
            SqlCommand cmd = con.CreateCommand();
            myTran = con.BeginTransaction();
            cmd.Connection = con;
            cmd.Transaction = myTran;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd = new SqlCommand("Sp_StockAdjustments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (hfTrackId.Value != "" && lblOperationMode.Text == "Edit Mode")
                {
                    cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 2;
                }
                else
                {
                    cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 1;
                }
                cmd.Parameters.Add("@LotNumber", SqlDbType.NVarChar).Value = txtLotNumber.Text;
                cmd.Parameters.Add("@ItemCode", SqlDbType.NVarChar).Value = cmItemName.SelectedValue;
                cmd.Parameters.Add("@AdjDate", SqlDbType.DateTime).Value = dpAdjDate.SelectedDate;
                cmd.Parameters.Add("@AdjStockQty", SqlDbType.NVarChar).Value = txtAdjQty.Text;
                cmd.Parameters.Add("@AdjValue", SqlDbType.NVarChar).Value = txtAdjValue.Text;
                cmd.Parameters.Add("@AdjType", SqlDbType.NVarChar).Value = cmAdjType.SelectedValue;
                cmd.Parameters.Add("@Causes", SqlDbType.NVarChar).Value = txtCauses.Text;
                if (hfTrackId.Value != "" && lblOperationMode.Text == "Edit Mode")
                    cmd.Parameters.Add("@SrlNo", SqlDbType.NVarChar).Value = hfTrackId.Value;

                cmd.Transaction = myTran;
                cmd.ExecuteNonQuery();

                myTran.Commit();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
                try
                {
                    myTran.Rollback();
                }
                catch (Exception ex1)
                {
                    lblMessage.Text = ex1.Message.ToString();
                    return;
                }
            }
            con.Close();
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
                EnableControl(true);
                ClearControl();
                ButtonControl("N");

                dpAdjDate.SelectedDate = System.DateTime.Now;
                lblOperationMode.Text = "Save Mode";
                lblMessage.Text = "";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtLotNumber.Text == "")
            {
                lblMessage.Text = "Lot Number can not be blank.";
            }
            else if (cmItemName.SelectedValue == "")
            {
                lblMessage.Text = "Select Item Name.";
            }
            else if (dpAdjDate.SelectedDate == null)
            {
                lblMessage.Text = "Select Entry Date.";
            }
            else
            {
                try
                {
                    SaveData();
                    ButtonControl("L");
                    ClearControl();
                    EnableControl(false);
                    lblMessage.Text = "Data Saved Successfully.";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
                ReloadMainGrid();
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ButtonControl("L");
            EnableControl(false);
            ClearControl();
            rgMain.Rebind();
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
                cmd = new SqlCommand("Sp_OpeningStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 6;
                cmd.Parameters.Add("@ItemCatId", SqlDbType.Int).Value = cmCategory.SelectedValue;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_StockAdjustments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@SrlNo", SqlDbType.VarChar).Value = hfTrackId.Value;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();

                ButtonControl("L");
                ClearControl();
                EnableControl(false);
                lblMessage.Text = "Data Deleted Successfully.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void rgMain_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }
        protected void rgMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRefill();
        }
    }
}