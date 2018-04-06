<%@ Page Title="Registration" Language="C#" AutoEventWireup="true" MasterPageFile="~/newUserMaster.Master" CodeBehind="Registration.aspx.cs" Inherits="UL.registration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            $('input:checkbox[id*=cbSameAddress]').change(function() {
                if ($(this).is(':checked')) {
                    $('input:text[id*=txtStreetNumberBill]').val($('input:text[id*=txtStreetNumber]').val());
                    $('input:text[id*=txtStreetNameBill]').val($('input:text[id*=txtStreetName]').val());
                    $('input:text[id*=txtCityBill]').val($('input:text[id*=txtCity]').val());
                    $('input:text[id*=txtStateBill]').val($('input:text[id*=txtState]').val());
                    $('input:text[id*=txtPostcodeBill]').val($('input:text[id*=txtPostcode]').val());
                }
                else {
                    $('input:text[id*=txtStreetNumberBill]').val('');
                    $('input:text[id*=txtStreetNameBill]').val('');
                    $('input:text[id*=txtCityBill]').val('');
                    $('input:text[id*=txtStateBill]').val('');
                    $('input:text[id*=txtPostcodeBill]').val('');
                }
            });
        });
    </script>
    <div class="content">
        <table class="tableCentre">
            <tr>
                <th colspan="3">
                    <h2>Registration</h2>
                </th>
            </tr>
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
            <tr>
                <td colspan="3"></td>
            </tr>
            <tr>
                <td colspan="3"><hr /></td>
            </tr>
            <tr>
                <td colspan="3"></td>
            </tr>
            <tr>
                <th colspan="3">
                    Residential Address
                </th>
            </tr>
            <tr>
                <td>
                    Street Number:
                </td>
                <td>
                    <asp:TextBox ID="txtStreetNumber" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtStreetNumber"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Street Name:
                </td>
                <td>
                    <asp:TextBox ID="txtStreetName" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtStreetName"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    City:
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtCity"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    State:
                </td>
                <td>
                    <asp:TextBox ID="txtState" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtState"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Post Code:
                </td>
                <td>
                    <asp:TextBox ID="txtPostcode" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPostcode"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Use same Address?
                </td>
                <td>
                    <asp:CheckBox ID="cbSameAddress" runat="server" />
                </td>
            </tr>
            <tr>
                <th colspan="3">
                    Billing Address
                </th>
            </tr>
            <tr>
                <td>
                    Street Number:
                </td>
                <td>
                    <asp:TextBox ID="txtStreetNumberBill" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtStreetNumberBill"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Street Name:
                </td>
                <td>
                    <asp:TextBox ID="txtStreetNameBill" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtStreetNameBill"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    City:
                </td>
                <td>
                    <asp:TextBox ID="txtCityBill" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtCityBill"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    State:
                </td>
                <td>
                    <asp:TextBox ID="txtStateBill" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtStateBill"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Post Code:
                </td>
                <td>
                    <asp:TextBox ID="txtPostcodeBill" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPostcodeBill"
                        runat="server" />
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
                <td>
                    <asp:Button Text="Submit" runat="server" OnClick="RegisterUser" />
                </td>
                <td>
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
    <!-- </form> RegisterUser -->
    
</asp:Content>