﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UL.Classes;

namespace UL
{
    public partial class payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["log"] == null || Session["log"] == "notlogged")
            {
                Response.Redirect("Login.aspx");
            }
            amount.Text = "Amount to pay: $" + getTotalAmount();
            Pay.Click += new EventHandler(this.FinalizePayment);
        }

        //compute the total amount in the cart
        protected double getTotalAmount()
        {
            double total = 0;
            List<Clothes> clothes = (List<Clothes>)Session["cart"];
            if (clothes == null)
            {
                total = 0;
            }
            else
            {
                for (int i = 0; i < clothes.Count; i++)
                {
                    total += clothes[i].Price;
                }
            }
            return total;
        }
        
        //methode to reinitialize cart and go to payment confirmation page
        protected void FinalizePayment(Object sender, EventArgs e)
        {
            if (IsValid)
            {
                Session["cart"] = new List<Clothes>();
                Response.Redirect("~/Customer/PaymentConfirmation.aspx");
            }
        }
    }
}