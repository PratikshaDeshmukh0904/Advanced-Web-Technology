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
    public partial class Q2Employee : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-85EE4HM;Initial Catalog=AWTAssignment;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Employee where department='" + "Maths" + "' or department='" + "Statistics" + "'",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();

            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Employee where  gender = '" + "Female" + "' AND         salary > '" + Convert.ToInt32(15000) + "'", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            GridView2.DataSource = dt1;
            GridView2.DataBind();
            con.Close();

            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from Employee ", con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            GridView3.DataSource = dt2;
            GridView3.DataBind();
            con.Close();

            con.Open();
            SqlCommand cmd1 = new SqlCommand("select sum(salary) from Employee where gender='" + "Male" + "'", con);
            string total_sal = cmd1.ExecuteScalar().ToString().Replace(" ", "");
            txtsal.Text = total_sal;
            con.Close();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Employee(name,gender,salary,department,email) values('"+txtName.Text+"','"+ddlGender.SelectedItem.Text+"','"+txtSalary.Text+"','"+txtDepartment.Text+"','"+txtEmail.Text+"')",con);
            cmd.ExecuteNonQuery();
            con.Close();
           lblmsg.Text= "Record Saved Successfully";

        }

        protected void txtsal_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("Q2Employee.aspx");
        }
    }
}