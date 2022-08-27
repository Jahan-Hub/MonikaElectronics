using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using Telerik.Web.UI;

namespace ElectronicsMS.Forms.Forms
{
    public partial class Inquiry : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void dpStartDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            ReloadMainGrid();
        }
        protected void dpEndDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            ReloadMainGrid();
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (cmQueryType.SelectedValue == "Purchase")
            {
                rgPurchase.ExportSettings.OpenInNewWindow = true;
                rgPurchase.MasterTableView.ExportToPdf();
            }
            if (cmQueryType.SelectedValue == "Sales")
            {
                rgSales.ExportSettings.OpenInNewWindow = true;
                rgSales.MasterTableView.ExportToPdf();
            }
            if (cmQueryType.SelectedValue == "Payment")
            {
                rgPayment.ExportSettings.OpenInNewWindow = true;
                rgPayment.MasterTableView.ExportToPdf();
            }
            if (cmQueryType.SelectedValue == "Money Receive")
            {
                rgMoneyReceive.ExportSettings.OpenInNewWindow = true;
                rgMoneyReceive.MasterTableView.ExportToPdf();
            }
            if (cmQueryType.SelectedValue == "Expense")
            {
                rgExpense.ExportSettings.OpenInNewWindow = true;
                rgExpense.MasterTableView.ExportToPdf();
            }
            if (cmQueryType.SelectedValue == "Lend & Borrow")
            {
                rgLendBorrow.ExportSettings.OpenInNewWindow = true;
                rgLendBorrow.MasterTableView.ExportToPdf();
            }
            if (cmQueryType.SelectedValue == "Bank Transaction")
            {
                rgBankTransaction.ExportSettings.OpenInNewWindow = true;
                rgBankTransaction.MasterTableView.ExportToPdf();
            }
        }

        decimal sumAmount = 0;
        decimal sumPaid = 0;
        decimal sumDue = 0;
        protected void rgPurchase_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem dataItem = e.Item as GridDataItem;
                    sumAmount += Convert.ToDecimal(dataItem["NetAmount"].Text);
                    sumPaid += Convert.ToDecimal(dataItem["Paid"].Text);
                    sumDue += Convert.ToDecimal(dataItem["Due"].Text);
                }
                else if (e.Item is GridFooterItem)
                {
                    GridFooterItem footerItem = e.Item as GridFooterItem;
                    footerItem["NetAmount"].Text = sumAmount.ToString();
                    footerItem["Paid"].Text = sumPaid.ToString();
                    footerItem["Due"].Text = sumDue.ToString();
                    footerItem["SupplierName"].Text = "Total : ";
                    footerItem.BackColor = System.Drawing.Color.LightGray;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void rgSales_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem dataItem = e.Item as GridDataItem;
                    sumAmount += Convert.ToDecimal(dataItem["NetAmount"].Text);
                    sumPaid += Convert.ToDecimal(dataItem["Paid"].Text);
                    sumDue += Convert.ToDecimal(dataItem["Balance"].Text);
                }
                else if (e.Item is GridFooterItem)
                {
                    GridFooterItem footerItem = e.Item as GridFooterItem;
                    footerItem["NetAmount"].Text = sumAmount.ToString();
                    footerItem["Paid"].Text = sumPaid.ToString();
                    footerItem["Balance"].Text = sumDue.ToString();
                    footerItem["CustomerName"].Text = "Total : ";
                    footerItem.BackColor = System.Drawing.Color.LightGray;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void rgPayment_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem dataItem = e.Item as GridDataItem;
                    sumDue += Convert.ToDecimal(dataItem["PayAmount"].Text);
                }
                else if (e.Item is GridFooterItem)
                {
                    GridFooterItem footerItem = e.Item as GridFooterItem;
                    footerItem["PayAmount"].Text = sumDue.ToString();
                    footerItem["SupplierName"].Text = "Total : ";
                    footerItem.BackColor = System.Drawing.Color.LightGray;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void rgMoneyReceive_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem dataItem = e.Item as GridDataItem;
                    sumDue += Convert.ToDecimal(dataItem["ReceiveAmount"].Text);
                }
                else if (e.Item is GridFooterItem)
                {
                    GridFooterItem footerItem = e.Item as GridFooterItem;
                    footerItem["ReceiveAmount"].Text = sumDue.ToString();
                    footerItem["CustomerName"].Text = "Total : ";
                    footerItem.BackColor = System.Drawing.Color.LightGray;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void rgExpense_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem dataItem = e.Item as GridDataItem;
                    sumDue += Convert.ToDecimal(dataItem["Amount"].Text);
                }
                else if (e.Item is GridFooterItem)
                {
                    GridFooterItem footerItem = e.Item as GridFooterItem;
                    footerItem["Amount"].Text = sumDue.ToString();
                    footerItem["HandedTo"].Text = "Total : ";
                    footerItem.BackColor = System.Drawing.Color.LightGray;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void rgIncome_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem dataItem = e.Item as GridDataItem;
                    sumDue += Convert.ToDecimal(dataItem["Amount"].Text);
                }
                else if (e.Item is GridFooterItem)
                {
                    GridFooterItem footerItem = e.Item as GridFooterItem;
                    footerItem["Amount"].Text = sumDue.ToString();
                    footerItem["IncomeSourceName"].Text = "Total : ";
                    footerItem.BackColor = System.Drawing.Color.LightGray;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        decimal sumLend = 0;
        decimal sumBorrow = 0;
        protected void rgLendBorrow_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem dataItem = e.Item as GridDataItem;
                    sumLend += Convert.ToDecimal(dataItem["Lend"].Text);
                    sumBorrow += Convert.ToDecimal(dataItem["Borrow"].Text);
                    sumDue += Convert.ToDecimal(dataItem["Amount"].Text);
                }
                else if (e.Item is GridFooterItem)
                {
                    GridFooterItem footerItem = e.Item as GridFooterItem;
                    footerItem["Lend"].Text = sumLend.ToString();
                    footerItem["Borrow"].Text = sumBorrow.ToString();
                    footerItem["Amount"].Text = (sumLend - sumBorrow).ToString();
                    footerItem["CustomerName"].Text = "Total : ";
                    footerItem.BackColor = System.Drawing.Color.LightGray;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        decimal sumDeposit = 0;
        decimal sumWithdraw = 0;
        protected void rgBankTransaction_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem dataItem = e.Item as GridDataItem;
                    sumDeposit += Convert.ToDecimal(dataItem["Deposit"].Text);
                    sumWithdraw += Convert.ToDecimal(dataItem["Withdraw"].Text);
                    sumDue += Convert.ToDecimal(dataItem["Amount"].Text);
                }
                else if (e.Item is GridFooterItem)
                {
                    GridFooterItem footerItem = e.Item as GridFooterItem;
                    footerItem["Deposit"].Text = sumDeposit.ToString();
                    footerItem["Withdraw"].Text = sumWithdraw.ToString();
                    footerItem["Amount"].Text = sumDue.ToString();
                    footerItem["BankName"].Text = "Total : ";
                    footerItem.BackColor = System.Drawing.Color.LightGray;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void ReloadMainGrid()
        {
            if (cmQueryType.SelectedValue != "" && dpStartDate.SelectedDate != null && dpEndDate.SelectedDate != null)
            {
                DataTable dt = new DataTable();
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_Inquiry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 1;
                cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar).Value = cmQueryType.SelectedValue;
                if (cmCommon.SelectedValue != "")
                    cmd.Parameters.Add("@CommonId", SqlDbType.NVarChar).Value = cmCommon.SelectedValue;
                if (dpStartDate.SelectedDate != null)
                    cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dpStartDate.SelectedDate;
                if (dpEndDate.SelectedDate != null)
                    cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = dpEndDate.SelectedDate;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                dt = ds.Tables[0];
                if (cmQueryType.SelectedValue == "Purchase")
                {
                    rgPurchase.DataSource = dt;
                    rgPurchase.DataBind();

                    rgSales.DataSource = null;
                    rgMoneyReceive.DataSource = null;
                    rgPayment.DataSource = null;
                    rgExpense.DataSource = null;
                    rgLendBorrow.DataSource = null;
                    rgBankTransaction.DataSource = null;

                    rgSales.DataBind();
                    rgMoneyReceive.DataBind();
                    rgPayment.DataBind();
                    rgExpense.DataBind();
                    rgLendBorrow.DataBind();
                    rgBankTransaction.DataBind();

                    lblCommon.Text = "Supplier";
                }
                if (cmQueryType.SelectedValue == "Sales")
                {
                    rgSales.DataSource = dt;
                    rgSales.DataBind();

                    rgPurchase.DataSource = null;
                    rgMoneyReceive.DataSource = null;
                    rgPayment.DataSource = null;
                    rgExpense.DataSource = null;
                    rgLendBorrow.DataSource = null;
                    rgBankTransaction.DataSource = null;

                    rgPurchase.DataBind();
                    rgMoneyReceive.DataBind();
                    rgPayment.DataBind();
                    rgExpense.DataBind();
                    rgLendBorrow.DataBind();
                    rgBankTransaction.DataBind();

                    lblCommon.Text = "Customer";
                }
                if (cmQueryType.SelectedValue == "Payment")
                {
                    rgPayment.DataSource = dt;
                    rgPayment.DataBind();

                    rgPurchase.DataSource = null;
                    rgMoneyReceive.DataSource = null;
                    rgSales.DataSource = null;
                    rgExpense.DataSource = null;
                    rgLendBorrow.DataSource = null;
                    rgBankTransaction.DataSource = null;

                    rgPurchase.DataBind();
                    rgMoneyReceive.DataBind();
                    rgSales.DataBind();
                    rgExpense.DataBind();
                    rgLendBorrow.DataBind();
                    rgBankTransaction.DataBind();

                    lblCommon.Text = "Supplier";
                }
                if (cmQueryType.SelectedValue == "Money Receive")
                {
                    rgMoneyReceive.DataSource = dt;
                    rgMoneyReceive.DataBind();

                    rgPurchase.DataSource = null;
                    rgPayment.DataSource = null;
                    rgSales.DataSource = null;
                    rgExpense.DataSource = null;
                    rgLendBorrow.DataSource = null;
                    rgBankTransaction.DataSource = null;

                    rgPurchase.DataBind();
                    rgPayment.DataBind();
                    rgSales.DataBind();
                    rgExpense.DataBind();
                    rgLendBorrow.DataBind();
                    rgBankTransaction.DataBind();

                    lblCommon.Text = "Customer";
                }
                if (cmQueryType.SelectedValue == "Expense")
                {
                    rgExpense.DataSource = dt;
                    rgExpense.DataBind();

                    rgPurchase.DataSource = null;
                    rgPayment.DataSource = null;
                    rgSales.DataSource = null;
                    rgMoneyReceive.DataSource = null;
                    rgLendBorrow.DataSource = null;
                    rgBankTransaction.DataSource = null;

                    rgPurchase.DataBind();
                    rgPayment.DataBind();
                    rgSales.DataBind();
                    rgMoneyReceive.DataBind();
                    rgLendBorrow.DataBind();
                    rgBankTransaction.DataBind();

                    lblCommon.Text = "Expense Head";
                }
                if (cmQueryType.SelectedValue == "Income")
                {
                    rgPurchase.DataSource = null;
                    rgPayment.DataSource = null;
                    rgSales.DataSource = null;
                    rgMoneyReceive.DataSource = null;
                    rgExpense.DataSource = null;
                    rgLendBorrow.DataSource = null;
                    rgBankTransaction.DataSource = null;

                    rgPurchase.DataBind();
                    rgPayment.DataBind();
                    rgSales.DataBind();
                    rgMoneyReceive.DataBind();
                    rgExpense.DataBind();
                    rgLendBorrow.DataBind();
                    rgBankTransaction.DataBind();

                    lblCommon.Text = "Income Source";
                }
                if (cmQueryType.SelectedValue == "Lend & Borrow")
                {
                    rgLendBorrow.DataSource = dt;
                    rgLendBorrow.DataBind();

                    rgPurchase.DataSource = null;
                    rgPayment.DataSource = null;
                    rgSales.DataSource = null;
                    rgMoneyReceive.DataSource = null;
                    rgExpense.DataSource = null;
                    rgBankTransaction.DataSource = null;

                    rgPurchase.DataBind();
                    rgPayment.DataBind();
                    rgSales.DataBind();
                    rgMoneyReceive.DataBind();
                    rgExpense.DataBind();
                    rgBankTransaction.DataBind();

                    lblCommon.Text = "Customer";
                }
                if (cmQueryType.SelectedValue == "Bank Transaction")
                {
                    rgBankTransaction.DataSource = dt;
                    rgBankTransaction.DataBind();

                    rgPurchase.DataSource = null;
                    rgPayment.DataSource = null;
                    rgSales.DataSource = null;
                    rgMoneyReceive.DataSource = null;
                    rgExpense.DataSource = null;
                    rgLendBorrow.DataSource = null;

                    rgPurchase.DataBind();
                    rgPayment.DataBind();
                    rgSales.DataBind();
                    rgMoneyReceive.DataBind();
                    rgExpense.DataBind();
                    rgLendBorrow.DataBind();

                    lblCommon.Text = "Bank";
                }
            }
        }
        public void LoadCommon(string queryType)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_Inquiry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 2;
                cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar).Value = cmQueryType.SelectedValue;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dataRow in dt.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = (string)dataRow["Name"].ToString();
                    item.Value = dataRow["Id"].ToString();

                    string Id = (string)dataRow["Id"].ToString();
                    item.Attributes.Add("Id", Id.ToString());

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
        protected void cmQueryType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cmCommon.SelectedValue = "";
            cmCommon.Text = "";
            cmCommon.Items.Clear();
            RadPanelBar1.CollapseAllItems();
            RadPanelItem item = RadPanelBar1.FindItemByText(cmQueryType.Text);
            item.Expanded = true;

            ReloadMainGrid();
        }
        protected void cmCommon_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            cmCommon.SelectedValue = "";
            cmCommon.Text = "";
            cmCommon.Items.Clear();

            LoadCommon(cmQueryType.Text);
        }
        protected void cmCommon_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            LoadCommon(cmQueryType.Text);
            ReloadMainGrid();
        }
    }
}