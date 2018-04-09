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
                <a href="MenProducts.aspx">Mens Clothing</a><br />
                <asp:ImageButton ID="imgBtnMainMens" runat="server" ImageUrl="~/Images/Main_mens.jpg" Height="250px" BorderColor="Silver" BorderStyle="Ridge" OnClick="imgBtnMainMens_Click" AlternateText="Mens Clothes" />
                <br /><br />
                <a href="WomenProducts.aspx">Womens Clothing</a><br />
                <asp:ImageButton ID="imgBtnMainWomens" runat="server" ImageUrl="~/Images/Main_womens.jpg" BorderColor="Silver" BorderStyle="Ridge" Height="250px" OnClick="imgBtnMainWomens_Click" AlternateText="Womens Clothes" />
                <br /><br />
                and, of course<br />
                <a href="YouthProducts.aspx">Kids Clothes</a><br />
                <asp:ImageButton ID="imgBtnMainKids" runat="server" AlternateText="Kids Clothes" ImageUrl="~/Images/Main_children.jpg" Height="250" BorderColor="Silver" BorderStyle="Ridge" OnClick="imgBtnMainKids_Click" />
            </p>
        </div>
    </div>
</asp:Content>