﻿using DAL.Models;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace UL
{
    public partial class shoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Set the button listener and value
            btnPayment.Click += new EventHandler(this.GoToPayment);
            btnPayment.Text = "Payment: $" + getTotalAmount();
            lblTotal.Text = "Total: $" + getTotalAmount();
            lblSubtotal.Text = "Sub-Total: $" + getTotalAmount();
            bindDropDownList();
            if (!Request.IsSecureConnection)
            {
                string url =
                    ConfigurationManager.AppSettings["SecurePath"] + "Customer/ShoppingCart.aspx";
                Response.Redirect(url);
            }
        }

        //method need by the gridview to construct its rows for each items
        public List<Clothes> GetShoppingCartItems()
        {
            return (List<Clothes>)Session["cart"];
        }
        
        public List<Postage> GetPostageOptions()
        {
            PostageProcedures pP = new PostageProcedures();
            return pP.getPostage();
        }

        //method to use action in gridview
        //thanks https://stackoverflow.com/questions/14254880/how-to-get-row-data-by-clicking-a-button-in-a-row-in-an-asp-net-gridview for the help
        public void CartList_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            //when we wan't to remove an item of the cart from the shopping cart gridview
            //comented code is a obsolete version which had a problem
            if (e.CommandName == "Remove")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                List<Clothes> clothes = (List<Clothes>)Session["cart"];
                clothes.RemoveAt(index);
                Session["cart"] = clothes;
                /*
                for (int i=0; i < clothes.Count; i++)
                {
                    if (clothes[i].ID == IDToRemove)
                    {
                        clothes.RemoveAt(i);
                        Session["cart"] = clothes;
                    }
                }*/
                Response.Redirect("~/Customer/ShoppingCart.aspx");
            }
        }

        protected void bindDropDownList()
        {
            List<Postage> tempPostage = GetPostageOptions();
            ddlPostage.DataSource = tempPostage;
            ddlPostage.DataTextField = "postageDescription";
            ddlPostage.DataValueField = "postageCost";
            ddlPostage.DataBind();
        }

        //method to go to the payment page
        //doing nothing if there is nothing to pay
        protected void GoToPayment(Object sender, EventArgs e)
        {
            List<Clothes> clothes = (List<Clothes>)Session["cart"];
            if (clothes != null && getTotalAmount() != 0)
            {
                Response.Redirect("~/Customer/Payment.aspx");
            }
        }

        //method to get the total amount of the cart
        protected double getTotalAmount()
        {
            double total = 0;
            List<Clothes> clothes = (List<Clothes>)Session["cart"];
            //if the cart isn't initialized we consider it's empty so the amount is 0
            if (clothes == null)
            {
                total = 0;
            } else
            {
                for (int i = 0; i < clothes.Count; i++)
                {
                    total += clothes[i].Price;
                }
            }
            return total;
        }

        protected void getPostageAmount(object sender, EventArgs e)
        {
            Double postage = Convert.ToDouble(ddlPostage.SelectedValue);
            lblPostage.Text = "Postage: $" + postage;
            lblSubtotal.Text = "Sub-Total: $" + (postage + getTotalAmount());
        }
    }
}