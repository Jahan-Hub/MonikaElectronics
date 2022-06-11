using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;

namespace ElectronicsMS.Forms
{
    public partial class rptProfitLoss : Page
    {
        SqlConnection con;
        SqlCommand Cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(dpStartDate.SelectedDate);
            int year = date.Year;
            int month = date.Month;

            string startDay = new DateTime(year, month, 1).DayOfWeek.ToString();
            string endDay = new DateTime(year, month, DateTime.DaysInMonth(year, month)).DayOfWeek.ToString();

            DateTime checkFirstDate = new DateTime(year, month, 1);
            DateTime checkLastDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();

                if (AppEnv.Current.p_rptSource != null)
                {
                    AppEnv.Current.p_rptSource.Close();
                    AppEnv.Current.p_rptSource.Dispose();
                }
                AppEnv.Current.p_rptSource = new ReportDocument();

                Cmd = new SqlCommand("Sp_ReportManager", con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 4;
                Cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dpStartDate.SelectedDate;
                Cmd.Parameters.Add("@Todate", SqlDbType.DateTime).Value = dpEndDate.SelectedDate;

                SqlDataAdapter adpt = new SqlDataAdapter(Cmd);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                Cmd.Dispose();

                DataTable dtRpt = ds.Tables[0];
                DataTable dtRptSub = ds.Tables[1];
                DataTable dtRptSub2 = ds.Tables[2];
                //DataTable dtRptSub3 = ds.Tables[3];

                AppEnv.Current.p_rptObject = "~/Reports/ProfitLoss.rpt";
                AppEnv.Current.p_rptSource.Load(Server.MapPath(AppEnv.Current.p_rptObject.ToString()));

                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

                AppEnv.Current.p_rptSource.SetDataSource(dtRptSub2);
                //AppEnv.Current.p_rptSource.Subreports[1].SetDataSource(dtRptSub2);
                //AppEnv.Current.p_rptSource.SetDataSource(dtRptSub2);
                string tempPath = @System.IO.Path.GetTempPath() + "ProfitLoss";
                con.Close();

                if (dtRptSub.Rows.Count > 0)
                {
                    decimal Expense = Convert.ToDecimal(dtRpt.Rows[0]["NetAmountExpense"].ToString());
                    decimal Purchase = 0;
                    decimal Sales = 0;
                    for (int i = 0; i < dtRptSub.Rows.Count; i++)
                    {
                        Purchase += Convert.ToDecimal(dtRptSub.Rows[i]["NetAmountPurchase"].ToString());
                        Sales = +Convert.ToDecimal(dtRptSub.Rows[i]["NetAmountSales"].ToString());
                    }
                    decimal TotalOPEX = Expense + Purchase;
                    decimal GM = Sales-Purchase;
                    decimal GMPercent = (GM / Sales) * 100;
                    decimal NP = Sales - TotalOPEX;
                    decimal NPPercent = (NP / Sales) * 100;

                    ((TextObject)AppEnv.Current.p_rptSource.ReportDefinition.Sections["Section3"].ReportObjects["txtSales"]).Text = Sales.ToString("0.00");
                    ((TextObject)AppEnv.Current.p_rptSource.ReportDefinition.Sections["Section3"].ReportObjects["txtPurchase"]).Text = Purchase.ToString("0.00");
                    ((TextObject)AppEnv.Current.p_rptSource.ReportDefinition.Sections["Section3"].ReportObjects["txtExpense"]).Text = Expense.ToString("0.00");
                    ((TextObject)AppEnv.Current.p_rptSource.ReportDefinition.Sections["Section3"].ReportObjects["txtTotalOPEX"]).Text = TotalOPEX.ToString("0.00");
                    ((TextObject)AppEnv.Current.p_rptSource.ReportDefinition.Sections["Section3"].ReportObjects["txtGM"]).Text = GM.ToString("0.00");
                    ((TextObject)AppEnv.Current.p_rptSource.ReportDefinition.Sections["Section3"].ReportObjects["txtGMPercent"]).Text = GMPercent.ToString("0.00");
                    ((TextObject)AppEnv.Current.p_rptSource.ReportDefinition.Sections["Section3"].ReportObjects["txtNP"]).Text = NP.ToString("0.00");
                    ((TextObject)AppEnv.Current.p_rptSource.ReportDefinition.Sections["Section3"].ReportObjects["txtNPPercent"]).Text = NPPercent.ToString("0.00");

                    ((TextObject)AppEnv.Current.p_rptSource.ReportDefinition.Sections["Section5"].ReportObjects["txtUserName"]).Text = AppEnv.Current.p_UserName.ToString();
                    ((TextObject)AppEnv.Current.p_rptSource.ReportDefinition.Sections["PageHeaderSection1"].ReportObjects["txtFromToDate"]).Text = "From Date " + String.Format("{0:dd/MM/yyyy}",dpStartDate.SelectedDate) + " To " +  String.Format("{0:dd/MM/yyyy}",dpEndDate.SelectedDate);

                    if (rbtnPdf.Checked == true)
                    {
                        ViewState["preview"] = "pdf";
                        Response.Buffer = false;
                        Response.ClearContent();
                        Response.ClearHeaders();

                        ExportFormatType format = ExportFormatType.PortableDocFormat;
                        string reportName = "Profit&Loss";
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
                    }
                    if (rbtnWord.Checked == true)
                    {
                        ViewState["preview"] = "word";
                        Response.Buffer = false;
                        Response.ClearContent();
                        Response.ClearHeaders();

                        ExportFormatType format = ExportFormatType.WordForWindows;
                        //ExportFormatType format = ExportFormatType.ExcelRecord;
                        string reportName = "Profit&Loss";
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
                    }
                    if (rbtnExcel.Checked == true)
                    {
                        ViewState["preview"] = "word";
                        Response.Buffer = false;
                        Response.ClearContent();
                        Response.ClearHeaders();

                        ExportFormatType format = ExportFormatType.Excel;
                        string reportName = "Profit&Loss";
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
                    }

                    if (rbtnCrystal.Checked == true)
                    {
                        string URL = "~/CRpreview.aspx";
                        URL = Page.ResolveClientUrl(URL);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "onclick", "javascript:window.open('" + URL + "','_blank','height=700,width=1200,toolbar=no,location=no, directories=no,status=no,menubar=no,scrollbars=no,resizable=no');", true);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "onclick", "javascript:window.open('" + URL + "','_blank','height=700,width=1200,toolbar=yes,location=yes, directories=yes,status=yes,menubar=yes,scrollbars=yes,resizable=yes');", true);  //all yes
                    }
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
        private void GetMonthPeriodCode()
        {
            //int y = dpStartDate.SelectedDate.Value.Year;
            //string m = dpEffectiveTo.SelectedDate.Value.Month.ToString();
            //if (m.Length == 1)
            //{
            //    string c = (y + "" + "0" + m + "" + 1).ToString();
            //    hdfcode.Value = c;
            //}
            //else
            //{
            //    string c = (y + "" + "" + m + "" + 1).ToString();
            //    hdfcode.Value = c;
            //}
        }
        protected void cmReportType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmReportType.SelectedValue == "Custom Date")
            {
                dpStartDate.SelectedDate = DateTime.Now;
                dpEndDate.SelectedDate = DateTime.Now;
                dpEndDate.Visible = true;
                lblEndDate.Visible = true;
            }
            else if (cmReportType.SelectedValue == "As on Date")
            {
                dpStartDate.SelectedDate = DateTime.Now;
                dpEndDate.Visible = false;
                lblEndDate.Visible = false;
            }
        }
    }
}