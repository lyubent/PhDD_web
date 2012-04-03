<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="ViewUsers.aspx.cs" Inherits="AdminPanel_ViewUsers" %>

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
        <div>
            <table class="style1">
                <tr>
                    <td>
                        <div class="left50"><h1>Registered User Data</h1></div>
                    </td>
                    <td>
            <asp:Button ID="Button1" CssClass="LogoutBtn" runat="server" Text="Logout" 
                            onclick="Button1_Click" style="text-align: right;" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="dataGrid">
            <asp:GridView ID="GridViewUsers" runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="None" style="text-align: center" Width="795px">
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
    <</div>
</asp:Content>

