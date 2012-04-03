using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.Configuration;
using System.Data;

public partial class AdminPanel_ViewUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Timeout = 15;

        if (Session["UserSession"] == null)
        {
            Response.Redirect("~/AdminPanel/AdminLogin.aspx");
        }
        else if (Session["Admin"] == null)
        {
            Response.Redirect("~/AdminPanel/AdminLogin.aspx");
        }

        try
        {
            string ConnectionString = WebConfigurationManager.ConnectionStrings["YahooCon"].ConnectionString;
            MySqlConnection viewTemplate = new MySqlConnection(ConnectionString);//explisionremoteEntities{0}", Request.QueryString["ID"]);

            string query = String.Format("SELECT UsersID, Username, Email FROM Users");
            using (MySqlDataAdapter viewTemplateSet = new MySqlDataAdapter(query, viewTemplate))
            {
                DataSet viewDSet = new DataSet();
                viewTemplateSet.Fill(viewDSet);

                GridViewUsers.DataSource = viewDSet;
                GridViewUsers.DataBind();

                //UserName.Text = viewDSet.Tables[0].Rows[0]["Username"].ToString();
            }
        }
        catch (Exception ex)
        {
            Response.Write("<br>Error: <br>" + ex.Message);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Remove("Admin");
        Session.Remove("UserSession");
        Session.Abandon();

        Response.Redirect("~/AdminPanel/AdminLogin.aspx");
    }
}