using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
namespace WebApp
{
    public partial class Register : System.Web.UI.Page
    {
        private object txtuser;

        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayRecord();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {

            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["myconectionstring"].ConnectionString;
           
            SqlConnection con = new SqlConnection(cs);
            string filename = Path.GetFileName(fileupload.PostedFile.FileName);
            fileupload.SaveAs(Server.MapPath("~/Images/" + filename));

            string username = Request.Form["txtuser"];
            string Dob = txtdob.Text;
            string sex = Request.Form["gender"];
            string ph = TextBox2.Text;
            string address = TextBox3.Text;

           
            if (rb1.Checked == true)
            {

            
                string strQuery = "insert into registration(name,dob,sex,phone,address,image) values (@username,@Dob,@rb1,@ph,@address,@Image)";
           
            SqlCommand cmd = new SqlCommand(strQuery,con);
                cmd.Parameters.AddWithValue("@username",username);
                cmd.Parameters.AddWithValue("@Dob",Dob);
                cmd.Parameters.AddWithValue("@rb1",rb1.Text);
                cmd.Parameters.AddWithValue("@ph", ph);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@Image", "Images/" + filename);
              

                con.Open();
           

            cmd.ExecuteNonQuery();
            Response.Write("<script LANGUAGE='JavaScript' >alert('Added Successfull')</script>");
           
            }
            else
            {
                string strQuery = "insert into registration(name,dob,sex,phone,address,image) values (@username,@Dob,@rb1,@ph,@address,@Image)";

                SqlCommand cmd = new SqlCommand(strQuery, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@Dob", Dob);
                cmd.Parameters.AddWithValue("@rb1", rb2.Text);
                cmd.Parameters.AddWithValue("@ph", ph);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@Image", "Images/" + filename);

                con.Open();


                cmd.ExecuteNonQuery();
                Response.Write("<script LANGUAGE='JavaScript' >alert('Added Successfull')</script>");
            }
            con.Close();
            DisplayRecord();
        }

        public DataTable DisplayRecord()
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["myconectionstring"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter Adp = new SqlDataAdapter("select id,name,dob,sex,phone,address,image from registration", con);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            GridView1.DataSource = Dt;
            GridView1.DataBind();
            return Dt;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkbtnEdit")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                Response.Redirect("EditInfo.aspx?id=" + id); /* Pass id in querystring for updating record */
            }
            if (e.CommandName == "lnkbtnDelete")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["myconectionstring"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("delete from registration where id ='" + id + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayRecord(); /* Reload gridview */
            }
        }
    }
}