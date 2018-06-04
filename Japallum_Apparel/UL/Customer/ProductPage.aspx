<%@ Page  Title="Product" Language="C#" AutoEventWireup="true" MasterPageFile="~/newuserMaster.Master" CodeBehind="ProductPage.aspx.cs" Inherits="UL.Customer.ProductPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="content">
        <!-- just few comments for now -->
      <asp:GridView ID="SelectedProduct" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="4" HorizontalAlign="Center"
        ItemType="DAL.Models.Clothes" SelectMethod="GetProductDetails" onrowcommand="SelectedProduct_RowCommand">
    <%-- set the content of each rows of the gridview (the list of data we need for each product) --%>
     <%-- Code for gridview sourced from - https://docs.microsoft.com/en-us/aspnet/web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/shopping-cart --%>
        <Columns>
            <asp:ImageField DataImageUrlField="imagePath" HeaderText="image" ControlStyle-Width="100px" ControlStyle-Height = "100px"/>
            <asp:BoundField DataField="name" HeaderText="name"/>
            <asp:BoundField DataField="size" HeaderText="size"/>
            <asp:BoundField DataField="price" HeaderText="price in aud"/>
            <asp:BoundField DataField="description" HeaderText="description"/>
            <asp:BoundField DataField="gender" HeaderText="gender"/>
            <asp:BoundField DataField="active" HeaderText="active"/>
            <asp:ButtonField buttontype="Button" Text="Add to cart" commandname="AddToCart"/>
        </Columns>
    </asp:GridView>
    </div>
</asp:Content>
