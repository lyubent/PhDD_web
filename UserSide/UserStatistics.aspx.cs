using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Web.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

public partial class UserSide_UserStatistics : System.Web.UI.Page
{
    Random random;
    XmlDocument xmlDoc;
    DataSet viewDSet;
    MySqlCommand command;
    Boolean WriteXml;
    Int32 HarddriveTemp;
    Int32 HarddriveCycle;
    CompareSys CompXML;
    String UserXmlChart;
    String UserXmlAlert;
    String UserUniqueID;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Timeout = 15;

        if (this.Session["UserSession"] == null)
        {
            Server.Transfer("~/UserSide/Login.aspx");
        }

        UserXmlChart = (string)(Session["UserChart"]);
        UserXmlAlert = (string)(Session["UserAlert"]);
        UserUniqueID = (string)(Session["UserSession"]);
        random = new Random();
        xmlDoc = new XmlDocument();
        CompXML = new CompareSys();
        WriteXml = false;
    }

    protected void ViewStatistics_Click(object sender, EventArgs e)
    {
        string temp;
        string cycle;
        string email;
        string serial;
        TempLbl.Visible = false;
        CycleLbl.Visible = false;
        DownloadChart.Visible = false;

        try
        {
            string ConnectionString = WebConfigurationManager.ConnectionStrings["YahooCon"].ConnectionString;
            MySqlConnection viewTemplate = new MySqlConnection(ConnectionString);//explisionremoteEntities{0}", Request.QueryString["ID"]);

            string query = String.Format("CALL yahoohack.MaxUserHDD('"+ UserUniqueID +"')");
            using (MySqlDataAdapter viewTemplateSet = new MySqlDataAdapter(query, viewTemplate))
            {
                DataSet viewDSet = new DataSet();
                viewTemplateSet.Fill(viewDSet);

                UserLatestInfo.DataSource = viewDSet;
                UserLatestInfo.DataBind();

                serial = viewDSet.Tables[0].Rows[0]["SerialNumber"].ToString();

                temp = viewDSet.Tables[0].Rows[0]["Temp"].ToString();
                HarddriveTemp = Convert.ToInt32(temp);

                cycle = viewDSet.Tables[0].Rows[0]["LoadCycle"].ToString();
                HarddriveCycle = Convert.ToInt32(cycle);

                email = viewDSet.Tables[0].Rows[0]["Email"].ToString();

                XmlUpdate.Text = "Latest HDD Information";

                WriteXml = CompXML.HDDDataCompare(HarddriveTemp, HarddriveCycle);
                if (WriteXml)
                {
                    XMLWriter(email, serial, temp, cycle);
                }
                
            }
        }
        catch (Exception ex)
        {
            Response.Write("<br>Error: <br>" + ex.Message);
        }
    }

    protected void ViewChartsBtn_Click(object sender, EventArgs e)
    {
        XMLUserGraph(UserUniqueID);
    }

    public void XMLWriter(string email, string HDD, string temp, string cycle)
    {

        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "  ";
        settings.NewLineOnAttributes = true;
        bool IsWrite = false;

        string XMLName = Server.MapPath(UserXmlAlert);

        //Using XmlWriter to create xml file.
        using (XmlWriter writer = XmlWriter.Create(XMLName, settings))
        {
            writer.WriteComment("Yahoo Hack U Day");
                writer.WriteStartElement("SystemInfo");
                    writer.WriteStartElement("Details");
                        writer.WriteElementString("Email", email);
                        writer.WriteElementString("SerialNumber", HDD);
                        writer.WriteElementString("Temp", "Temperature." + temp);
                        writer.WriteElementString("Cycle", "Load/Unload Cycle." + cycle);
                    writer.WriteEndElement();
                writer.WriteEndElement();
            writer.Flush();
            writer.Close();
            IsWrite = true;
        }

        if (IsWrite)
        {
            XmlStatus.Text = "Email alert has been sent to your account!";
        }
    }

    public void XMLUserGraph(string user)
    {
        //Creating XmlWriter Settings
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "  ";
        settings.NewLineOnAttributes = true;
        bool IsWrite = false;
        DataSet viewDSet = new DataSet();

        /*string randomXMLNumber = random.Next(1000).ToString();
        string xmlUpload = DateTime.Now.Ticks.ToString() + randomXMLNumber + "UN" + user + ".xml";
        string XMLName = Server.MapPath("~/DBXMLFiles/") + xmlUpload;*/
        string XMLName = Server.MapPath(UserXmlChart);

        //Using XmlWriter to create xml file.
        using (XmlWriter writer = XmlWriter.Create(XMLName, settings))
        {
            writer.WriteComment("Yahoo Hack U Day Graph Report");
                writer.WriteStartElement("SystemInfo");
                    try
                    {
                        string ConnectionString = WebConfigurationManager.ConnectionStrings["YahooCon"].ConnectionString;
                        MySqlConnection viewTemplate = new MySqlConnection(ConnectionString);//explisionremoteEntities{0}", Request.QueryString["ID"]);

                        string query = String.Format("CALL yahoohack.UserGraph('"+ user +"')");
                        using (MySqlDataAdapter viewTemplateSet = new MySqlDataAdapter(query, viewTemplate))
                        {
                            viewTemplateSet.Fill(viewDSet);
                            for (int count = 0; count < viewDSet.Tables[0].Rows.Count; count++)
                            {
                                writer.WriteStartElement("Details");
                                    writer.WriteElementString("SerialNumber", viewDSet.Tables[0].Rows[count]["SerialNumber"].ToString());
                                    writer.WriteElementString("Temp", viewDSet.Tables[0].Rows[count]["Temp"].ToString());
                                    writer.WriteElementString("Cycle", viewDSet.Tables[0].Rows[count]["LoadCycle"].ToString());
                                writer.WriteEndElement();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<br>Error: <br>" + ex.Message);
                    }
                writer.WriteEndElement();
            writer.Flush();
            writer.Close();
            IsWrite = true;
        }
        if (IsWrite)
        {
            XmlStatus.Text = "XML Chart Printed";

            viewDSet.ReadXml(XMLName);

            ChartTemp.ChartAreas[0].AxisX.LabelStyle.Format = " ";
            ChartTemp.Series["Series1"].YValueMembers = Convert.ToString(viewDSet.Tables[0].Columns[1].ColumnName);
            ChartTemp.ChartAreas[0].AxisX.Interval = 1;
            ChartTemp.ToolTip = ("HDD Temperature Monitor");
            ChartTemp.DataSource = viewDSet;
            TempLbl.Visible = true;

            ChartCycle.ChartAreas[0].AxisX.LabelStyle.Format = " ";
            ChartCycle.Series["Series1"].YValueMembers = Convert.ToString(viewDSet.Tables[0].Columns[2].ColumnName);
            ChartCycle.ChartAreas[0].AxisX.Interval = 1;
            ChartCycle.ToolTip = ("HDD Load/Unload Monitor");
            ChartCycle.DataSource = viewDSet;
            CycleLbl.Visible = true;

            DownloadChart.NavigateUrl = XMLName;
            DownloadChart.Visible = true;
        }
    }
    protected void LogoutBtn_Click(object sender, EventArgs e)
    {
        Session.Remove("UserSession");
        Session.Abandon();
        Server.Transfer("~/UserSide/Login.aspx");
    }
}
