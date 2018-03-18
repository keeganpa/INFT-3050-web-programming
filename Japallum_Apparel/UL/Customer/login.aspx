<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/usermaster.Master" CodeBehind="login.aspx.cs" Inherits="UL.login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- code inspired from bootswatch forms code -->
    <form>
      <fieldset>
        <legend>Login Form</legend>
        <div class="form-group">
          <label for="exampleInputEmail1">Name</label>
          <input class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter name"/>
        </div>
        <div class="form-group">
          <label for="exampleInputPassword1">Password</label>
          <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password"/>
        </div>
        <div>
          <button type="button" class="btn btn-primary">Submit</button>
        </div>
      </fieldset>
    </form>
</asp:Content>
