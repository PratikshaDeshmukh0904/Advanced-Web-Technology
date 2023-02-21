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
    public partial class Q4Product : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-85EE4HM;Initial Catalog=AWTAssignment;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Product", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();

        }
       

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Product(productname,purchaseamount,sellingamount,manufacturingdate,expirydate) values('" + txtPName.Text + "','" + Convert.ToInt32(txtPAmount.Text) + "','" + Convert.ToInt32(txtSAmount.Text) + "','" + Convert.ToDateTime(txtMDate.Text) + "','" + Convert.ToDateTime(txtEDate.Text) + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmsg.Text= "Record Saved Successfully";

           
        }
        protected void linkSelect_Click(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex ;
           
            ViewState["id"] = GridView1.Rows[rowind].Cells[1].Text;
            txtPName.Text = GridView1.Rows[rowind].Cells[2].Text;
            txtPAmount.Text = GridView1.Rows[rowind].Cells[3].Text;
            txtSAmount.Text = GridView1.Rows[rowind].Cells[4].Text;
            txtMDate.Text = GridView1.Rows[rowind].Cells[5].Text;
            txtEDate.Text = GridView1.Rows[rowind].Cells[6].Text;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("Q4Product.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState["id"] != null)//&& !ViewState["id"].Equals("-1")
            {
                int id = Convert.ToInt32(ViewState["id"]);
                con.Open();
                SqlCommand cmd1 = new SqlCommand("update Product set productname='" + txtPName.Text + "',purchaseamount='" + Convert.ToInt32(txtPAmount.Text) + "',sellingamount='" + Convert.ToInt32(txtSAmount.Text) + "',manufacturingdate='" + Convert.ToDateTime(txtMDate.Text) + "',expirydate='" + Convert.ToDateTime(txtEDate.Text) + "' where productid='" + id + "'", con);
                cmd1.ExecuteNonQuery();
                con.Close();
                lblmsg.Text = "Record Updated Successfully";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (ViewState["id"] != null)
            {
               // int id = Convert.ToInt32(ViewState["id"]);
                con.Open();
                SqlCommand cmd2 = new SqlCommand("delete from Product where productid='" + Convert.ToInt32(ViewState["id"]) + "' ", con);
                cmd2.ExecuteNonQuery();
                con.Close();
                lblmsg.Text = "Record Deleted";
            }
           

        }
    }
}