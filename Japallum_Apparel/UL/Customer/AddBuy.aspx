<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/newUsermaster.Master" CodeBehind="AddBuy.aspx.cs" Inherits="UL.addBuy" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- all info about the clothes you are going to add to cart (including image)-->
    <div style="margin-left: 50px">
        <br />
        <asp:Image ID="img" runat="server" BorderStyle="NotSet" Height="100px" Width="100px" />
        <br />
        <asp:label ID="id" runat="server"></asp:label>
        <br />
        <asp:label ID="name" runat="server"></asp:label>
        <br />
        <asp:label ID="size" runat="server"></asp:label>
        <br />
        <asp:label ID="price" runat="server"></asp:label>
        <br />
        <asp:label ID="type" runat="server"></asp:label>
        <br />
        <asp:label ID="description" runat="server"></asp:label>
        <br />
        <asp:label ID="gender" runat="server"></asp:label>
        <br />
        <!-- button to add to cart -->
        <div style="margin-top: 20px;"><asp:Button ID="Add" runat="server" Text="AddToCart"/></div>
    </div>
</asp:Content>
