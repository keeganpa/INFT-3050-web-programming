<%@ Page Title="Checkout" Language="C#" AutoEventWireup="true" MasterPageFile="~/newUsermaster.Master" CodeBehind="Checkout.aspx.cs" Inherits="UL.Customer.Checkout" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div style="text-align: center; margin-top: 20px;">
    <!-- gridview to organize the presentation of cart items -->
    <asp:Label runat="server" Text="Your Items:"></asp:Label>
    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="4" HorizontalAlign="Center"
        ItemType="DAL.Models.Clothes" SelectMethod="GetShoppingCartItems">
    <%-- set the content of each rows of the gridview (the list of data we need for each cart items) --%>
    <Columns>
        <asp:BoundField DataField="iD" HeaderText="ID"/>
        <asp:ImageField DataImageUrlField="imagePath" HeaderText="image" ControlStyle-Width="100px" ControlStyle-Height = "100px"/>
        <asp:BoundField DataField="name" HeaderText="name"/>
        <asp:BoundField DataField="size" HeaderText="size"/>
        <asp:BoundField DataField="price" HeaderText="price in aud"/>
        <asp:BoundField DataField="description" HeaderText="description"/>
        <asp:BoundField DataField="gender" HeaderText="gender"/>
    </Columns>
    </asp:GridView>
    <br />
    <asp:Label Text="Select payment option:" runat="server"></asp:Label>
    <asp:GridView ID="PostageList" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="4" HorizontalAlign="Center"
        ItemType="DAL.Models.Postage" SelectMethod="GetPostageOptions" onrowcommand="PostageList_RowCommand">
    <%-- set the content of each rows of the gridview (the list of data we need for each cart items) --%>
    <Columns>
        <asp:BoundField DataField="postageDescription" HeaderText="Postage Type"/>
        <asp:BoundField DataField="postageCost" HeaderText="Price"/>
        <asp:ButtonField buttonType="Button" Text="Select" CommandName="Select"/>
    </Columns>
    </asp:GridView>
        <br />
        <asp:Label runat="server" ID="lblTotal" HorizontalAlign="Center"></asp:Label> 
        <br />
        <br />
        <asp:Label runat="server" ID="lblPostage" HorizontalAlign="Center"></asp:Label>
        <br />
        <br />
        <asp:Label runat="server" ID="lblSubtotal" HorizontalAlign="Center"></asp:Label>
        <br />
        <br />
    <!-- button to go to payment with total amount written-->
        <asp:Button ID="btnPayment" Text="Proceed to Payment" runat="server" />
        <br />
    </div>
    <br />
</asp:Content>
