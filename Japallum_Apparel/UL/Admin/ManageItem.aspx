<%@ Page Title="Manage Products" Language="C#" AutoEventWireup="true" MasterPageFile="~/adminMaster.Master" CodeBehind="ManageItem.aspx.cs" Inherits="UL.manageItem" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">

    <!-- Data info form -->
    <div class="content">
        <table class="tableCentre">
            <tr>
                <th colspan="3">
                    <h2>Item Data</h2>
                </th>
            </tr>
            <!-- ID textbox -->
            <tr>
                <td>
                    ID (to search only):
                </td>
                <td>
                    <asp:TextBox ID="txtID" runat="server" />
                </td>
            </tr>
            <!-- size textbox -->
            <tr>
                <td>
                    Size:
                </td>
                <td>
                    <asp:TextBox ID="txtSize" runat="server" MaxLength="3"/>
                </td>
            </tr>
            <!-- price textbox -->
            <tr>
                <td>
                    Price:
                </td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server" />
                </td>
            </tr>
            <!-- description textbox -->
            <tr>
                <td>
                    Description:
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" MaxLength="100"/>
                </td>
            </tr>
            <!-- long description textbox -->
            <tr>
                <td>
                    Long Description:
                </td>
                <td>
                    <asp:TextBox ID="txtLongDescription" runat="server" TextMode="MultiLine" Rows="3" MaxLength="500"/>
                </td>
            </tr>
            <!-- gender textbox -->
            <tr>
                <td>
                    Gender:
                </td>
                <td>
                    <asp:TextBox ID="txtGender" runat="server" MaxLength="1"/>
                </td>
            </tr>
            <!-- stock textbox -->
            <tr>
                <td>
                    stock:
                </td>
                <td>
                    <asp:TextBox ID="txtStock" runat="server" />
                </td>
            </tr>
            <!-- path textbox -->
            <tr>
                <td>
                    Path:
                </td>
                <td>
                    <asp:TextBox ID="txtPath" runat="server" MaxLength="300"/>
                </td>
            </tr>
            <!-- Buttons -->
            <tr>
                <td>
                    <!-- Button to add an item to the database (with info above) -->
                    <asp:Button ID="Add" runat="server" Text="Add" Height="50px" Width="95%" />
                </td>
                <td>
                    <!-- Button to search in database (with info above) -->
                    <asp:Button ID="search" runat="server" Text="Search" Height="50px" Width="95%"/>
                </td>
            </tr>
            <tr>
                <td colspan="3"></td>
            </tr>
            <tr>
                <td colspan="3"><hr /></td>
            </tr>
            <tr>
                <td colspan="3"></td>
            </tr>
        </table>
        <div class="warning"><asp:Label Text="" ID="errorMessage" runat="server" /></div>
        <br />
        <br />
    


    <!-- gridview to show search result -->
    <asp:GridView ID="SearchResult" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="4"
        ItemType="DAL.Models.Clothes" SelectMethod="GetSearchResult" onrowcommand="SearchResult_RowCommand">
    <%-- set the content of each rows of the gridview (the list of data we need for each items) --%>
    <Columns>
        <asp:BoundField DataField="iD" HeaderText="ID"/>
        <asp:ImageField DataImageUrlField="imagePath" HeaderText="image" ControlStyle-Width="100px" ControlStyle-Height = "100px"/>
        <asp:BoundField DataField="size" HeaderText="size"/>
        <asp:BoundField DataField="price" HeaderText="price in aud"/>
        <asp:BoundField DataField="description" HeaderText="description"/>
        <asp:BoundField DataField="gender" HeaderText="gender"/>
        <asp:BoundField DataField="stockCount" HeaderText="stock"/>
        <asp:BoundField DataField="active" HeaderText="active"/>
        <asp:ButtonField buttontype="Button" Text="activate/deactivate" commandname="Remove"/>
    </Columns>
    </asp:GridView>
   </div>
</asp:Content>
