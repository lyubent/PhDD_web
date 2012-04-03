<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="ViewHDD.aspx.cs" Inherits="ViewHDD" %>

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
        <div class="left50">
            <table class="style1">
                <tr>
                    <td>
                        <h1>Registered HDD's for all Users</h1>
                    </td>
                    <td>
                        <asp:Button ID="Button1" CssClass="LogoutBtn" runat="server" style="text-align: right" 
                            Text="Logout" Font-Size="Large" onclick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="dataGrid">
            <asp:GridView ID="HDDGridView" runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="None" style="text-align: center" 
                Width="795px">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

