<%@ Page Title="Login" Language="C#" AutoEventWireup="true" MasterPageFile="~/newUserMaster.Master" CodeBehind="Login.aspx.cs" Inherits="UL.login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="content">
        <table class="tableCentre">
            <tr>
                <th colspan="3">
                    <h2>Login</h2>
                </th>
            </tr>
            <tr>
                <td>
                    Email:
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                        ControlToValidate="txtEmail" runat="server" />
                    <!--Regular expression to ensure that the email is valid, expression found courtesy of RegExlib.com-->
                    <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
                </td>
            </tr>
            <tr>
                <td>
                    Password:
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button Text="Login" runat="server" OnClick="userLogin" />
                </td>
                <td>
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>  
</asp:Content>
