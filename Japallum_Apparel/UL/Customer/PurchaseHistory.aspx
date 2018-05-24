<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/newUsermaster.Master" CodeBehind="PurchaseHistory.aspx.cs" Inherits="UL.purchaseHistory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="content">
        <div class="text_container">
            <h1>Purchase History</h1>
        </div>
        <!--A very basic idea of what purchase history will most likely look like as we have no data to input in here at the moment-->
        <asp:GridView ID="grdOrderHistory" runat="server" GridLines="Horizontal" AutoGenerateColumns="False" HorizontalAlign="center" CellPadding="4"
            ItemType="DAL.Models.Order" SelectMethod="GetOrderHistory"  OnRowCommand="History_RowCommand">
            <Columns>
                <asp:BoundField DataField="iD" HeaderText="ID No."/>
                <asp:BoundField DataField="date" HeaderText="Order Date" />
                <asp:BoundField DataField="total" HeaderText="Total" />
                <asp:BoundField DataField="postage" HeaderText="Postage" />
                <asp:BoundField DataField="tax" HeaderText="Tax" />
                <asp:ButtonField ButtonType="Button" Text="View Full Order" commandname="Select"/>
            </Columns>
        </asp:GridView>
        <asp:GridView ID="grdOrderDetails" runat="server" GridLines="Horizontal" AutoGenerateColumns="False" HorizontalAlign="center" CellPadding="4"
            ItemType="DAL.Models.Product" SelectMethod="GetOrderDetails">
            <Columns>
                <asp:BoundField DataField="iD" HeaderText="ID No."/>
                <asp:BoundField DataField="size" HeaderText="Size"/>
                <asp:BoundField DataField="price" HeaderText="Price"/>
                <asp:BoundField DataField="shortDesc" HeaderText="Description"/>
                <asp:BoundField DataField="gender" HeaderText="Gender"/>
                <asp:BoundField DataField="quantity" HeaderText="Quantity"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>