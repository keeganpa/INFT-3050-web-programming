<%@ Page Title="Logout" Language="C#" AutoEventWireup="true" MasterPageFile="~/newuserMaster.Master" CodeBehind="Logout.aspx.cs" Inherits="UL.logout" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- just a little content to tell the user he successfully logged out and a button to return to the main page -->
    <div class="content">
        <div class="text_container">
            <h2>you have successfully logged out!</h2>
            <br />
            <div class="centre link">
                <a href="Main.aspx">Return home</a> or <a href="Login.aspx">Login</a>
            </div>
        </div>
    </div>
</asp:Content>
