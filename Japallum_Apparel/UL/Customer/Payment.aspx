<%@ Page Title="Payment" Language="C#" AutoEventWireup="true" MasterPageFile="~/newuserMaster.Master" CodeBehind="Payment.aspx.cs" Inherits="UL.payment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- display the total amount to pay -->
    <div class="text_container"><h1><asp:label ID="amount" runat="server"></asp:label></h1></div>
    <!-- button to pay and go to payment confirmation -->
    <div style="text-align: center; margin-top: 20px;"><asp:Button ID="Pay" runat="server" Text="Pay"/></div>
</asp:Content>
