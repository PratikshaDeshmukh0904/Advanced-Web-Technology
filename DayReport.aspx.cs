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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;


public partial class DayReport : System.Web.UI.Page
{
    public static string StationName;
    public static string Timestamp;
    protected void Page_Load(object sender, EventArgs e)
    {
        string json = (new WebClient()).DownloadString("http://late.aashayweather.com/api/weather/cwprstest.php?StationName=cwprs");
        var obj = JsonConvert.DeserializeObject<DataTable>(json);

        string Timestamp = obj.Rows[0][0].ToString();

        string Constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        MySqlConnection con = new MySqlConnection(Constring);
        con.Open();
        MySqlCommand cmd = new MySqlCommand("select Timestamp,AmbTemperature,Humidity,Rain_last10min AS `RainFall0.2`,AirPressure AS `AirPressure(MSLP)`,AtmPressureMSLP AS `AirPressure(SLP)`, Extrachannel AS `WindSpeed-Ultrasonic`, TZ AS `WindDirection-Ultrasonic`,SolarRadiation AS `SolarRadiation(W / M2)`, RainfalTodayTotal AS `RainFall2-Total`, WindSpeed AS `WindSpeed-CUP(m / s)`,Winddirection AS `WindDirection-Vane(Deg)`, SupplyVtg AS `SupplyVoltage(V)`, aaa As TZ, PWR5V, star from weather_daily_data where StationName = 'CWPRS' AND Timestamp='" + Timestamp + "'", con);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void show_Click(object sender, EventArgs e)
    {
        
        string timestamp = Request.Form["DATE"];
        //timestamp = timestamp.Replace('-', '/');
        DateTime d = DateTime.Parse(timestamp);
        string formatted = d.ToString("yyyy/MM/dd");
        formatted = formatted.Replace('-', '/');

        string timestamp1 = Request.Form["enddate"];
            //timestamp = timestamp.Replace('-', '/');
        DateTime d1 = DateTime.Parse(timestamp1);
        string formatted1 = d1.ToString("yyyy/MM/dd");
        formatted1 = formatted1.Replace('-', '/');


        string Constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        MySqlConnection con = new MySqlConnection(Constring);
        con.Open();
        //MySqlCommand cmd = new MySqlCommand("select AmbTemperature,Humidity,AtmPressureMSLP,WindSpeed,Winddirection,SolarRadiation,Rain_last10min from weather_daily_data where StationName='CWPRS' AND  Timestamp LIKE '%" + formatted + "%' ", con);
        //MySqlCommand cmd = new MySqlCommand("select Timestamp,AmbTemperature,Humidity,AtmPressureMSLP,WindSpeed,Winddirection,SolarRadiation,Rain_last10min from weather_daily_data where StationName='CWPRS' AND  Timestamp between '" + formatted + "'AND '" + formatted1 + "' ORDER BY Timestamp desc", con);
        MySqlCommand cmd = new MySqlCommand("select Timestamp,AmbTemperature,Humidity,Rain_last10min AS `RainFall0.2`,AirPressure AS `AirPressure(MSLP)`,AtmPressureMSLP AS `AirPressure(SLP)`, Extrachannel AS `WindSpeed-Ultrasonic`, TZ AS `WindDirection-Ultrasonic`,SolarRadiation AS `SolarRadiation(W / M2)` from weather_daily_data where StationName='CWPRS' AND STR_TO_DATE(Timestamp, '%Y/%m/%d') between STR_TO_DATE('" + formatted + "', '%Y/%m/%d') AND STR_TO_DATE('"+ formatted1 +"', '%Y/%m/%d') ORDER BY Timestamp desc", con);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        con.Close();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the run time error "  
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
    }
    protected void export_Click(object sender, EventArgs e)
    {
        ExportGridToExcel();
    }
    private void ExportGridToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Weather_Daily_Data" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        GridView1.GridLines = GridLines.Both;
        GridView1.HeaderStyle.Font.Bold = true;
        GridView1.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();

    }

    private void bindgrid()
    {
        string timestamp = Request.Form["DATE"];
        //timestamp = timestamp.Replace('-', '/');
        DateTime d = DateTime.Parse(timestamp);
        string formatted = d.ToString("yyyy/MM/dd");
        formatted = formatted.Replace('-', '/');

        string timestamp1 = Request.Form["enddate"];
        //timestamp = timestamp.Replace('-', '/');
        DateTime d1 = DateTime.Parse(timestamp1);
        string formatted1 = d1.ToString("yyyy/MM/dd");
        formatted1 = formatted1.Replace('-', '/');




        string Constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        MySqlConnection con = new MySqlConnection(Constring);
        con.Open();
        //MySqlCommand cmd = new MySqlCommand("select AmbTemperature,Humidity,AtmPressureMSLP,WindSpeed,Winddirection,SolarRadiation,Rain_last10min from weather_daily_data where StationName='CWPRS' AND  Timestamp LIKE '%" + formatted + "%' ", con);
        //MySqlCommand cmd = new MySqlCommand("select StationName,Timestamp,AmbTemperature,Humidity,AtmPressureMSLP,WindSpeed,Winddirection,SolarRadiation,Rain_last10min from weather_daily_data where StationName='CWPRS' AND  Timestamp between '" + formatted + "'and '" + formatted1 + "' ORDER BY Timestamp desc", con);
        MySqlCommand cmd = new MySqlCommand("select StationName,Timestamp,AmbTemperature,Humidity,Rain_last10min AS `RainFall0.2`,AirPressure AS `AirPressure(MSLP)`,AtmPressureMSLP AS `AirPressure(SLP)`, Extrachannel AS `WindSpeed-Ultrasonic`, TZ AS `WindDirection-Ultrasonic`,SolarRadiation AS `SolarRadiation(W / M2)`from weather_daily_data where StationName='CWPRS' AND STR_TO_DATE(Timestamp, '%Y/%m/%d') between STR_TO_DATE('" + formatted +"', '%Y/%m/%d') AND STR_TO_DATE('"+ formatted1 +"', '%Y/%m/%d') ORDER BY Timestamp desc", con);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        Gridview2.DataSource = dt;
        Gridview2.DataBind();



        con.Close();
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview2.PageIndex = e.NewPageIndex;
        this.bindgrid();
    }

    protected void pdfclick_Click(object sender, EventArgs e)
    {
        bindgrid();

        string timestamp = Request.Form["DATE"];
        //timestamp = timestamp.Replace('-', '/');
        DateTime d = DateTime.Parse(timestamp);
        string formatted = d.ToString("yyyy/MM/dd");
        formatted = formatted.Replace('-', '/');

        string timestamp1 = Request.Form["enddate"];
        //timestamp = timestamp.Replace('-', '/');
        DateTime d1 = DateTime.Parse(timestamp1);
        string formatted1 = d1.ToString("yyyy/MM/dd");
        formatted1 = formatted1.Replace('-', '/');



        string Constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        MySqlConnection con = new MySqlConnection(Constring);
        con.Open();
        //MySqlCommand cmd = new MySqlCommand("select StationName,Timestamp,AmbTemperature,Humidity,AtmPressureMSLP,WindSpeed,Winddirection,SolarRadiation,Rain_last10min from weather_daily_data where StationName='CWPRS' AND  Timestamp LIKE '%" + formatted + "%' ", con);
        //MySqlCommand cmd = new MySqlCommand("select StationName,Timestamp, AmbTemperature,Humidity,AtmPressureMSLP,WindSpeed,Winddirection,SolarRadiation,Rain_last10min from weather_daily_data where StationName='CWPRS' AND  Timestamp between '" + formatted + "'and '" + formatted1 + "' ORDER BY Timestamp desc", con);
        MySqlCommand cmd = new MySqlCommand("select StationName,Timestamp,AmbTemperature,Humidity,Rain_last10min AS `RainFall0.2`,AirPressure AS `AirPressure(MSLP)`,AtmPressureMSLP AS `AirPressure(SLP)`, Extrachannel AS `WindSpeed-Ultrasonic`, TZ AS `WindDirection-Ultrasonic`,SolarRadiation AS `SolarRadiation(W / M2)` from weather_daily_data where StationName='CWPRS' AND STR_TO_DATE(Timestamp, '%Y/%m/%d') between STR_TO_DATE('" + formatted +"', '%Y/%m/%d') AND STR_TO_DATE('"+ formatted1 +"', '%Y/%m/%d') ORDER BY Timestamp desc", con);
        var obj = cmd.ExecuteReader();
        if (obj.Read())
        {
            StationName = (obj["StationName"].ToString());
            Timestamp = (obj["Timestamp"].ToString());

        }
        con.Close();
        PdfPTable pdfTable = new PdfPTable(Gridview2.HeaderRow.Cells.Count);

        foreach (TableCell headerCell in Gridview2.HeaderRow.Cells)
        {

            iTextSharp.text.Font font = new iTextSharp.text.Font();
            font.Color = new BaseColor(Gridview2.HeaderStyle.ForeColor);


            PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text, font));
            pdfCell.BackgroundColor = new BaseColor(Gridview2.HeaderStyle.BackColor);
            pdfTable.AddCell(pdfCell);
        }
        foreach (GridViewRow gridViewRow in Gridview2.Rows)
        {
            foreach (TableCell tableCell in gridViewRow.Cells)
            {
                iTextSharp.text.Font font = new iTextSharp.text.Font();
                font.Color = new BaseColor(Gridview2.RowStyle.ForeColor);

                PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text));
                pdfCell.BackgroundColor = new BaseColor(Gridview2.RowStyle.BackColor);
                pdfTable.AddCell(pdfCell);
            }
        }

        //Set the Size of PDF document.
        Rectangle rect = new Rectangle(1500, 1500);
        //Document pdfDocument = new Document(rect, 30f, 30f, 30f, 0f);

        Document pdfDocument = new Document(PageSize.A4, -5f, -5f, -4f, -5f);
        PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

        pdfDocument.Open();
        //add image to pdf
        byte[] file;
        file = System.IO.File.ReadAllBytes(Server.MapPath(@"~/img/logo_01.jpg"));//ImagePath    
        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(file);
        jpg.ScaleToFit(550F, 200F);//Set width and height in float
        jpg.Alignment = Element.ALIGN_CENTER;
        pdfDocument.Add(jpg);

        Paragraph para0 = new Paragraph(" ");
        pdfDocument.Add(para0);

        string text = @"StationName = " + " " + "" + StationName + "";
        Paragraph para = new Paragraph(text);
        para.Alignment = Element.ALIGN_CENTER;
        pdfDocument.Add(para);

        string text1 = @"Timestamp = " + " " + "" + Timestamp + "";
        Paragraph para1 = new Paragraph(text1);
        para1.Alignment = Element.ALIGN_CENTER;
        pdfDocument.Add(para1);


        Paragraph para7 = new Paragraph("  ");
        pdfDocument.Add(para7);

        Paragraph paragraph = new Paragraph();
        paragraph.SpacingBefore = 10f;
        paragraph.SpacingAfter = 10f;
        paragraph.Alignment = Element.ALIGN_RIGHT;
        paragraph.Font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15f, BaseColor.BLACK);

        pdfDocument.Add(paragraph);

        pdfDocument.Add(pdfTable);
        pdfDocument.Close();

        Response.ContentType = "application/pdf";
        Response.AppendHeader("content-disposition", "attachment;filename=weather_daily_data.pdf");
        Response.Write(pdfDocument);
        Response.Flush();
        Response.End();
    }
}