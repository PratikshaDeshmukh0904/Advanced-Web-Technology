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
    public partial class Display_Image : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void upload_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = Path.GetFileName(fileupload.PostedFile.FileName);
                fileupload.SaveAs(Server.MapPath("~/Images/" + filename));
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["myconectionstring"].ConnectionString;
                //string cs = @"Data Source=.\SQLEXPRESS;Initial Catalog=Student;User ID=sa;Password=me123;";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Image_Details (ImageName,Image) values(@ImageName,@Image)", con);
                cmd.Parameters.AddWithValue("@ImageName", filename);
                cmd.Parameters.AddWithValue("@Image", "Images/" + filename);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter("select * from Image_Details", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gdImage.DataSource = ds;
                gdImage.DataBind();
            }
            catch (Exception ex)
            {
                upload.Text = ex.Message;
            }
        }
    }
}