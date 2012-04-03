<%@ Page Title="" Language="C#" MasterPageFile="~/UserSide/UserPage.master" AutoEventWireup="true" CodeFile="Uploads.aspx.cs" Inherits="UserSide_Uploads" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id ="wrapper">
        <asp:Button ID="LogoutBtn" runat="server" Text="Logout" CssClass="LogoutBtn" 
                        onclick="LogoutBtn_Click" />
        <h1>Uploads</h1>
        <div id="Upload">
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:Panel ID="UploadFilePanel" runat="server">
                    <asp:Label ID="UploadText" runat="server" Text="Upload your XML File: " /><br />                
                    <asp:Label ID="UploadErrorLbl" runat="server" Text=""></asp:Label>
                    <asp:Label ID="xmlWriter" runat="server" Text=""></asp:Label>
                    <asp:FileUpload ID="HarddriveXMLUpload" runat="server" />
                    <asp:Button ID="HarddriveUploadBtn" runat="server" Text="Drive it" 
                        onclick="HarddriveUploadBtn_Click" />
                </asp:Panel>
                <asp:Label ID="UserGridLbl" runat="server" Text="" />
        </div>
    </div>
</asp:Content>

