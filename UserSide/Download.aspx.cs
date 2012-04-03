using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserSide_Download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Timeout = 15;

        if (this.Session["UserSession"] == null)
        {
            Server.Transfer("~/UserSide/Login.aspx");
        }
    }
    protected void LogoutBtn_Click(object sender, EventArgs e)
    {
        Session.Remove("UserSession");
        Session.Abandon();
        Server.Transfer("~/UserSide/Login.aspx");
    }
}