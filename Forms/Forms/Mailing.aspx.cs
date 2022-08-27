using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ElectronicsMS.Forms.Forms
{
    public partial class Mailing : Page
    {
        SqlConnection con;
        SqlCommand Cmd = new SqlCommand();
        public void EnableControl(bool ec)
        {
            txtBody.Enabled = ec;
            txtHost.Enabled = ec;
            txtPort.Enabled = ec;
            txtSubject.Enabled = ec;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //var p = (from d in db.tblEmails
                    //         select d).ToList();
                    //string filepath = p[0].FILEPATH;
                    //Session["filepath"] = p[0].FILEPATH;
                    //string SMTPHOST = p[0].SMTPHOST;
                    //Session["SMTPHOST"] = p[0].SMTPHOST;
                    //string PORT = p[0].PORT.ToString();
                    //Session["PORT"] = p[0].PORT;
                    //Session["fromemail"] = p[0].FROMEMAILID;
                    //string subject = p[0].SUBJECT;
                    //Session["subject"] = p[0].SUBJECT;
                    //string body = p[0].BODY;
                    //Session["body"] = "<pre>" + p[0].BODY + "<pre/>";
                    //string emailpwd = p[0].EMAILPWD;
                    //Session["emailpwd"] = p[0].EMAILPWD;
                    //string SSLSTATUS = p[0].SSLSTATUS.ToString();
                    //Session["SSLSTATUS"] = p[0].SSLSTATUS;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
                RadWindow1.VisibleOnPageLoad = false;
                txtRecipients.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
            }
        }
        public void SendMailMessage(string from, string to, string cc, string bcc, string subject, string body, string atch, bool IsHTML)
        {
            System.Net.Mail.MailMessage sms = new System.Net.Mail.MailMessage();
            sms.From = new MailAddress(from);
            sms.To.Add(new MailAddress(to));
            if (cc != null && cc != "")
                sms.CC.Add(new MailAddress(cc));
            if (bcc != null && bcc != "")
                sms.Bcc.Add(new MailAddress(bcc));
            sms.Subject = subject;
            sms.Body = body;
            sms.IsBodyHtml = IsHTML;
            //string FileEx1 ="";
            //string FileEx2 ="";
            //if(FileUpload1.HasFile)
            //    FileEx1 = Path.GetExtension(FileUpload1.PostedFile.FileName).Substring(1);
            //if(FileUpload2.HasFile)
            //    FileEx2 = Path.GetExtension(FileUpload2.PostedFile.FileName).Substring(1);
            //if (FileUpload1.HasFile==true && (FileEx1=="pdf" || FileEx1=="jpg" || FileEx1=="xlsx" || FileEx1=="pptx"))
            //{
            if (FileUpload1.HasFile)
            {
                string fname1 = FileUpload1.PostedFile.FileName.ToString();
                file1 = Session["filepath"] + fname1; //
                sms.Attachments.Add(new Attachment(file1));
            }
            //}
            //if (FileUpload2.HasFile == true && (FileEx2 == "pdf" || FileEx2 == "jpg" || FileEx2 == "xlsx" || FileEx2 == "pptx"))
            //{
            if (FileUpload2.HasFile)
            {
                string fname2 = FileUpload2.PostedFile.FileName.ToString();
                file2 = Session["filepath"] + fname2; //
                sms.Attachments.Add(new Attachment(file2));
            }
            //}
            sms.Priority = System.Net.Mail.MailPriority.Normal;
            sms.SubjectEncoding = System.Text.Encoding.UTF8;
            SmtpClient client = new SmtpClient(Session["SMTPHOST"].ToString(), Convert.ToInt32(Session["PORT"].ToString()));
            client.EnableSsl = true;//Convert.ToBoolean(0);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(Session["fromemail"].ToString(), Session["emailpwd"].ToString());
            client.Send(sms);
            sms.Dispose();
        }
        string file1 = "";
        string file2 = "";
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            if (txtRecipients.Text == "")
            {
                lblMessage.Text = "Select Recipient.";
            }
            else if (txtSubject.Text == "")
            {
                lblMessage.Text = "Subject can not be blank.";
            }
            else if (txtBody.Text == "")
            {
                lblMessage.Text = "Body can not be blank.";
            }
            else
            {
                try
                {
                    for (int i = 0; i < SelectedRecipient.Rows.Count; i++)
                    {
                        SendMailMessage(Session["fromemail"].ToString(), SelectedRecipient.Rows[i]["Email"].ToString(), "", "", txtSubject.Text, "<pre>" + txtBody.Text + "<pre/>", (file1 + file2), true);
                        lblMessage.Text = "Email Sent Successful.";
                    }
                    btnSearch.Enabled = true;
                    txtRecipients.Enabled = false;
                    btnEdit.Enabled = false;
                    btnSave.Enabled = false;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //var k = (from c in db.tblEmails
                //         select c).First();
                //txtBody.Text = k.BODY;
                //txtHost.Text = k.SMTPHOST;
                //txtPort.Text = k.PORT.ToString();
                //txtSubject.Text = k.SUBJECT;

                btnSearch.Enabled = false;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EnableControl(true);
            btnEdit.Enabled = false; ;
            btnSave.Enabled = true;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //var k = (from c in db.tblEmails
                //         select c).First();
                //k.MODULEID = 1001;
                //k.UIID = 1;
                //k.RPTCATEGORY = "Email";
                //k.USERNAME = "Jahan";
                //k.SUBJECT = txtSubject.Text;
                //k.BODY = txtBody.Text;
                //k.FILEPATH = @"C:\Email\";
                //k.SMTPHOST = txtHost.Text;
                //k.PORT = Convert.ToInt32(txtPort.Text);
                //k.SSLSTATUS = true;
                //db.SaveChanges();
                //EnableControl(false);

                //btnEdit.Enabled = false; ;
                //btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
            }
        }
        public DataTable SelectedRecipient
        {
            get
            {
                object obj = this.Session["SelectedRecipient"];
                if (obj != null)
                {
                    return (DataTable)obj;
                }
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("rowid", typeof(Int16));
                dt1.Columns.Add("CustId", typeof(string));
                dt1.Columns.Add("Email", typeof(string));
                dt1.Columns.Add("Name", typeof(string));
                dt1.Columns.Add("selected", typeof(string));
                dt1.PrimaryKey = new DataColumn[] { dt1.Columns["rowid"] };
                this.Session["SelectedRecipient"] = dt1;
                return SelectedRecipient;
            }
        }
        public DataTable TagRecipient
        {
            get
            {
                object obj = this.Session["TagRecipient"];
                if (obj != null)
                {
                    return (DataTable)obj;
                }
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("rowid", typeof(Int16));
                dt1.Columns.Add("CustId", typeof(string));
                dt1.Columns.Add("Email", typeof(string));
                dt1.Columns.Add("Name", typeof(string));
                dt1.Columns.Add("selected", typeof(string));
                dt1.PrimaryKey = new DataColumn[] { dt1.Columns["rowid"] };
                this.Session["TagRecipient"] = dt1;
                return TagRecipient;
            }
        }
        protected void btnRecipients_Click(object sender, EventArgs e)
        {
            try
            {
                TagRecipient.Clear();
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                var commandStr = "if not exists (select name from sysobjects where name = 'tblRecipient') CREATE TABLE tblRecipient(CustId int,Email varchar(150),Name varchar(150),selected varchar(1))";
                using (SqlCommand command = new SqlCommand(commandStr, con))
                    command.ExecuteNonQuery();
                con.Close();

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                var sqlStr = " delete from tblRecipient INSERT INTO tblRecipient (CustId, Name,Email)SELECT CustId, Name,Email FROM tblCustomers WHERE Email<>''";
                using (SqlCommand command = new SqlCommand(sqlStr, con))
                    command.ExecuteNonQuery();
                con.Close();

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                Cmd = new SqlCommand("select CustId, Name,Email from tblCustomers", con);
                SqlDataReader Dr;
                Dr = Cmd.ExecuteReader();
                while (Dr.Read())
                {
                    DataRow newRow = this.TagRecipient.NewRow();
                    newRow["rowid"] = this.TagRecipient.Rows.Count + 1;
                    newRow["CustId"] = Dr["CustId"].ToString();
                    newRow["Email"] = Dr["Email"].ToString();
                    newRow["Name"] = Dr["Name"].ToString();
                    this.TagRecipient.Rows.Add(newRow);
                    this.TagRecipient.AcceptChanges();
                }
                Cmd.Dispose();
                con.Close();
                RGSelect.Rebind();
                RadWindow1.VisibleOnPageLoad = true;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void RGSelect_EditCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }
        protected void RGSelect_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {

        }
        protected void RGSelect_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RGSelect.DataSource = this.TagRecipient;
        }
        protected void chkRecipient_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                foreach (GridDataItem dataItem in RGSelect.Items)
                {
                    CheckBox chk = (CheckBox)dataItem.FindControl("chkRecipient");
                    bool status = chk.Checked;
                    if (status)
                    {
                        Int32 strtxt = Convert.ToInt32(dataItem["CustId"].Text);
                        SqlCommand sqlcmd = new SqlCommand();
                        sqlcmd = new SqlCommand("update tblRecipient set selected ='Y' where CustId =" + strtxt + "", con);
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.Dispose();
                    }
                    else
                    {
                        Int32 strtxt = Convert.ToInt32(dataItem["CustId"].Text);
                        SqlCommand sqlcmd = new SqlCommand();
                        //sqlcmd = new SqlCommand("update " + ImpActPlus.AppEnv.Current.p_TempTableName1 + " set SELECTED='N' where " + ViewState["KeyFld"].ToString() + "='" + strtxt + "'", SqlCon);
                        sqlcmd = new SqlCommand("update tblRecipient set  selected ='N' where CustId =" + strtxt + "", con);
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.Dispose();
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedRecipient.Clear();
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                Cmd = new SqlCommand("select * from tblRecipient where selected='Y'", con);
                SqlDataReader Dr;
                Dr = Cmd.ExecuteReader();
                while (Dr.Read())
                {
                    DataRow newRow = this.SelectedRecipient.NewRow();
                    newRow["rowid"] = this.SelectedRecipient.Rows.Count + 1;
                    newRow["CustId"] = Dr["CustId"].ToString();
                    newRow["Email"] = Dr["Email"].ToString();
                    newRow["Name"] = Dr["Name"].ToString();
                    this.SelectedRecipient.Rows.Add(newRow);
                    this.SelectedRecipient.AcceptChanges();
                }
                Cmd.Dispose();
                con.Close();
                //RGBillTerm.Rebind();
                //GetPIData(PiNO);
                string a = "";
                for (int i = 0; i < SelectedRecipient.Rows.Count; i++)
                {
                    if (SelectedRecipient.Rows.Count > 0)
                    {
                        a += SelectedRecipient.Rows[i]["Email"].ToString() + ", ";
                    }
                }
                txtRecipients.Text = a;
                RadWindow1.VisibleOnPageLoad = false;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void btnExit_Click(object sender, EventArgs e)
        {
            RadWindow1.VisibleOnPageLoad = false;
        }

        public void HelpMethod()
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                SqlCommand Cmd;
                Cmd = new SqlCommand("select * from tblCustomers order by Name", con);
                Cmd.CommandType = CommandType.Text;
                SqlDataAdapter Dap = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                Dap.Fill(dt);
                Cmd.Dispose();

                if (AppEnv.Current.p_rptSource != null)
                {
                    AppEnv.Current.p_rptSource.Close();
                    AppEnv.Current.p_rptSource.Dispose();
                }
                AppEnv.Current.p_rptSource = new ReportDocument();

                AppEnv.Current.p_rptObject = "~/Reports/DocOffer.rpt";
                AppEnv.Current.p_rptSource.Load(Server.MapPath(AppEnv.Current.p_rptObject.ToString()));
                AppEnv.Current.p_rptSource.SetDataSource(dt);

                string reportName = txtSubject.Text;
                ViewState["reportName"] = reportName;
                for (int i = 0; i < SelectedRecipient.Rows.Count; i++)
                {
                    if (System.IO.File.Exists(Session["filepath"] + reportName + ".pdf"))
                    {
                        System.IO.File.Delete(Session["filepath"] + reportName + ".pdf");
                    }
                    AppEnv.Current.p_rptSource.ExportToDisk(ExportFormatType.PortableDocFormat, Session["filepath"] + reportName + ".pdf");
                    ClientScript.RegisterStartupScript(this.Page.GetType(), "popupOpener", "", true);
                    SendMailMessage(Session["fromemail"].ToString(), SelectedRecipient.Rows[i]["Email"].ToString(), "", "", txtSubject.Text, txtBody.Text, "", true);
                    if (System.IO.File.Exists(Session["filepath"] + reportName + ".pdf"))
                    {
                        System.IO.File.Delete(Session["filepath"] + reportName + ".pdf");
                    }
                }
                btnSearch.Enabled = true;
                txtRecipients.Enabled = false;
                btnEdit.Enabled = false;
                btnRecipients.Enabled = false;
                btnSave.Enabled = false;
                btnSendMail.Enabled = false;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void btnGetSampleBody_Click(object sender, EventArgs e)
        {
            string body = " Line 1 " + "\n"
            + "Line 2 " + "\n"
            + "Line 3 " + "\n"
            + "Line 4 " + "\n"
            + " ";
            txtBody.Text = body;//.Replace("\n", "<br/>");
        }
    }
}
