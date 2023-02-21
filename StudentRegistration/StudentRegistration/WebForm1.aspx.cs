using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class WebForm1 : System.Web.UI.Page
    {

    SqlConnection cn = new SqlConnection(@"Data Source=.\sqlExpress;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }
        void loadData()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Studinfo", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Load(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            cn.Close();

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("Insert into Studinfo(Sid,Sname,Contact,Email,DOB,Class,Marks) VALUES (" + Convert.ToInt16(TextBox1.Text) + ",'" + TextBox2.Text + "','" + Convert.ToInt16(TextBox3.Text) + "','" + TextBox4.Text + "','" + Convert.ToInt16(TextBox5.Text) + "','" + DropDownList1.SelectedItem.Text + "','" + TextBox6.Text + "')", cn);
            cmd.ExecuteNonQuery();
            cn.Close();

            Response.Write("<script language='javascript'> alert('Record Inserted Successfully') </script>");
            loadData();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        { 

        }




        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
