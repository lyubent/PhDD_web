<%@ Page Title="" Language="C#" MasterPageFile="~/UserSide/UserPage.master" AutoEventWireup="true" CodeFile="UserStatistics.aspx.cs" Inherits="UserSide_UserStatistics" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="wrapper">
        <div class="yui-skin-sam">
        <br />
            <div class="yui-layout-unit-middle">
            <script src="http://l.yimg.com/a/i/us/pps/listbadge_1.6.js">{"pipe_id":"4dde0a5978530e01ec2fb0cbfd274551","_btype":"list","height":"180px"}</script>
            </div>
        </div>
        <asp:Button ID="LogoutBtn" runat="server" Text="Logout" CssClass="LogoutBtn" onclick="LogoutBtn_Click" />
        <h1>Statistics</h1>
            <asp:Label ID="ErrorLbl" runat="server" Text="" CssClass="StatText" /><br />
            <asp:Label ID="XmlStatus" runat="server" Text="" /><br />

            <asp:Button ID="ViewStatistics" runat="server" Text="Check Latest" CssClass="UserLatestBtn" 
                    onclick="ViewStatistics_Click" /><br />
            <asp:Label ID="XmlUpdate" runat="server" Text="" /><br />

            <div id="LatestHDD">
                <asp:GridView ID="UserLatestInfo" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>
            <asp:Button ID="ViewChartsBtn" runat="server" Text="View Charts" CssClass="UserStatisticsBtn" 
                onclick="ViewChartsBtn_Click" /><br />

            <asp:Chart ID="ChartTemp" runat="server" Width="880px">
                <Series>
                    <asp:Series Name="Series1" YValuesPerPoint="8">
                
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <br />
            <div class="StatText">
                <asp:Label ID="TempLbl" runat="server" Text="Recent HDD temperatures" 
                    Visible="False"></asp:Label><br />
            </div>
                <asp:Chart ID="ChartCycle" runat="server" Width="880px">
                <Series>
                    <asp:Series Name="Series1" YValuesPerPoint="12">
                
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <br />
            <asp:Label ID="CycleLbl" runat="server" Text="Recent Load/Unload Cycles" 
                Visible="False"></asp:Label>
            <br />

            <div id="downloadXml">
                <asp:HyperLink ID="DownloadChart" runat="server" 
                              NavigateUrl=""
                              Text="Download XML"
                              Target="_blank"/>
            </div>
    </div>
</asp:Content>

