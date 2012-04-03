<%@ Page Title="" Language="C#" MasterPageFile="~/UserSide/UserPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="UserSide_Login_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="wrapper">
        <div class="loginPanel">
            <table ID="Login" runat="server" bgcolor="#993399" title="User Login">
                <tr>
                    <td><asp:Label ID="UsernameLbl" runat="server" Text="Username:"></asp:Label></td>
                    <td><asp:TextBox ID="UsernameBox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="PasswordLbl" runat="server" Text="Password:"></asp:Label></td>
                    <td><asp:TextBox ID="PasswordBox" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
            </table>
         <asp:Button ID="LoginBtn" runat="server" Text="Login" CssClass="LoginBtn" 
            onclick="LoginBtn_Click" />
        </div>
    </div>
</asp:Content>
