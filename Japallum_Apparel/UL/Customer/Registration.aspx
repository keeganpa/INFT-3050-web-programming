﻿<%@ Page Title="Registration" Language="C#" AutoEventWireup="true" MasterPageFile="~/Usermaster.Master" CodeBehind="Registration.aspx.cs" Inherits="UL.registration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- code inspired from bootswatch forms code examples https://bootswatch.com/lux/ -->
    <!-- form to register -->
    <form>
      <fieldset>
        <legend>Registration Form</legend>
        <!-- firstname -->
        <div class="form-group">
          <label for="firstname">first name</label>
          <input class="form-control" id="firstname" placeholder="first name"/>
        </div>
        <!-- lastname -->
        <div class="form-group">
          <label for="familyname">family name</label>
          <input class="form-control" id="familyname" placeholder="family name"/>
        </div>
        <!-- email -->
        <div class="form-group">
          <label for="email">Email address</label>
          <input type="email" class="form-control" id="email" aria-describedby="emailHelp" placeholder="Enter email"/>
          <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
        </div>
        <!-- password -->
        <div class="form-group">
          <label for="password1">Password</label>
          <input type="password" class="form-control" id="password1" placeholder="Password"/>
        </div>
        <!-- password verification -->
        <div class="form-group">
          <label for="password2">Password again</label>
          <input type="password" class="form-control" id="password2" placeholder="Password"/>
        </div>
        <!-- submit button -->
        <div>
          <button type="button" class="btn btn-primary">Submit</button>
        </div>
      </fieldset>
    </form>
</asp:Content>