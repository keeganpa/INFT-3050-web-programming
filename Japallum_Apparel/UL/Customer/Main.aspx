<%@ Page Title="Home" Language="C#" AutoEventWireup="true" MasterPageFile="~/newUsermaster.Master" CodeBehind="Main.aspx.cs" Inherits="UL.main" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="content">
        <div class="text_container">
            <h1> WELCOME TO JAPALLUM APPAREL!</h1>
        </div>
        <div class="text_container_2col">
            <p>
                Welcome to Japallum Apparel, we pride ourselves on keeping both quality and quantity to the best standards possible.<br /><br />
                <strong> What kind of apparel you ask?</strong><br />
                Well! We have plenty to choose from for all kinds including<br />
                <br />
                <!-- This format is used so that if the images dont load there is still the hyperlinks on the text for the customers to use to naviagte unless they use the navbar-->
                <a href="MenProducts.aspx">Mens Clothing</a><br />
                <asp:ImageButton ID="imgBtnMainMens" runat="server" ImageUrl="~/Images/Main_mens.jpg" Height="250px" BorderColor="Silver" BorderStyle="Ridge" OnClick="imgBtnMainMens_Click" AlternateText="Mens Clothes" />
                <br /><br />
                <a href="WomenProducts.aspx">Womens Clothing</a><br />
                <asp:ImageButton ID="imgBtnMainWomens" runat="server" ImageUrl="~/Images/Main_womens.jpg" BorderColor="Silver" BorderStyle="Ridge" Height="250px" OnClick="imgBtnMainWomens_Click" AlternateText="Womens Clothes" />
                <br /><br />
                and, of course<br />
                <a href="YouthProducts.aspx">Kids Clothes</a><br />
                <asp:ImageButton ID="imgBtnMainKids" runat="server" AlternateText="Kids Clothes" ImageUrl="~/Images/Main_children.jpg" Height="250" BorderColor="Silver" BorderStyle="Ridge" OnClick="imgBtnMainKids_Click" />
                <br />
                <strong>More Coming Soon&trade;</strong>
            </p>
        </div>
        <div class="text_container_2col">
            <h3>
                Where to Get Started
            </h3>
            <p>
                To get started on this site simply click the Register link at the top of the screen below the logo to make yourself a login <strong>OR</strong> if you already have a login then click the login button on the top right to log in to your account and get shopping.
                <br />
                <br />
                Alternatively you can just browse the store by hovering your mouse over the "Products" button and select which area you would like to look through to be able to see what we have on offer.
            </p>
        </div>
    </div>
</asp:Content>