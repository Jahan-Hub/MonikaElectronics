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
    public partial class ReportManager : Page
    {
        SqlConnection con;
        SqlCommand Cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsCallback)
            {

            }
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
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
                SqlCommand Cmd;
                Cmd = new SqlCommand("ShareholderForm", con);
                Cmd.CommandType = CommandType.StoredProcedure;
                if (rbInviCustomer.Checked == true) //individual shareholder
                {
                    if (cmParty.SelectedValue != "")
                    {
                        Cmd.Parameters.Add("@p_OpMode", SqlDbType.VarChar).Value = 1;
                    }
                    else
                    {
                        lblMessage.Text = "Select Shareholder";
                        return;
                    }
                }
                if (rbIndiShareForm.Checked == true) //individual shareholder form
                {
                    if (cmParty.SelectedValue != "")
                    {
                        Cmd.Parameters.Add("@p_OpMode", SqlDbType.VarChar).Value = 1;
                    }
                    else
                    {
                        lblMessage.Text = "Select Shareholder";
                        return;
                    }
                }
                else if (rbAllCustomer.Checked == true && cmParty.SelectedValue == "") //all shareholder
                {
                    Cmd.Parameters.Add("@p_OpMode", SqlDbType.VarChar).Value = 2;
                }
                else if (rbIndiAcc.Checked == true) //individual accounts
                {
                    if (cmParty.SelectedValue != "")
                    {
                        Cmd.Parameters.Add("@p_OpMode", SqlDbType.VarChar).Value = 3;
                    }
                    else
                    {
                        lblMessage.Text = "Select Shareholder";
                        return;
                    }
                }
                else if (rbAllAcc.Checked == true && cmParty.SelectedValue == "") //all accounts
                {
                    Cmd.Parameters.Add("@p_OpMode", SqlDbType.VarChar).Value = 4;
                }
                if (cmParty.SelectedValue != "")
                    Cmd.Parameters.Add("@p_SupSufix", SqlDbType.Int).Value = Convert.ToInt32(cmParty.SelectedValue);
                SqlDataAdapter Dap = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                Dap.Fill(dt);
                Cmd.Dispose();

                string tempPath = "";
                string reportName = "";
                if (rbIndiShareForm.Checked == true && cmParty.SelectedValue != "")
                {
                    AppEnv.Current.p_rptObject = "~/Reports/ShareholderForm.rpt";
                    tempPath = @System.IO.Path.GetTempPath() + "ShareholderForm";
                    reportName = "ShareholderForm";
                }
                else if (rbInviCustomer.Checked == true || rbAllCustomer.Checked == true)
                {
                    AppEnv.Current.p_rptObject = "~/Reports/Shareholder.rpt";
                    tempPath = @System.IO.Path.GetTempPath() + "ShareholderInfo";
                    reportName = "ShareholderInfo";
                }
                else if (rbIndiAcc.Checked == true || rbAllAcc.Checked == true)
                {
                    AppEnv.Current.p_rptObject = "~/Reports/Accounts.rpt";
                    tempPath = @System.IO.Path.GetTempPath() + "ShareholderAccounts";
                    reportName = "ShareholderAccountsInfo";
                }
                AppEnv.Current.p_rptSource.Load(Server.MapPath(AppEnv.Current.p_rptObject.ToString()));
                AppEnv.Current.p_rptSource.SetDataSource(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
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
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void rbAllShareholder_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAllCustomer.Checked == true)
            {
                cmParty.Text = "";
                cmParty.SelectedValue = "";
            }
        }
        protected void rbAllAcc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAllAcc.Checked == true)
            {
                cmParty.Text = "";
                cmParty.SelectedValue = "";
            }
        }
        protected void cmEmployee_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rbAllAcc.Checked == true)
            {
                rbAllAcc.Checked = false;
                rbIndiAcc.Checked = true;
            }
            else if (rbAllCustomer.Checked == true)
            {
                rbAllCustomer.Checked = false;
                rbInviCustomer.Checked = true;
            }
        }
        protected void cmParty_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
        protected void cmParty_ItemsRequested(object sender, Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                Cmd = new SqlCommand("Sp_ReportManager", con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 1;
                SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                //Session["DtCust"] = dt;
                foreach (DataRow dataRow in dt.Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = (string)dataRow["Name"];
                    item.Value = dataRow["CustId"].ToString();

                    string groupname = (string)dataRow["FatherName"].ToString();
                    item.Attributes.Add("FatherName", groupname.ToString());

                    cmParty.Items.Add(item);
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