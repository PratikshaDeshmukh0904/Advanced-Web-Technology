using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using System.Web.UI.DataVisualization.Charting;

public partial class samplechart : System.Web.UI.Page
{
    private MySqlConnection con;
    private MySqlCommand com;
    private string Constring, query;
    private void connection()
    {
         Constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
         con = new MySqlConnection(Constring);
        con.Open();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bindchart();

        }
    }
    private void Bindchart()
    {
        connection();
        query = "select `AirTemperature(AVG)`,id from weather_monthly_data where StationName='CWPRS'";//not recommended this i have written just for example,write stored procedure for security    
        com = new MySqlCommand(query, con);
        MySqlDataAdapter da = new MySqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable ChartData = ds.Tables[0];
        //storing total rows count to loop on each Record    
        string[] XPointMember = new string[ChartData.Rows.Count];
        int[] YPointMember = new int[ChartData.Rows.Count];
        for (int count = 0; count < ChartData.Rows.Count; count++)
        {
            //storing Values for X axis    
            XPointMember[count] = ChartData.Rows[count]["AirTemperature(AVG)"].ToString();
            //storing values for Y Axis    
            YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["id"]);
        }
        //binding chart control    
        Chart1.Series[0].Points.DataBindXY(XPointMember, YPointMember);
        //Setting width of line    
        Chart1.Series[0].BorderWidth = 1;
        //setting Chart type     
        Chart1.Series[0].ChartType = SeriesChartType.Line;
        // Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;    
        // Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;    
        //  Chart1.Series[0].ChartType = SeriesChartType.Spline;    
        //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;   
        con.Close();
    }
}