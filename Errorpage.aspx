<%@ Page Title="Errorpage" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Errorpage.aspx.cs" Inherits="Errorpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="ErrorpageLbl" runat="server" Text="Label"></asp:Label>
    <div id ="wrapper">
        <h1>Something went wrong with our page. Please, try again later !</h1>
    </div>
    
</asp:Content>

