using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Text;
using Newtonsoft.Json;
//using System.Web.UI.DataVisualization.Charting;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using FusionCharts;
using FusionCharts.Charts;

public partial class temperature : System.Web.UI.Page
{
    private MySqlConnection con;
    private MySqlCommand com;
    private string Constring, query;
    public string desiredDate;
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

        //var dateAndTime = DateTime.Now;
        //var test = dateAndTime.Date;
        string curdate = DateTime.Now.ToString("dd/MM/yyyy");
        var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);
       

        labeldate.Text = now.ToString("dd/MM/yyyy");

        //String dy = test.Day.ToString();
        //String mn = test.Month.ToString();
        //String yy = test.Year.ToString();
        // string strDate = "2022/08/29"; //Format - dd/MM/yyyy
        //split string date by separator, here I'm using '/'



    string[] arrDate = curdate.Split('/');
        //now use array to get specific date object
        string day = arrDate[0].ToString();
        string month = arrDate[1].ToString();
        string year = arrDate[2].ToString();
        arrDate[0] = day;
        
        //string hh = test.Hour.ToString();

        string finaldate = arrDate[2] + "/" + arrDate[1] + "/" +arrDate[0] ;
        string finaldate1 = finaldate + " " + "08" + ":" + "30";
        string finaldate2 = finaldate + " " + "23" + ":" + "59";
        label1.Text = finaldate;
        label.Text = finaldate1;
        label2.Text = finaldate2;

        connection();
        query = "select Timestamp,AmbTemperature,Humidity from weather_daily_data where StationName='CWPRS' AND  Timestamp between '" + finaldate1 + "'AND '" + finaldate2 + "' order by timestamp desc limit 100";//not recommended this i have written just for example,write stored procedure for security    
        com = new MySqlCommand(query, con);
        MySqlDataAdapter da = new MySqlDataAdapter(query, con);
        DataTable ds = new DataTable();
        da.Fill(ds);

        string[] Timestamp = new string[100];
        string[] AmbTemperature = new string[100];
        string[] Humidity = new string[100];


        //var time1 = Timestamp[0];
        //var time2 = Timestamp[1];
        //var time3 = Timestamp[2];
        //var time4 = Timestamp[3];

        for (int i = 0; i < ds.Rows.Count; i++)
        {
            AmbTemperature[i] = ds.Rows[i][1].ToString();

            String currenttime = ds.Rows[i][0].ToString();
            var words = currenttime.Split(' ');
            DateTime time = Convert.ToDateTime(words[1].ToString());


            string date = time.ToString("HH:mm");
            Timestamp[i] = date.ToString();

            Humidity[i] = ds.Rows[i][2].ToString();

        }



        // This page demonstrates the ease of generating charts using FusionCharts.
        // For this chart, we've used a pre-defined Data.xml (contained in /Data/ folder)
        // Ideally, you would NOT use a physical data file. Instead you'll have
        // your own ASP.NET scripts virtually relay the XML data document.
        // FusionCharts supports various data format, please comment the code for
        // current data format (Chart.DataFormat.xmlurl) and uncomment the required format to view respective examples.
        // For a head-start, we've kept this example very simple.

        // Create the chart - spline Chart with data from Data/Data.xml
        Chart sales1 = new Chart();

        // Setting chart id
        sales1.SetChartParameter(Chart.ChartParameter.chartId, "myChart12");

        // Setting chart type to spline chart
        sales1.SetChartParameter(Chart.ChartParameter.chartType, "spline");

        // Setting chart width to 600px
        sales1.SetChartParameter(Chart.ChartParameter.chartWidth, "1000");

        // Setting chart height to 350px
        sales1.SetChartParameter(Chart.ChartParameter.chartHeight, "350");
        //        String me = "Pratiksha";
        //int tenp = 15;

        // Setting chart data as JSON String (Uncomment below line
        sales1.SetData("{\n  \"chart\": {\n    \"caption\": \"  \",\n    \"yaxisname\": \" \",\n    \"anchorradius\": \"1\",\n    \"plottooltext\": \" temperature in $label is <b>$dataValue</b>\",\n    \"showhovereffect\": \"1\",\n    \"showvalues\": \"0\",\n    \"numbersuffix\": \"°C\",\n    \"theme\": \"fusion\",\n    \"anchorbgcolor\": \"#000033\",\n    \"palettecolors\": \"#000080\"\n  },\n  \"data\": [\n    {\n      \"label\": \"" + Timestamp[0] + "\",\n       \"value\": \"" + AmbTemperature[0] + "\"\n   },\n    {\n      \"label\": \"" + Timestamp[1] + "\",\n      \"value\": \"" + AmbTemperature[1] + "\"\n    },\n    {\n      \"label\": \"" + Timestamp[2] + "\",\n      \"value\": \"" + AmbTemperature[2] + "\"\n    },\n    {\n      \"label\": \"" + Timestamp[3] + "\",\n      \"value\": \"" + AmbTemperature[3] + "\"\n    },\n    {\n      \"label\": \"" + Timestamp[4] + "\",\n      \"value\": \"" + AmbTemperature[4] + "\"\n    },\n    {\n      \"label\": \"" + Timestamp[5] + "\",\n      \"value\": \"" + AmbTemperature[5] + "\"\n    },\n    {\n      \"label\": \"" + Timestamp[6] + "\",\n      \"value\": \"" + AmbTemperature[6] + "\"\n    },\n    {\n      \"label\": \"" + Timestamp[7] + "\",\n      \"value\": \"" + AmbTemperature[7] + "\"\n    },\n    {\n      \"label\": \"" + Timestamp[8] + "\",\n      \"value\": \"" + AmbTemperature[8] + "\"\n    },\n    {\n      \"label\": \"" + Timestamp[9] + "\",\n      \"value\": \"" + AmbTemperature[9] + "\"\n    },\n    {\n      \"label\": \"" + Timestamp[10] + "\",\n      \"value\": \"" + AmbTemperature[10] + "\"\n    },\n {\n      \"label\": \"" + Timestamp[11] + "\",\n      \"value\": \"" + AmbTemperature[11] + "\"\n    },\n    {\n      \"label\": \"" + Timestamp[12] + "\",\n      \"value\": \"" + AmbTemperature[12] + "\"\n    },\n {\n      \"label\": \"" + Timestamp[13] + "\",\n       \"value\": \"" + AmbTemperature[13] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[14] + "\",\n       \"value\": \"" + AmbTemperature[14] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[15] + "\",\n       \"value\": \"" + AmbTemperature[15] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[16] + "\",\n       \"value\": \"" + AmbTemperature[16] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[17] + "\",\n       \"value\": \"" + AmbTemperature[17] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[18] + "\",\n       \"value\": \"" + AmbTemperature[18] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[19] + "\",\n       \"value\": \"" + AmbTemperature[19] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[20] + "\",\n       \"value\": \"" + AmbTemperature[20] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[21] + "\",\n       \"value\": \"" + AmbTemperature[21] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[22] + "\",\n       \"value\": \"" + AmbTemperature[22] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[23] + "\",\n       \"value\": \"" + AmbTemperature[23] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[24] + "\",\n       \"value\": \"" + AmbTemperature[24] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[25] + "\",\n       \"value\": \"" + AmbTemperature[25] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[26] + "\",\n       \"value\": \"" + AmbTemperature[26] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[27] + "\",\n       \"value\": \"" + AmbTemperature[27] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[28] + "\",\n       \"value\": \"" + AmbTemperature[28] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[29] + "\",\n       \"value\": \"" + AmbTemperature[29] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[30] + "\",\n       \"value\": \"" + AmbTemperature[30] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[31] + "\",\n       \"value\": \"" + AmbTemperature[31] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[32] + "\",\n       \"value\": \"" + AmbTemperature[32] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[33] + "\",\n       \"value\": \"" + AmbTemperature[33] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[34] + "\",\n       \"value\": \"" + AmbTemperature[34] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[35] + "\",\n       \"value\": \"" + AmbTemperature[35] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[36] + "\",\n       \"value\": \"" + AmbTemperature[36] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[37] + "\",\n       \"value\": \"" + AmbTemperature[37] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[38] + "\",\n       \"value\": \"" + AmbTemperature[38] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[39] + "\",\n       \"value\": \"" + AmbTemperature[39] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[40] + "\",\n       \"value\": \"" + AmbTemperature[40] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[41] + "\",\n       \"value\": \"" + AmbTemperature[41] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[42] + "\",\n       \"value\": \"" + AmbTemperature[42] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[43] + "\",\n       \"value\": \"" + AmbTemperature[43] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[44] + "\",\n       \"value\": \"" + AmbTemperature[44] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[45] + "\",\n       \"value\": \"" + AmbTemperature[45] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[46] + "\",\n       \"value\": \"" + AmbTemperature[46] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[47] + "\",\n       \"value\": \"" + AmbTemperature[47] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[48] + "\",\n       \"value\": \"" + AmbTemperature[48] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[49] + "\",\n       \"value\": \"" + AmbTemperature[49] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[50] + "\",\n       \"value\": \"" + AmbTemperature[50] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[51] + "\",\n       \"value\": \"" + AmbTemperature[51] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[52] + "\",\n       \"value\": \"" + AmbTemperature[52] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[53] + "\",\n       \"value\": \"" + AmbTemperature[53] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[54] + "\",\n       \"value\": \"" + AmbTemperature[54] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[55] + "\",\n       \"value\": \"" + AmbTemperature[55] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[56] + "\",\n       \"value\": \"" + AmbTemperature[56] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[57] + "\",\n       \"value\": \"" + AmbTemperature[57] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[58] + "\",\n       \"value\": \"" + AmbTemperature[58] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[59] + "\",\n       \"value\": \"" + AmbTemperature[59] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[60] + "\",\n       \"value\": \"" + AmbTemperature[60] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[61] + "\",\n       \"value\": \"" + AmbTemperature[61] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[62] + "\",\n       \"value\": \"" + AmbTemperature[62] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[63] + "\",\n       \"value\": \"" + AmbTemperature[63] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[64] + "\",\n       \"value\": \"" + AmbTemperature[64] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[65] + "\",\n       \"value\": \"" + AmbTemperature[65] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[66] + "\",\n       \"value\": \"" + AmbTemperature[66] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[67] + "\",\n       \"value\": \"" + AmbTemperature[67] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[68] + "\",\n       \"value\": \"" + AmbTemperature[68] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[69] + "\",\n       \"value\": \"" + AmbTemperature[69] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[70] + "\",\n       \"value\": \"" + AmbTemperature[70] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[71] + "\",\n       \"value\": \"" + AmbTemperature[71] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[72] + "\",\n       \"value\": \"" + AmbTemperature[72] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[73] + "\",\n       \"value\": \"" + AmbTemperature[73] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[74] + "\",\n       \"value\": \"" + AmbTemperature[74] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[75] + "\",\n       \"value\": \"" + AmbTemperature[75] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[76] + "\",\n       \"value\": \"" + AmbTemperature[76] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[77] + "\",\n       \"value\": \"" + AmbTemperature[77] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[78] + "\",\n       \"value\": \"" + AmbTemperature[78] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[79] + "\",\n       \"value\": \"" + AmbTemperature[79] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[80] + "\",\n       \"value\": \"" + AmbTemperature[80] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[81] + "\",\n       \"value\": \"" + AmbTemperature[81] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[82] + "\",\n       \"value\": \"" + AmbTemperature[82] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[83] + "\",\n       \"value\": \"" + AmbTemperature[83] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[84] + "\",\n       \"value\": \"" + AmbTemperature[84] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[85] + "\",\n       \"value\": \"" + AmbTemperature[85] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[86] + "\",\n       \"value\": \"" + AmbTemperature[86] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[87] + "\",\n       \"value\": \"" + AmbTemperature[87] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[88] + "\",\n       \"value\": \"" + AmbTemperature[88] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[89] + "\",\n       \"value\": \"" + AmbTemperature[89] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[90] + "\",\n       \"value\": \"" + AmbTemperature[90] + "\"\n   },\n {\n      \"label\": \"" + Timestamp[91] + "\",\n       \"value\": \"" + AmbTemperature[91] + "\"\n   },\n ]\n}", Chart.DataFormat.json);


        literal.Text = sales1.Render();

    }

}

