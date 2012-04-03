<%@ Page Title="" Language="C#" MasterPageFile="~/UserSide/UserPage.master" AutoEventWireup="true" CodeFile="Download.aspx.cs" Inherits="UserSide_Download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id ="wrapper">
            <asp:Button ID="LogoutBtn" runat="server" Text="Logout" CssClass="LogoutBtn" 
                    onclick="LogoutBtn_Click" />
        <h1>Download PhDD</h1>
        <p1>Please click the Download Icon below to begin downloading the PhDD Application to discover how 
            your Hard Drive is performing! A Readme text file is included in the download folder. 
        </p1>
        </br></br>
        <div>
            <a href="../Downloads/PhDD_download.zip">
                <img src="../Images/download.png"  align="middle" width="auto" height="auto" />
            </a>
        </div>

</div>
</asp:Content>

