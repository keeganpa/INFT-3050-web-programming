<%@ Page Title="About" Language="C#" MasterPageFile="~/newuserMaster.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="UL.about" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="content">
        <!-- just few text to explain the web site to customers -->
        <div class="text_container">
            <h2>We are an apparel business that puts quality and quantity on the same level</h2>
        </div>
        <div class="text_container_2col">
            <h3>About the Site</h3>
            <p>
               You can order any of our clothes through this site. Each piece of clothing has detailed information to help you choose the right clothes for you!<br /> 
               They can be delivered to your personal address from a selection of mailing options.<br />
               For any inquiries please check out our <a href="Contact.aspx">Contact Page</a> for more information
            </p>
        </div>
        <div class="text_container_2col">
            <h3> About the Company</h3>
            <p>
                Japallum was started by 3 beleaguered university students as a project for their IT course and has grown rapidly since then to be a major brand for the spending wary.
                We pride ourselves on our commitment to keeping your personal data that you share with us completely safe from being used in any party apart from ourselves and the couriers.
            </p>
        </div>
    </div>
</asp:Content>
