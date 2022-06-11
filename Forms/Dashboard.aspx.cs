using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using Telerik.Web.UI;

namespace ElectronicsMS.Forms
{
    public partial class Dashboard : Page
    {
        SqlConnection con;
        SqlCommand Cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ElectronicsCon"].ConnectionString);
            con.Open();
            Cmd = new SqlCommand("Sp_Dashboard", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@Mode", SqlDbType.Int).Value = 1;
            SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
            DataSet ds = new DataSet();
            DataTable dt0 = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();

            adapter.Fill(ds);
            dt0 = ds.Tables[0];
            dt1 = ds.Tables[1];
            dt2 = ds.Tables[2];
            dt3 = ds.Tables[3];
            dt4 = ds.Tables[4];
            dt5 = ds.Tables[5];
            dt6 = ds.Tables[6];

            rgCount.DataSource = dt0;
            rgCount.Rebind();

            rgMaxMinStockQty.DataSource = dt1;
            rgMaxMinStockQty.Rebind();

            rgTotalSummary.DataSource = dt2;
            rgTotalSummary.Rebind();

            rgNotification.DataSource = dt3;
            rgNotification.Rebind();

            Radticker1.DataSource = dt4;
            Radticker1.DataTextField = "Description";
            Radticker1.DataBind();

            rgInFlow.DataSource = dt5;
            rgInFlow.Rebind();

            rgOutFlow.DataSource = dt6;
            rgOutFlow.Rebind();

            //TopChart.PlotArea.Series.Clear();
            PieSeries curCol = new PieSeries();
            PieSeries OldCol = new PieSeries();

            OldCol.DataFieldY = dt0.Columns[0].Caption;

            //TopChart.PlotArea.Series.Add(curCol);
            //TopChart.PlotArea.Series.Add(OldCol);

            //TopChart.PlotArea.XAxis.DataLabelsField = dt1.Columns[0].Caption.ToString();
            //TopChart.PlotArea.XAxis.Visible = true;
            con.Close();
        }
    }
}