using System;
using DAL.Models;
using BL.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UL.Customer
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnPayment.Click += new EventHandler(this.GoToPayment);
            lblTotal.Text = "Total: $" + getTotalAmount();
            if (Session["postage"] != null)
            {
                Double subTotal = getTotalAmount() + ((Double)Session["postage"]);
                lblPostage.Text = "Postage: $" + ((Double)Session["postage"]);
                lblSubtotal.Text = "Sub-Total: $" + subTotal;
            }
            else
            {
                lblPostage.Text = "Postage: $0";
                lblSubtotal.Text = "Sub-Total: $" + (getTotalAmount());
            }
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

        // Method used in postage girdview to show postage options
        public List<Postage> GetPostageOptions()
        {
            PostageProcedures pP = new PostageProcedures();
            return pP.getPostage();
        }

        //method to use action in gridview
        //thanks https://stackoverflow.com/questions/14254880/how-to-get-row-data-by-clicking-a-button-in-a-row-in-an-asp-net-gridview for the help
        public void PostageList_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            //when we wan't to remove an item of the cart from the shopping cart gridview
            //comented code is a obsolete version which had a problem
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                List<Postage> postageOptions = GetPostageOptions();
                Session["postage"] = postageOptions[index].postageCost;
                Response.Redirect("Checkout.aspx");
            }
        }

        //method to go to the payment page
        //doing nothing if there is nothing to pay
        protected void GoToPayment(Object sender, EventArgs e)
        {
            List<Clothes> clothes = (List<Clothes>)Session["cart"];
            if (clothes != null && getTotalAmount() != 0)
            {
                Double subTotal = getTotalAmount() + (Double)Session["postage"];
                Session["total"] = getTotalAmount();
                Session["subTotal"] = subTotal;
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
    }
}