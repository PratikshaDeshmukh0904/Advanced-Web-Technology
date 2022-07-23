using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Drawing;

public partial class admin_AgentHistory : System.Web.UI.Page
{
    public int count = 0;
 
    protected void Page_Load(object sender, EventArgs e)
    {

     
       
    }

    protected void btn_search_agent_history_Click(object sender, EventArgs e)
    {
        string RegDate = txtRegDate.Value;

        string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        con.Open();
        string var = txtRegDate.Value;

        SqlCommand cmd = new SqlCommand("select count(*) from Registration where RegDate='" + var + "'", con);
      
        count = Convert.ToInt32(cmd.ExecuteScalar());
        SqlDataAdapter da = new SqlDataAdapter("Select FullName,FullAddress,ReferalCode,ContentType,RegDate from Registration WHERE RegDate='" + txtRegDate.Value + "' AND  ReferalCode='" + refferalcode.Text + "'", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        grdView1.DataSource = dt;
        grdView1.DataBind();

    }
    //public int Total_var(string Registration)
    //{
    //    string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
    //    SqlConnection con = new SqlConnection(connectionString);
    //    con.Open();
    //    string var = txtRegDate.Value;
        
    //    SqlCommand cmd = new SqlCommand("select count(*) from " + Registration + " where RegDate='" + var + "'", con);
    //    int Count = 0;
    //    Count = Convert.ToInt32(cmd.ExecuteScalar());
        
    //    con.Close();
     
    //    return Count;
    //}
    //public DataTable DisplayHistory()
    //{
    //    string RegDate = txtRegDate.Value;



    //    //date = Convert.ToDateTime(date);
    //    string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
    //    SqlConnection con = new SqlConnection(connectionString);

    //    con.Open();
    //    SqlDataAdapter da = new SqlDataAdapter("Select FullName,FullAddress ,ReferalCode,ContentType,RegDate from Registration WHERE RegDate='" + txtRegDate.Value + "' AND ReferalCode='" + refferalcode.Text + "' ", con);
    //    DataTable dt = new DataTable();
    //    da.Fill(dt);
    //    grdView1.DataSource = dt;
    //    grdView1.DataBind();
    //    return dt;
    //}


    





}
   


    //protected void grdView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        DataRowView dr = (DataRowView)e.Row.DataItem;
    //        string imageUrl = "../images/banner.png", + Convert.ToBase64String((byte[])dr["Data"]);
    //        (e.Row.FindControl("Image") as Image).ImageUrl = imageUrl;
    //    }
    //}
