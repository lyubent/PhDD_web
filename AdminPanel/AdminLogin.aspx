<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminPanel_AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 46%;
        }
        .style2
        {
            text-align: left;
        }
        .style3
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="wrapper">
        
        

        <div class="loginPanel">
            <table ID="Login" runat="server" bgcolor="#993399" title="User Login">
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
            </table>
         <asp:Button ID="Button1" runat="server" onclick="Button1_Click" CssClass="LoginBtn" Text="Login" />
        </div>
    </div>
</asp:Content>

