using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class UserSide_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Timeout = 15;

        Session["temp"] = Session["UserSession"];
        if (Session["temp"] == null)
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