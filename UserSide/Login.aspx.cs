using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;

public partial class UserSide_Login_Login : System.Web.UI.Page
{
    String Username;
    //String DecryptPassword;
    String InputPassword;
    String IDSession;
    String XmlChart;
    String XmlAlert;
    String Pass = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void LoginBtn_Click(object sender, EventArgs e)
    {
        try
        {
            
            Debug.WriteLine("yes"); 
            Username = UsernameBox.Text;
            InputPassword = PasswordBox.Text;
            InputPassword.Trim();

            byte[] encryptPassword = System.Text.Encoding.UTF8.GetBytes(InputPassword);
            byte[] hashPassword = SHA256.Create().ComputeHash(encryptPassword);

            Pass = Convert.ToBase64String(hashPassword);

            string ConnectionString = WebConfigurationManager.ConnectionStrings["YahooCon"].ConnectionString;
            MySqlConnection viewTemplate = new MySqlConnection(ConnectionString);//explisionremoteEntities

            string query = String.Format("SELECT UsersID,ChartKey,AlertKey FROM Users WHERE Username='" + Username + "' AND Password ='" + Pass + "' ");
            using (MySqlDataAdapter viewTemplateSet = new MySqlDataAdapter(query, viewTemplate))
            {
                DataSet viewDSet = new DataSet();
                viewTemplateSet.Fill(viewDSet);

                //Debug.WriteLine(viewTemplateSet.ToString() + "fdasfadsfads33333"); 
                IDSession = viewDSet.Tables[0].Rows[0]["UsersID"].ToString();
                XmlChart = viewDSet.Tables[0].Rows[0]["ChartKey"].ToString();
                XmlAlert = viewDSet.Tables[0].Rows[0]["AlertKey"].ToString();
                Session["UserSession"] = null;
                Session["UserSession"] = IDSession;
                Session["UserChart"] = null;
                Session["UserChart"] = XmlChart;
                Session["UserAlert"] = null;
                Session["UserAlert"] = XmlAlert;
                Response.Redirect("~/UserSide/Index.aspx");
                
            }
        }
        catch (Exception ex)
        {
            Response.Write("Error message " + ex.Message);
        }
    }


}