<%@ Page Title="" Language="C#" MasterPageFile="~/UserSide/UserPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="UserSide_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="wrapper">
        <asp:Button ID="LogoutBtn" runat="server" Text="Logout" CssClass="LogoutBtn"
                onclick="LogoutBtn_Click" />
        <h1>How is your Hard Drive performing?</h1>
        <p>
            Welcome to the Indexer PHD (Performance Hard Drive.) This website can be used to download the PHD application which enables you to analyse the 
            performance of your Computers Hard Drive. This application compares how the Hard Drive is meant to be performing against how it is actually performing! This
            comparison allows the user to identify potential problems and innificenies within the hard drive. With the PHD application the user can figure out how to extract
            the optimum performance out of their harddrive!
        </p>
    </div>
</asp:Content>

