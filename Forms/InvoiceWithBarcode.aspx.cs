using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using Telerik.Web.UI;

namespace ElectronicsMS.Forms
{
    public partial class InvoiceWithBarcode : Page
    {
        ElectronicsMSDBEntities db = new ElectronicsMSDBEntities();
        SqlConnection con;
        SqlCommand cmd;
        public DataTable dtSalesWithBarcode
        {
            get
            {
                object obj = this.Session["dtSalesWithBarcode"];
                if (obj != null)
                {
                    return (DataTable)obj;
                }
                DataTable dt1 = new DataTable();

                dt1.Columns.Add("rowid", typeof(Int16));
                dt1.Columns.Add("Barcode", typeof(string));
                dt1.Columns.Add("ItemCode", typeof(string));
                dt1.Columns.Add("ItemName", typeof(string));
                dt1.Columns.Add("CatName", typeof(string)); 
                dt1.Columns.Add("UnitPrice", typeof(decimal));

                dt1.PrimaryKey = new DataColumn[] { dt1.Columns["Barcode"] };

                this.Session["dtSalesWithBarcode"] = dt1;
                return dtSalesWithBarcode;
            }
        }
        public DataTable dtInstallment
        {
            get
            {
                object obj = this.Session["dtInstallment"];
                if (obj != null)
                {
                    return (DataTable)obj;
                }
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("rowid", typeof(Int16));
                dt1.Columns.Add("CustId", typeof(string));
                dt1.Columns.Add("TotalAmount", typeof(decimal));
                dt1.Columns.Add("InstallNo", typeof(int));
                dt1.Columns.Add("InstallAmt", typeof(decimal));
                dt1.Columns.Add("InstallDate", typeof(DateTime));
                dt1.Columns.Add("track_id", typeof(Int16));
                
                dt1.PrimaryKey = new DataColumn[] { dt1.Columns["rowid"] };

                this.Session["dtInstallment"] = dt1;
                return dtInstallment;
            }
        }

        public DataTable dtSales
        {
            get
            {
                object obj = this.Session["dtSales"];
                if (obj != null)
                {
                    return (DataTable)obj;
                }
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("rowid", typeof(Int32));
                dt1.Columns.Add("SalesId", typeof(string));
                dt1.Columns.Add("SalesDate", typeof(DateTime));
                dt1.Columns.Add("CustId", typeof(string));
                dt1.Columns.Add("CustomerName", typeof(string));
                dt1.Columns.Add("NetAmount", typeof(decimal));
                dt1.Columns.Add("Discount", typeof(decimal));
                dt1.Columns.Add("LabourCost", typeof(decimal));
                dt1.Columns.Add("Paid", typeof(decimal));
                dt1.Columns.Add("Due", typeof(decimal));
                dt1.PrimaryKey = new DataColumn[] { dt1.Columns["rowid"] };
                this.Session["dtSales"] = dt1;
                return dtSales;
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
                return "5001";
            }
            finally
            {
                con.Close();
            }
        }
        public string GetAutoNumberChallan(string fieldName, string tableName)
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
                return "3001";
            }
            finally
            {
                con.Close();
            }
        }
        public void ClearControl()
        {      
            txtSalesID.Text = "";
            cmInstallment.SelectedValue = "";
            cmInstallment.Text = "";
            dpSalesDt.SelectedDate = null;
            cmCustomerName.SelectedValue = "";
            cmCustomerName.Text = "";

            txtPaidAmount.Text = "0";
            txtDiscount.Text = "0";
            lblDueAmount.Text = "0.00";
            lblNetAmount.Text = "0.00";
            txtPercent.Text = "0";
            dtSalesWithBarcode.Clear();
            RadGrid1.Rebind();
        }
        public void ClearControlGranter()
        {
            txtGranterName.Text = "";
            txtGranterFatherName.Text = "";
            txtGranterMobile.Text = "";
            txtGranterAddress.Text = "";
        }
        public void EnableGranterControl(bool ec)
        {
            txtGranterName.Enabled = ec;
            txtGranterFatherName.Enabled = ec;
            txtGranterMobile.Enabled = ec;
            txtGranterAddress.Enabled = ec;
        }
        private void ReloadMainGrid()
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_Sales", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 4;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adpt.Fill(ds);
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow newRow = this.dtSales.NewRow();
                    newRow["rowid"] = this.dtSales.Rows.Count + 1;
                    newRow["SalesId"] = dt.Rows[i]["SalesId"].ToString();
                    newRow["SalesDate"] = dt.Rows[i]["SalesDate"].ToString();
                    newRow["CustId"] = dt.Rows[i]["CustId"].ToString();
                    newRow["CustomerName"] = dt.Rows[i]["CustomerName"].ToString();
                    newRow["NetAmount"] = dt.Rows[i]["NetAmount"].ToString();
                    newRow["Discount"] = dt.Rows[i]["Discount"].ToString();
                    newRow["LabourCost"] = dt.Rows[i]["LabourCost"].ToString();
                    newRow["Paid"] = dt.Rows[i]["Paid"].ToString();
                    newRow["Due"] = dt.Rows[i]["Due"].ToString();
                    this.dtSales.Rows.Add(newRow);
                    this.dtSales.AcceptChanges();
                }
                rgMain.Rebind();
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
                this.dtSalesWithBarcode.Clear();
                RadGrid1.DataSource = null;
                RadGrid1.Rebind();

                GridDataItem selectedItem = (GridDataItem)rgMain.SelectedItems[0];
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_Sales", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 6;
                cmd.Parameters.Add("@SalesId", SqlDbType.VarChar).Value = selectedItem["SalesId"].Text;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                adpt.Fill(ds);
                dt1 = ds.Tables[0];
                dt2 = ds.Tables[1];

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    DataRow newRow = this.dtSalesWithBarcode.NewRow();
                    newRow["rowid"] = this.dtSalesWithBarcode.Rows.Count + 1;
                    newRow["Barcode"] = dt2.Rows[i]["Barcode"].ToString();
                    newRow["ItemCode"] = dt2.Rows[i]["ItemCode"].ToString();
                    newRow["ItemName"] = dt2.Rows[i]["ItemName"].ToString();
                    newRow["CatName"] = dt2.Rows[i]["CatName"].ToString();
                    newRow["UnitPrice"] = dt2.Rows[i]["UnitPrice"].ToString();
                    this.dtSalesWithBarcode.Rows.Add(newRow);
                    this.dtSalesWithBarcode.AcceptChanges();
                }
                RadGrid1.Rebind();
                Session["PreItemsDetails"] = dt2;

                txtSalesID.Text = dt1.Rows[0]["SalesId"].ToString();
                cmInstallment.SelectedValue = dt1.Rows[0]["Instalment"].ToString();
                cmInstallment.Text = dt1.Rows[0]["InstalmentName"].ToString();
                if (dt1.Rows[0]["SalesDate"].ToString() != "")
                    dpSalesDt.SelectedDate = Convert.ToDateTime(dt1.Rows[0]["SalesDate"].ToString());
                cmCustomerName.SelectedValue = dt1.Rows[0]["CustId"].ToString();
                cmCustomerName.Text = dt1.Rows[0]["CustName"].ToString();
                txtPaidAmount.Text = dt1.Rows[0]["Paid"].ToString();
                txtDiscount.Text = dt1.Rows[0]["Discount"].ToString();
                txtPercent.Text= dt1.Rows[0]["Percents"].ToString();
                lblDueAmount.Text = dt1.Rows[0]["Due"].ToString();
                txtDeedFee.Text = dt1.Rows[0]["DeedFee"].ToString();

                txtGranterName.Text = dt1.Rows[0]["GranterName"].ToString();
                txtGranterFatherName.Text = dt1.Rows[0]["GranterFatherName"].ToString();
                txtGranterMobile.Text = dt1.Rows[0]["GranterMobile"].ToString();
                txtGranterAddress.Text = dt1.Rows[0]["GranterAddress"].ToString();


                hfOnlyPrint.Value = "OnlyPrint";
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
                cmd = new SqlCommand("Sp_Sales", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@SalesId", SqlDbType.Int).Value = txtSalesID.Text;
                cmd.Parameters.Add("@Instalment", SqlDbType.Int).Value = cmInstallment.SelectedValue;
                ViewState["salesid"] = txtSalesID.Text;
                cmd.Parameters.Add("@SalesDate", SqlDbType.DateTime).Value = dpSalesDt.SelectedDate;
                cmd.Parameters.Add("@CustId", SqlDbType.NVarChar).Value = cmCustomerName.SelectedValue;

                cmd.Parameters.Add("@Percents", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPercent.Text);
                cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = Convert.ToDecimal(txtDiscount.Text);
                cmd.Parameters.Add("@NetAmount", SqlDbType.Decimal).Value = lblNetAmount.Text;
                cmd.Parameters.Add("@Paid", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPaidAmount.Text);
                cmd.Parameters.Add("@Due", SqlDbType.Decimal).Value = Convert.ToDecimal(lblDueAmount.Text);
                cmd.Parameters.Add("@DeedFee", SqlDbType.Decimal).Value = Convert.ToDecimal(txtDeedFee.Text);
                cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = AppEnv.Current.p_UserName.ToString();

                cmd.Parameters.Add("@GranterName", SqlDbType.VarChar).Value = txtGranterName.Text;
                cmd.Parameters.Add("@GranterFatherName", SqlDbType.VarChar).Value = txtGranterFatherName.Text;
                cmd.Parameters.Add("@GranterMobile", SqlDbType.VarChar).Value = txtGranterMobile.Text;
                cmd.Parameters.Add("@GranterAddress", SqlDbType.VarChar).Value = txtGranterAddress.Text;

                cmd.Transaction = myTran;
                cmd.ExecuteNonQuery();
                ///////////////////////update or opening Money Receive Table and insert it for the first time (check)
                cmd = new SqlCommand("Sp_Sales", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 7;
                cmd.Parameters.Add("@SalesId", SqlDbType.Int).Value = Convert.ToInt32(txtSalesID.Text);
                cmd.Parameters.Add("@CustId", SqlDbType.NVarChar).Value = cmCustomerName.SelectedValue;
                cmd.Parameters.Add("@SalesDate", SqlDbType.DateTime).Value = dpSalesDt.SelectedDate;
                cmd.Parameters.Add("@Paid", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPaidAmount.Text);
                cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = AppEnv.Current.p_UserName.ToString();

                cmd.Transaction = myTran;
                cmd.ExecuteNonQuery();

                if (this.dtSalesWithBarcode.Rows.Count > 0)
                {
                    for (int i = 0; i < this.dtSalesWithBarcode.Rows.Count; i++)
                    {
                        cmd = new SqlCommand("Sp_Sales", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 11;
                        cmd.Parameters.Add("@SalesId", SqlDbType.Int).Value = Convert.ToInt32(txtSalesID.Text);
                        cmd.Parameters.Add("@CustId", SqlDbType.NVarChar).Value = cmCustomerName.SelectedValue;
                        cmd.Parameters.Add("@Itemcode", SqlDbType.Int).Value = this.dtSalesWithBarcode.Rows[i]["ItemCode"].ToString();
                        cmd.Parameters.Add("@Barcode", SqlDbType.VarChar).Value = this.dtSalesWithBarcode.Rows[i]["Barcode"].ToString();
                        cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = this.dtSalesWithBarcode.Rows[i]["UnitPrice"].ToString();
                        cmd.Transaction = myTran;
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("Sp_Sales", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 111;
                        //cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = 1; //??
                        cmd.Parameters.Add("@Itemcode", SqlDbType.VarChar).Value = this.dtSalesWithBarcode.Rows[i]["ItemCode"].ToString();
                        cmd.Transaction = myTran;
                        cmd.ExecuteNonQuery();
                    }
                }
                myTran.Commit();
                con.Close();
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearControl();
                this.dtSalesWithBarcode.Clear();
                ReloadMainGrid();
                ViewState["salesid"] = "";
                int max = Convert.ToInt32(GetAutoNumber("SalesId", "tblSalesHDR"));
                txtSalesID.Text = max.ToString();
                dpSalesDt.SelectedDate = DateTime.Now;
                hfOnlyPrint.Value = "";
                ClearControlGranter();
                btnDelete.Enabled = false;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cmCustomerName.SelectedValue == "")
            {
                lblMessage.Text = "Select Customer.";
            }
            else if (dpSalesDt.SelectedDate == null)
            {
                lblMessage.Text = "Select Invoice Date.";
            }
            else if (this.dtSalesWithBarcode.Rows.Count <= 0)
            {
                lblMessage.Text = "Add Product.";
            }
            else if (Convert.ToDecimal(lblDueAmount.Text) < 0)
            {
                lblMessage.Text = "Due Amount can not be Negetive.";
            }
            else
            {
                    try
                    {
                        ////============Validation Check==============
                        //con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                        //con.Open();
                        //if (this.dtSalesWithBarcode.Rows.Count > 0)
                        //{
                        //    for (int i = 0; i < this.dtSalesWithBarcode.Rows.Count; i++)
                        //    {
                        //        cmd = new SqlCommand("Sp_ValidationAll", con);
                        //        cmd.CommandType = CommandType.StoredProcedure;
                        //        cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 1;
                        //        cmd.Parameters.Add("@Itemcode", SqlDbType.Int).Value = this.dtSalesWithBarcode.Rows[i]["ItemCode"].ToString();
                        //        SqlDataReader dr = cmd.ExecuteReader();
                        //        if (dr.Read())
                        //        {
                        //            string a = this.dtSalesWithBarcode.Rows[i]["Qty"].ToString();
                        //            if (Convert.ToDecimal(dr["StockQty"].ToString()) < Convert.ToDecimal(this.dtSalesWithBarcode.Rows[i]["Qty"].ToString()))
                        //            {
                        //                lblMessage.Text = "Check Stock Quantity for " + this.dtSalesWithBarcode.Rows[i]["ItemCode"].ToString() + "";
                        //                return;
                        //            }
                        //        }
                        //        cmd.Dispose();
                        //        dr.Dispose();
                        //        dr.Close();
                        //    }
                        //}
                        //con.Close();
                        //=============End Validation Check=============

                        SaveData();
                        ClearControl();
                        this.dtSalesWithBarcode.Clear();
                        this.dtSalesWithBarcode.AcceptChanges();
                        RadGrid1.Rebind();
                        lblMessage.Text = "Sales Successful.";
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message;
                    }
                }
                ReloadMainGrid();
                txtSalesID.Text = ViewState["salesid"].ToString();
        }
        protected void btnPrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmCustomerName.SelectedValue=="")
                {
                    lblMessage.Text = "Select Customer.";
                    return;
                }
                if (txtSalesID.Text == "")
                {
                    lblMessage.Text = "Sales ID can not be Blank.";
                    return;
                }
                if (cmInstallment.SelectedValue == "")
                {
                    lblMessage.Text = "Select Instalment.";
                    return;
                }
                if (dtSalesWithBarcode.Rows.Count<=0)
                {
                    lblMessage.Text = "Add Item.";
                    return;
                }

                if (hfOnlyPrint.Value != "OnlyPrint")
                {
                    SaveData();
                    ReloadMainGrid();
                }

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();

                if (AppEnv.Current.p_rptSource != null)
                {
                    AppEnv.Current.p_rptSource.Close();
                    AppEnv.Current.p_rptSource.Dispose();
                }

                AppEnv.Current.p_rptSource = new ReportDocument();
                cmd = new SqlCommand("Sp_ReportManager", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 7;
                cmd.Parameters.Add("@SalesId", SqlDbType.VarChar).Value = txtSalesID.Text;
                cmd.Parameters.Add("@CustId", SqlDbType.Int).Value = Convert.ToInt32(cmCustomerName.SelectedValue);
                if (ckDiscountYN.Checked == true)
                    cmd.Parameters.Add("@DiscountYN", SqlDbType.VarChar).Value = "Y";
                SqlDataAdapter Dap = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dtInstallmentDetails = new DataTable();
                DataSet ds = new DataSet();
                Dap.Fill(ds);

                ReportDocument subInstallmentDetails;

                dt1 = ds.Tables[0];
                dt2 = ds.Tables[1];
                dtInstallmentDetails = ds.Tables[2];

                cmd.Dispose();

                string tempPath = "";
                string reportName = "";
                reportName = "Invoice-" + txtSalesID.Text + " " + " " + cmCustomerName.Text + " " + Convert.ToDateTime(dpSalesDt.SelectedDate).ToString("dd-MM-yyyy");
                AppEnv.Current.p_rptObject = "~/Reports/InvoiceA4Half.rpt";
                tempPath = @System.IO.Path.GetTempPath() + "Invoice";
                AppEnv.Current.p_rptSource.Load(Server.MapPath(AppEnv.Current.p_rptObject.ToString()));

                subInstallmentDetails = AppEnv.Current.p_rptSource.OpenSubreport("subInstallmentDetails.rpt");
                subInstallmentDetails.SetDataSource(dtInstallmentDetails);

                AppEnv.Current.p_rptSource.SetDataSource(dt1);
                con.Close();

                if (dt1.Rows.Count > 0)
                {
                    decimal TotalDues = Convert.ToDecimal(dt1.Rows[0]["Due"].ToString());

                    Session["dt"] = dt1;

                    ViewState["preview"] = "pdf";
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

                    //string URL = "~/CRpreview.aspx";
                    //URL = Page.ResolveClientUrl(URL);
                    //ClientScript.RegisterStartupScript(this.Page.GetType(), "popupOpener", "var popup=window.open('" + URL + "');popup.focus();", true);
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

        decimal sumUnitPrice = 0;
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = this.dtSalesWithBarcode;
        }
        protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem dataItem = e.Item as GridDataItem;
                    sumUnitPrice += Convert.ToDecimal(dataItem["UnitPrice"].Text);
                    ViewState["sumUnitPrice"] = sumUnitPrice;
                    lblDueAmount.Text = sumUnitPrice.ToString();
                }
                else if (e.Item is GridFooterItem)
                {
                    GridFooterItem footerItem = e.Item as GridFooterItem;
                    footerItem["UnitPrice"].Text = sumUnitPrice.ToString("#,##0.00");
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
                    DataRow[] Drow = this.dtSalesWithBarcode.Select("rowid='" + RID + "'");
                    if (Drow.Length > 0)
                    {
                        Drow[0].Delete();
                        this.dtSalesWithBarcode.AcceptChanges();
                        RadGrid1.Rebind();
                    }
                    txtPaidAmount.Text = "0";
                    //txtTax.Text = "0";
                    txtDiscount.Text = "0";
                    if (txtDiscount.Text != "" && lblDueAmount.Text != "" && txtPaidAmount.Text != "")
                    {
                        decimal total = Convert.ToDecimal(ViewState["sumUnitPrice"]);
                        //decimal taxVAT = Convert.ToDecimal(txtTax.Text);
                        decimal discount = Convert.ToDecimal(txtDiscount.Text);
                        decimal netamount = total - discount;
                        lblNetAmount.Text = String.Format("{0:N2}", Convert.ToDouble(netamount));
                        decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                        decimal due = (total - discount) - paid;
                        lblDueAmount.Text = String.Format("{0:N2}", Convert.ToDouble(due));
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
        protected void rgMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.dtSalesWithBarcode.Clear();
                ClearControl();
                DataRefill();
                txtSalesID.Enabled = false;
                dpSalesDt.Enabled = false;

                if (txtDiscount.Text != "" && lblDueAmount.Text != "" && txtPaidAmount.Text != "")
                {
                    decimal total = Convert.ToDecimal(ViewState["sumUnitPrice"]);
                    decimal discount = Convert.ToDecimal(txtDiscount.Text);
                    decimal netamount = total - discount;
                    lblNetAmount.Text = String.Format("{0:N2}", Convert.ToDouble(netamount));
                    decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                    decimal due = (total - discount) - paid;
                    lblDueAmount.Text = String.Format("{0:N2}", Convert.ToDouble(due));
                }
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void txtOtherCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDiscount.Text != "" && lblDueAmount.Text != "" && txtPaidAmount.Text != "")
                {
                    decimal total = Convert.ToDecimal(ViewState["sumUnitPrice"]);
                    decimal discount = Convert.ToDecimal(txtDiscount.Text);
                    decimal netamount = total - discount;
                    lblNetAmount.Text = String.Format("{0:N2}", Convert.ToDouble(netamount));
                    decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                    decimal due = (total - discount) - paid;
                    lblDueAmount.Text = String.Format("{0:N2}", Convert.ToDouble(due));
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
                    decimal total = Convert.ToDecimal(ViewState["sumUnitPrice"]);
                    decimal discount = Convert.ToDecimal(txtDiscount.Text);
                    decimal netamount = total - discount;
                    lblNetAmount.Text = String.Format("{0:N2}", Convert.ToDouble(netamount));
                    decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                    decimal due = (total - discount) - paid;
                    lblDueAmount.Text = String.Format("{0:N2}", Convert.ToDouble(due));
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
                    decimal total = Convert.ToDecimal(ViewState["sumUnitPrice"]);
                    decimal discount = Convert.ToDecimal(txtDiscount.Text);
                    decimal netamount = total - discount;
                    lblNetAmount.Text = String.Format("{0:N2}", Convert.ToDouble(netamount));
                    decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                    decimal due = (total - discount) - paid;
                    lblDueAmount.Text = String.Format("{0:N2}", Convert.ToDouble(due));
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
                    decimal due = 0;
                    decimal total = Convert.ToDecimal(ViewState["sumUnitPrice"]);
                    decimal discount = Convert.ToDecimal(txtDiscount.Text);
                    if(cmInstallment.SelectedValue=="0")
                    {
                        decimal netamount = total - discount;
                        lblNetAmount.Text = String.Format("{0:N2}", Convert.ToDouble(netamount));
                        decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                        due = (total - discount) - paid;
                    }
                    else
                    {
                        decimal netamount = total + discount;
                        lblNetAmount.Text = String.Format("{0:N2}", Convert.ToDouble(netamount));
                        decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                        due = (total + discount) - paid;
                    }

                    lblDueAmount.Text = String.Format("{0:N2}", Convert.ToDouble(due));
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDiscount.Text != "" && lblDueAmount.Text != "" && txtPaidAmount.Text != "")
                {
                    decimal due = 0;
                    decimal total = Convert.ToDecimal(ViewState["sumUnitPrice"]);
                    decimal discount = Convert.ToDecimal(txtDiscount.Text);
                    if (cmInstallment.SelectedValue == "0")
                    {
                        decimal netamount = total - discount;
                        lblNetAmount.Text = String.Format("{0:N2}", Convert.ToDouble(netamount));
                        decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                        due = (total - discount) - paid;
                    }
                    else
                    {
                        decimal netamount = total + discount;
                        lblNetAmount.Text = String.Format("{0:N2}", Convert.ToDouble(netamount));
                        decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                        due = (total + discount) - paid;
                    }
                    lblDueAmount.Text = String.Format("{0:N2}", Convert.ToDouble(due));
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void cmCustomerName_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_Sales", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 8;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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

                    string Mobile = (string)dataRow["Mobile"].ToString();
                    item.Attributes.Add("Mobile", Mobile.ToString());

                    string Balance = (string)dataRow["Balance"].ToString();
                    item.Attributes.Add("Balance", Balance.ToString());

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
        protected void btnCustomerName_Click(object sender, EventArgs e)
        {
            lblMessagePopup.Text = "";
            lblInsertType.Text = "Insert Customer";
            ViewState["btnType"] = "Customer";
            int max = Convert.ToInt32(GetAutoNumber("CustId", "tblCustomers"));
            txtCodeMaster.Text = max.ToString();
            txtNameMaster.Text = "";
            txtMobileNo.Text = "";
            txtAddress.Text = "";
            lblTypeName.Visible = true;
            lblTypeName.Text = "Mobile";
            RadWindow1.VisibleOnPageLoad = true;
        }
        protected void btnSaveMaster_Click(object sender, EventArgs e)
        {
            if (txtNameMaster.Text == "")
            {
                lblMessagePopup.Text = "Name can not be Blank.";
            }
            else if (txtMobileNo.Text == "")
            {
                lblMessagePopup.Text = "Mobile No can not be Blank.";
            }
            else if (txtAddress.Text == "")
            {
                lblMessagePopup.Text = "Address No can not be Blank.";
            }
            else
            {
                if (ViewState["btnType"].ToString() == "Customer")
                {
                    tblCustomer tbl = new tblCustomer();
                    tbl.CustId = Convert.ToInt32(txtCodeMaster.Text);
                    tbl.Name = txtNameMaster.Text;
                    tbl.Mobile = txtMobileNo.Text;
                    tbl.Address = txtAddress.Text;
                    db.tblCustomers.Add(tbl);
                    db.SaveChanges();
                    cmCustomerName.DataBind();

                    lblMessagePopup.Text = txtNameMaster.Text + " Saved Successfully.";
                    txtNameMaster.Text = "";
                    txtCodeMaster.Text = "";
                    txtMobileNo.Text = "";
                    txtAddress.Text = "";
                    int max = Convert.ToInt32(GetAutoNumber("CustId", "tblCustomers"));
                    txtCodeMaster.Text = max.ToString();
                }
            }
        }
        protected void btnCancelMaster_Click(object sender, EventArgs e)
        {
            txtNameMaster.Text = "";
            txtCodeMaster.Text = "";
            txtMobileNo.Text = "";
            txtAddress.Text = "";
            RadWindow1.VisibleOnPageLoad = false;
        }
        protected void cmCustomerName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (cmCustomerName.SelectedValue != "")
                {
                    ViewState["PreviousDue"] = 0;
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("Sp_Sales", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 14;
                    cmd.Parameters.Add("@CustId", SqlDbType.Int).Value = Convert.ToInt32(cmCustomerName.SelectedValue);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ViewState["PreviousDue"] = Convert.ToDecimal(dt.Rows[0]["Due"].ToString()).ToString("0");
                    }
                    lblMessage.Text = "";
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                //lblBalance.Text = "0.00";
                lblMessage.Text = ex.Message;
            }
        }
        protected void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_Sales", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 15;
                cmd.Parameters.Add("@Barcode", SqlDbType.VarChar).Value = txtBarcode.Text;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt1 = new DataTable();
                adpt.Fill(ds);
                dt1 = ds.Tables[0];

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    DataRow newRow = this.dtSalesWithBarcode.NewRow();
                    newRow["rowid"] = this.dtSalesWithBarcode.Rows.Count + 1;
                    newRow["Barcode"] = dt1.Rows[i]["Barcode"].ToString();
                    newRow["ItemCode"] = dt1.Rows[i]["ItemCode"].ToString();
                    newRow["ItemName"] = dt1.Rows[i]["ItemName"].ToString();
                    newRow["CatName"] = dt1.Rows[i]["CatName"].ToString();
                    newRow["UnitPrice"] = dt1.Rows[i]["SalesRate"].ToString();
                    this.dtSalesWithBarcode.Rows.Add(newRow);
                    this.dtSalesWithBarcode.AcceptChanges();
                }
                RadGrid1.Rebind();
                lblMessage.Text = "";

                txtPaidAmount.Text = "0";
                txtDiscount.Text = "0";
                if (txtDiscount.Text != "" && lblDueAmount.Text != "" && txtPaidAmount.Text != "")
                {
                    decimal total = Convert.ToDecimal(ViewState["sumUnitPrice"]);
                    decimal discount = Convert.ToDecimal(txtDiscount.Text);
                    decimal netamount = total - discount;
                    lblNetAmount.Text = netamount.ToString("#,##0.00");
                    decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                    decimal due = (total - discount) - paid;
                    lblDueAmount.Text = due.ToString("#,##0.00");
                }
                txtBarcode.Text = "";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void cmInstallment_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_Sales", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 16;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dataRow in dt.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = (string)dataRow["Name"];
                    item.Value = dataRow["Id"].ToString();

                    cmInstallment.Items.Add(item);
                    item.DataBind();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void txtPercent_TextChanged(object sender, EventArgs e)
        {
            if(cmInstallment.SelectedValue=="")
            {
                txtPercent.Text = "";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Select Instalment.');", true);
            }
            else
            {
                decimal netAmount = 0;
                decimal paidAmount = 0;
                if (lblNetAmount.Text != "")
                {
                    paidAmount = Convert.ToDecimal(txtPaidAmount.Text);
                    decimal percent = Convert.ToDecimal(txtPercent.Text);
                    if (Convert.ToInt32(cmInstallment.SelectedValue) > 6 && txtPaidAmount.Text !="" && txtPaidAmount.Text != "0")
                    {
                        netAmount = Convert.ToDecimal(lblNetAmount.Text);
                        txtDiscount.Text = (percent / 100 * (netAmount - paidAmount)).ToString();
                    }
                    else
                    {
                        netAmount = Convert.ToDecimal(lblNetAmount.Text);
                        txtDiscount.Text = (percent / 100 * netAmount).ToString();
                    }

                    lblDueAmount.Text = "0";
                }
                else
                {
                    lblMessage.Text = "Add Items.";
                }

                try
                {
                    if (txtDiscount.Text != "" && lblDueAmount.Text != "" && txtPaidAmount.Text != "")
                    {
                        decimal due = 0;
                        decimal discount = Convert.ToDecimal(txtDiscount.Text);
                        netAmount = Convert.ToDecimal(lblNetAmount.Text);
                        paidAmount = Convert.ToDecimal(txtPaidAmount.Text);
                        if (cmInstallment.SelectedValue == "0")
                        {
                            due = (netAmount - discount) - paidAmount;
                        }
                        else if(Convert.ToInt32(cmInstallment.SelectedValue) > 6)
                        {
                            due = netAmount - paidAmount+ discount;
                        }
                        else
                        {
                            //if(Convert.ToInt32(cmInstallment.SelectedValue) > 6)
                            //{
                                due = (netAmount + discount) - paidAmount;
                            //}
                            //else
                            //{
                            //    due = (netAmount + discount) - paidAmount;
                            //}
                        }
                        lblDueAmount.Text = due.ToString();
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
        }
        protected void cmInstallment_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (txtDiscount.Text != "" && lblDueAmount.Text != "" && txtPaidAmount.Text != "")
            {
                decimal total = Convert.ToDecimal(ViewState["sumUnitPrice"]);
                decimal discount = Convert.ToDecimal(txtDiscount.Text);
                decimal netamount = total; //- discount;
                lblNetAmount.Text = netamount.ToString("#,##0.00");
                decimal paid = Convert.ToDecimal(txtPaidAmount.Text);
                decimal due = (total - discount) - paid;
                lblDueAmount.Text = due.ToString("#,##0.00");
            }

            if (cmInstallment.SelectedValue== "0")
            {
                txtDeedFee.Enabled = false;
                btnCalculateInstallment.Enabled = false;
                ClearControlGranter();
                EnableGranterControl(false);
                txtDeedFee.Text = "0";
            }
            else
            {
                txtDeedFee.Text = "0";
                txtDeedFee.Enabled = true;
                btnCalculateInstallment.Enabled = true;
                txtPercent.Text = "0";
                EnableGranterControl(true);
                txtDiscount.Text = "0";
                lblDueAmount.Text = lblNetAmount.Text;
                txtPaidAmount.Text = "0";
                txtDeedFee.Text = "0";
            }
        }

        protected void btnCreateInstallment_Click(object sender, EventArgs e)
        {
            if (cmCustomerName.SelectedValue == "")
            {
                lblMessage.Text = "Select Customer.";
            }
            else if (lblNetAmount.Text == "")
            {
                lblMessage.Text = "Amount should be Zero.";
            }
            else if (cmInstallment.SelectedValue == "")
            {
                lblMessage.Text = "Select Installment.";
            }
            else
            {

            }
        }
        protected void btnSaveInstallment_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                for (int i = 0; i < dtInstallment.Rows.Count; i++)
                {
                    cmd = new SqlCommand("Sp_Sales", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 17;
                    //cmd.Parameters.Add("@rowid", SqlDbType.Int).Value = dtInstallment.Rows[i]["rowid"].ToString();
                    cmd.Parameters.Add("@CustId", SqlDbType.Int).Value = cmCustomerName.SelectedValue;
                    cmd.Parameters.Add("@SalesId", SqlDbType.Int).Value = txtSalesID.Text;
                    cmd.Parameters.Add("@Due", SqlDbType.Decimal).Value = Convert.ToDecimal(lblDueAmount.Text);
                    cmd.Parameters.Add("@InstallNo", SqlDbType.Int).Value = dtInstallment.Rows[i]["InstallNo"].ToString();
                    cmd.Parameters.Add("@InstallDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInstallment.Rows[i]["InstallDate"]);
                    decimal instalamt = Convert.ToDecimal(dtInstallment.Rows[i]["InstallAmt"]);
                    cmd.Parameters.Add("@InstallAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(dtInstallment.Rows[i]["InstallAmt"]);
                    cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = AppEnv.Current.p_UserName.ToString();
                    cmd.ExecuteNonQuery();
                    lblMessageInstallment.Text = "Installment Details Saved Successfully...";
                }
                rwInstallment.VisibleOnPageLoad = false;
                con.Close();
            }
            catch (Exception ex)
            {
                lblMessageInstallment.Text = ex.Message.ToString();
            }
        }
        protected void btnCalculateInstallment_Click(object sender, EventArgs e)
        {
            dtInstallment.Clear();

            for (int i = 1; i <= Convert.ToInt32(cmInstallment.SelectedValue); i++)
            {
                DataRow newRow = this.dtInstallment.NewRow();
                newRow["rowid"] = this.dtInstallment.Rows.Count + 1;
                newRow["CustId"] = cmCustomerName.SelectedValue;
                newRow["InstallNo"] = i;
                newRow["TotalAmount"] = lblNetAmount.Text;
                newRow["InstallDate"] = Convert.ToDateTime(dpSalesDt.SelectedDate).AddMonths(i);
                newRow["InstallAmt"] = (Convert.ToDecimal(lblDueAmount.Text) / Convert.ToDecimal(cmInstallment.SelectedValue));
                //newRow["track_id"] = Convert.ToDecimal(txtEachFloorHeight.Text);
                this.dtInstallment.Rows.Add(newRow);
                this.dtInstallment.AcceptChanges();
            }
            rgInstallment.Rebind();

            rwInstallment.VisibleOnPageLoad = true;
        }

        protected void rgInstallment_EditCommand(object sender, GridCommandEventArgs e)
        {

        }
        protected void rgInstallment_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }
        protected void rgInstallment_ItemUpdated(object sender, GridUpdatedEventArgs e)
        {

        }
        protected void rgInstallment_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgInstallment.DataSource = this.dtInstallment;
        }
        protected void rgInstallment_UpdateCommand(object sender, GridCommandEventArgs e)
        {

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            rwInstallment.VisibleOnPageLoad = false;
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
                if (txtSalesID.Text == "")
                {
                    lblMessage.Text = "Select Sales ID";
                }
                else if (dtSalesWithBarcode.Rows.Count==0)
                {
                    lblMessage.Text = "Select Items for Specific Sales ID.";
                }
                else
                {
                    cmd = new SqlCommand("Sp_Sales", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 3;
                    cmd.Parameters.Add("@SalesId", SqlDbType.Int).Value = txtSalesID.Text;
                    cmd.Parameters.Add("@CustId", SqlDbType.NVarChar).Value = cmCustomerName.SelectedValue;
                    cmd.Transaction = myTran;
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < dtSalesWithBarcode.Rows.Count; i++)
                    {
                        cmd = new SqlCommand("Sp_Sales", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 33;
                        cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@Itemcode", SqlDbType.Int).Value = this.dtSalesWithBarcode.Rows[i]["ItemCode"].ToString();
                        cmd.Transaction = myTran;
                        cmd.ExecuteNonQuery();
                    }
                    myTran.Commit();
                    con.Close();

                    //EnableControl(false);
                    //ClearControlPartial();
                    //ButtonControl("L");
                    ClearControl();
                    this.dtSalesWithBarcode.Clear();
                    RadGrid1.Rebind();
                    txtSalesID.Text = "";
                    ReloadMainGrid();
                    lblMessage.Text = "Delete Successful.";
                }
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

        protected void rgMain_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgMain.DataSource = dtSales;
        }
    }
}