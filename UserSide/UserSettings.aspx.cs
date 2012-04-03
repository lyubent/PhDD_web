using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

public partial class UserSide_UserSettings : System.Web.UI.Page
{
    String User;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Timeout = 15;

        if (this.Session["UserSession"] == null)
        {
            Server.Transfer("~/UserSide/Login.aspx");
        }
        User = (string)(Session["UserSession"]);
        LoadUserInfo(User);
    }

    private void LoadUserInfo(string UserID)
    {
        try
        {
            string ConnectionString = WebConfigurationManager.ConnectionStrings["YahooCon"].ConnectionString;
            MySqlConnection viewTemplate = new MySqlConnection(ConnectionString);//explisionremoteEntities{0}", Request.QueryString["ID"]);

            string query = String.Format("SELECT Email,Username FROM Users WHERE UsersID='" + UserID + "'");
            using (MySqlDataAdapter viewTemplateSet = new MySqlDataAdapter(query, viewTemplate))
            {
                DataSet viewDSet = new DataSet();
                viewTemplateSet.Fill(viewDSet);

                UserDetails.DataSource = viewDSet;
                UserDetails.DataBind();

                //UserName.Text = viewDSet.Tables[0].Rows[0]["Username"].ToString();
            }
        }
        catch (Exception ex)
        {
            Response.Write("<br>Error: <br>" + ex.Message);
        }
    }
    protected void LogoutBtn_Click(object sender, EventArgs e)
    {
        Session.Remove("UserSession");
        Session.Abandon();
        Server.Transfer("~/UserSide/Login.aspx");
    }
}