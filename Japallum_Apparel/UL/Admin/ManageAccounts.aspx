<%@ Page Title="Manage Accounts" Language="C#" AutoEventWireup="true" MasterPageFile="~/adminMaster.Master" CodeBehind="ManageAccounts.aspx.cs" Inherits="UL.manageAccounts" %>

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
            <!-- Name textbox -->
            <tr>
                <td>
                    First Name:
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" />
                </td>
            </tr>
            <!-- size textbox -->
            <tr>
                <td>
                    Last Name:
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" />
                </td>
            </tr>
            <!-- price textbox -->
            <tr>
                <td>
                    Email:
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" />
                </td>
            </tr>
            <!-- type textbox -->
            <tr>
                <td>
                    Password:
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" />
                </td>
            </tr>
            <!-- Buttons -->
            <tr>
                <td>
                    <!-- Button to add an item to the database (with info above) -->
                    <asp:Button ID="Add" runat="server" Text="Add" Height="50px" Width="95%"/>
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
        <br />
        <br />
    </div>


    <!-- gridview to show search result -->
    <asp:GridView ID="SearchResult" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="4"
        ItemType="UL.Classes.User" SelectMethod="GetSearchResult" onrowcommand="SearchResult_RowCommand">
    <%-- set the content of each rows of the gridview (the list of data we need for each user) --%>
    <Columns>
        <asp:BoundField DataField="iD" HeaderText="ID"/>
        <asp:BoundField DataField="fname" HeaderText="firstname"/>
        <asp:BoundField DataField="lname" HeaderText="lastname"/>
        <asp:BoundField DataField="eadd" HeaderText="email address"/>
        <asp:BoundField DataField="password" HeaderText="password"/>
        <asp:BoundField DataField="active" HeaderText="active"/>
        <asp:ButtonField buttontype="Button" Text="activate/desactivate" commandname="Remove"/>
    </Columns>
    </asp:GridView>
</asp:Content>
