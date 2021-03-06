using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using Telerik.Web.UI;

namespace ElectronicsMS.Forms.ReportForms
{
    public partial class rptPayment : Page
    {
        SqlConnection con;
        SqlCommand Cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void cmCommon_ItemsRequested(object sender, Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                Cmd = new SqlCommand("Sp_Payment", con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 8;
                SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dataRow in dt.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = (string)dataRow["Name"].ToString();
                    item.Value = dataRow["SupplierId"].ToString();

                    string ItemCode = (string)dataRow["SupplierId"].ToString();
                    item.Attributes.Add("SupplierId", ItemCode.ToString());

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
        protected void cmCommon_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
        protected void cmReportType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmReportType.SelectedValue == "Custom Date")
            {
                dpStartDate.SelectedDate = DateTime.Now;
                dpEndDate.SelectedDate = DateTime.Now;
                dpStartDate.Visible = true;
                dpEndDate.Visible = true;
                lblStartDate.Visible = true;
                lblEndDate.Visible = true;
            }
            else if (cmReportType.SelectedValue == "As on Date")
            {
                dpEndDate.SelectedDate = DateTime.Now;
                lblStartDate.Visible = false;
                dpStartDate.Visible = false;
                dpStartDate.SelectedDate = null;

            }
        }
        protected void rbSingle_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void rbAll_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmReportType.SelectedValue == "")
                {
                    lblMessage.Text = "Select Report Type.";
                }
                else
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                    con.Open();

                    if (AppEnv.Current.p_rptSource != null)
                    {
                        AppEnv.Current.p_rptSource.Close();
                        AppEnv.Current.p_rptSource.Dispose();
                    }
                    AppEnv.Current.p_rptSource = new ReportDocument();
                    SqlCommand Cmd;
                    Cmd = new SqlCommand("Sp_Payment", con);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = 10;
                    Cmd.Parameters.Add("@DateOption", SqlDbType.VarChar).Value = cmReportType.SelectedValue;
                    if (cmCommon.SelectedValue != "")
                        Cmd.Parameters.Add("@SupplierId", SqlDbType.VarChar).Value = cmCommon.SelectedValue;
                    if (dpStartDate.SelectedDate != null)
                        Cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dpStartDate.SelectedDate;
                    Cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = dpEndDate.SelectedDate;

                    SqlDataAdapter Dap = new SqlDataAdapter(Cmd);
                    DataTable dt = new DataTable();
                    Dap.Fill(dt);
                    Cmd.Dispose();

                    string tempPath = "";
                    string reportName = "";
                    if (rbSingle.Checked == true && cmCommon.SelectedValue != "")
                    {
                        AppEnv.Current.p_rptObject = "~/Reports/Payment.rpt";
                        tempPath = @System.IO.Path.GetTempPath() + "Payment";
                        reportName = "Payment";
                    }
                    else if (rbAll.Checked == true)
                    {
                        AppEnv.Current.p_rptObject = "~/Reports/Payment.rpt";
                        tempPath = @System.IO.Path.GetTempPath() + "Payment";
                        reportName = "Payment";
                    }

                    AppEnv.Current.p_rptSource.Load(Server.MapPath(AppEnv.Current.p_rptObject.ToString()));
                    AppEnv.Current.p_rptSource.SetDataSource(dt);
                    con.Close();

                    if (dt.Rows.Count > 0)
                    {
                        ((TextObject)AppEnv.Current.p_rptSource.ReportDefinition.Sections["Section5"].ReportObjects["txtUserName"]).Text = AppEnv.Current.p_UserName.ToString();
                        ((TextObject)AppEnv.Current.p_rptSource.ReportDefinition.Sections["Section1"].ReportObjects["txtCompanyName"]).Text = Session["Name"].ToString();
                        ((TextObject)AppEnv.Current.p_rptSource.ReportDefinition.Sections["Section1"].ReportObjects["txtAddress"]).Text = Session["Address"].ToString();
                        ((TextObject)AppEnv.Current.p_rptSource.ReportDefinition.Sections["Section1"].ReportObjects["txtContact"]).Text = Session["Contact1"].ToString();
                        ((TextObject)AppEnv.Current.p_rptSource.ReportDefinition.Sections["Section1"].ReportObjects["txtContact"]).Text = Session["Contact2"].ToString();
                        ((TextObject)AppEnv.Current.p_rptSource.ReportDefinition.Sections["Section1"].ReportObjects["txtDateRange"]).Text = "Payment Info: Date From " + String.Format("{0:dd/MM/yyyy}", dpStartDate.SelectedDate) + " To " + String.Format("{0:dd/MM/yyyy}", dpEndDate.SelectedDate);

                        if (rbtnPdf.Checked == true)
                        {
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
                        }
                        if (rbtnWord.Checked == true)
                        {
                            ViewState["preview"] = "word";
                            Response.Buffer = false;
                            Response.ClearContent();
                            Response.ClearHeaders();

                            ExportFormatType format = ExportFormatType.WordForWindows;
                            //ExportFormatType format = ExportFormatType.ExcelRecord;
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
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }
}