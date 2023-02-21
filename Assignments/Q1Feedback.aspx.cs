using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace AWTAsignment
{
    public partial class Q1 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-85EE4HM;Initial Catalog=AWTAssignment;Integrated Security=True");
            con.Open();
                SqlCommand cmd = new SqlCommand("insert into Feedback values(@name,@email,@feedback)", con);
                cmd.Parameters.AddWithValue("name", txtname.Text);
                cmd.Parameters.AddWithValue("email", txtemail.Text);
                cmd.Parameters.AddWithValue("feedback", txtfeedback.Text);
                cmd.ExecuteNonQuery();

                txtname.Text = "";
                txtemail.Text = "";
                txtfeedback.Text = "";

                con.Close();

                Response.Write("<script language='javascript'>alert('Record Saved Successfully')</script>");
            
        }
    }
}