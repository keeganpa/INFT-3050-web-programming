<%@ Page Title="" Language="C#" MasterPageFile="~/newUserMaster.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="UL.Customer.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="content">
        <div class="text_container">
            <h2>
                Lost Your Password?
            </h2>
            <%-- The Following should not be used in a proper website environment, for security reasons.--%>
            <table class="tableCentre">
                <tr>
                    <td colspan="3">
                        <h3>Not to worry, just put your email below and we will email it to you.</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>Email:</p>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxEmail" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Please put in an email" ControlToValidate="tbxEmail" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnPasswordRecover" runat="server" Text="Email Me My Password" OnClick="btnPasswordRecover_Click" />
                    </td>
                </tr>
            </table>
            <table class="tableCentre">
                <tr>
                    <td colspan="3">
                        <asp:TextBox ID="tbxInvalidEmail" runat="server" Visible="False" Font-Bold="True" ForeColor="Red" Width="209px" >That is not a valid Email Address</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TbxSentEmail" runat="server" Visible="False"  Text="Email has been sent." Font-Bold="True" ForeColor="Green" Width="132px" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
