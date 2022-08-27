using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using Telerik.Web.UI;

namespace ElectronicsMS.Forms.Forms
{
    public partial class Purchase : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        protected DataTable dtPurchaseWithBarcode
        {
            get
            {
                object obj = this.Session["dtPurchaseWithBarcode"];
                if (obj != null)
                {
                    return (DataTable)obj;
                }
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("rowid", typeof(Int16));
                dt1.Columns.Add("ItemCode", typeof(string));
                dt1.Columns.Add("ItemName", typeof(string));
                dt1.Columns.Add("CatName", typeof(string));
                dt1.Columns.Add("ItemQty", typeof(decimal));
                dt1.Columns.Add("UnitRate", typeof(decimal));
                dt1.Columns.Add("Barcode", typeof(string));

                dt1.PrimaryKey = new DataColumn[] { dt1.Columns["Barcode"] };

                this.Session["dtPurchaseWithBarcode"] = dt1;
                return dtPurchaseWithBarcode;
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
            txtBillNo.Enabled = ec;
            txtUnitPrice.Enabled = ec;
            cmItemName.Enabled = ec;
            cmCategory.Enabled = ec;
            txtBarcode.Enabled = ec;
            cmPartyName.Enabled = ec;
            dpPurchaseDate.Enabled = ec;
            txtPaidAmount.Enabled = ec;
            txtDiscount.Enabled = ec;
            lblDueAmount.Enabled = ec;
            lblNetAmount.Enabled = ec;
        }
        public void ClearControl()
        {
            txtBillNo.Text = "";
            txtUnitPrice.Text = "";
            cmItemName.Text = "";
            cmItemName.SelectedValue = "";
            txtBarcode.Text = "";
            cmPartyName.Text = "";
            cmPartyName.SelectedValue = "";
            dpPurchaseDate.SelectedDate = null;
            txtPaidAmount.Text = "0";
            txtDiscount.Text = "0";
            lblDueAmount.Text = "0.00";
            lblNetAmount.Text = "0.00";
        }
        public void ClearControlPartial()
        {
            cmItemName.SelectedValue = "";
            cmItemName.Text = "";
            txtUnitPrice.Text = "";
        }
        public void ButtonControl(string bc)
        {
            if (bc == "L")
            {
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = false;
                lblMessage.Text = "";
            }
            else if (bc == "N")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                lblMessage.Text = "";
            }
            else if (bc == "F")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = false;
                btnDelete.Enabled = true;
                btnCancel.Enabled = true;
                lblMessage.Text = "";
            }
            else if (bc == "E")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = true;
                lblMessage.Text = "";
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
                cmd = new SqlCommand("Sp_Purchase", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 1; /////////////// insert to purchase table
                cmd.Parameters.Add("@PurID", SqlDbType.Int).Value = Convert.ToInt32(txtPurchaseNo.Text);
                cmd.Parameters.Add("@PurDate", SqlDbType.DateTime).Value = dpPurchaseDate.SelectedDate;
                cmd.Parameters.Add("@SupplierId", SqlDbType.NVarChar).Value = cmPartyName.SelectedValue;
                cmd.Parameters.Add("@BillNo", SqlDbType.NVarChar).Value = txtBillNo.Text;

                cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = Convert.ToDecimal(txtDiscount.Text);
                cmd.Parameters.Add("@NetAmount", SqlDbType.Decimal).Value = lblNetAmount.Text;
                cmd.Parameters.Add("@Paid", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPaidAmount.Text);
                cmd.Parameters.Add("@Due", SqlDbType.Decimal).Value = Convert.ToDecimal(lblDueAmount.Text);
                cmd.Parameters.Add("@Userid", SqlDbType.NVarChar).Value = AppEnv.Current.p_UserName.ToString();
                cmd.Transaction = myTran;
                cmd.ExecuteNonQuery();

                ///////////////////////update or opening Payment Table and insert it for the first time (check)
                cmd = new SqlCommand("Sp_Purchase", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 7; /////////////// insert to payment table
                cmd.Parameters.Add("@PurID", SqlDbType.Int).Value = Convert.ToInt32(txtPurchaseNo.Text);
                cmd.Parameters.Add("@SupplierId", SqlDbType.NVarChar).Value = cmPartyName.SelectedValue;
                cmd.Parameters.Add("@BillNo", SqlDbType.NVarChar).Value = txtBillNo.Text;
                cmd.Parameters.Add("@PayDate", SqlDbType.DateTime).Value = dpPurchaseDate.SelectedDate;
                cmd.Parameters.Add("@Paid", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPaidAmount.Text);
                cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = AppEnv.Current.p_UserName.ToString();
                cmd.Transaction = myTran;
                cmd.ExecuteNonQuery();

                if (this.dtPurchaseWithBarcode.Rows.Count > 0)
                {
                    for (int i = 0; i < this.dtPurchaseWithBarcode.Rows.Count; i++)
                    {
                        cmd = new SqlCommand("Sp_Purchase", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 11; /////////////// insert to purchase detail
                        cmd.Parameters.Add("@PurID", SqlDbType.Int).Value = Convert.ToInt32(txtPurchaseNo.Text);
                        cmd.Parameters.Add("@ItemCode", SqlDbType.Int).Value = this.dtPurchaseWithBarcode.Rows[i]["ItemCode"].ToString();
                        cmd.Parameters.Add("@Barcode", SqlDbType.VarChar).Value = this.dtPurchaseWithBarcode.Rows[i]["Barcode"].ToString();
                        cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = this.dtPurchaseWithBarcode.Rows[i]["UnitRate"].ToString();
                        cmd.Parameters.Add("@SupplierId", SqlDbType.Decimal).Value = cmPartyName.SelectedValue;
                        cmd.Transaction = myTran;
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("Sp_Purchase", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 111; /////////////// if item exist then update otherwise insert
                        cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = this.dtPurchaseWithBarcode.Rows[i]["ItemQty"].ToString();
                        cmd.Parameters.Add("@Itemcode", SqlDbType.Int).Value = this.dtPurchaseWithBarcode.Rows[i]["ItemCode"].ToString();
                        cmd.Transaction = myTran;
                        cmd.ExecuteNonQuery();
                    }
                }
                myTran.Commit();
                con.Close();
                ButtonControl("L");
                ClearControl();
                ClearControlPartial();
                EnableControl(false);
                this.dtPurchaseWithBarcode.Clear();
                RadGrid1.Rebind();
                lblMessage.Text = "Purchase Successful.";
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
        }
        private void EditData()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();

            //SqlTransaction myTran;
            //SqlCommand cmd = con.CreateCommand();
            //myTran = con.BeginTransaction();
            //cmd.Connection = con;
            //cmd.Transaction = myTran;
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd = new SqlCommand("Sp_Purchase_Update", con); //// delete 
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 3;
            cmd.Parameters.Add("@PurID", SqlDbType.Int).Value = Convert.ToInt32(txtPurchaseNo.Text);
            cmd.Parameters.Add("@SupplierId", SqlDbType.NVarChar).Value = cmPartyName.SelectedValue;
            //cmd.Transaction = myTran;
            cmd.ExecuteNonQuery();

            DataTable PreItemDetails = (DataTable)Session["PreItemsDetails"]; // or update from database then run the delete operation

            List<DataRow> rows = PreItemDetails.AsEnumerable()
                   .Where(x => !dtPurchaseWithBarcode.AsEnumerable()
                                   .Select(y => y.Field<string>("Itemcode"))
                                   .Contains(x.Field<string>("Itemcode"))).ToList();

            if (PreItemDetails.Rows.Count > 0) // stock increase 
            {
                for (int i = 0; i < PreItemDetails.Rows.Count; i++)
                {
                    cmd = new SqlCommand("Sp_Purchase_Update", con); // increase stock qty incase of delete
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 112;
                    cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = PreItemDetails.Rows[i]["Qty"].ToString();
                    cmd.Parameters.Add("@Itemcode", SqlDbType.Int).Value = PreItemDetails.Rows[i]["ItemCode"].ToString();
                    //cmd.Transaction = myTran;
                    cmd.ExecuteNonQuery();
                }
            }
            if (rows.Count > 0)
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    cmd = new SqlCommand("Sp_Purchase_Update", con); // increase stock qty incase of delete
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 113;
                    cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = rows[i]["Qty"].ToString();
                    cmd.Parameters.Add("@Itemcode", SqlDbType.Int).Value = rows[i]["ItemCode"].ToString();
                    //cmd.Transaction = myTran;
                    cmd.ExecuteNonQuery();
                }
            }

            try
            {
                cmd = new SqlCommand("Sp_Purchase_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@PurID", SqlDbType.Int).Value = Convert.ToInt32(txtPurchaseNo.Text);
                cmd.Parameters.Add("@PurDate", SqlDbType.DateTime).Value = dpPurchaseDate.SelectedDate;
                cmd.Parameters.Add("@SupplierId", SqlDbType.NVarChar).Value = cmPartyName.SelectedValue;
                cmd.Parameters.Add("@BillNo", SqlDbType.NVarChar).Value = txtBillNo.Text;
                cmd.Parameters.Add("@VoucherNo", SqlDbType.NVarChar).Value = "";// txtVoucherNo.Text;

                cmd.Parameters.Add("@taxVAT", SqlDbType.Decimal).Value = 0;// Convert.ToDecimal(txtTax.Text);
                cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = Convert.ToDecimal(txtDiscount.Text);
                cmd.Parameters.Add("@LabourCost", SqlDbType.Decimal).Value = 0;//Convert.ToDecimal(txtLabourCost.Text);
                cmd.Parameters.Add("@NetAmount", SqlDbType.Decimal).Value = lblNetAmount.Text;
                cmd.Parameters.Add("@Paid", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPaidAmount.Text);
                cmd.Parameters.Add("@Due", SqlDbType.Decimal).Value = Convert.ToDecimal(lblDueAmount.Text);
                cmd.Parameters.Add("@Userid", SqlDbType.NVarChar).Value = AppEnv.Current.p_UserName.ToString();
                //cmd.Transaction = myTran;
                cmd.ExecuteNonQuery();

                ///////////////////////update or opening Payment Table and insert it for the first time (check)
                cmd = new SqlCommand("Sp_Purchase_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 7;
                cmd.Parameters.Add("@PurID", SqlDbType.Int).Value = Convert.ToInt32(txtPurchaseNo.Text);
                cmd.Parameters.Add("@SupplierId", SqlDbType.NVarChar).Value = cmPartyName.SelectedValue;
                cmd.Parameters.Add("@BillNo", SqlDbType.NVarChar).Value = txtBillNo.Text;
                cmd.Parameters.Add("@PayDate", SqlDbType.DateTime).Value = dpPurchaseDate.SelectedDate;
                cmd.Parameters.Add("@Paid", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPaidAmount.Text);
                cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = AppEnv.Current.p_UserName.ToString();
                //cmd.Transaction = myTran;
                cmd.ExecuteNonQuery();

                if (this.dtPurchaseWithBarcode.Rows.Count > 0)
                {
                    for (int i = 0; i < this.dtPurchaseWithBarcode.Rows.Count; i++)
                    {
                        cmd = new SqlCommand("Sp_Purchase_Update", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 11; // insert to purchase detail table 
                        cmd.Parameters.Add("@PurID", SqlDbType.Int).Value = Convert.ToInt32(txtPurchaseNo.Text);
                        cmd.Parameters.Add("@SupplierId", SqlDbType.NVarChar).Value = cmPartyName.SelectedValue;
                        cmd.Parameters.Add("@ItemCode", SqlDbType.Int).Value = this.dtPurchaseWithBarcode.Rows[i]["ItemCode"].ToString();
                        cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = this.dtPurchaseWithBarcode.Rows[i]["ItemQty"].ToString();
                        cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = this.dtPurchaseWithBarcode.Rows[i]["UnitRate"].ToString();
                        //cmd.Transaction = myTran;
                        cmd.ExecuteNonQuery();
                    }
                }
                if (this.dtPurchaseWithBarcode.Rows.Count > 0)
                {
                    for (int i = 0; i < this.dtPurchaseWithBarcode.Rows.Count; i++)
                    {
                        cmd = new SqlCommand("Sp_Purchase_Update", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 111; // update or insert to stock table (insert for new)
                        cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = this.dtPurchaseWithBarcode.Rows[i]["ItemQty"].ToString();
                        cmd.Parameters.Add("@Itemcode", SqlDbType.Int).Value = this.dtPurchaseWithBarcode.Rows[i]["ItemCode"].ToString();
                        //cmd.Transaction = myTran;
                        cmd.ExecuteNonQuery();
                    }
                }
                //myTran.Commit();
                con.Close();
                ButtonControl("L");
                ClearControl();
                ClearControlPartial();
                EnableControl(false);
                this.dtPurchaseWithBarcode.Clear();
                RadGrid1.Rebind();
                lblMessage.Text = "Purchase Successful.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
                //try
                //{
                //    myTran.Rollback();
                //}
                //catch (Exception ex1)
                //{
                //    lblMessage.Text = ex1.Message.ToString();
                //    return;
                //}
            }
        }
        private void ReloadMainGrid()
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_Purchase", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 4;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adpt.Fill(ds);
                dt = ds.Tables[0];
                rgMain.DataSource = dt;
                rgMain.DataBind();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        private void DataRefill()
        {
            this.dtPurchaseWithBarcode.Clear();
            RadGrid1.DataSource = null;
            RadGrid1.Rebind();

            GridDataItem selectedItem = (GridDataItem)rgMain.SelectedItems[0];
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("Sp_Purchase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 6;
            cmd.Parameters.Add("@PurID", SqlDbType.VarChar).Value = selectedItem["PurID"].Text;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            adpt.Fill(ds);
            dt1 = ds.Tables[0];
            dt2 = ds.Tables[1];

            try
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    DataRow newRow = this.dtPurchaseWithBarcode.NewRow();
                    newRow["rowid"] = this.dtPurchaseWithBarcode.Rows.Count + 1;
                    newRow["ItemCode"] = dt2.Rows[i]["ItemCode"].ToString();
                    newRow["Barcode"] = dt2.Rows[i]["Barcode"].ToString();
                    newRow["ItemName"] = dt2.Rows[i]["ItemName"].ToString();
                    newRow["CatName"] = dt2.Rows[i]["CatName"].ToString();
                    newRow["UnitRate"] = dt2.Rows[i]["UnitPrice"].ToString();
                    this.dtPurchaseWithBarcode.Rows.Add(newRow);
                    this.dtPurchaseWithBarcode.AcceptChanges();
                }
                RadGrid1.Rebind();
                Session["PreItemsDetails"] = dt2;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            txtPurchaseNo.Text = dt1.Rows[0]["PurID"].ToString();
            if (dt1.Rows[0]["PurDate"].ToString() != "")
                dpPurchaseDate.SelectedDate = Convert.ToDateTime(dt1.Rows[0]["PurDate"].ToString());
            cmPartyName.SelectedValue = dt1.Rows[0]["CustId"].ToString();
            cmPartyName.Text = dt1.Rows[0]["SupplierName"].ToString();
            txtBillNo.Text = dt1.Rows[0]["BillNo"].ToString();
            lblNetAmount.Text = dt1.Rows[0]["NetAmount"].ToString();
            txtPaidAmount.Text = dt1.Rows[0]["Paid"].ToString();
            txtDiscount.Text = dt1.Rows[0]["Discount"].ToString();
            lblDueAmount.Text = dt1.Rows[0]["Due"].ToString();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EnableControl(false);
                ClearControl();
                ClearControlPartial();
                ButtonControl("L");
                this.dtPurchaseWithBarcode.Clear();
                ReloadMainGrid();
            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                int max = Convert.ToInt32(GetAutoNumber("PurId", "tblPurchaseHDR"));
                txtPurchaseNo.Text = max.ToString();
                EnableControl(true);
                ClearControl();
                ButtonControl("N");
                dpPurchaseDate.SelectedDate = System.DateTime.Now;
                this.dtPurchaseWithBarcode.Clear();
                RadGrid1.Rebind();
                cmPartyName.Focus();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPurchaseNo.Text == "")
            {
                lblMessage.Text = "Purchase No can not be blank.";
            }
            else if (cmPartyName.SelectedValue == "")
            {
                lblMessage.Text = "Select Party Name.";
            }
            else if (txtBillNo.Text == "")
            {
                lblMessage.Text = "Bill No can not be blank.";
            }
            else if (dpPurchaseDate.SelectedDate == null)
            {
                lblMessage.Text = "Select Purchase Date.";
            }
            else if (this.dtPurchaseWithBarcode.Rows.Count <= 0)
            {
                lblMessage.Text = "Add Product.";
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
            ReloadMainGrid();
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            ButtonControl("E");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ButtonControl("L");
            EnableControl(false);
            ClearControl();
        }

        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = this.dtPurchaseWithBarcode;
        }
        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem dataItem = e.Item as GridDataItem;
                    sumAmount += Convert.ToDecimal(dataItem["UnitRate"].Text);
                    ViewState["UnitPrice"] = sumAmount;
                }
                else if (e.Item is GridFooterItem)
                {
                    GridFooterItem footerItem = e.Item as GridFooterItem;
                    footerItem["UnitRate"].Text = sumAmount.ToString("#,##0.00");
                    footerItem["ItemName"].Text = "Total : ";
                    footerItem.BackColor = System.Drawing.Color.LightGray;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "GridDelete")
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    int RID = Convert.ToInt16(item["rowid"].Text);
                    DataRow[] Drow = this.dtPurchaseWithBarcode.Select("rowid='" + RID + "'");
                    if (Drow.Length > 0)
                    {
                        Drow[0].Delete();
                        this.dtPurchaseWithBarcode.AcceptChanges();
                        RadGrid1.Rebind();
                    }

                    txtPaidAmount.Text = "0";
                    txtDiscount.Text = "0";
                    try
                    {
                        if (txtDiscount.Text != "" && lblDueAmount.Text != "" && txtPaidAmount.Text != "")
                        {
                            decimal total = Convert.ToDecimal(ViewState["UnitPrice"]);
                            decimal discount = Convert.ToDecimal(txtDiscount.Text);
                            decimal netamount = total - discount;
                            lblNetAmount.Text = netamount.ToString();
                            decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                            decimal due = (total - discount) - paid;
                            lblDueAmount.Text = due.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void rbtDeleteGrid_Click(object sender, ImageClickEventArgs e)
        {

        }
        decimal sumAmount = 0;
        protected void rgMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.dtPurchaseWithBarcode.Clear();
                ClearControl();
                ClearControlPartial();

                DataRefill();
                ButtonControl("E");
                EnableControl(true);

                txtBillNo.Enabled = false;

                //if (txtDiscount.Text != "" && lblDueAmount.Text != "" && txtPaidAmount.Text != "")
                //{
                //    decimal total = Convert.ToDecimal(ViewState["UnitRate"]);
                //    decimal discount = Convert.ToDecimal(txtDiscount.Text);
                //    decimal netamount = total - discount;
                //    lblNetAmount.Text = String.Format("{0:N2}", Convert.ToDouble(netamount));
                //    decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                //    decimal due = (total - discount) - paid;
                //    lblDueAmount.Text = String.Format("{0:N2}", Convert.ToDouble(due));
                //}
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void btnPurchaseStatement_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forms\rptReportManager.aspx");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["ReportHeading"] = "Purchase Statement";
            Session["ReportStartDate"] = dpPurchaseDate.SelectedDate;
            Session["ReportEndDate"] = dpPurchaseDate.SelectedDate;
            Response.Redirect("~/Forms/rptReportManager.aspx");
        }
        protected void rgMain_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }
        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDiscount.Text != "" && lblDueAmount.Text != "" && txtPaidAmount.Text != "")
                {
                    decimal total = Convert.ToDecimal(ViewState["UnitPrice"]);
                    decimal discount = Convert.ToDecimal(txtDiscount.Text);
                    decimal netamount = total - discount;
                    lblNetAmount.Text = netamount.ToString();
                    decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                    decimal due = (total - discount) - paid;
                    lblDueAmount.Text = due.ToString();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDiscount.Text != "" && lblDueAmount.Text != "" && txtPaidAmount.Text != "")
                {
                    decimal total = Convert.ToDecimal(ViewState["UnitPrice"]);
                    decimal discount = Convert.ToDecimal(txtDiscount.Text);
                    decimal netamount = total - discount;
                    lblNetAmount.Text = netamount.ToString();
                    decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                    decimal due = (total - discount) - paid;
                    lblDueAmount.Text = due.ToString();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void txtTax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDiscount.Text != "" && lblDueAmount.Text != "" && txtPaidAmount.Text != "")
                {
                    decimal total = Convert.ToDecimal(ViewState["UnitPrice"]);
                    decimal discount = Convert.ToDecimal(txtDiscount.Text);
                    decimal netamount = total - discount;
                    lblNetAmount.Text = netamount.ToString();
                    decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                    decimal due = (total - discount) - paid;
                    lblDueAmount.Text = due.ToString();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void txtVAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDiscount.Text != "" && lblDueAmount.Text != "" && txtPaidAmount.Text != "")
                {
                    decimal total = Convert.ToDecimal(ViewState["UnitPrice"]);
                    decimal discount = Convert.ToDecimal(txtDiscount.Text);
                    decimal netamount = total - discount;
                    lblNetAmount.Text = netamount.ToString();
                    decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                    decimal due = (total - discount) - paid;
                    lblDueAmount.Text = due.ToString();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void cmItemName_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {

        }
        protected void cmPartyName_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_Purchase", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 9;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dataRow in dt.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = (string)dataRow["Name"].ToString();
                    item.Value = dataRow["SupplierId"].ToString();

                    string ItemCode = (string)dataRow["SupplierId"].ToString();
                    item.Attributes.Add("SupplierId", ItemCode.ToString());

                    cmPartyName.Items.Add(item);
                    item.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
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
                cmd = new SqlCommand("Sp_ReportManager", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 5;
                cmd.Parameters.Add("@ItemCatId", SqlDbType.Int).Value = cmCategory.SelectedValue;
                //cmd.Parameters.Add("@SupplierId", SqlDbType.Int).Value = cmPartyName.SelectedValue;
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

                    cmItemName.Items.Add(item);
                    item.DataBind();
                }
                con.Close();
                cmItemName.Focus();
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

            SqlTransaction myTran;
            SqlCommand cmd = con.CreateCommand();
            myTran = con.BeginTransaction();
            cmd.Connection = con;
            cmd.Transaction = myTran;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (txtPurchaseNo.Text != "")
                {
                    cmd = new SqlCommand("Sp_Purchase", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 3;
                    cmd.Parameters.Add("@PurID", SqlDbType.Int).Value = txtPurchaseNo.Text;
                    cmd.Parameters.Add("@SupplierId", SqlDbType.NVarChar).Value = cmPartyName.SelectedValue;
                    cmd.Transaction = myTran;
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < dtPurchaseWithBarcode.Rows.Count; i++)
                    {
                        cmd = new SqlCommand("Sp_Purchase", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 33;
                        cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@Itemcode", SqlDbType.Int).Value = this.dtPurchaseWithBarcode.Rows[i]["ItemCode"].ToString();
                        cmd.Transaction = myTran;
                        cmd.ExecuteNonQuery();
                    }
                    lblMessage.Text = "Delete Successful.";
                }
                myTran.Commit();
                con.Close();

                EnableControl(false);
                ClearControl();
                ClearControlPartial();
                ButtonControl("L");
                this.dtPurchaseWithBarcode.Clear();
                RadGrid1.Rebind();
                txtPurchaseNo.Text = "";
                ReloadMainGrid();
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
        }

        protected void cmPartyName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cmCategory.Focus();
        }
        protected void cmItemName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                txtUnitPrice.Text = "";

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("select a.PurRate, a.SalesRate, isnull(d.StockQty,0)StockQty from tblItems a left join tblStocks d on a.ItemCode=d.ItemCode where a.ItemCode='" + cmItemName.SelectedValue + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtUnitPrice.Text = dr["PurRate"].ToString();
                    lblStock.Text = "Stock: " + dr["StockQty"].ToString();
                }
                txtBarcode.Focus();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (cmItemName.Text == "")
            {
                lblMessage.Text = "Select Item.";
            }
            else if (txtUnitPrice.Text == "")
            {
                lblMessage.Text = "Unit Price can not be Blank.";
            }
            else
            {
                try
                {
                    if (cmItemName.SelectedValue != "")
                    {
                        //check barcode already in database or not
                        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                        con.Open();
                        cmd = new SqlCommand("Sp_Purchase", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 15;
                        cmd.Parameters.Add("@Barcode", SqlDbType.VarChar).Value = txtBarcode.Text;
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            return;
                        }
                        //check barcode already in database or not


                        DataRow newRow = this.dtPurchaseWithBarcode.NewRow();
                        newRow["rowid"] = this.dtPurchaseWithBarcode.Rows.Count + 1;
                        newRow["ItemCode"] = cmItemName.SelectedValue;
                        newRow["ItemName"] = cmItemName.Text;
                        newRow["CatName"] = cmCategory.Text;
                        newRow["ItemQty"] = 1;
                        newRow["UnitRate"] = Convert.ToDecimal(txtUnitPrice.Text);
                        newRow["Barcode"] = txtBarcode.Text;

                        this.dtPurchaseWithBarcode.Rows.Add(newRow);
                        this.dtPurchaseWithBarcode.AcceptChanges();
                        RadGrid1.Rebind();
                        //ClearControlPartial();
                        lblMessage.Text = "";

                        txtPaidAmount.Text = "0";
                        txtDiscount.Text = "0";
                        if (txtDiscount.Text != "" && lblDueAmount.Text != "" && txtPaidAmount.Text != "")
                        {
                            decimal total = Convert.ToDecimal(ViewState["UnitPrice"]);
                            decimal discount = Convert.ToDecimal(txtDiscount.Text);
                            decimal netamount = total - discount;
                            lblNetAmount.Text = netamount.ToString("#,##0.00");
                            decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                            decimal due = (total - discount) - paid;
                            lblDueAmount.Text = due.ToString("#,##0.00");

                        }
                        txtBarcode.Text = "";
                        txtBarcode.Focus();
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
        }
    }
}