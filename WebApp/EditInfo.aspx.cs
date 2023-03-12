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
    public partial class EditInfo : System.Web.UI.Page
    {
      
        public int id;
        public string servervalue=String.Empty;
        public string servervalue1 = String.Empty;
        public string servervalue2 = String.Empty;
        public string servervalue3 = String.Empty;
        public string servervalue4 = String.Empty;


        public string usern,u;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            id = int.Parse(Request.QueryString["id"].ToString());

            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["myconectionstring"].ConnectionString;
            //string cs = @"Data Source=.\SQLEXPRESS;Initial Catalog=Student;User ID=sa;Password=me123;";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter Adp = new SqlDataAdapter("select name,dob,sex,phone,address,image from registration where id='"+ id+ "'", con);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                servervalue = Dt.Rows[0][0].ToString();
                string sex = Dt.Rows[0][2].ToString();
                servervalue3 = Dt.Rows[0][4].ToString();
                servervalue2 = Dt.Rows[0][3].ToString();
                servervalue1 = Dt.Rows[0][1].ToString();
               
                if (sex == "Female")
                {
                    rb2.Checked = true;
                }
                else
                {
                    rb1.Checked = true;
                }
            }
            else
            {

            }
            //string username = Request.Form["user"];


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["myconectionstring"].ConnectionString;
            //string cs = @"Data Source=.\SQLEXPRESS;Initial Catalog=Student;User ID=sa;Password=me123;";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            id = int.Parse(Request.QueryString["id"].ToString());
            var usern = Request.Form["user"];
            var dob = Request.Form["dob"];
            var add = Request.Form["add"];
            var ph = Request.Form["pho"];

            string filename = Path.GetFileName(fileupload.PostedFile.FileName);
            fileupload.SaveAs(Server.MapPath("~/Images/" + filename));

            string Query = "Update registration SET name = '" + usern + "',dob='" + dob + "',phone='" + ph + "',address='"+ add + "',image='"+ "Images/" + filename + "' where id= " + id+ "";
            SqlCommand cmd = new SqlCommand(Query, con);
            
            cmd.ExecuteNonQuery();
            Response.Write("<script LANGUAGE='JavaScript' >alert('Updated Successfull')</script>");
            Response.Redirect("Register.aspx");
        }
    }
}