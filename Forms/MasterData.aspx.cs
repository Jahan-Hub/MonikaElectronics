using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ElectronicsMS.Forms
{
    public partial class MasterData : Page
    {
        ElectronicsMSDBEntities db = new ElectronicsMSDBEntities();
        SqlConnection con;
        SqlCommand cmd;
        public string GetAutoNumber(string fieldName, string tableName)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                string ss = "Select  isnull(Max(" + fieldName + "),0) from " + tableName;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EnableVillage(false);
                btnVillageCancel.Enabled = false;
                btnVillageEdit.Enabled = false;
                btnVillageSave.Enabled = false;
                rgVillage.DataSource = db.tblVillages.ToList();
                rgVillage.DataBind();

                EnableThana(false);
                btnThanaCancel.Enabled = false;
                btnThanaEdit.Enabled = false;
                btnThanaSave.Enabled = false;

                txtDistrictName.Enabled = false;
                btnDistrictCancel.Enabled = false;
                btnDistrictEdit.Enabled = false;
                btnDistrictSave.Enabled = false;

                txtDesignationName.Enabled = false;
                btnDesignationCancel.Enabled = false;
                btnDesignationEdit.Enabled = false;
                btnDesignationSave.Enabled = false;

                txtDepartmentName.Enabled = false;
                btnDepartmentCancel.Enabled = false;
                btnDepartmentEdit.Enabled = false;
                btnDepartmentSave.Enabled = false;

                txtCategoryName.Enabled = false;
                btnCategoryCancel.Enabled = false;
                btnCategoryDelete.Enabled = false;
                btnCategoryEdit.Enabled = false;
                btnCategorySave.Enabled = false;

                txtWeightName.Enabled = false;
                txtWeightDesr.Enabled = false;
                btnWeightCancel.Enabled = false;
                btnWeightEdit.Enabled = false;
                btnWeightSave.Enabled = false;

                txtItemSizeName.Enabled = false;
                btnItemSizeCancel.Enabled = false;
                btnItemSizeEdit.Enabled = false;
                btnItemSizeDelete.Enabled = false;
                btnItemSizeSave.Enabled = false;

                txtPackingName.Enabled = false;
                btnPackingCancel.Enabled = false;
                btnPackingEdit.Enabled = false;
                btnPackingDelete.Enabled = false;
                btnPackingSave.Enabled = false;

                txtCostName.Enabled = false;
                btnCostCancel.Enabled = false;
                btnCostEdit.Enabled = false;
                btnCostDelete.Enabled = false;
                btnCostSave.Enabled = false;

                txtCostElementName.Enabled = false;
                cmCostCenter.Enabled = false;
                btnCostElementCancel.Enabled = false;
                btnCostElementEdit.Enabled = false;
                btnCostElementDelete.Enabled = false;
                btnCostElementSave.Enabled = false;
            }
        }

        protected void btnCompanyNew_Click(object sender, EventArgs e)
        {

        }
        protected void btnSaveCompany_Click(object sender, EventArgs e)
        {

        }
        protected void btnCompanyFind_Click(object sender, EventArgs e)
        {

        }
        protected void btnCompanyEdit_Click(object sender, EventArgs e)
        {

        }
        protected void btnCompanyCancel_Click(object sender, EventArgs e)
        {

        }

        public void EnableVillage(bool ec)
        {
            txtVillageName.Enabled = ec;
            cmThana.Enabled = ec;
        }
        protected void btnVillageNew_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(GetAutoNumber("ViId", "tblVillages"));
            txtVillageCode.Text = max.ToString();
            txtVillageName.Text = "";
            cmThana.Text = "";
            cmThana.SelectedValue = "";

            btnVillageSave.Enabled = true;
            btnVillageCancel.Enabled = true;
            btnVillageFind.Enabled = false;
            btnVillageEdit.Enabled = false;
            btnVillageNew.Enabled = false;
            EnableVillage(true);
            txtVillageName.Focus();

            lblVillageMode.Text = "Save Mode";
            lblVillage.Text = "";
        }
        protected void btnVillageSave_Click(object sender, EventArgs e)
        {
            if (txtVillageCode.Text == "")
            {
                lblVillage.Text = "Village Code can not be blank.";
            }
            else if (txtVillageName.Text == "")
            {
                lblVillage.Text = "Village Name can not be blank.";
            }
            else if (cmThana.SelectedValue == "")
            {
                lblVillage.Text = "Select Thana.";
            }
            else
            {
                if (lblVillageMode.Text == "Save Mode")
                {
                    try
                    {
                        tblVillage tbl = new tblVillage();
                        tbl.ViId = Convert.ToInt32(txtVillageCode.Text);
                        tbl.Name = txtVillageName.Text;
                        tbl.ThanaId = Convert.ToInt32(cmThana.SelectedValue);
                        db.tblVillages.Add(tbl);
                        db.SaveChanges();
                        lblVillage.Text = "Village Name " + "\"" + txtVillageName.Text + "\" Saved Successfully.";
                        lblVillageMode.Text = "";
                        txtVillageCode.Text = "";
                        txtVillageName.Text = "";
                        cmThana.Text = "";
                        cmThana.SelectedValue = "";

                        btnVillageSave.Enabled = false;
                        btnVillageCancel.Enabled = false;
                        btnVillageFind.Enabled = true;
                        btnVillageEdit.Enabled = false;
                        btnVillageNew.Enabled = true;
                        EnableVillage(false);
                        rgVillage.DataSource = db.tblVillages.ToList();
                        rgVillage.DataBind();
                    }
                    catch (Exception ex)
                    {
                        lblVillage.Text = ex.Message;
                    }
                }
                else if (lblVillageMode.Text == "Edit Mode")
                {
                    try
                    {
                        Int32 id = Convert.ToInt32(txtVillageCode.Text);
                        var k = (from c in db.tblVillages
                                 where c.ViId == id
                                 select c).First();
                        k.ViId = Convert.ToInt32(txtVillageCode.Text);
                        k.Name = txtVillageName.Text;
                        k.ThanaId = Convert.ToInt32(cmThana.SelectedValue);
                        db.SaveChanges();

                        lblVillage.Text = "Village Name " + "\"" + txtVillageName.Text + "\" Updated Successfully.";
                        lblVillageMode.Text = "";
                        txtVillageCode.Text = "";
                        txtVillageName.Text = "";
                        cmThana.Text = "";
                        cmThana.SelectedValue = "";

                        btnVillageSave.Enabled = false;
                        btnVillageCancel.Enabled = false;
                        btnVillageFind.Enabled = true;
                        btnVillageEdit.Enabled = false;
                        btnVillageNew.Enabled = true;
                        EnableVillage(false);
                        rgVillage.DataSource = db.tblVillages.ToList();
                        rgVillage.DataBind();
                    }
                    catch (Exception ex)
                    {
                        lblVillage.Text = ex.Message;
                    }
                }
            }
        }
        protected void btnVillageFind_Click(object sender, EventArgs e)
        {
            //if (txtVillageCode.Text == "")
            //{
            //    lblVillage.Text = "Village Code Needed.";
            //}
            //else
            //{
            //    try
            //    {
            //        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            //        string ss = "select v.ViId,v.Name as VName,p.PostId,p.Name as PName from tblVillages v inner join tblPosts p on v.PostId=p.PostId where ViId=" + txtVillageCode.Text;
            //        SqlCommand cmd = new SqlCommand(ss, con);
            //        con.Open();
            //        SqlDataReader dr = cmd.ExecuteReader();
            //        while (dr.Read())
            //        {
            //            txtVillageName.Text = dr["VName"].ToString();
            //            cmPost.SelectedValue = dr["PostId"].ToString();
            //            cmPost.Text = dr["PName"].ToString();
            //        }

            //        lblVillage.Text = "";

            //        btnVillageSave.Enabled = false;
            //        btnVillageCancel.Enabled = true;
            //        btnVillageFind.Enabled = true;
            //        btnVillageEdit.Enabled = true;
            //        btnVillageNew.Enabled = true;
            //        EnableVillage(false);
            //    }
            //    catch (Exception ex)
            //    {
            //        lblVillage.Text = ex.Message;
            //    }
            //}
        }
        protected void btnVillageEdit_Click(object sender, EventArgs e)
        {
            btnVillageSave.Enabled = true;
            btnVillageCancel.Enabled = true;
            btnVillageFind.Enabled = false;
            btnVillageEdit.Enabled = false;
            btnVillageNew.Enabled = false;
            lblVillageMode.Text = "Edit Mode";
            lblVillage.Text = "";
            EnableVillage(true);
        }
        protected void btnVillageCancel_Click(object sender, EventArgs e)
        {
            btnVillageSave.Enabled = false;
            btnVillageCancel.Enabled = false;
            btnVillageFind.Enabled = true;
            btnVillageEdit.Enabled = false;
            btnVillageNew.Enabled = true;
            EnableVillage(false);
            lblVillage.Text = "";
            lblVillageMode.Text = "";

            txtVillageCode.Text = "";
            txtVillageName.Text = "";
        }

        public void EnableThana(bool ec)
        {
            txtThanaName.Enabled = ec;
        }
        protected void btnThanaNew_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(GetAutoNumber("ThanaId", "tblThanas"));
            txtThanaCode.Text = max.ToString();
            txtThanaName.Text = "";

            btnThanaSave.Enabled = true;
            btnThanaCancel.Enabled = true;
            btnThanaFind.Enabled = false;
            btnThanaEdit.Enabled = false;
            btnThanaNew.Enabled = false;
            EnableThana(true);
            txtThanaName.Focus();

            lblThana.Text = "";
            lblThanaMode.Text = "Save Mode";
        }
        protected void btnThanaSave_Click(object sender, EventArgs e)
        {
            if (txtThanaCode.Text == "")
            {
                lblThana.Text = "Thana Code can not be blank.";
            }
            else if (txtThanaName.Text == "")
            {
                lblThana.Text = "Thana Name can not be blank.";
            }
            else if (txtThanaName.Text == "")
            {
                lblThana.Text = "Thana Name can not be blank.";
            }
            else
            {
                if (lblThanaMode.Text == "Save Mode")
                {
                    try
                    {
                        tblThana tbl = new tblThana();
                        tbl.ThanaId = Convert.ToInt32(txtThanaCode.Text);
                        tbl.Name = txtThanaName.Text;
                        db.tblThanas.Add(tbl);
                        db.SaveChanges();
                        cmThana.DataBind();
                        rgThana.Rebind();

                        lblThana.Text = "Thana Name " + "\"" + txtThanaName.Text + "\" Saved Successfully.";
                        lblThanaMode.Text = "";
                        txtThanaCode.Text = "";
                        txtThanaName.Text = "";

                        btnThanaSave.Enabled = false;
                        btnThanaCancel.Enabled = false;
                        btnThanaFind.Enabled = true;
                        btnThanaEdit.Enabled = false;
                        btnThanaNew.Enabled = true;
                        EnableThana(false);
                    }
                    catch (Exception ex)
                    {
                        lblThana.Text = ex.Message;
                    }
                }

                else if (lblThanaMode.Text == "Edit Mode")
                {
                    try
                    {
                        Int32 id = Convert.ToInt32(txtThanaCode.Text);
                        tblThana tbl = new tblThana();
                        var k = (from c in db.tblThanas
                                 where c.ThanaId == id
                                 select c).First();
                        k.Name = txtThanaName.Text;
                        db.SaveChanges();
                        cmThana.DataBind();
                        rgThana.Rebind();

                        lblThana.Text = "Thana Name " + "\"" + txtThanaName.Text + "\" Updated Successfully.";
                        lblThanaMode.Text = "";
                        txtThanaCode.Text = "";
                        txtThanaName.Text = "";

                        btnThanaSave.Enabled = false;
                        btnThanaCancel.Enabled = false;
                        btnThanaFind.Enabled = true;
                        btnThanaEdit.Enabled = false;
                        btnThanaNew.Enabled = true;
                        EnableThana(false);
                    }
                    catch (Exception ex)
                    {
                        lblThana.Text = ex.Message;
                    }
                }
            }
        }
        protected void btnThanaFind_Click(object sender, EventArgs e)
        {
            if (txtThanaCode.Text == "")
            {
                lblThana.Text = "Thana Code Needed.";
            }
            else
            {
                try
                {

                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                    string ss = "select t.ThanaId,t.Name as TName,d.DistId,d.Name as DName from tblThanas t inner join tblDistricts d on d.DistId=t.DistId where ThanaId=" + txtThanaCode.Text;
                    SqlCommand cmd = new SqlCommand(ss, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtThanaName.Text = dr["TName"].ToString();
                    }

                    lblThana.Text = "";
                    lblThanaMode.Text = "";

                    btnThanaSave.Enabled = false;
                    btnThanaCancel.Enabled = true;
                    btnThanaFind.Enabled = true;
                    btnThanaEdit.Enabled = true;
                    btnThanaNew.Enabled = true;
                    EnableThana(false);
                }
                catch (Exception ex)
                {
                    lblThana.Text = ex.Message;
                }
            }
        }
        protected void btnThanaEdit_Click(object sender, EventArgs e)
        {
            btnThanaSave.Enabled = true;
            btnThanaCancel.Enabled = true;
            btnThanaFind.Enabled = false;
            btnThanaEdit.Enabled = false;
            btnThanaNew.Enabled = false;
            lblThanaMode.Text = "Edit Mode";
            lblThana.Text = "";
            EnableThana(true);

        }
        protected void btnThanaCancel_Click(object sender, EventArgs e)
        {
            btnThanaSave.Enabled = false;
            btnThanaCancel.Enabled = false;
            btnThanaFind.Enabled = true;
            btnThanaEdit.Enabled = false;
            btnThanaNew.Enabled = true;
            EnableThana(false);
            lblThana.Text = "";
            lblThanaMode.Text = "";

            txtThanaCode.Text = "";
            txtThanaName.Text = "";
        }

        protected void btnDistrictNew_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(GetAutoNumber("DistId", "tblDistricts"));
            txtDistrictCode.Text = max.ToString();
            txtDistrictName.Text = "";

            btnDistrictSave.Enabled = true;
            btnDistrictCancel.Enabled = true;
            btnDistrictFind.Enabled = false;
            btnDistrictEdit.Enabled = false;
            btnDistrictNew.Enabled = false;
            txtDistrictName.Enabled = true;
            txtDistrictName.Focus();

            lblDistrict.Text = "";
            lblDistrictMode.Text = "Save Mode";
        }
        protected void btnDistrictSave_Click(object sender, EventArgs e)
        {
            if(txtDistrictCode.Text=="")
            {
                lblDistrict.Text = "District Code can not be blank.";
            }
            else if(txtDistrictName.Text =="")
            {
                lblDistrict.Text = "District Name can not be blank.";
            }
            else
            {
                if (lblDistrictMode.Text == "Save Mode")
                {
                    try
                    {
                        //tblDistrict tbl = new tblDistrict();
                        //tbl.DistId = Convert.ToInt32(txtDistrictCode.Text);
                        //tbl.Name = txtDistrictName.Text;
                        //db.tblDistricts.Add(tbl);
                        //db.SaveChanges();
                        //rgDistrict.Rebind();

                        lblDistrict.Text = "District Name " + "\"" + txtDistrictName.Text + "\" Saved Successfully.";
                        lblDistrictMode.Text = "";
                        txtDistrictCode.Text = "";
                        txtDistrictName.Text = "";

                        btnDistrictSave.Enabled = false;
                        btnDistrictCancel.Enabled = false;
                        btnDistrictFind.Enabled = true;
                        btnDistrictEdit.Enabled = false;
                        btnDistrictNew.Enabled = true;
                        txtDistrictName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblDistrict.Text = ex.Message;
                    }
                }
                else if (lblDistrictMode.Text == "Edit Mode")
                {
                    try
                    {
                        //Int32 id = Convert.ToInt32(txtDistrictCode.Text);
                        //tblDistrict tbl = new tblDistrict();
                        //var k = (from c in db.tblDistricts
                        //         where c.DistId == id
                        //         select c).First();
                        //k.Name = txtDistrictName.Text;
                        //db.SaveChanges();
                        //rgDistrict.Rebind();

                        lblDistrict.Text = "District Name " + "\"" + txtDistrictName.Text + "\" Updated Successfully.";
                        lblDistrictMode.Text = "";
                        txtDistrictCode.Text = "";
                        txtDistrictName.Text = "";

                        btnDistrictSave.Enabled = false;
                        btnDistrictCancel.Enabled = false;
                        btnDistrictFind.Enabled = true;
                        btnDistrictEdit.Enabled = false;
                        btnDistrictNew.Enabled = true;
                        txtDistrictName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblDistrict.Text = ex.Message;
                    }
                }
            }   
        }
        protected void btnDistrictFind_Click(object sender, EventArgs e)
        {
            if(txtDistrictCode.Text=="")
            {
                lblDistrict.Text = "District Code Needed.";
            }
            else
            {
                try
                {
                    //Int32 id = Convert.ToInt32(txtDistrictCode.Text);
                    //tblDistrict tbl = new tblDistrict();
                    //var k = (from c in db.tblDistricts
                    //         where c.DistId == id
                    //         select c).First();
                    //txtDistrictName.Text = k.Name.ToString();
                    //lblDistrict.Text = "";

                    btnDistrictSave.Enabled = false;
                    btnDistrictCancel.Enabled = true;
                    btnDistrictFind.Enabled = true;
                    btnDistrictEdit.Enabled = true;
                    btnDistrictNew.Enabled = true;
                    txtDistrictName.Enabled = false;
                }
                catch (Exception ex)
                {
                    lblDistrict.Text = ex.Message;
                }
            }
        }
        protected void btnDistrictEdit_Click(object sender, EventArgs e)
        {
            btnDistrictSave.Enabled = true;
            btnDistrictCancel.Enabled = true;
            btnDistrictFind.Enabled = false;
            btnDistrictEdit.Enabled = false;
            btnDistrictNew.Enabled = false;
            lblDistrictMode.Text = "Edit Mode";
            lblDistrict.Text = "";
            txtDistrictName.Enabled = true;
        }
        protected void btnDistrictCancel_Click(object sender, EventArgs e)
        {
            btnDistrictSave.Enabled = false;
            btnDistrictCancel.Enabled = false;
            btnDistrictFind.Enabled = true;
            btnDistrictEdit.Enabled = false;
            btnDistrictNew.Enabled = true;
            txtDistrictName.Enabled = false;
            lblDistrict.Text = "";
            lblDistrictMode.Text = "";

            txtDistrictCode.Text = "";
            txtDistrictName.Text = "";
        }

        protected void btnDesignationNew_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(GetAutoNumber("DesigId", "tblDesignations"));
            txtDesignationCode.Text = max.ToString();
            btnDesignationSave.Enabled = true;
            btnDesignationCancel.Enabled = true;
            btnDesignationFind.Enabled = false;
            btnDesignationEdit.Enabled = false;
            btnDesignationNew.Enabled = false;
            txtDesignationName.Enabled = true;
            txtDesignationName.Focus();

            txtDesignationName.Text = "";
            lblDesignationMode.Text = "Save Mode";
            lblDesignation.Text = "";
        }
        protected void btnDesignationSave_Click(object sender, EventArgs e)
        {
            if (txtDesignationCode.Text == "")
            {
                lblDesignation.Text = "Occupation Code can not be blank.";
            }
            else if (txtDesignationName.Text == "")
            {
                lblDesignation.Text = "Occupation Name can not be blank.";
            }
            else
            {
                if (lblDesignationMode.Text == "Save Mode")
                {
                    try
                    {
                        //tblDesignation tbl = new tblDesignation();
                        //tbl.DesigId = Convert.ToInt32(txtDesignationCode.Text);
                        //tbl.Name = txtDesignationName.Text;
                        //db.tblDesignations.Add(tbl);
                        //db.SaveChanges();
                        //rgOccupation.Rebind();

                        lblDesignation.Text = "Occupation Name " + "\"" + txtDesignationName.Text + "\" Saved Successfully.";
                        lblDesignationMode.Text = "";
                        txtDesignationCode.Text = "";
                        txtDesignationName.Text = "";

                        btnDesignationSave.Enabled = false;
                        btnDesignationCancel.Enabled = false;
                        btnDesignationFind.Enabled = true;
                        btnDesignationEdit.Enabled = false;
                        btnDesignationNew.Enabled = true;
                        txtDesignationName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblDesignation.Text = ex.Message;
                    }
                }
                else if (lblDesignationMode.Text == "Edit Mode")
                {
                    try
                    {
                        //Int32 id = Convert.ToInt32(txtDesignationCode.Text);
                        //var k = (from c in db.tblDesignations
                        //         where c.DesigId == id
                        //         select c).First();
                        //k.Name = txtDesignationName.Text;
                        //db.SaveChanges();
                        //rgOccupation.Rebind();

                        lblDesignation.Text = "Occupation Name " + "\"" + txtDesignationName.Text + "\" Updated Successfully.";
                        lblDesignationMode.Text = "";
                        txtDesignationCode.Text = "";
                        txtDesignationName.Text = "";

                        btnDesignationSave.Enabled = false;
                        btnDesignationCancel.Enabled = false;
                        btnDesignationFind.Enabled = true;
                        btnDesignationEdit.Enabled = false;
                        btnDesignationNew.Enabled = true;
                        txtDesignationName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblDesignation.Text = ex.Message;
                    }
                }
            }   
        }
        protected void btnDesignationFind_Click(object sender, EventArgs e)
        {
            if (txtDesignationCode.Text == "")
            {
                lblDesignation.Text = "Designation Code Needed.";
            }
            else
            {
                try
                {
                    //Int32 id = Convert.ToInt32(txtDesignationCode.Text);
                    //tblDesignation tbl = new tblDesignation();
                    //var k = (from c in db.tblDesignations
                    //         where c.DesigId == id
                    //         select c).First();
                    //txtDesignationName.Text = k.Name.ToString();
                    //lblDesignation.Text = "";

                    btnDesignationSave.Enabled = false;
                    btnDesignationCancel.Enabled = true;
                    btnDesignationFind.Enabled = true;
                    btnDesignationEdit.Enabled = true;
                    btnDesignationNew.Enabled = true;
                    txtDesignationName.Enabled = false;
                }
                catch (Exception ex)
                {
                    lblDesignation.Text = ex.Message;
                }
            }
        }
        protected void btnDesignationEdit_Click(object sender, EventArgs e)
        {
            btnDesignationSave.Enabled = true;
            btnDesignationCancel.Enabled = true;
            btnDesignationFind.Enabled = false;
            btnDesignationEdit.Enabled = false;
            btnDesignationNew.Enabled = false;
            lblDesignationMode.Text = "Edit Mode";
            lblDesignation.Text = "";
            txtDesignationName.Enabled = true;
        }
        protected void btnDesignationCancel_Click(object sender, EventArgs e)
        {
            btnDesignationSave.Enabled = false;
            btnDesignationCancel.Enabled = false;
            btnDesignationFind.Enabled = true;
            btnDesignationEdit.Enabled = false;
            btnDesignationNew.Enabled = true;
            txtDesignationName.Enabled = false;
            lblDesignation.Text = "";
            lblDesignationMode.Text = "";

            txtDesignationCode.Text = "";
            txtDesignationName.Text = "";
        }

        protected void btnDepartmentNew_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(GetAutoNumber("DeptId", "tblDepartments"));
            txtDepartmentCode.Text = max.ToString();
            btnDepartmentSave.Enabled = true;
            btnDepartmentCancel.Enabled = true;
            btnDepartmentFind.Enabled = false;
            btnDepartmentEdit.Enabled = false;
            btnDepartmentNew.Enabled = false;
            txtDepartmentName.Enabled = true;
            txtDepartmentName.Focus();

            txtDepartmentName.Text = "";
            lblDepartmentMode.Text = "Save Mode";
            lblDepartment.Text = "";
        }
        protected void btnDepartmentSave_Click(object sender, EventArgs e)
        {
            if (txtDepartmentCode.Text == "")
            {
                lblDepartment.Text = "Department Code can not be blank.";
            }
            else if (txtDepartmentName.Text == "")
            {
                lblDepartment.Text = "Department Name can not be blank.";
            }
            else
            {
                if (lblDepartmentMode.Text == "Save Mode")
                {
                    try
                    {
                        //tblDepartment tbl = new tblDepartment();
                        //tbl.DeptId = Convert.ToInt32(txtDepartmentCode.Text);
                        //tbl.Name = txtDepartmentName.Text;
                        //db.tblDepartments.Add(tbl);
                        //db.SaveChanges();
                        //lblDepartment.Text = "Department Name " + "\"" + txtDepartmentName.Text + "\" Saved Successfully.";
                        //lblDepartmentMode.Text = "";
                        //txtDepartmentCode.Text = "";
                        //txtDepartmentName.Text = "";

                        btnDepartmentSave.Enabled = false;
                        btnDepartmentCancel.Enabled = false;
                        btnDepartmentFind.Enabled = true;
                        btnDepartmentEdit.Enabled = false;
                        btnDepartmentNew.Enabled = true;
                        txtDepartmentName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblDepartment.Text = ex.Message;
                    }
                }
                else if (lblDepartmentMode.Text == "Edit Mode")
                {
                    try
                    {
                        //Int32 id = Convert.ToInt32(txtDepartmentCode.Text);
                        //var k = (from c in db.tblDepartments
                        //         where c.DeptId == id
                        //         select c).First();
                        //k.Name = txtDepartmentName.Text;
                        //db.SaveChanges();

                        lblDepartment.Text = "Department Name " + "\"" + txtDepartmentName.Text + "\" Updated Successfully.";
                        lblDepartmentMode.Text = "";
                        txtDepartmentCode.Text = "";
                        txtDepartmentName.Text = "";

                        btnDepartmentSave.Enabled = false;
                        btnDepartmentCancel.Enabled = false;
                        btnDepartmentFind.Enabled = true;
                        btnDepartmentEdit.Enabled = false;
                        btnDepartmentNew.Enabled = true;
                        txtDepartmentName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblDepartment.Text = ex.Message;
                    }
                }
            }   
        }
        protected void btnDepartmentFind_Click(object sender, EventArgs e)
        {
            if (txtDepartmentCode.Text == "")
            {
                lblDepartment.Text = "Department Code Needed.";
            }
            else
            {
                try
                {
                    //Int32 id = Convert.ToInt32(txtDepartmentCode.Text);
                    //var k = (from c in db.tblDepartments
                    //         where c.DeptId == id
                    //         select c).First();
                    //txtDepartmentName.Text = k.Name.ToString();
                    //lblDepartment.Text = "";

                    //btnDepartmentSave.Enabled = false;
                    //btnDepartmentCancel.Enabled = true;
                    //btnDepartmentFind.Enabled = true;
                    //btnDepartmentEdit.Enabled = true;
                    //btnDepartmentNew.Enabled = true;
                    //txtDepartmentName.Enabled = false;
                }
                catch (Exception ex)
                {
                    lblDepartment.Text = ex.Message;
                }
            }
        }
        protected void btnDepartmentEdit_Click(object sender, EventArgs e)
        {
            btnDepartmentSave.Enabled = true;
            btnDepartmentCancel.Enabled = true;
            btnDepartmentFind.Enabled = false;
            btnDepartmentEdit.Enabled = false;
            btnDepartmentNew.Enabled = false;
            lblDepartmentMode.Text = "Edit Mode";
            lblDepartment.Text = "";
            txtDepartmentName.Enabled = true;
        }
        protected void btnDepartmentCancel_Click(object sender, EventArgs e)
        {
            btnDepartmentSave.Enabled = false;
            btnDepartmentCancel.Enabled = false;
            btnDepartmentFind.Enabled = true;
            btnDepartmentEdit.Enabled = false;
            btnDepartmentNew.Enabled = true;
            txtDepartmentName.Enabled = false;
            lblDepartment.Text = "";
            lblDepartmentMode.Text = "";

            txtDepartmentCode.Text = "";
            txtDepartmentName.Text = "";
        }

        protected void btnCategoryNew_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(GetAutoNumber("CatId", "tblCategory"));
            txtCategoryCode.Text = max.ToString();
            btnCategorySave.Enabled = true;
            btnCategoryCancel.Enabled = true;
            btnCategoryDelete.Enabled = false;
            btnCategoryFind.Enabled = false;
            btnCategoryEdit.Enabled = false;
            btnCategoryNew.Enabled = false;
            txtCategoryName.Enabled = true;
            txtCategoryName.Focus();

            txtCategoryName.Text = "";
            lblCategoryMode.Text = "Save Mode";
            lblCategory.Text = "";
        }
        protected void btnCategorySave_Click(object sender, EventArgs e)
        {
            if (txtCategoryCode.Text == "")
            {
                lblCategory.Text = "Category Code can not be blank.";
            }
            else if (txtCategoryName.Text == "")
            {
                lblCategory.Text = "Category Name can not be blank.";
            }
            else
            {
                if (lblCategoryMode.Text == "Save Mode")
                {
                    try
                    {
                        tblCategory tbl = new tblCategory();
                        tbl.CatId = Convert.ToInt32(txtCategoryCode.Text);
                        tbl.Name = txtCategoryName.Text;
                        db.tblCategories.Add(tbl);
                        db.SaveChanges();
                        rgCategory.Rebind();

                        lblCategory.Text = "Category Name " + "\"" + txtCategoryName.Text + "\" Saved Successfully.";
                        lblCategoryMode.Text = "";
                        txtCategoryCode.Text = "";
                        txtCategoryName.Text = "";

                        btnCategorySave.Enabled = false;
                        btnCategoryCancel.Enabled = false;
                        btnCategoryDelete.Enabled = false;
                        btnCategoryFind.Enabled = true;
                        btnCategoryEdit.Enabled = false;
                        btnCategoryNew.Enabled = true;
                        txtCategoryName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblCategory.Text = ex.Message;
                    }
                }
                else if (lblCategoryMode.Text == "Edit Mode")
                {
                    try
                    {
                        Int32 id = Convert.ToInt32(txtCategoryCode.Text);
                        var k = (from c in db.tblCategories
                                 where c.CatId == id
                                 select c).First();
                        k.Name = txtCategoryName.Text;
                        db.SaveChanges();
                        rgCategory.Rebind();

                        lblCategory.Text = "Category Name " + "\"" + txtCategoryName.Text + "\" Updated Successfully.";
                        lblCategoryMode.Text = "";
                        txtCategoryCode.Text = "";
                        txtCategoryName.Text = "";

                        btnCategorySave.Enabled = false;
                        btnCategoryCancel.Enabled = false;
                        btnCategoryDelete.Enabled = false;
                        btnCategoryFind.Enabled = true;
                        btnCategoryEdit.Enabled = false;
                        btnCategoryNew.Enabled = true;
                        txtCategoryName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblCategory.Text = ex.Message;
                    }
                }
            }   
        }
        protected void btnCategoryFind_Click(object sender, EventArgs e)
        {
            if (txtCategoryCode.Text == "")
            {
                lblCategory.Text = "Category Code Needed.";
            }
            else
            {
                try
                {
                    Int32 id = Convert.ToInt32(txtCategoryCode.Text);
                    var k = (from c in db.tblCategories
                             where c.CatId == id
                             select c).First();
                    txtCategoryName.Text = k.Name.ToString();
                    lblCategory.Text = "";

                    btnCategorySave.Enabled = false;
                    btnCategoryCancel.Enabled = true;
                    btnCategoryDelete.Enabled = true;
                    btnCategoryFind.Enabled = true;
                    btnCategoryEdit.Enabled = true;
                    btnCategoryNew.Enabled = true;
                    txtCategoryName.Enabled = false;
                }
                catch (Exception ex)
                {
                    lblCategory.Text = ex.Message;
                }
            }
        }
        protected void btnCategoryEdit_Click(object sender, EventArgs e)
        {
            btnCategorySave.Enabled = true;
            btnCategoryCancel.Enabled = true;
            btnCategoryDelete.Enabled = false;
            btnCategoryFind.Enabled = false;
            btnCategoryEdit.Enabled = false;
            btnCategoryNew.Enabled = false;
            lblCategoryMode.Text = "Edit Mode";
            lblCategory.Text = "";
            txtCategoryName.Enabled = true;
        }
        protected void btnCategoryDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_ValidationAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 2;
                cmd.Parameters.Add("@ItemCatId", SqlDbType.Int).Value = txtCategoryCode.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                rgCategory.Rebind();

                btnCategorySave.Enabled = false;
                btnCategoryCancel.Enabled = false;
                btnCategoryFind.Enabled = true;
                btnCategoryEdit.Enabled = false;
                btnCategoryNew.Enabled = true;
                txtCategoryName.Enabled = false;
                lblCategory.Text = "Category Name " + "\"" + txtCategoryName.Text + "\" Deleted Successfully.";
                lblCategoryMode.Text = "";

                txtCategoryCode.Text = "";
                txtCategoryName.Text = "";
            }
            catch (Exception ex)
            {
                lblCategory.Text = ex.Message;
            }
        }
        protected void btnCategoryCancel_Click(object sender, EventArgs e)
        {
            btnCategorySave.Enabled = false;
            btnCategoryCancel.Enabled = false;
            btnCategoryFind.Enabled = true;
            btnCategoryEdit.Enabled = false;
            btnCategoryNew.Enabled = true;
            txtCategoryName.Enabled = false;
            lblCategory.Text = "";
            lblCategoryMode.Text = "";

            txtCategoryCode.Text = "";
            txtCategoryName.Text = "";
        }

        protected void btnWeightNew_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(GetAutoNumber("WgtId", "tblWeights"));
            txtWeightCode.Text = max.ToString();
            btnWeightSave.Enabled = true;
            btnWeightCancel.Enabled = true;
            btnWeightFind.Enabled = false;
            btnWeightEdit.Enabled = false;
            btnWeightNew.Enabled = false;
            txtWeightName.Enabled = true;
            txtWeightDesr.Enabled = true;
            txtWeightName.Focus();

            txtWeightName.Text = "";
            txtWeightDesr.Text = "";
            lblWeightMode.Text = "Save Mode";
            lblWeight.Text = "";
        }
        protected void btnWeightSave_Click(object sender, EventArgs e)
        {
            if (txtWeightCode.Text == "")
            {
                lblWeight.Text = "Weight Code can not be blank.";
            }
            else if (txtWeightName.Text == "")
            {
                lblWeight.Text = "Weight Name can not be blank.";
            }
            else
            {
                if (lblWeightMode.Text == "Save Mode")
                {
                    try
                    {
                        //tblWeight tbl = new tblWeight();
                        //tbl.WgtId = Convert.ToInt32(txtWeightCode.Text);
                        //tbl.Unit = txtWeightName.Text;
                        //tbl.Description = txtWeightDesr.Text;
                        //db.tblWeights.Add(tbl);
                        //db.SaveChanges();
                        //rgWeight.Rebind();

                        lblWeight.Text = "Weight Name " + "\"" + txtWeightName.Text + "\" Saved Successfully.";
                        lblWeightMode.Text = "";
                        txtWeightCode.Text = "";
                        txtWeightName.Text = "";
                        txtWeightDesr.Text = "";

                        btnWeightSave.Enabled = false;
                        btnWeightCancel.Enabled = false;
                        btnWeightFind.Enabled = true;
                        btnWeightEdit.Enabled = false;
                        btnWeightNew.Enabled = true;
                        txtWeightName.Enabled = false;
                        txtWeightDesr.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblWeight.Text = ex.Message;
                    }
                }
                else if (lblWeightMode.Text == "Edit Mode")
                {
                    try
                    {
                        //Int32 id = Convert.ToInt32(txtWeightCode.Text);
                        //var k = (from c in db.tblWeights
                        //         where c.WgtId == id
                        //         select c).First();
                        //k.Unit = txtWeightName.Text;
                        //k.Description = txtWeightDesr.Text;
                        //db.SaveChanges();
                        //rgWeight.Rebind();

                        lblWeight.Text = "Weight Name " + "\"" + txtWeightName.Text + "\" Updated Successfully.";
                        lblWeightMode.Text = "";
                        txtWeightCode.Text = "";
                        txtWeightName.Text = "";
                        txtWeightDesr.Text = "";

                        btnWeightSave.Enabled = false;
                        btnWeightCancel.Enabled = false;
                        btnWeightFind.Enabled = true;
                        btnWeightEdit.Enabled = false;
                        btnWeightNew.Enabled = true;
                        txtWeightName.Enabled = false;
                        txtWeightDesr.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblWeight.Text = ex.Message;
                    }
                }
            }   
        }
        protected void btnWeightFind_Click(object sender, EventArgs e)
        {
            if (txtWeightCode.Text == "")
            {
                lblWeight.Text = "Weight Code Needed.";
            }
            else
            {
                try
                {
                    Int32 id = Convert.ToInt32(txtWeightCode.Text);
                    var k = (from c in db.tblCategories
                             where c.CatId == id
                             select c).First();
                    txtWeightName.Text = k.Name.ToString();
                    lblWeight.Text = "";

                    btnWeightSave.Enabled = false;
                    btnWeightCancel.Enabled = true;
                    btnWeightFind.Enabled = true;
                    btnWeightEdit.Enabled = true;
                    btnWeightNew.Enabled = true;
                    txtWeightName.Enabled = false;
                    txtWeightDesr.Enabled = false;
                }
                catch (Exception ex)
                {
                    lblWeight.Text = ex.Message;
                }
            }
        }
        protected void btnWeightEdit_Click(object sender, EventArgs e)
        {
            btnWeightSave.Enabled = true;
            btnWeightCancel.Enabled = true;
            btnWeightFind.Enabled = false;
            btnWeightEdit.Enabled = false;
            btnWeightNew.Enabled = false;
            lblWeightMode.Text = "Edit Mode";
            lblWeight.Text = "";
            txtWeightName.Enabled = true;
            txtWeightDesr.Enabled = true;
        }
        protected void btnWeightCancel_Click(object sender, EventArgs e)
        {
            btnWeightSave.Enabled = false;
            btnWeightCancel.Enabled = false;
            btnWeightFind.Enabled = true;
            btnWeightEdit.Enabled = false;
            btnWeightNew.Enabled = true;
            txtWeightName.Enabled = false;
            txtWeightDesr.Enabled = false;
            lblWeight.Text = "";
            lblWeightMode.Text = "";

            txtWeightCode.Text = "";
            txtWeightName.Text = "";
            txtWeightDesr.Text = "";
        }

        protected void btnDegreeNew_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(GetAutoNumber("DegreeId", "tblDegree"));
            txtDegreeCode.Text = max.ToString();
            btnDegreeSave.Enabled = true;
            btnDegreeCancel.Enabled = true;
            btnDegreeFind.Enabled = false;
            btnDegreeEdit.Enabled = false;
            btnDegreeNew.Enabled = false;
            txtDegreeName.Enabled = true;
            txtDegreeName.Focus();

            txtDegreeName.Text = "";
            lblDegreeMode.Text = "Save Mode";
            lblDegree.Text = "";
        }
        protected void btnDegreeSave_Click(object sender, EventArgs e)
        {
            if (txtDegreeCode.Text == "")
            {
                lblDegree.Text = "Degree Code can not be blank.";
            }
            else if (txtDegreeName.Text == "")
            {
                lblDegree.Text = "Degree Name can not be blank.";
            }
            else
            {
                if (lblDegreeMode.Text == "Save Mode")
                {
                    try
                    {
                        //tblDegree tbl = new tblDegree();
                        //tbl.DegreeId = Convert.ToInt32(txtDegreeCode.Text);
                        //tbl.Name = txtDegreeName.Text;
                        //db.tblDegrees.Add(tbl);
                        //db.SaveChanges();
                        lblDegree.Text = "Degree Name " + "\"" + txtDegreeName.Text + "\" Saved Successfully.";
                        lblDegreeMode.Text = "";
                        txtDegreeCode.Text = "";
                        txtDegreeName.Text = "";

                        btnDegreeSave.Enabled = false;
                        btnDegreeCancel.Enabled = false;
                        btnDegreeFind.Enabled = true;
                        btnDegreeEdit.Enabled = false;
                        btnDegreeNew.Enabled = true;
                        txtDegreeName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblDegree.Text = ex.Message;
                    }
                }
                else if (lblDegreeMode.Text == "Edit Mode")
                {
                    try
                    {
                        //Int32 id = Convert.ToInt32(txtDegreeCode.Text);
                        //var k = (from c in db.tblDegrees
                        //         where c.DegreeId == id
                        //         select c).First();
                        //k.Name = txtDegreeName.Text;
                        //db.SaveChanges();

                        lblDegree.Text = "Degree Name " + "\"" + txtDegreeName.Text + "\" Updated Successfully.";
                        lblDegreeMode.Text = "";
                        txtDegreeCode.Text = "";
                        txtDegreeName.Text = "";

                        btnDegreeSave.Enabled = false;
                        btnDegreeCancel.Enabled = false;
                        btnDegreeFind.Enabled = true;
                        btnDegreeEdit.Enabled = false;
                        btnDegreeNew.Enabled = true;
                        txtDegreeName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblDegree.Text = ex.Message;
                    }
                }
                //rgDegree.DataSource = db.tblDegrees.ToList();
                //rgDegree.DataBind();
            }
        }
        protected void btnDegreeFind_Click(object sender, EventArgs e)
        {
            if (txtDegreeCode.Text == "")
            {
                lblDegree.Text = "Degree Code Needed.";
            }
            else
            {
                try
                {
                    //Int32 id = Convert.ToInt32(txtDegreeCode.Text);
                    //var k = (from c in db.tblDegrees
                    //         where c.DegreeId == id
                    //         select c).First();
                    //txtDegreeName.Text = k.Name.ToString();
                    lblDegree.Text = "";

                    btnDegreeSave.Enabled = false;
                    btnDegreeCancel.Enabled = true;
                    btnDegreeFind.Enabled = true;
                    btnDegreeEdit.Enabled = true;
                    btnDegreeNew.Enabled = true;
                    txtDegreeName.Enabled = false;
                }
                catch (Exception ex)
                {
                    lblDegree.Text = ex.Message;
                }
            }
        }
        protected void btnDegreeEdit_Click(object sender, EventArgs e)
        {
            btnDegreeSave.Enabled = true;
            btnDegreeCancel.Enabled = true;
            btnDegreeFind.Enabled = false;
            btnDegreeEdit.Enabled = false;
            btnDegreeNew.Enabled = false;
            lblDegreeMode.Text = "Edit Mode";
            lblDegree.Text = "";
            txtDegreeName.Enabled = true;
        }
        protected void btnDegreeCancel_Click(object sender, EventArgs e)
        {
            btnDegreeSave.Enabled = false;
            btnDegreeCancel.Enabled = false;
            btnDegreeFind.Enabled = true;
            btnDegreeEdit.Enabled = false;
            btnDegreeNew.Enabled = true;
            txtDegreeName.Enabled = false;
            lblDegree.Text = "";
            lblDegreeMode.Text = "";

            txtDegreeCode.Text = "";
            txtDegreeName.Text = "";
        }

        protected void btnItemSizeNew_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(GetAutoNumber("Id", "tblItemSize"));
            txtItemSizeCode.Text = max.ToString();
            txtItemSizeName.Text = "";

            btnItemSizeSave.Enabled = true;
            btnItemSizeCancel.Enabled = true;
            btnItemSizeFind.Enabled = false;
            btnItemSizeEdit.Enabled = false;
            btnItemSizeDelete.Enabled = false;
            btnItemSizeNew.Enabled = false;
            txtItemSizeName.Enabled = true;
            txtItemSizeName.Focus();

            lblItemSize.Text = "";
            lblItemSizeMode.Text = "Save Mode";
        }
        protected void btnItemSizeSave_Click(object sender, EventArgs e)
        {
            if (txtItemSizeCode.Text == "")
            {
                lblItemSize.Text = "Item Size Code can not be blank.";
            }
            else if (txtItemSizeName.Text == "")
            {
                lblItemSize.Text = "Item Size Name can not be blank.";
            }
            else
            {
                if (lblItemSizeMode.Text == "Save Mode")
                {
                    try
                    {
                        tblItemSize tbl = new tblItemSize();
                        tbl.Id = Convert.ToInt32(txtItemSizeCode.Text);
                        tbl.Name = txtItemSizeName.Text;
                        db.tblItemSizes.Add(tbl);
                        db.SaveChanges();
                        rgItemSize.Rebind();

                        lblItemSize.Text = "Item Size Name " + "\"" + txtItemSizeName.Text + "\" Saved Successfully.";
                        lblItemSizeMode.Text = "";
                        txtItemSizeCode.Text = "";
                        txtItemSizeName.Text = "";

                        btnItemSizeSave.Enabled = false;
                        btnItemSizeCancel.Enabled = false;
                        btnItemSizeFind.Enabled = true;
                        btnItemSizeEdit.Enabled = false;
                        btnItemSizeDelete.Enabled = false;
                        btnItemSizeNew.Enabled = true;
                        txtItemSizeName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblItemSize.Text = ex.Message;
                    }
                }
                else if (lblItemSizeMode.Text == "Edit Mode")
                {
                    try
                    {
                        Int32 id = Convert.ToInt32(txtItemSizeCode.Text);
                        tblItemSize tbl = new tblItemSize();
                        var k = (from c in db.tblItemSizes
                                 where c.Id == id
                                 select c).First();
                        k.Name = txtItemSizeName.Text;
                        db.SaveChanges();
                        rgItemSize.Rebind();

                        lblItemSize.Text = "Item Size Name " + "\"" + txtItemSizeName.Text + "\" Updated Successfully.";
                        lblItemSizeMode.Text = "";
                        txtItemSizeCode.Text = "";
                        txtItemSizeName.Text = "";

                        btnItemSizeSave.Enabled = false;
                        btnItemSizeCancel.Enabled = false;
                        btnItemSizeFind.Enabled = true;
                        btnItemSizeEdit.Enabled = false;
                        btnItemSizeDelete.Enabled = false;
                        btnItemSizeNew.Enabled = true;
                        txtItemSizeName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblItemSize.Text = ex.Message;
                    }
                }
            }
        }
        protected void btnItemSizeFind_Click(object sender, EventArgs e)
        {
            if (txtItemSizeCode.Text == "")
            {
                lblItemSize.Text = "ItemSize Code Needed.";
            }
            else
            {
                try
                {
                    Int32 id = Convert.ToInt32(txtItemSizeCode.Text);
                    tblItemSize tbl = new tblItemSize();
                    var k = (from c in db.tblItemSizes
                             where c.Id == id
                             select c).First();
                    txtItemSizeName.Text = k.Name.ToString();
                    lblItemSize.Text = "";

                    btnItemSizeSave.Enabled = false;
                    btnItemSizeCancel.Enabled = true;
                    btnItemSizeFind.Enabled = true;
                    btnItemSizeEdit.Enabled = true;
                    btnItemSizeDelete.Enabled = false;
                    btnItemSizeNew.Enabled = true;
                    txtItemSizeName.Enabled = false;
                }
                catch (Exception ex)
                {
                    lblItemSize.Text = ex.Message;
                }
            }
        }
        protected void btnItemSizeEdit_Click(object sender, EventArgs e)
        {
            btnItemSizeSave.Enabled = true;
            btnItemSizeCancel.Enabled = true;
            btnItemSizeFind.Enabled = false;
            btnItemSizeEdit.Enabled = false;
            btnItemSizeDelete.Enabled = false;
            btnItemSizeNew.Enabled = false;
            lblItemSizeMode.Text = "Edit Mode";
            lblItemSize.Text = "";
            txtItemSizeName.Enabled = true;
        }
        protected void btnItemSizeDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_ValidationAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@ItemSize", SqlDbType.Int).Value = txtItemSizeCode.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                rgItemSize.Rebind();

                lblItemSize.Text = "Item Size Name " + "\"" + txtItemSizeName.Text + "\" Deleted Successfully.";
                lblItemSizeMode.Text = "";
                txtItemSizeCode.Text = "";
                txtItemSizeName.Text = "";

                btnItemSizeSave.Enabled = false;
                btnItemSizeCancel.Enabled = false;
                btnItemSizeFind.Enabled = true;
                btnItemSizeEdit.Enabled = false;
                btnItemSizeDelete.Enabled = false;
                btnItemSizeNew.Enabled = true;
                txtItemSizeName.Enabled = false;
            }
            catch (Exception ex)
            {
                lblItemSize.Text = ex.Message;
            }
        }
        protected void btnItemSizeCancel_Click(object sender, EventArgs e)
        {
            btnItemSizeSave.Enabled = false;
            btnItemSizeCancel.Enabled = false;
            btnItemSizeFind.Enabled = true;
            btnItemSizeEdit.Enabled = false;
            btnItemSizeDelete.Enabled = false;
            btnItemSizeNew.Enabled = true;
            txtItemSizeName.Enabled = false;
            lblItemSize.Text = "";
            lblItemSizeMode.Text = "";

            txtItemSizeCode.Text = "";
            txtItemSizeName.Text = "";
        }

        protected void btnPackingNew_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(GetAutoNumber("Id", "tblPacking"));
            txtPackingCode.Text = max.ToString();
            txtPackingName.Text = "";

            btnPackingSave.Enabled = true;
            btnPackingCancel.Enabled = true;
            btnPackingFind.Enabled = false;
            btnPackingEdit.Enabled = false;
            btnPackingNew.Enabled = false;
            btnPackingDelete.Enabled = false;
            txtPackingName.Enabled = true;
            txtPackingName.Focus();

            lblPacking.Text = "";
            lblPackingMode.Text = "Save Mode";
        }
        protected void btnPackingSave_Click(object sender, EventArgs e)
        {
            if (txtPackingCode.Text == "")
            {
                lblPacking.Text = "Packing Code can not be blank.";
            }
            else if (txtPackingName.Text == "")
            {
                lblPacking.Text = "Packing Name can not be blank.";
            }
            else
            {
                if (lblPackingMode.Text == "Save Mode")
                {
                    try
                    {
                        tblPacking tbl = new tblPacking();
                        tbl.Id = Convert.ToInt32(txtPackingCode.Text);
                        tbl.Name = txtPackingName.Text;
                        db.tblPackings.Add(tbl);
                        db.SaveChanges();
                        rgPacking.Rebind();

                        lblPacking.Text = "Packing Name " + "\"" + txtPackingName.Text + "\" Saved Successfully.";
                        lblPackingMode.Text = "";
                        txtPackingCode.Text = "";
                        txtPackingName.Text = "";

                        btnPackingSave.Enabled = false;
                        btnPackingCancel.Enabled = false;
                        btnPackingFind.Enabled = true;
                        btnPackingEdit.Enabled = false;
                        btnPackingDelete.Enabled = false;
                        btnPackingNew.Enabled = true;
                        txtPackingName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblPacking.Text = ex.Message;
                    }
                }
                else if (lblPackingMode.Text == "Edit Mode")
                {
                    try
                    {
                        Int32 id = Convert.ToInt32(txtPackingCode.Text);
                        tblPacking tbl = new tblPacking();
                        var k = (from c in db.tblPackings
                                 where c.Id == id
                                 select c).First();
                        k.Name = txtPackingName.Text;
                        db.SaveChanges();
                        rgPacking.Rebind();

                        lblPacking.Text = "Packing Name " + "\"" + txtPackingName.Text + "\" Updated Successfully.";
                        lblPackingMode.Text = "";
                        txtPackingCode.Text = "";
                        txtPackingName.Text = "";

                        btnPackingSave.Enabled = false;
                        btnPackingCancel.Enabled = false;
                        btnPackingFind.Enabled = true;
                        btnPackingEdit.Enabled = false;
                        btnPackingDelete.Enabled = false;
                        btnPackingNew.Enabled = true;
                        txtPackingName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblPacking.Text = ex.Message;
                    }
                }
            }
        }
        protected void btnPackingFind_Click(object sender, EventArgs e)
        {
            if (txtPackingCode.Text == "")
            {
                lblPacking.Text = "Packing Code Needed.";
            }
            else
            {
                try
                {
                    Int32 id = Convert.ToInt32(txtPackingCode.Text);
                    tblPacking tbl = new tblPacking();
                    var k = (from c in db.tblPackings
                             where c.Id == id
                             select c).First();
                    txtPackingName.Text = k.Name.ToString();
                    lblPacking.Text = "";

                    btnPackingSave.Enabled = false;
                    btnPackingCancel.Enabled = true;
                    btnPackingFind.Enabled = true;
                    btnPackingEdit.Enabled = true;
                    btnPackingDelete.Enabled = false;
                    btnPackingNew.Enabled = true;
                    txtPackingName.Enabled = false;
                }
                catch (Exception ex)
                {
                    lblPacking.Text = ex.Message;
                }
            }
        }
        protected void btnPackingEdit_Click(object sender, EventArgs e)
        {
            btnPackingSave.Enabled = true;
            btnPackingCancel.Enabled = true;
            btnPackingFind.Enabled = false;
            btnPackingEdit.Enabled = false;
            btnPackingDelete.Enabled = false;
            btnPackingNew.Enabled = false;
            lblPackingMode.Text = "Edit Mode";
            lblPacking.Text = "";
            txtPackingName.Enabled = true;
        }
        protected void btnPackingDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_ValidationAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 4;
                cmd.Parameters.Add("@Pack", SqlDbType.Int).Value = txtPackingCode.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                rgPacking.Rebind();

                lblPacking.Text = "Packing Name " + "\"" + txtPackingName.Text + "\" Deleted Successfully.";
                lblPackingMode.Text = "";
                txtPackingCode.Text = "";
                txtPackingName.Text = "";

                btnPackingSave.Enabled = false;
                btnPackingCancel.Enabled = false;
                btnPackingFind.Enabled = true;
                btnPackingEdit.Enabled = false;
                btnPackingDelete.Enabled = false;
                btnPackingNew.Enabled = true;
                txtPackingName.Enabled = false;
            }
            catch (Exception ex)
            {
                lblPacking.Text = ex.Message;
            }
        }
        protected void btnPackingCancel_Click(object sender, EventArgs e)
        {
            btnPackingSave.Enabled = false;
            btnPackingCancel.Enabled = false;
            btnPackingFind.Enabled = true;
            btnPackingEdit.Enabled = false;
            btnPackingDelete.Enabled = false;
            btnPackingNew.Enabled = true;
            txtPackingName.Enabled = false;
            lblPacking.Text = "";
            lblPackingMode.Text = "";

            txtPackingCode.Text = "";
            txtPackingName.Text = "";
        }

        protected void btnCostNew_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(GetAutoNumber("Id", "tblCostCenters"));
            txtCostCode.Text = max.ToString();
            txtCostName.Text = "";

            btnCostSave.Enabled = true;
            btnCostCancel.Enabled = true;
            btnCostFind.Enabled = false;
            btnCostEdit.Enabled = false;
            btnCostDelete.Enabled = false;
            btnCostNew.Enabled = false;
            txtCostName.Enabled = true;
            txtCostName.Focus();

            lblCost.Text = "";
            lblCostMode.Text = "Save Mode";
        }
        protected void btnCostSave_Click(object sender, EventArgs e)
        {
            if (txtCostName.Text == "")
            {
                lblCost.Text = "Cost Center Name can not be blank.";
            }
            else
            {
                if (lblCostMode.Text == "Save Mode")
                {
                    try
                    {
                        tblCostCenter tbl = new tblCostCenter();
                        tbl.Id = Convert.ToInt32(txtCostCode.Text);
                        tbl.Name = txtCostName.Text;
                        db.tblCostCenters.Add(tbl);
                        db.SaveChanges();
                        rgCostCenter.Rebind();

                        lblCost.Text = "Cost Center Name " + "\"" + txtCostName.Text + "\" Saved Successfully.";
                        lblCostMode.Text = "";
                        txtCostCode.Text = "";
                        txtCostName.Text = "";
                        cmCostCenter.DataBind();

                        btnCostSave.Enabled = false;
                        btnCostCancel.Enabled = false;
                        btnCostFind.Enabled = true;
                        btnCostEdit.Enabled = false;
                        btnCostDelete.Enabled = false;
                        btnCostNew.Enabled = true;
                        txtCostName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblCost.Text = ex.Message;
                    }
                }
                else if (lblCostMode.Text == "Edit Mode")
                {
                    try
                    {
                        Int32 id = Convert.ToInt32(txtCostCode.Text);
                        tblCostCenter tbl = new tblCostCenter();
                        var k = (from c in db.tblCostCenters
                                 where c.Id == id
                                 select c).First();
                        k.Name = txtCostName.Text;
                        db.SaveChanges();
                        rgCostCenter.Rebind();

                        lblCost.Text = "Cost Center Name " + "\"" + txtCostName.Text + "\" Updated Successfully.";
                        lblCostMode.Text = "";
                        txtCostCode.Text = "";
                        txtCostName.Text = "";
                        cmCostCenter.DataBind();

                        btnCostSave.Enabled = false;
                        btnCostCancel.Enabled = false;
                        btnCostFind.Enabled = true;
                        btnCostEdit.Enabled = false;
                        btnCostDelete.Enabled = false;
                        btnCostNew.Enabled = true;
                        txtCostName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblCost.Text = ex.Message;
                    }
                }
            }
        }
        protected void btnCostFind_Click(object sender, EventArgs e)
        {
            if (txtCostCode.Text == "")
            {
                lblCost.Text = "Cost Code Needed.";
            }
            else
            {
                try
                {
                    Int32 id = Convert.ToInt32(txtCostCode.Text);
                    tblCostCenter tbl = new tblCostCenter();
                    var k = (from c in db.tblCostCenters
                             where c.Id == id
                             select c).First();
                    txtCostName.Text = k.Name.ToString();
                    lblCost.Text = "";

                    btnCostSave.Enabled = false;
                    btnCostCancel.Enabled = true;
                    btnCostFind.Enabled = true;
                    btnCostEdit.Enabled = true;
                    btnCostDelete.Enabled = false;
                    btnCostNew.Enabled = true;
                    txtCostName.Enabled = false;
                }
                catch (Exception ex)
                {
                    lblCost.Text = ex.Message;
                }
            }
        }
        protected void btnCostEdit_Click(object sender, EventArgs e)
        {
            btnCostSave.Enabled = true;
            btnCostCancel.Enabled = true;
            btnCostFind.Enabled = false;
            btnCostEdit.Enabled = false;
            btnCostDelete.Enabled = false;
            btnCostNew.Enabled = false;
            lblCostMode.Text = "Edit Mode";
            lblCost.Text = "";
            txtCostName.Enabled = true;
        }
        protected void btnCostDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_ValidationAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 5;
                cmd.Parameters.Add("@CostHead", SqlDbType.Int).Value = txtCostCode.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                rgCostCenter.Rebind();

                lblCost.Text = "Cost Center Name " + "\"" + txtCostName.Text + "\" Deleted Successfully.";
                lblCostMode.Text = "";
                txtCostCode.Text = "";
                txtCostName.Text = "";
                cmCostCenter.DataBind();

                btnCostSave.Enabled = false;
                btnCostCancel.Enabled = false;
                btnCostFind.Enabled = true;
                btnCostEdit.Enabled = false;
                btnCostDelete.Enabled = false;
                btnCostNew.Enabled = true;
                txtCostName.Enabled = false;
            }
            catch (Exception ex)
            {
                lblCost.Text = ex.Message;
            }
        }
        protected void btnCostCancel_Click(object sender, EventArgs e)
        {
            btnCostSave.Enabled = false;
            btnCostCancel.Enabled = false;
            btnCostFind.Enabled = true;
            btnCostEdit.Enabled = false;
            btnCostDelete.Enabled = false;
            btnCostNew.Enabled = true;
            txtCostName.Enabled = false;
            lblCost.Text = "";
            lblCostMode.Text = "";

            txtCostCode.Text = "";
            txtCostName.Text = "";
        }

        protected void btnCostElementNew_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(GetAutoNumber("Id", "tblCostElements"));
            txtCostElementCode.Text = max.ToString();
            txtCostElementName.Text = "";
            cmCostCenter.Text = "";
            cmCostCenter.SelectedValue = "";

            btnCostElementSave.Enabled = true;
            btnCostElementCancel.Enabled = true;
            btnCostElementFind.Enabled = false;
            btnCostElementEdit.Enabled = false;
            btnCostElementDelete.Enabled = false;
            btnCostElementNew.Enabled = false;
            txtCostElementName.Enabled = true;
            cmCostCenter.Enabled = true;
            txtCostElementName.Focus();

            lblCostElement.Text = "";
            lblCostElementMode.Text = "Save Mode";
        }
        protected void btnCostElementSave_Click(object sender, EventArgs e)
        {
            if (txtCostElementName.Text == "")
            {
                lblCostElement.Text = "Cost Element Name can not be blank.";
            }
            else if (cmCostCenter.SelectedValue == "")
            {
                lblCostElement.Text = "Select Cost Center Name.";
            }
            else
            {
                if (lblCostElementMode.Text == "Save Mode")
                {
                    try
                    {
                        tblCostElement tbl = new tblCostElement();
                        tbl.Id = Convert.ToInt32(txtCostElementCode.Text);
                        tbl.Name = txtCostElementName.Text;
                        tbl.CostCenterId = Convert.ToInt32(cmCostCenter.SelectedValue);
                        db.tblCostElements.Add(tbl);
                        db.SaveChanges();
                        rgCostElements.Rebind();

                        lblCostElement.Text = "Cost Element Name " + "\"" + txtCostElementName.Text + "\" Saved Successfully.";
                        lblCostElementMode.Text = "";
                        txtCostElementCode.Text = "";
                        txtCostElementName.Text = "";

                        btnCostElementSave.Enabled = false;
                        btnCostElementCancel.Enabled = false;
                        btnCostElementFind.Enabled = true;
                        btnCostElementEdit.Enabled = false;
                        btnCostElementDelete.Enabled = false;
                        btnCostElementNew.Enabled = true;
                        txtCostElementName.Enabled = false;
                        cmCostCenter.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblCostElement.Text = ex.Message;
                    }
                }
                else if (lblCostElementMode.Text == "Edit Mode")
                {
                    try
                    {
                        Int32 id = Convert.ToInt32(txtCostElementCode.Text);
                        tblCostElement tbl = new tblCostElement();
                        var k = (from c in db.tblCostElements
                                 where c.Id == id
                                 select c).First();
                        k.Name = txtCostElementName.Text;
                        k.CostCenterId = Convert.ToInt32(cmCostCenter.SelectedValue);
                        db.SaveChanges();
                        rgCostElements.Rebind();

                        lblCostElement.Text = "Cost Element Name " + "\"" + txtCostElementName.Text + "\" Updated Successfully.";
                        lblCostElementMode.Text = "";
                        txtCostElementCode.Text = "";
                        txtCostElementName.Text = "";

                        btnCostElementSave.Enabled = false;
                        btnCostElementCancel.Enabled = false;
                        btnCostElementFind.Enabled = true;
                        btnCostElementEdit.Enabled = false;
                        btnCostElementDelete.Enabled = false;
                        btnCostElementNew.Enabled = true;
                        txtCostElementName.Enabled = false;
                        cmCostCenter.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblCostElement.Text = ex.Message;
                    }
                }
            }
        }
        protected void btnCostElementFind_Click(object sender, EventArgs e)
        {
            if (txtCostElementCode.Text == "")
            {
                lblCostElement.Text = "Cost Element Code Needed.";
            }
            else
            {
                try
                {
                    Int32 id = Convert.ToInt32(txtCostElementCode.Text);
                    tblCostElement tbl = new tblCostElement();
                    var k = (from c in db.tblCostElements
                             where c.Id == id
                             select c).First();
                    txtCostElementName.Text = k.Name.ToString();
                    cmCostCenter.SelectedValue = k.CostCenterId.ToString();
                    lblCostElement.Text = "";

                    btnCostElementSave.Enabled = false;
                    btnCostElementCancel.Enabled = true;
                    btnCostElementFind.Enabled = true;
                    btnCostElementEdit.Enabled = true;
                    btnCostElementDelete.Enabled = false;
                    btnCostElementNew.Enabled = true;
                    txtCostElementName.Enabled = false;
                    cmCostCenter.Enabled = false;
                }
                catch (Exception ex)
                {
                    lblCostElement.Text = ex.Message;
                }
            }
        }
        protected void btnCostElementEdit_Click(object sender, EventArgs e)
        {
            btnCostElementSave.Enabled = true;
            btnCostElementCancel.Enabled = true;
            btnCostElementFind.Enabled = false;
            btnCostElementEdit.Enabled = false;
            btnCostElementDelete.Enabled = false;
            btnCostElementNew.Enabled = false;
            lblCostElementMode.Text = "Edit Mode";
            lblCostElement.Text = "";
            txtCostElementName.Enabled = true;
            cmCostCenter.Enabled = true;
        }
        protected void btnCostElementDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_ValidationAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 6;
                cmd.Parameters.Add("@CostElement", SqlDbType.Int).Value = txtCostElementCode.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                rgCostElements.Rebind();

                lblCostElement.Text = "Cost Element Name " + "\"" + txtCostElementName.Text + "\" Deleted Successfully.";
                lblCostElementMode.Text = "";
                txtCostElementCode.Text = "";
                txtCostElementName.Text = "";

                btnCostElementSave.Enabled = false;
                btnCostElementCancel.Enabled = false;
                btnCostElementFind.Enabled = true;
                btnCostElementEdit.Enabled = false;
                btnCostElementDelete.Enabled = false;
                btnCostElementNew.Enabled = true;
                txtCostElementName.Enabled = false;
                cmCostCenter.Enabled = false;
            }
            catch (Exception ex)
            {
                lblCostElement.Text = ex.Message;
            }
        }
        protected void btnCostElementCancel_Click(object sender, EventArgs e)
        {
            btnCostElementSave.Enabled = false;
            btnCostElementCancel.Enabled = false;
            btnCostElementFind.Enabled = true;
            btnCostElementEdit.Enabled = false;
            btnCostElementNew.Enabled = true;
            txtCostElementName.Enabled = false;
            cmCostCenter.Enabled = false;

            lblCostElement.Text = "";
            lblCostElementMode.Text = "";

            txtCostElementCode.Text = "";
            txtCostElementName.Text = "";
        }

        protected void btnBankNew_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(GetAutoNumber("BankCode", "tblBank"));
            txtBankCode.Text = max.ToString();
            btnBankSave.Enabled = true;
            btnBankCancel.Enabled = true;
            btnBankFind.Enabled = false;
            btnBankEdit.Enabled = false;
            btnBankDelete.Enabled = false;
            btnBankNew.Enabled = false;
            txtBankName.Enabled = true;
            txtBankName.Focus();

            txtBankName.Text = "";
            lblBankMode.Text = "Save Mode";
            lblBank.Text = "";
        }
        protected void btnBankSave_Click(object sender, EventArgs e)
        {
            if (txtBankCode.Text == "")
            {
                lblBank.Text = "Bank Code can not be blank.";
            }
            else if (txtBankName.Text == "")
            {
                lblBank.Text = "Bank Name can not be blank.";
            }
            else
            {
                if (lblBankMode.Text == "Save Mode")
                {
                    try
                    {
                        //tblBank tbl = new tblBank();
                        //tbl.BankCode = Convert.ToInt32(txtBankCode.Text);
                        //tbl.Name = txtBankName.Text;
                        //db.tblBanks.Add(tbl);
                        //db.SaveChanges();
                        //rgBank.Rebind();

                        lblBank.Text = "Bank Name " + "\"" + txtBankName.Text + "\" Saved Successfully.";
                        lblBankMode.Text = "";
                        txtBankCode.Text = "";
                        txtBankName.Text = "";

                        btnBankSave.Enabled = false;
                        btnBankCancel.Enabled = false;
                        btnBankFind.Enabled = true;
                        btnBankEdit.Enabled = false;
                        btnBankDelete.Enabled = false;
                        btnBankNew.Enabled = true;
                        txtBankName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblBank.Text = ex.Message;
                    }
                }
                else if (lblBankMode.Text == "Edit Mode")
                {
                    try
                    {
                        //Int32 id = Convert.ToInt32(txtBankCode.Text);
                        //var k = (from c in db.tblBanks
                        //         where c.BankCode == id
                        //         select c).First();
                        //k.Name = txtBankName.Text;
                        //db.SaveChanges();
                        //rgBank.Rebind();

                        lblBank.Text = "Bank Name " + "\"" + txtBankName.Text + "\" Updated Successfully.";
                        lblBankMode.Text = "";
                        txtBankCode.Text = "";
                        txtBankName.Text = "";

                        btnBankSave.Enabled = false;
                        btnBankCancel.Enabled = false;
                        btnBankFind.Enabled = true;
                        btnBankEdit.Enabled = false;
                        btnBankDelete.Enabled = false;
                        btnBankNew.Enabled = true;
                        txtBankName.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        lblBank.Text = ex.Message;
                    }
                }
            }
        }
        protected void btnBankFind_Click(object sender, EventArgs e)
        {
            if (txtBankCode.Text == "")
            {
                lblBank.Text = "Bank Code Needed.";
            }
            else
            {
                try
                {
                    //Int32 id = Convert.ToInt32(txtBankCode.Text);
                    //var k = (from c in db.tblBanks
                    //         where c.BankCode == id
                    //         select c).First();
                    //txtBankName.Text = k.Name.ToString();
                    //lblBank.Text = "";

                    btnBankSave.Enabled = false;
                    btnBankCancel.Enabled = true;
                    btnBankFind.Enabled = true;
                    btnBankEdit.Enabled = true;
                    btnBankDelete.Enabled = false;
                    btnBankNew.Enabled = true;
                    txtBankName.Enabled = false;
                }
                catch (Exception ex)
                {
                    lblBank.Text = ex.Message;
                }
            }
        }
        protected void btnBankEdit_Click(object sender, EventArgs e)
        {
            btnBankSave.Enabled = true;
            btnBankCancel.Enabled = true;
            btnBankFind.Enabled = false;
            btnBankEdit.Enabled = false;
            btnBankDelete.Enabled = false;
            btnBankNew.Enabled = false;
            lblBankMode.Text = "Edit Mode";
            lblBank.Text = "";
            txtBankName.Enabled = true;
        }
        protected void btnBankDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["AgroSalesMSConnectionString"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("Sp_ValidationAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 8;
                cmd.Parameters.Add("@Bank", SqlDbType.VarChar).Value = txtBankCode.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                rgBank.Rebind();

                lblBank.Text = "Bank Name " + "\"" + txtBankName.Text + "\" Deleted Successfully.";
                lblBankMode.Text = "";
                txtBankCode.Text = "";
                txtBankName.Text = "";

                btnBankSave.Enabled = false;
                btnBankCancel.Enabled = false;
                btnBankFind.Enabled = true;
                btnBankEdit.Enabled = false;
                btnBankDelete.Enabled = false;
                btnBankDelete.Enabled = false;
                btnBankNew.Enabled = true;
                txtBankName.Enabled = false;
            }
            catch (Exception ex)
            {
                lblBank.Text = ex.Message;
            }
        }
        protected void btnBankCancel_Click(object sender, EventArgs e)
        {
            btnBankSave.Enabled = false;
            btnBankCancel.Enabled = false;
            btnBankFind.Enabled = true;
            btnBankEdit.Enabled = false;
            btnBankDelete.Enabled = false;
            btnBankNew.Enabled = true;
            txtBankName.Enabled = false;
            lblBank.Text = "";
            lblBankMode.Text = "";

            txtBankCode.Text = "";
            txtBankName.Text = "";
        }

        protected void rgVillage_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            rgVillage.DataSource = db.tblVillages.ToList();
        }
        protected void rgVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridDataItem selectedItem = (GridDataItem)rgVillage.SelectedItems[0];
            txtVillageCode.Text = selectedItem["ViId"].Text;
            txtVillageName.Text = selectedItem["Name"].Text;
            cmThana.SelectedValue = selectedItem["ThanaId"].Text;
            btnVillageEdit.Enabled = true;
            txtVillageCode.Enabled = false;
            lblVillage.Text = "";
        }

        protected void rgThana_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgThana.DataSource = db.tblThanas.ToList();
        }
        protected void rgThana_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridDataItem selectedItem = (GridDataItem)rgThana.SelectedItems[0];
            txtThanaCode.Text = selectedItem["ThanaId"].Text;
            txtThanaName.Text = selectedItem["Name"].Text;
            btnThanaEdit.Enabled = true;
            txtThanaCode.Enabled = false;
            lblThana.Text = "";
        }

        protected void rgDistrict_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //rgDistrict.DataSource = db.tblDistricts.ToList();
        }
        protected void rgDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridDataItem selectedItem = (GridDataItem)rgDistrict.SelectedItems[0];
            txtDistrictCode.Text = selectedItem["DistId"].Text;
            txtDistrictName.Text = selectedItem["Name"].Text;
            btnDistrictEdit.Enabled = true;
            txtDistrictCode.Enabled = false;
            lblDistrict.Text = "";
        }

        protected void rgOccupation_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //rgOccupation.DataSource = db.tblDesignations.ToList();
        }
        protected void rgOccupation_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridDataItem selectedItem = (GridDataItem)rgOccupation.SelectedItems[0];
            txtDesignationCode.Text = selectedItem["DesigId"].Text;
            txtDesignationName.Text = selectedItem["Name"].Text;
            btnDesignationEdit.Enabled = true;
            txtDesignationCode.Enabled = false;
            lblDesignation.Text = "";
        }

        protected void rgDepartment_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //rgDepartment.DataSource = db.tblDepartments.ToList();
        }
        protected void rgDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridDataItem selectedItem = (GridDataItem)rgDepartment.SelectedItems[0];
            txtDepartmentCode.Text = selectedItem["DeptId"].Text;
            txtDepartmentName.Text = selectedItem["Name"].Text;
            btnDepartmentEdit.Enabled = true;
            txtDepartmentCode.Enabled = false;
            lblDepartment.Text = "";
        }

        protected void rgDegree_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //rgDegree.DataSource = db.tblDegrees.ToList();
        }
        protected void rgDegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridDataItem selectedItem = (GridDataItem)rgDegree.SelectedItems[0];
            txtDegreeCode.Text = selectedItem["DegreeId"].Text;
            txtDegreeName.Text = selectedItem["Name"].Text;
            btnDegreeEdit.Enabled = true;
            txtDegreeCode.Enabled = false;
            lblDegree.Text = "";
        }

        protected void rgCategory_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgCategory.DataSource = db.tblCategories.ToList();
        }
        protected void rgCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridDataItem selectedItem = (GridDataItem)rgCategory.SelectedItems[0];
            txtCategoryCode.Text = selectedItem["CatId"].Text;
            txtCategoryName.Text = selectedItem["Name"].Text;
            btnCategoryEdit.Enabled = true;
            btnCategoryDelete.Enabled = true;
            txtCategoryCode.Enabled = false;
            lblCategory.Text = "";
        }

        protected void rgWeight_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //rgWeight.DataSource = db.tblWeights.ToList();
        }
        protected void rgWeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridDataItem selectedItem = (GridDataItem)rgWeight.SelectedItems[0];
            txtWeightCode.Text = selectedItem["WgtId"].Text;
            txtWeightName.Text = selectedItem["Unit"].Text;
            txtWeightDesr.Text = selectedItem["Description"].Text;
            btnWeightEdit.Enabled = true;
            txtWeightCode.Enabled = false;
            lblWeight.Text = "";
        }

        protected void rgItemSize_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgItemSize.DataSource = db.tblItemSizes.ToList();
        }
        protected void rgItemSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridDataItem selectedItem = (GridDataItem)rgItemSize.SelectedItems[0];
            txtItemSizeCode.Text = selectedItem["Id"].Text;
            txtItemSizeName.Text = selectedItem["Name"].Text;
            btnItemSizeEdit.Enabled = true;
            btnItemSizeDelete.Enabled = true;
            txtItemSizeCode.Enabled = false;
            lblItemSize.Text = "";
        }

        protected void rgPacking_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgPacking.DataSource = db.tblPackings.ToList();
        }
        protected void rgPacking_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridDataItem selectedItem = (GridDataItem)rgPacking.SelectedItems[0];
            txtPackingCode.Text = selectedItem["Id"].Text;
            txtPackingName.Text = selectedItem["Name"].Text;
            btnPackingEdit.Enabled = true;
            btnPackingDelete.Enabled = true;
            txtPackingCode.Enabled = false;
            lblPacking.Text = "";
        }

        protected void rgCostCenter_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgCostCenter.DataSource = db.tblCostCenters.ToList();
        }
        protected void rgCostCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridDataItem selectedItem = (GridDataItem)rgCostCenter.SelectedItems[0];
                txtCostCode.Text = selectedItem["Id"].Text;
                txtCostName.Text = selectedItem["Name"].Text;
                btnCostEdit.Enabled = true;
                btnCostDelete.Enabled = true;
                txtCostCode.Enabled = false;
                lblCost.Text = "";
            }
            catch (Exception ex)
            {
                lblCost.Text = ex.Message;
            }
        }

        protected void rgCostElements_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgCostElements.DataSource = db.tblCostElements.ToList();
        }
        protected void rgCostElements_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridDataItem selectedItem = (GridDataItem)rgCostElements.SelectedItems[0];
                txtCostElementCode.Text = selectedItem["Id"].Text;
                txtCostElementName.Text = selectedItem["Name"].Text;
                cmCostCenter.SelectedValue = selectedItem["CostCenterId"].Text;
                btnCostElementEdit.Enabled = true;
                btnCostElementDelete.Enabled = true;
                txtCostElementCode.Enabled = false;
                lblCostElement.Text = "";
            }
            catch (Exception ex)
            {
                lblCostElement.Text = ex.Message;
            }
        }

        protected void rgBank_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //rgBank.DataSource = db.tblBanks.ToList();
        }
        protected void rgBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridDataItem selectedItem = (GridDataItem)rgBank.SelectedItems[0];
            txtBankCode.Text = selectedItem["BankCode"].Text;
            txtBankName.Text = selectedItem["Name"].Text;
            btnBankEdit.Enabled = true;
            btnBankDelete.Enabled = true;
            lblBank.Text = "";
        }
    }
}