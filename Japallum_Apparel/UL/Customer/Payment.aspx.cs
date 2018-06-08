using DAL.Models;
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
    public partial class payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Request.IsSecureConnection)
            {
                string url =
                    ConfigurationManager.AppSettings["SecurePath"] + "Customer/Payment.aspx";
                Response.Redirect(url);
            }

            //you need to be logged for this page, this is the redirection if your not
            if (Session["log"] == null || Session["log"] == "notlogged")
            {
                Response.Redirect("Login.aspx");
            }
            ValidateOrder vO = new ValidateOrder();
            lblTotal.Text = "Total: $" + vO.getTotalAmount();
            lblSubTotal.Text = "Sub-Total: $" + vO.getSubTotalAmount();
            lblPostage.Text = "Postage: $" + vO.getPostageAmount();
            lblTax.Text = "Tax: $" + vO.getTaxAmount();
            lblAmountToPay.Text = "Amount to pay: $" + vO.getSubTotalAmount();
            //listener for the finalize payment button
            Pay.Click += new EventHandler(this.FinalizePayment);
        }
        
        //methode to reinitialize cart and go to payment confirmation page
        protected void FinalizePayment(Object sender, EventArgs e)
        {
            if (IsValid)
            {
                LoginProcedures lP = new LoginProcedures();
                    //so if the password is correct:
                    //- we create an order in the database
                    //- we empty the cart
                    //- we redirect the customer to the payment confirmation page
                    ValidateOrder vO = new ValidateOrder();
                    vO.createOrder();
                    Session["cart"] = null;
                    Session["postage"] = null;
                    Session["total"] = null;
                    Session["subTotal"] = null;
                    Response.Redirect("~/Customer/PaymentConfirmation.aspx");
                
            }
        }
    }
}