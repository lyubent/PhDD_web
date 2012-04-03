using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel;

public partial class Register_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CreateUserIndexer_CreatedUser(object sender, EventArgs e)
    {
        try
        {
            
            TextBox NameBox = (TextBox)MainUserStep.ContentTemplateContainer.FindControl("UserName");
            TextBox PassBox = (TextBox)MainUserStep.ContentTemplateContainer.FindControl("Password");
            TextBox EmailBox = (TextBox)MainUserStep.ContentTemplateContainer.FindControl("Email");

            String Name = NameBox.Text;
            String PassEncrypt = PassBox.Text;
            String Email = EmailBox.Text;
            String Pass = "";
            PassEncrypt.Trim();
            

            byte[] encryptPassword = System.Text.Encoding.UTF8.GetBytes(PassEncrypt);
            byte[] hashPassword = SHA256.Create().ComputeHash(encryptPassword);

            Pass = Convert.ToBase64String(hashPassword);

            string ConnectionString = WebConfigurationManager.ConnectionStrings["YahooCon"].ConnectionString;
            MySqlConnection CreatUser = new MySqlConnection(ConnectionString);

            /*------------------------ saleDesigns Table query ----------------------------------*/
            /*  */
            string user = "INSERT INTO Users (Username,Password,Email) values(@name,@pass,@email)";

            MySqlCommand Sqluser = new MySqlCommand(user, CreatUser);

            /*------------------------------ saleDesigns Table Entries ------------------------------------*/
            //

            Sqluser.Parameters.Add(new MySqlParameter("@name", Name));
            Sqluser.Parameters.Add(new MySqlParameter("@pass", Pass));
            Sqluser.Parameters.Add(new MySqlParameter("@email", Email));

            /*------------------------------ Execute ------------------------------------*/
            CreatUser.Open();
            Sqluser.ExecuteNonQuery();
            CreatUser.Close();

        }
        catch (Exception ex)
        {
            Response.Write("<br>Error: <br>" + ex.Message);
        }
    }

   
}

