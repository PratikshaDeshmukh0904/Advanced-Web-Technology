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
    public partial class Q6SPEmp : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-85EE4HM;Initial Catalog=AWTAssignment;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("exec displaylist ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("exec InsertProcedure '" + txtName.Text + "','" + ddlDept.SelectedItem.Text + "','" + Convert.ToInt32(txtSalary.Text) + "','" + Convert.ToDateTime(txtDate.Text) + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmsg.Text = "Record Saved Successfully";
        }
        protected void linkSelect_Click(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            ViewState["id"] = GridView1.Rows[rowind].Cells[1].Text;
            txtName.Text = GridView1.Rows[rowind].Cells[2].Text;
            ddlDept.SelectedItem.Text = GridView1.Rows[rowind].Cells[3].Text;
            txtSalary.Text = GridView1.Rows[rowind].Cells[4].Text;
            txtDate.Text = GridView1.Rows[rowind].Cells[5].Text;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("exec UpdateProcedure '" + Convert.ToInt32(ViewState["id"]) + "','" + txtName.Text + "', '" + ddlDept.SelectedItem.Text + "', '" + Convert.ToInt32(txtSalary.Text) + "', '" + Convert.ToDateTime(txtDate.Text) + "'", con);
            cmd1.ExecuteNonQuery();
            con.Close();
            lblmsg.Text = "Record Updated Successfully";
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("Q6SPEmp.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand("exec DeleteProcedure '" + Convert.ToInt32(ViewState["id"]) + "'", con);
            cmd2.ExecuteNonQuery();
            con.Close();
            lblmsg.Text = "Record Deleted";
        }
    }
}