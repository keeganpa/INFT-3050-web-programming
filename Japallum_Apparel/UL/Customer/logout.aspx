<%@ Page Title="Logout" Language="C#" AutoEventWireup="true" MasterPageFile="~/usermaster.Master" CodeBehind="logout.aspx.cs" Inherits="UL.logout" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <small>you have successfully logged out</small>
    <a href="/Customer/login.aspx">log in</a>
</asp:Content>