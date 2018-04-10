<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminMaster.Master" CodeBehind="AdminLogin.aspx.cs" Inherits="UL.adminLogin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="content">
        <div class="text_container">
            <h2>Login</h2>
        </div>
        <div class="text_container_2col">
            <fieldset>
                <!--
                <asp:Login ID="Login1" runat="server" UserNameRequiredErrorMessage="Email is required." UserNameLabelText="Email:">
                </asp:Login>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Login1" />
                -->
                <asp:ValidationSummary ID="ValidationSummaryCust" runat="server" ValidationGroup="LoginCustom" />
                <asp:Label ID="lblLoginEmail" runat="server" Text="Email: "></asp:Label>
                <asp:TextBox ID="tbxLoginEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="loginEmail" runat="server" ErrorMessage="You must enter your email" ControlToValidate="tbxLoginEmail" Font-Bold="False" ValidationGroup="LoginCustom"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="EmailExpressionValidator" runat="server" ErrorMessage="Invalid Email Address" ControlToValidate="tbxLoginEmail" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ValidationGroup="LoginCustom"></asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="lblLoginPassword" runat="server" Text="Password: "></asp:Label>
                <asp:TextBox ID="tbxLoginPassword" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="loginPassword" runat="server" ErrorMessage="You must enter a password" ValidationGroup="LoginCustom" ControlToValidate="tbxLoginPassword"></asp:RequiredFieldValidator>
                
                <%--<asp:Button ID="btnLogin" runat="server" Text="Login" />--%>
            </fieldset>
        </div>
    </div>
      
</asp:Content>
