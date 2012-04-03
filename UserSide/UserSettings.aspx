<%@ Page Title="" Language="C#" MasterPageFile="~/UserSide/UserPage.master" AutoEventWireup="true" CodeFile="UserSettings.aspx.cs" Inherits="UserSide_UserSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="wrapper">
        <asp:Button ID="LogoutBtn" runat="server" Text="Logout" CssClass="LogoutBtn"
                    onclick="LogoutBtn_Click" />
        <h1>User Settings</h1>
        <asp:DetailsView ID="UserDetails" runat="server" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4"
            ForeColor="Black" GridLines="Horizontal" 
            Height="50px" Width="125px">
            <EditRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        </asp:DetailsView>
    </div>
</asp:Content>

