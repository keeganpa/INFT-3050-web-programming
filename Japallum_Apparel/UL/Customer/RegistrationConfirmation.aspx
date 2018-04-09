<%@ Page Title="Registration Confirmation" Language="C#" AutoEventWireup="true" MasterPageFile="~/newuserMaster.Master" CodeBehind="RegistrationConfirmation.aspx.cs" Inherits="UL.Customer.RegistrationConfirmation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="content">
        <!-- just few comments for now -->
        <div class="text_container">
            <h2>Congratulations!</h2>
            <br />
            <p class="centre">You have successfully created a User Account.</p>
            <br />
            <div class="centre link">
                <a href="About.aspx">Return home</a> or <a href="Login.aspx">Login</a>
            </div>
        </div>
    </div>
</asp:Content>
