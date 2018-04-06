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
    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="4"
        ItemType="UL.Classes.Clothes" SelectMethod="GetShoppingCartItems" onrowcommand="CartList_RowCommand">
    <%-- set the content of each rows of the gridview (the list of data we need for each cart items) --%>
    <Columns>
        <asp:BoundField DataField="iD" HeaderText="ID"/>
        <asp:TemplateField HeaderText="Img">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/sweater.png" Height="100px" Width="100px"/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="name" HeaderText="name"/>
        <asp:BoundField DataField="size" HeaderText="size"/>
        <asp:BoundField DataField="price" HeaderText="price in aud"/>
        <asp:BoundField DataField="type" HeaderText="type"/>
        <asp:BoundField DataField="description" HeaderText="description"/>
        <asp:BoundField DataField="gender" HeaderText="gender"/>
        <asp:ButtonField buttontype="Button" Text="remove" commandname="Remove"/>
    </Columns>
    </asp:GridView>

    <!-- button to go to payment with total amount written-->
    <div style="text-align: center; margin-top: 20px;"><asp:Button ID="btnPayment" runat="server" /></div>
</asp:Content>