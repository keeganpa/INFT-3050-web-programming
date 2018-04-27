<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/newUsermaster.Master" CodeBehind="PurchaseHistory.aspx.cs" Inherits="UL.purchaseHistory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="content">
        <div class="text_container">
            <h1>Purchase History</h1>
        </div>
        <!--A very basic idea of what purchase history will most likely look like as we have no data to input in here at the moment-->
        <asp:GridView ID="grdOrderhistory" runat="server" GridLines="Horizontal" AutoGenerateColumns="False" CellPadding="4"
            ItemType="UL.Classes.Order" SelectMethod="GetOrderFromGridView">
            <Columns>
                <asp:BoundField HeaderText="ID No."/>
                <asp:BoundField HeaderText="Order Date" />
                <asp:BoundField HeaderText="Products" />
                <asp:BoundField HeaderText="Postage" />
                <asp:BoundField HeaderText="Cost" />
                <asp:ButtonField ButtonType="Button" Text="View Full Order" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>