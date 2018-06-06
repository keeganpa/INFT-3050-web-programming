<%@ Page Title="Shopping Cart" Language="C#" AutoEventWireup="true" MasterPageFile="~/newUsermaster.Master" CodeBehind="ShoppingCart.aspx.cs" Inherits="UL.shoppingCart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- old static version -->
    <!-- <div style="display:flex; flex-direction: row;">
        <div style="padding-left: 20px;">
            <asp:Image ID="sweater" runat="server" ImageUrl="~/Images/sweater.png" BorderStyle="NotSet" Height="100px" Width="100px"/>
            <li class="small">size: L</li>
            <li class="small">price: $20</li>
            <li class="small">type: sweater</li>
            <li class="small">description: school sweater for students</li>
            <li class="small">gender: male</li>
        </div>
        <div style="padding-left: 20px;">
            <asp:Image ID="sweater2" runat="server" ImageUrl="~/Images/sweater.png" BorderStyle="NotSet" Height="100px" Width="100px"/>
            <li class="small">size: L</li>
            <li class="small">price: $20</li>
            <li class="small">type: sweater</li>
            <li class="small">description: school sweater for students</li>
            <li class="small">gender: male</li>
        </div>
        <div style="padding-left: 20px;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/sweater.png" BorderStyle="NotSet" Height="100px" Width="100px"/>
            <li class="small">size: L</li>
            <li class="small">price: $20</li>
            <li class="small">type: sweater</li>
            <li class="small">description: school sweater for students</li>
            <li class="small">gender: male</li>
        </div>
    </div>-->




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
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:Label runat="server" ID="lblTotal" HorizontalAlign="Center"></asp:Label> 
        <br />
        <asp:DropDownList ID="ddlPostage" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="getPostageAmount" runat="server"></asp:DropDownList>
        <br />
        <asp:Label runat="server" ID="lblPostage" Text="Postage: $0" HorizontalAlign="Center"></asp:Label>
        <br />
        <asp:Label runat="server" ID="lblSubtotal" HorizontalAlign="Center"></asp:Label>
    </div>
    
    <!-- button to go to payment with total amount written-->
    <div style="text-align: center; margin-top: 20px;"><asp:Button ID="btnPayment" runat="server" /></div>
</asp:Content>