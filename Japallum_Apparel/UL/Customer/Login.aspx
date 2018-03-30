<%@ Page Title="Login" Language="C#" AutoEventWireup="true" MasterPageFile="~/Usermaster.Master" CodeBehind="Login.aspx.cs" Inherits="UL.login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- code inspired from bootswatch forms code examples https://bootswatch.com/lux/ -->
      <fieldset>
        <legend>Login Form</legend>
        <!-- email -->
        <div class="form-group">
          <label for="email">Email address</label>
          <input type="email" class="form-control" id="email" aria-describedby="emailHelp" placeholder="Enter email"/>
        </div>
        <!-- password -->
        <div class="form-group">
          <label for="password">Password</label>
          <input type="password" class="form-control" id="password" placeholder="Password"/>
        </div>
        <!-- link to registration -->
        <a href="/Customer/registration.aspx">don't have an account yet? register</a>
      </fieldset>
      <!-- submit button -->
      <asp:Button CssClass="btn btn-primary" ID="submitButton" runat="server" Text="submit" OnClick="ReturnHome"/>
</asp:Content>
