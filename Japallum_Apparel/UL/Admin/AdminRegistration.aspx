<%@ Page Title="Admin Registration" Language="C#" AutoEventWireup="true" MasterPageFile="~/AdminMaster.Master" CodeBehind="AdminRegistration.aspx.cs" Inherits="UL.adminRegistration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="content">
        <table class="tableCentre">
            <tr>
                <th colspan="3">
                    <h2>Registration</h2>
                </th>
            </tr>
            <!-- First name textbox with validators -->
            <tr>
                <td>
                    First Name:
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtFirstName"
                        runat="server" />
                </td>
            </tr>
            <!-- Last name textbox with validators -->
            <tr>
                <td>
                    Last Name:
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtLastName"
                          runat="server" />
                </td>
            </tr>
            <!-- Password textbox with validators -->
            <tr>
                <td>
                    Password
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                        runat="server" />
                </td>
            </tr>
            <!-- Confirm password textbox with validators -->
            <tr>
                <td>
                    Confirm Password
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" />
                </td>
                <td>
                    <asp:CompareValidator ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPassword"
                        ControlToValidate="txtConfirmPassword" runat="server" />
                </td>
            </tr>
            <!-- Email address textbox with validators -->
            <tr>
                <td>
                    Email
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                        ControlToValidate="txtEmail" runat="server" />
                    <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <!-- Submit button runs RegisterAdmin method when clicked -->
                <td>
                    <asp:Button Text="Submit" runat="server" OnClick="RegisterAdmin" />
                </td>
                <td>
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
    </asp:Content>
