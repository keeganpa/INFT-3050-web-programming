<%@ Page Title="Shopping Cart" Language="C#" AutoEventWireup="true" MasterPageFile="~/newUsermaster.Master" CodeBehind="ShoppingCart.aspx.cs" Inherits="UL.shoppingCart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div style="text-align: center; margin-top: 20px;">
        <asp:Label runat="server" Text="Your Items:" ID="lblItems" />
        <!-- gridview to organize the presentation of cart items -->
        <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="4" HorizontalAlign="Center"
            ItemType="DAL.Models.Clothes" SelectMethod="GetShoppingCartItems" onrowcommand="CartList_RowCommand">
        <%-- set the content of each rows of the gridview (the list of data we need for each cart items) --%>
        <Columns>
            <asp:BoundField DataField="iD" HeaderText="ID"/>
            <asp:ImageField DataImageUrlField="imagePath" HeaderText="image" ControlStyle-Width="100px" ControlStyle-Height = "100px"/>
            <asp:BoundField DataField="name" HeaderText="name"/>
            <asp:BoundField DataField="size" HeaderText="size"/>
            <asp:BoundField DataField="price" HeaderText="price in aud"/>
            <asp:BoundField DataField="description" HeaderText="description"/>
            <asp:BoundField DataField="gender" HeaderText="gender"/>
            <asp:ButtonField buttontype="Button" Text="remove" commandname="Remove"/>
        </Columns>
        </asp:GridView>
        <br />
        <!-- button to go to payment with total amount written-->
        <asp:Button ID="btnAddMoreItems" Text="Add more items" runat="server" />
        <br />
        <br />
        <asp:Button ID="btnCheckout" Text="Proceed to Checkout" runat="server" />
    </div>
    <br />
</asp:Content>