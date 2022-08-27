using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ElectronicsMS
{
    public partial class Home : Page
    {
        SqlConnection con;
        SqlCommand Cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblWelcome.Text = "Welcome : " + AppEnv.Current.p_UserName.ToString();
                AppEnv.Current.p_UserName = AppEnv.Current.p_UserName.ToString();
                DateTime date = DateTime.Today;
                DateTime vdate = Convert.ToDateTime("2030-06-22 17:16:00");
                if (date > vdate)
                {
                    Response.Redirect("~/Validation.aspx");
                }
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                Cmd = new SqlCommand("select * from tblCompany", con);
                Cmd.CommandType = CommandType.Text;
                SqlDataReader Dr;
                Dr = Cmd.ExecuteReader();
                while (Dr.Read())
                {
                    lblCompanyName.Text = Dr["Name"].ToString();
                    Session["Name"] = Dr["Name"].ToString();
                    Session["Address"] = Dr["Address"].ToString();
                    Session["Contact1"] = Dr["Contact1"].ToString();
                    Session["Contact2"] = Dr["Contact2"].ToString();
                    Session["Fax"] = Dr["Fax"].ToString();
                    Session["CompanyLogo"] = Dr["CompanyLogo"].ToString();
                    Session["CompanyMoto"] = Dr["CompanyMoto"].ToString();
                    Session["Email"] = Dr["Email"].ToString();
                    Session["Website"] = Dr["Website"].ToString();
                    Page.Title = Dr["Name"].ToString();
                }
                con.Close();
            }

            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = Convert.ToString(Session.Timeout * 20) + ";url=LogIn.aspx";
            this.Page.Header.Controls.Add(meta);

            DateTime dt = DateTime.Now;
            string Day = dt.Day.ToString();
            string Month = dt.ToString("MMMM");
            string Year = dt.ToString("yyyy");

            string Hour = dt.Hour.ToString();
            string Minute = dt.ToString("mm");
            string Seconds = dt.ToString("ss");
            lblDateTime.Text = Day + " " + Month + "   " + Year + ",   " + Hour + ":" + Minute + ":" + Seconds;
            lblDayName.Text = DateTime.Now.DayOfWeek.ToString();
            LoadIFrame("Forms/Forms/Dashboard.aspx");
        }

        private void LoadIFrame(string src)
        {
            if (RadPane2.FindControl("frame") != null)
            {
                ((HtmlGenericControl)RadPane2.FindControl("frame")).Attributes.Remove("src");
                ((HtmlGenericControl)RadPane2.FindControl("frame")).Attributes.Add("src", src);
            }
            else
            {
                HtmlGenericControl iFrame = new HtmlGenericControl("iframe");
                iFrame.ID = "frame";
                iFrame.Attributes.Add("frameborder", "0");
                iFrame.Attributes.Add("class", "module");
                iFrame.Attributes.Add("style", "width:100%;height:100%;padding:0;");
                iFrame.Attributes.Add("src", src);

                RadPane2.Controls.Add(iFrame);
            }
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            // Label1.Text = Session["admn"].ToString();
        }
        protected void RadButton2_Click(object sender, EventArgs e)
        {
            LoadIFrame("HR/element/newemp.aspx");
            //Response.Redirect("HR/element/newemp.aspx");
        }
        private void LoadUserControl(Telerik.Web.UI.RadPanelItem item)
        {
            Label userControl1 = new Label();
            userControl1.ID = "userControl1";
            userControl1.Text = DateTime.Now.ToString();
            item.Items[1].Controls.Add(userControl1);
        }
        protected void MainMenu_ItemClick1(object sender, Telerik.Web.UI.RadPanelBarEventArgs e)
        {
            //this.LoadUserControl(e.Item);
            RadPanelItem ItemClicked = e.Item; //Response.Write("Server event raised -- you clicked: " + ItemClicked.Text);
            string s = ItemClicked.Text;

            if (s == "Company Info")
            {
                LoadIFrame("Forms/Forms/CompanyInfo.aspx");
            }
            if (s == "Master Data")
            {
                LoadIFrame("Forms/Forms/MasterData.aspx");
            }
            if (s == "Dashboard")
            {
                LoadIFrame("Forms/Forms/Dashboard.aspx");
            }
            if (s == "DB Backup")
            {
                LoadIFrame("Forms/Forms/DBBackup.aspx");
            }
            if (s == "Notifications")
            {
                LoadIFrame("Forms/Forms/Notifications.aspx");
            }
            if (s == "Products")
            {
                LoadIFrame("Forms/Forms/ItemInfo.aspx");
            }
            if (s == "Customers")
            {
                LoadIFrame("Forms/Forms/CustomerInfo.aspx");
            }
            if (s == "Suppliers")
            {
                LoadIFrame("Forms/Forms/SupplierInfo.aspx");
            }
            if (s == "Purchases")
            {
                LoadIFrame("Forms/Forms/Purchase.aspx");
            }
            if (s == "Sales")
            {
                LoadIFrame("Forms/Forms/Sales.aspx");
            }
            if (s == "Payments")
            {
                LoadIFrame("Forms/Forms/Payment.aspx");
            }
            if (s == "Money Received")
            {
                LoadIFrame("Forms/Forms/MoneyReceive.aspx");
            }
            if (s == "Sales Returns")
            {
                LoadIFrame("Forms/Forms/SalesReturn.aspx");
            }
            if (s == "Expenses Entry")
            {
                LoadIFrame("Forms/Forms/Expense.aspx");
            }
            if (s == "Bank Transactions")
            {
                LoadIFrame("Forms/Forms/BankTransaction.aspx");
            }
            if (s == "Emailing")
            {
                LoadIFrame("Forms/Forms/Mailing.aspx");
            }
            if (s == "Price Offer")
            {
                LoadIFrame("Forms/Forms/PriceOffer.aspx");
            }
            if (s == "Opening Stock")
            {
                LoadIFrame("Forms/Forms/OpeningStock.aspx");
            }
            if (s == "Stock Adjustments")
            {
                LoadIFrame("Forms/Forms/StockAdjustments.aspx");
            }
            if (s == "Opening Balance(Cust)")
            {
                LoadIFrame("Forms/Forms/OpeningBalanceCust.aspx");
            }
            if (s == "Opening Balance(Sup)")
            {
                LoadIFrame("Forms/Forms/OpeningBalanceSup.aspx");
            }
            if (s == "Price Setup")
            {
                LoadIFrame("Forms/Forms/PriceSetup.aspx");
            }
            if (s == "Lend/Borrow")
            {
                LoadIFrame("Forms/Forms/LendBorrow.aspx");
            }

            if (s == "Sales (Scan)")
            {
                LoadIFrame("Forms/Forms/Sales.aspx");
            }
            if (s == "Purchase (Scan)")
            {
                LoadIFrame("Forms/Forms/Purchase.aspx");
            }
            if (s == "Inquiry")
            {
                LoadIFrame("Forms/Forms/Inquiry.aspx");
            }


            ///////////////Reports////////////////
            if (s == "Report Manager")
            {
                LoadIFrame("Forms/ReportForms/ReportManager.aspx");
            }
            if (s == "Product")
            {
                LoadIFrame("Forms/ReportForms/rptItem.aspx");
            }
            if (s == "Customer")
            {
                LoadIFrame("Forms/ReportForms/rptCustomer.aspx");
            }
            if (s == "Supplier")
            {
                LoadIFrame("Forms/ReportForms/rptSuppliers.aspx");
            }
            if (s == "Purchase")
            {
                LoadIFrame("Forms/ReportForms/rptPurchase.aspx");
            }
            if (s == "Sale")
            {
                LoadIFrame("Forms/ReportForms/rptSales.aspx");
            }
            if (s == "Payment")
            {
                LoadIFrame("Forms/ReportForms/rptPayment.aspx");
            }
            if (s == "Money Receive")
            {
                LoadIFrame("Forms/ReportForms/rptMoneyReceive.aspx");
            }
            if (s == "Sales Return")
            {
                LoadIFrame("Forms/ReportForms/rptSalesReturn.aspx");
            }
            if (s == "Expense")
            {
                LoadIFrame("Forms/ReportForms/rptExpense.aspx");
            }
            if (s == "Bank Transaction")
            {
                LoadIFrame("Forms/ReportForms/rptBankTransactions.aspx");
            }
            if (s == "All Master Data")
            {
                LoadIFrame("Forms/ReportForms/rptMasterData.aspx");
            }
            if (s == "Stock")
            {
                LoadIFrame("Forms/ReportForms/rptStocks.aspx");
            }
            if (s == "Stock New")
            {
                LoadIFrame("Forms/ReportForms/rptStockNew.aspx");
            }
            if (s == "Profit & Loss")
            {
                LoadIFrame("Forms/ReportForms/rptProfitLoss.aspx");
            }
            if (s == "Halkhata Label")
            {
                LoadIFrame("Forms/ReportForms/rptHalkhataLabel.aspx");
            }
            if (s == "Customer Due List")
            {
                LoadIFrame("Forms/ReportForms/rptCustomerDueList.aspx");
            }
            if (s == "Due List")
            {
                LoadIFrame("Forms/ReportForms/DueList.aspx");
            }
            if (s == "Daily Transactions")
            {
                LoadIFrame("Forms/ReportForms/rptDailyTotalTransaction.aspx");
            }

        }
        protected void RadContextMenu1_ItemClick(object sender, RadMenuEventArgs e)
        {

        }
    }
}