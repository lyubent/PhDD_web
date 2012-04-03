using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Subgurim.Controles;
using System.Data;
using System.Web.Configuration;
using MySql.Data.MySqlClient;

public partial class UserSide_Uploads : System.Web.UI.Page
{
    Random random;
    XmlDocument xmlDoc;
    XmlNode xmlKey;
    XmlNode rootNode;
    String UserSession;

    protected void Page_Load(object sender, EventArgs e)
    {
        random = new Random();
        xmlDoc = new XmlDocument();

        Session.Timeout = 15;

        if (this.Session["UserSession"] == null)
        {
            Server.Transfer("~/UserSide/Login.aspx");
        }

        UserSession = (string)(Session["UserSession"]);
    }
    protected void HarddriveUploadBtn_Click(object sender, EventArgs e)
    {
        /*--- Global Variables ---*/
        String xmlFile = HarddriveXMLUpload.FileName.ToString();
        Boolean IsUploaded = false;

        /*--- Upload thumbs ---*/
        if (HarddriveXMLUpload.HasFile)
        {
            try
            {
                if (HarddriveXMLUpload.PostedFile.ContentType == "text/xml")
                {
                        if (HarddriveXMLUpload.PostedFile.ContentLength < 102400)
                        {
                            string randomXMLNumber = random.Next(1000).ToString();
                            string xmlUpload = DateTime.Now.Ticks.ToString() + randomXMLNumber + xmlFile;
                            HarddriveXMLUpload.SaveAs(Server.MapPath("~/DBXMLFiles/Users/Keys/") + xmlUpload);
                            UploadErrorLbl.Text = "Upload status: File uploaded!";
                            IsUploaded = true;

                            if (IsUploaded)
                            {
                                string graph, alert;
                                graph = "graph";
                                alert = "alert";
                                string xmlGraphFile = DateTime.Now.Ticks.ToString() + randomXMLNumber + "UN" + UserSession + "Graphs.xml";
                                string xmlAlertFile = DateTime.Now.Ticks.ToString() + randomXMLNumber + "UN" + UserSession + "Alerts.xml";
                                
                                XMLWriter(xmlGraphFile, graph);
                                XMLWriter(xmlAlertFile, alert);
                                ReadXml(xmlUpload, UserSession);
                                UploadXmlKey(xmlUpload,xmlGraphFile,xmlAlertFile,UserSession);
                            }
                            
                          }
                          else { UploadErrorLbl.Text = "Upload status: The file has to be less than 100 kb!"; }
                 }
                 else { UploadErrorLbl.Text = "Upload status: Only XML files are accepted!"; }
            }
            catch (Exception ex)
            {
                Response.Write("<br>Error: <br>" + ex.Message);
            }
        }
    }

    protected void ReadXml(String Xml, string User)
    {
        
        //string User = "1";
        string strFilename = "~\\DBXMLFiles\\Users\\Keys\\" + Xml;
        xmlDoc.Load(Server.MapPath(strFilename));
        rootNode = xmlDoc.DocumentElement;
        xmlKey = rootNode.SelectSingleNode("Details");
        string readKey = xmlKey.InnerText;
        UploadErrorLbl.Text = readKey;
        //InsertXmlKey(readKey, User);
    }

    protected void InsertXmlKey(String Key, string User)
    {
        try
        {
            string ConnectionString = WebConfigurationManager.ConnectionStrings["YahooCon"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(ConnectionString);

            /*------------------------ UsersHDD Table query ----------------------------------*/
            /*  */
            string user = "INSERT INTO UsersHDD (UsersID,HDDKey) values(@user,@key)";

            MySqlCommand Sqluser = new MySqlCommand(user, Conn);

            /*------------------------------ UsersHDD Table Entries ------------------------------------*/
            //

            Sqluser.Parameters.Add(new MySqlParameter("@user", User));
            Sqluser.Parameters.Add(new MySqlParameter("@key", Key));

            /*------------------------------ Execute ------------------------------------*/
            Conn.Open();
            Sqluser.ExecuteNonQuery();
            Conn.Close();
        }
        catch (Exception ex)
        {
            Response.Write("<br>Error: <br>" + ex.Message);
        }
    }

    protected void UploadXmlKey(string xmlKey, string xmlGraph, string xmlAlert, string userID)
    {
        string xmlKeyUp = "../DBXMLFiles/Users/Keys/" + xmlKey;
        string xmlGraphUp = "../DBXMLFiles/Users/Charts/user2xxr/" + xmlGraph;
        string xmlAlertUp = "../DBXMLFiles/Users/Alerts/user2xxr/" + xmlAlert;

        try
        {
            string ConnectionString = WebConfigurationManager.ConnectionStrings["YahooCon"].ConnectionString;
            MySqlConnection Conn = new MySqlConnection(ConnectionString);

            /*------------------------ UsersHDD Table query ----------------------------------*/
            /*  */
            string user = "UPDATE Users SET AppKey = '"+ xmlKeyUp +"',ChartKey = '"+ xmlGraphUp +"',AlertKey = '"+ xmlAlertUp +"' WHERE UsersID = '"+ userID +"'";

            MySqlCommand Sqluser = new MySqlCommand(user, Conn);
            Conn.Open();
            Sqluser.ExecuteNonQuery();
            Conn.Close();
        }
        catch (Exception ex)
        {
            Response.Write("<br>Error: <br>" + ex.Message);
        }

    }

    public void XMLWriter(string xml, string place)
    {
        
        try
        {

            XmlDocument xmlDOC = new XmlDocument();
            XmlNode xmlNode = xmlDOC.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDOC.AppendChild(xmlNode);

            XmlNode productsNode = xmlDOC.CreateElement("SystemInfo");
            xmlDOC.AppendChild(productsNode);

            XmlNode productNode = xmlDOC.CreateElement("Details");
            productsNode.AppendChild(productNode);

            XmlNode nameNode = xmlDOC.CreateElement("Email");
            nameNode.AppendChild(xmlDOC.CreateTextNode("PhDD@hack.com"));
            productNode.AppendChild(nameNode);
            XmlNode priceNode = xmlDOC.CreateElement("Temp");
            priceNode.AppendChild(xmlDOC.CreateTextNode("High"));
            productNode.AppendChild(priceNode);
            if (place == "graph")
            {
                xmlDOC.Save(Server.MapPath("~/DBXMLFiles/Users/Charts/user2xxr/" + xml));
            }
            else
            {
                xmlDOC.Save(Server.MapPath("~/DBXMLFiles/Users/Alerts/user2xxr/" + xml));
            }
            
            xmlWriter.Text = "XML writer/creater created";
        }
        catch (Exception ex)
        {
            Response.Write("ERROR: " + ex.Message);
        }
    }

    protected void LogoutBtn_Click(object sender, EventArgs e)
    {
        Session.Remove("UserSession");
        Session.Abandon();
        Server.Transfer("~/UserSide/Login.aspx");
    }
}