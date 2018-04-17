<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminMaster.Master" CodeBehind="AdminLogout.aspx.cs" Inherits="UL.Admin.AdminLogout" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="content">
        <div class="text_container">
            <h2>you have successfully logged out!</h2>
            <br />
            <div class="centre link">
                <a href="../Customer/Main.aspx">Return home</a> or <a href="AdminLogin.aspx">Login</a>
            </div>
        </div>
    </div>
</asp:Content>
