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
    
    public partial class Q5FBRegistration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-85EE4HM;Initial catalog=AWTAssignment;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Facebook(username,email,password) values('" + txtUName.Text + "','" + txtEmail.Text + "','" + txtPass.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmsg.Text = "Registered Successfully";
        }
    }
}