using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class Login : System.Web.UI.Page
{
    String a;
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }
    protected void Button_Login_Click(object sender, EventArgs e)
    {
      
        
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UserDataConnectionString"].ConnectionString);
       
                    conn.Open();
                    string checkuser = "select count(*) from UserData where UserName='" + TextBoxUserName.Text + "'";
                    SqlCommand com = new SqlCommand(checkuser, conn);
                    int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                    conn.Close();
                    if (temp == 1)
                    {
                        conn.Open();
                        string checkPasswordQuery = "select password from UserData where UserName='" + TextBoxUserName.Text + "'";
                        SqlCommand passcomm = new SqlCommand(checkPasswordQuery, conn);
                        string password = passcomm.ExecuteScalar().ToString().Replace(" ", "");

                        if (password == TextBoxPassword.Text)
                        {
                            string checkid = "select ID from UserData where UserName='" + TextBoxUserName.Text + "'";
                            SqlCommand idcom = new SqlCommand(checkid, conn);
                             SqlDataReader reader = idcom.ExecuteReader();
                             if (reader.Read())
                             {

                               a = reader["ID"].ToString();
                              }
                             if (a == TextBox1.Text)
                             {

                                 Session["ID"] = TextBox1.Text;
                                 Session["New"] = TextBoxUserName.Text;
                                 Response.Redirect("Home.aspx");
                             }
                             else
                             {
                                 Label1.Text = "User ID is Not Correct";
                                 Label1.ForeColor = System.Drawing.Color.Red;
                             }
                        }
                        else
                        {
                            Label1.Text = "Password is Not Correct";
                            Label1.ForeColor = System.Drawing.Color.Red;
                        }


                    }
                    else
                    {
                        Label1.Text ="User Name is Not Correct";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                
                

            }
                
            
}