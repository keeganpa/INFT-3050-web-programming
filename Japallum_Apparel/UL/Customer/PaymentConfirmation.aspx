<%@ Page Title="PaymentConfirmation" Language="C#" AutoEventWireup="true" MasterPageFile="~/newuserMaster.Master" CodeBehind="PaymentConfirmation.aspx.cs" Inherits="UL.paymentConfirmation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- text for payment success -->
    <div class="text_container"><h1>You have successfully paid</h1></div>
    <!-- button to return home page -->
    <div style="text-align: center; margin-top: 20px;"><asp:Button ID="Return" runat="server" Text="ReturnHome"/></div>
</asp:Content>
