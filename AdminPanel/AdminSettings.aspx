<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminSettings.aspx.cs" Inherits="AdminSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="wrapper">
        <table class="style1">
            <tr>
                <td>
                    <div class="left50"><h1>Admin Data</h1></div>
                </td>
                <td>
                    <asp:Button ID="Button1" CssClass="LogoutBtn" runat="server" Text="Logout" 
                        Font-Size="Large" onclick="Button1_Click" />
                </td>
            </tr>
        </table>
        <div class="dataGrid">
            
            <asp:DetailsView ID="DetailsView1" runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="None" Height="50px" Width="395px">
                <AlternatingRowStyle BackColor="White" />
                <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                <EditRowStyle BackColor="#2461BF" />
                <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
            </asp:DetailsView>
            
        </div>
    </div>
</asp:Content>

