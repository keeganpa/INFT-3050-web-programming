<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminPostage.aspx.cs" Inherits="UL.Admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" runat="server">

    <div class="content">
        <table class="tableCentre">
            <tr>
                <th colspan="3">
                    <h3>Postage Data</h3>
                </th>
            </tr>
            <!--ID Search Bar-->
            <tr>
                <td>
                    ID (Search Only):
                </td>
                <td>
                    <asp:TextBox ID="tbxPostID" runat="server"/>
                </td>
            </tr>
            <!--Postage Name-->
            <tr>
                <td>
                    Postage Name:
                </td>
                <td>
                    <asp:TextBox ID="tbxPostName" runat="server"/>
                </td>
            </tr>
            <!--Postage Cost Box-->
            <tr>
                <td>
                    Postage Cost:
                </td>
                <td>
                    <asp:TextBox ID="tbxPostageCost" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAddPost" runat="server" Text="Add" Height="50px" Width="95%" />
                </td>
                <td>
                    <asp:Button ID="btnSearchPost" runat="server" Text="Search" Height="50px" Width="95%" />
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
        <!--Shows Search Results that fit criteria-->
        <asp:GridView ID="PostageList" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="4" HorizontalAlign="Center"
        ItemType="DAL.Models.Postage" SelectMethod="GetPostageOptions" onrowcommand="PostageList_RowCommand">
        <%-- set the content of each rows of the gridview (the list of data we need for each cart items) --%>
        <Columns>
            <asp:BoundField DataField="postageDescription" HeaderText="Postage Type"/>
            <asp:BoundField DataField="postageCost" HeaderText="Price"/>
            <asp:BoundField DataField="postageActive" HeaderText="Active" />
            <asp:ButtonField buttonType="Button" Text="Activate/Deactivate" CommandName="select"/>
        </Columns>
        </asp:GridView>
    </div>
</asp:Content>
