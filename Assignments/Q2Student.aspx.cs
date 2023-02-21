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
    public partial class Q2Student : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-85EE4HM;Initial Catalog=AWTAssignment;Integrated Security=True");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd1 = new SqlCommand("insert into Student(sname,contact,dob,email,class,marks,gender) values('"+txtSName.Text+"','"+Convert.ToInt32(txtContact.Text)+"','"+Convert.ToDateTime(txtDOB.Text)+"','"+txtEmail.Text+"','"+ddlClass.SelectedItem.Text+"','"+Convert.ToInt32(txtMarks.Text)+"','"+chkGender.SelectedItem.Text+"')", cn);
            cmd1.ExecuteNonQuery();
            cn.Close();
            lblmsg.Text = "Record Saved Successfully";

            cn.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select * from Student",cn);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            GridView5.DataSource = dt3;
            GridView5.DataBind();
            cn.Close();
            
        }
        

        protected void btnShow1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Student where marks>='" + 60 + "'", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView2.DataSource = dt;
            GridView2.DataBind();
            cn.Close();

        }

        protected void btnShow2_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM Student WHERE class = '" + "MSc" + "' AND Sname LIKE '" + "A%" + "'", cn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            GridView3.DataSource = dt1;
            GridView3.DataBind();
            cn.Close();

        }

        protected void btnShow3_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from Student where class='" + "MCA" + "'", cn);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            GridView4.DataSource = dt2;
            GridView4.DataBind();
            cn.Close();
        }

        protected void btnShow4_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd1 = new SqlCommand("select count(*) from Student where class='" + "MCA" + "'", cn);
            string total = cmd1.ExecuteScalar().ToString().Replace(" ", "");
            txtTotal.Text = total;
            cn.Close();


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}