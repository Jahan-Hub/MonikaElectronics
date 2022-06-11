using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;

namespace ElectronicsMS.Forms
{
    public partial class ItemInfo : Page
    {
        ElectronicsMSDBEntities db = new ElectronicsMSDBEntities();
        SqlConnection con;
        SqlCommand cmd;
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        public DataTable dtItems
        {
            get
            {
                object obj = this.Session["dtItems"];
                if (obj != null)
                {
                    return (DataTable)obj;
                }
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("rowid", typeof(Int32));
                dt1.Columns.Add("ItemCode", typeof(Int32));
                dt1.Columns.Add("ItemName", typeof(string));
                dt1.Columns.Add("ItemCatId", typeof(string));
                dt1.Columns.Add("CategoryName", typeof(string));
                dt1.Columns.Add("PurRate", typeof(string));
                dt1.Columns.Add("SalesRate", typeof(string));
                dt1.PrimaryKey = new DataColumn[] { dt1.Columns["rowid"] };
                this.Session["dtItems"] = dt1;
                return dtItems;
            }
        }
        public string GetAutoNumber(string fieldName, string tableName, string WhereCondition, string ControlName)
        {
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                string ss = "Select  convert(int,Max(" + fieldName + ")) from " + tableName + " where " + WhereCondition + "=" + ControlName + "";
                SqlCommand cmd = new SqlCommand(ss, con);

                con.Open();
                int x = (int)cmd.ExecuteScalar() + 1;
                return x.ToString();
            }
            catch (Exception)
            {
                string prefix = "001";
                txtItemCode.Text = cmCategory.SelectedValue + prefix;
                return txtItemCode.Text;
            }
            finally
            {
                con.Close();
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
                return "1";
            }
            finally
            {
                con.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ReloadMainGrid();
                EnableControl(false);
                ClearControl();
                ButtonControl("L");
                ViewState["Photo"] = null;
            }
        }

        public void EnableControl(bool ec)
        {
            txtItemName.Enabled = ec;
            txtPurchaseRate.Enabled = ec;
        }
        public void ButtonControl(string bc)
        {
            if (bc == "L")
            {
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = false;
                lblMessage.Text = "";
            }
            else if (bc == "N")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                lblMessage.Text = "";
            }
            else if (bc == "F")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = false;
                lblMessage.Text = "";
            }
            else if (bc == "E")
            {
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = true;
                btnCancel.Enabled = true;
                lblMessage.Text = "";
            }
        }
        public void ClearControl()
        {
            txtItemCode.Text = "";
            txtItemName.Text = "";
            txtPurchaseRate.Text = "0";
            txtSalesRate.Text = "0";
            txtMinStock.Text = "0";
            cmCategory.SelectedValue = "";
            cmCategory.Text = "";
            Image1.ImageUrl = null;
        }

        private void ReloadMainGrid()
        {
            this.dtItems.Clear();
            rgMain.Rebind();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("Sp_ItemInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = "5";
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            adpt.Fill(ds);
            dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow newRow = this.dtItems.NewRow();
                newRow["rowid"] = i + 1;
                newRow["ItemCode"] = Convert.ToInt32(dt.Rows[i]["ItemCode"].ToString());
                newRow["ItemName"] = dt.Rows[i]["ItemName"].ToString();
                newRow["ItemCatId"] = dt.Rows[i]["ItemCatId"].ToString();
                newRow["CategoryName"] = dt.Rows[i]["CategoryName"].ToString();
                newRow["PurRate"] = dt.Rows[i]["PurRate"].ToString();
                newRow["SalesRate"] = dt.Rows[i]["SalesRate"].ToString();

                this.dtItems.Rows.Add(newRow);
                this.dtItems.AcceptChanges();
            }
            rgMain.Rebind();
            cmd.Dispose();
            con.Close();
        }
        private void SaveData()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();
            try
            {
                cmd = new SqlCommand("Sp_ItemInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value =1;
                cmd.Parameters.Add("@ItemCode", SqlDbType.NVarChar).Value = txtItemCode.Text;
                cmd.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = textInfo.ToTitleCase(txtItemName.Text);
                cmd.Parameters.Add("@ItemCatId", SqlDbType.NVarChar).Value = cmCategory.SelectedValue;
                if (txtPurchaseRate.Text != "")
                    cmd.Parameters.Add("@PurRate", SqlDbType.Decimal).Value = txtPurchaseRate.Text;
                if (txtSalesRate.Text != "")
                    cmd.Parameters.Add("@SalesRate", SqlDbType.Decimal).Value = txtSalesRate.Text;
                cmd.Parameters.Add("@MaxQty", SqlDbType.Int).Value = 0;//txtMaxQty.Text;
                cmd.Parameters.Add("@MinQty", SqlDbType.Int).Value = txtMinStock.Text;
                cmd.Parameters.Add("@SupplierId", SqlDbType.NVarChar).Value = cmPartyName.SelectedValue;

                //int imglength = FileUpload2.PostedFile.ContentLength;
                //byte[] bytearray = new byte[imglength];
                //HttpPostedFile image = FileUpload2.PostedFile;
                //image.InputStream.Read(bytearray, 0, imglength);
                //if (FileUpload2.HasFile)
                //    cmd.Parameters.Add("@Photo", SqlDbType.Image).Value = bytearray;

                cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = AppEnv.Current.p_UserName.ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //cmd = new SqlCommand("Sp_ItemInfo", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 8;
                //cmd.Parameters.Add("@Itemcode", SqlDbType.Int).Value = txtItemCode.Text;
                //cmd.Parameters.Add("@MaxQty", SqlDbType.Int).Value = 0;// txtMaxQty.Text;
                //cmd.Parameters.Add("@MinQty", SqlDbType.Int).Value = 0;// txtMinQty.Text;
                //cmd.ExecuteNonQuery();
                //cmd.Dispose();

                con.Close();
                ReloadMainGrid();
                ButtonControl("L");
                cmCategory.Enabled = true;
                lblMessage.Text = "Item \"" + txtItemName.Text + "\" Saved Successfully.";
                ClearControl();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
            }
        }
        private void DataRefillForGrid()
        {
            GridDataItem selectedItem = (GridDataItem)rgMain.SelectedItems[0];
            ViewState["ItemCode"] = selectedItem["ItemCode"].Text;
            ViewState["rowid"] = selectedItem["rowid"].Text;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("Sp_ItemInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 6;
            cmd.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = selectedItem["ItemCode"].Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtItemCode.Text = dr["ItemCode"].ToString();
                txtItemName.Text = dr["ItemName"].ToString();
                txtPurchaseRate.Text = dr["PurRate"].ToString();
                txtSalesRate.Text = dr["SalesRate"].ToString();
                cmCategory.SelectedValue = dr["ItemCatId"].ToString();
                cmPartyName.SelectedValue = dr["SupplierId"].ToString();
                cmPartyName.Text = dr["SupplierName"].ToString();
                txtMinStock.Text = dr["MinQty"].ToString();
                //txtMinQty.Text = dr["MinQty"].ToString();
                //txtMaxQty.Text = dr["MaxQty"].ToString();
                ViewState["Photo"] = dr["Photo"];
                if(dr["Photo"].ToString()!="")
                {
                    byte[] bytes = (byte[])dr["Photo"];
                    if (bytes.Length > 0)
                    {
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        Image1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(MakeThumbnail(bytes, 100, 100), 0, (MakeThumbnail(bytes, 100, 100).Length));
                        Image1.DataBind();
                    }
                    ViewState["Photo"] = (byte[])dr["Photo"];
                }
            }
        }

        public static byte[] GetPhoto(string imageloc)
        {

            FileStream stream = new FileStream(imageloc, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }
        public static byte[] MakeThumbnail(byte[] myImage, int thumbWidth, int thumbHeight)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            using (System.Drawing.Image thumbnail = System.Drawing.Image.FromStream(new MemoryStream(myImage)).GetThumbnailImage(thumbWidth, thumbHeight, null, new IntPtr()))
            {
                thumbnail.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmCategory.SelectedValue == "")
                {
                    lblMessage.Text = "Select Category.";
                }
                else
                {
                    int max = Convert.ToInt32(GetAutoNumber("ItemCode", "tblItems", "ItemCatId", cmCategory.SelectedValue));
                    txtItemCode.Text = max.ToString();
                    EnableControl(true);
                    cmCategory.Enabled = false;
                    lblMessage.Text = "";
                    ButtonControl("N");
                    txtItemName.Focus();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtItemCode.Text == "")
            {
                lblMessage.Text = "Item Code can not be blank.";
            }
            else if (txtItemName.Text == "")
            {
                lblMessage.Text = "Item Name can not be blank.";
            }
            //else if (cmPack.SelectedValue == "")
            //{
            //    lblMessage.Text = "Select Pack.";
            //}
            //else if (cmItemSize.SelectedValue == "")
            //{
            //    lblMessage.Text = "Select Item Size.";
            //}
            else if (cmCategory.SelectedValue == "")
            {
                lblMessage.Text = "Select Category.";
            }
            //else if (txtMaxQty.Text == "0")
            //{
            //    lblMessage.Text = "Max Qty can not be blank.";
            //}
            //else if (txtMinQty.Text == "0")
            //{
            //    lblMessage.Text = "Min Qty can not be blank.";
            //}
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
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EnableControl(true);
            ButtonControl("E");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
            EnableControl(false);
            cmCategory.Enabled = true;
            ButtonControl("L");
        }
        protected void rgMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                DataRefillForGrid();
                ButtonControl("E");
                EnableControl(true);
                cmCategory.Enabled = false;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void FileUpload2_DataBinding(object sender, EventArgs e)
        {
            try
            {
                //byte[] bytes = (byte[])(FileUpload2.FileBytes);
                //Image1.ImageUrl = (System.IO.Path.GetFileName(FileUpload2.FileName)).ToString();
                //Image1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(MakeThumbnail(bytes, 100, 100), 0, (MakeThumbnail(bytes, 100, 100).Length));
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void cmCategory_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (cmCategory.SelectedValue == "")
                {
                    lblMessage.Text = "Select Category.";
                }
                else
                {
                    lblMessage.Text = "";
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("Sp_ItemInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 7;
                    cmd.Parameters.Add("@ItemCatId", SqlDbType.Int).Value = cmCategory.SelectedValue;
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    adpt.Fill(ds);
                    dt = ds.Tables[0];

                    rgMain.DataSource = dt;
                    rgMain.DataBind();
                }
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
                cmd = new SqlCommand("Sp_ItemInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mode", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = txtItemCode.Text;
                cmd.ExecuteNonQuery();
                con.Close();

                ReloadMainGrid();
                ButtonControl("L");
                lblMessage.Text = "Item Name \"" + txtItemName.Text + "\" Deleted Successfully.";
                ClearControl();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void rgMain_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgMain.DataSource = this.dtItems;
        }

        protected void btnSaveMaster_Click(object sender, EventArgs e)
        {
            if (ViewState["btnType"].ToString() == "ItemSize")
            {
                tblItemSize tbl = new tblItemSize();
                tbl.Id = Convert.ToInt32(txtCodeMaster.Text);
                tbl.Name = txtNameMaster.Text;
                db.tblItemSizes.Add(tbl);
                db.SaveChanges();

                lblMessagePopup.Text = txtNameMaster.Text + " Saved Successfully.";
                txtNameMaster.Text = "";
                txtCodeMaster.Text = "";
                int max = Convert.ToInt32(GetAutoNumber("Id", "tblItemSize"));
                txtCodeMaster.Text = max.ToString();
            }
            if (ViewState["btnType"].ToString() == "ItemType")
            {
                tblPacking tbl = new tblPacking();
                tbl.Id = Convert.ToInt32(txtCodeMaster.Text);
                tbl.Name = txtNameMaster.Text;
                db.tblPackings.Add(tbl);
                db.SaveChanges();

                lblMessagePopup.Text = txtNameMaster.Text + " Saved Successfully.";
                txtNameMaster.Text = "";
                txtCodeMaster.Text = "";
                int max = Convert.ToInt32(GetAutoNumber("Id", "tblPacking"));
                txtCodeMaster.Text = max.ToString();
            }
            if (ViewState["btnType"].ToString() == "Category")
            {
                tblCategory tbl = new tblCategory();
                tbl.CatId = Convert.ToInt32(txtCodeMaster.Text);
                tbl.Name = txtNameMaster.Text;
                db.tblCategories.Add(tbl);
                db.SaveChanges();
                cmCategory.DataBind();

                lblMessagePopup.Text = txtNameMaster.Text + " Saved Successfully.";
                txtNameMaster.Text = "";
                txtCodeMaster.Text = "";
                int max = Convert.ToInt32(GetAutoNumber("CatId", "tblCategory"));
                txtCodeMaster.Text = max.ToString();
            }
        }
        protected void btnCancelMaster_Click(object sender, EventArgs e)
        {
            txtNameMaster.Text = "";
            txtCodeMaster.Text = "";
            RadWindow1.VisibleOnPageLoad = false;
        }
        protected void btnItemSize_Click(object sender, EventArgs e)
        {
            lblMessagePopup.Text = "";
            lblInsertType.Text = "Insert Item Size";
            ViewState["btnType"] = "ItemSize";
            int max = Convert.ToInt32(GetAutoNumber("Id", "tblItemSize"));
            txtCodeMaster.Text = max.ToString();
            txtNameMaster.Text = "";
            RadWindow1.VisibleOnPageLoad = true;
        }
        protected void btnPackType_Click(object sender, EventArgs e)
        {
            lblMessagePopup.Text = "";
            lblInsertType.Text = "Insert Pack";
            ViewState["btnType"] = "ItemType";
            int max = Convert.ToInt32(GetAutoNumber("Id", "tblPacking"));
            txtCodeMaster.Text = max.ToString();
            txtNameMaster.Text = "";
            RadWindow1.VisibleOnPageLoad = true;
        }
        protected void btnCategory_Click(object sender, EventArgs e)
        {
            lblMessagePopup.Text = "";
            lblInsertType.Text = "Insert Category";
            ViewState["btnType"] = "Category";
            int max = Convert.ToInt32(GetAutoNumber("CatId", "tblCategory"));
            txtCodeMaster.Text = max.ToString();
            txtNameMaster.Text = "";
            RadWindow1.VisibleOnPageLoad = true;
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
    }
}