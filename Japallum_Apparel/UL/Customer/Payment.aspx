<%@ Page Title="Payment" Language="C#" AutoEventWireup="true" MasterPageFile="~/newuserMaster.Master" CodeBehind="Payment.aspx.cs" Inherits="UL.payment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- display the total amount to pay -->
    <div class="text_container">
        <br />
        <asp:Label ID="lblTotal" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblTax" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblPostage" runat="server"></asp:Label>
        <br />
        <br />
        <asp:label ID="lblSubTotal" runat="server"></asp:label>
        <br />
        <br />
        <h2><asp:Label ID="lblAmountToPay" runat="server"></asp:Label></h2>
    </div>
    <hr />
    <!-- from for the card data -->
    <div class="content">
        <table class="tableCentre">
            <tr>
                <th colspan="3">
                    <h2>Card data</h2>
                </th>
            </tr>

            <!-- name on card textbox with validator -->
            <tr>
                <td>
                    Name on Card (no accents or special charaters):
                </td>
                <!-- textbox -->
                <td>
                    <asp:TextBox ID="txtName" runat="server" />
                </td>
                <!-- validator -->
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtName"
                        runat="server" />
                    <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="^([a-zA-Z\040]+)$"
                        ControlToValidate="txtName" ForeColor="Red" ErrorMessage="You can't have such a weird name" />
                </td>
            </tr>

            <!-- Card Number textbox with validator -->
            <tr>
                <td>
                    Card Number:
                </td>
                <!-- textbox -->
                <td>
                    <asp:TextBox ID="txtCardNumber" runat="server" />
                </td>
                <!-- validator -->
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtCardNumber"
                          runat="server" />
                    <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="^[0-9]{4}[\040\055]*[0-9]{4}[\040\055]*[0-9]{4}[\040\055]*[0-9]{4}$"
                        ControlToValidate="txtCardNumber" ForeColor="Red" ErrorMessage="Invalid Card Number" />
                </td>
            </tr>

            <!-- Expiration date of the card textboxes with validators -->
            <tr>
                <td>
                    Expiration Date:
                </td>
                <!-- textboxes -->
                <td>
                    <div><asp:TextBox ID="txtMonth" runat="server" MaxLength="2" PlaceHolder="MM" Width="30px"/>/<asp:TextBox ID="txtYear" runat="server" MaxLength="2" PlaceHolder="YY" Width="30px"/></div>
                </td>
                <!-- validators -->
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtMonth"
                        runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtYear"
                        runat="server" />
                    <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="(^0[1-9]{1}$)|^10$|^11$|^12$"
                        ControlToValidate="txtMonth" ForeColor="Red" ErrorMessage="Invalid Month" />
                    <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="(^2{1}[0-9]{1}$)|^18$|^19$"
                        ControlToValidate="txtYear" ForeColor="Red" ErrorMessage="Invalid Year" />
                </td>
            </tr>

            <!-- security code textbox with validator -->
            <tr>
                <td>
                    Security Code:
                </td>
                <!-- textbox -->
                <td>
                    <asp:TextBox ID="txtSecurity" runat="server" MaxLength="3" />
                </td>
                <!-- validator -->
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtSecurity"
                          runat="server" />
                    <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="[0-9]{3}"
                        ControlToValidate="txtSecurity" ForeColor="Red" ErrorMessage="Invalid Security Code." />
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

            <!-- password textbox with validator -->
            <tr>
                <td>
                    Password
                </td>
                <!-- textbox -->
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                </td>
                <!-- validator -->
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                        runat="server" />
                </td>
            </tr>
        </table>
    </div>

    <!-- button to pay and go to payment confirmation -->
    <div style="text-align: center; margin-top: 20px;">
        <asp:Button ID="Pay" runat="server" Text="Pay"/>
        <br />
        <br />
    </div>
</asp:Content>
