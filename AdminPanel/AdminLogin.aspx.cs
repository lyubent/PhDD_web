using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.Configuration;
using System.Security.Cryptography;

public partial class AdminPanel_AdminLogin : System.Web.UI.Page
{
    String Username;
    String InputPassword;
    String IDSession;
    String Pass = "";

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Username = TextBox1.Text;
            InputPassword = TextBox2.Text;
            InputPassword.Trim();

            byte[] encryptPassword = System.Text.Encoding.UTF8.GetBytes(InputPassword);
            byte[] hashPassword = SHA256.Create().ComputeHash(encryptPassword);

            Pass = Convert.ToBase64String(hashPassword);

            string ConnectionString = WebConfigurationManager.ConnectionStrings["YahooCon"].ConnectionString;
            MySqlConnection viewTemplate = new MySqlConnection(ConnectionString);//explisionremoteEntities

            string query = String.Format("SELECT UsersID FROM yahoohack.Superuser"
                + " WHERE Username='" + Username + "' AND Password ='" + Pass + "';");

            using (MySqlDataAdapter viewTemplateSet = new MySqlDataAdapter(query, viewTemplate))
            {
                DataSet viewDSet = new DataSet();
                viewTemplateSet.Fill(viewDSet);

                IDSession = viewDSet.Tables[0].Rows[0]["UsersID"].ToString();
                Session["Admin"] = IDSession;
                Session["UserSession"] = IDSession;
                Response.Redirect("~/AdminPanel/ViewUsers.aspx");

            }
        }
        catch (Exception ex)
        {
            Response.Write("Error message " + ex.Message);
        }
    }
}