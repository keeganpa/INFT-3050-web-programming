using BL.Models;
using System;
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
            //you need to be logged for this page, this is the redirection if your not
            if (Session["log"] == null || Session["log"] == "notlogged")
            {
                Response.Redirect("Login.aspx");
            }
            ValidateOrder vO = new ValidateOrder();
            amount.Text = "Amount to pay: $" + vO.getTotalAmount();

            //listener for the finalize payment button
            Pay.Click += new EventHandler(this.FinalizePayment);
        }
        
        //methode to reinitialize cart and go to payment confirmation page
        protected void FinalizePayment(Object sender, EventArgs e)
        {
            if (IsValid)
            {
                LoginProcedures lP = new LoginProcedures();
                if (lP.checkPassword(txtPassword.Text))
                {
                    //so if the password is correct:
                    //- we create an order in the database
                    //- we empty the cart
                    //- we redirect the customer to the payment confirmation page
                    ValidateOrder vO = new ValidateOrder();
                    vO.createOrder();
                    Session["cart"] = new List<Clothes>();
                    Response.Redirect("~/Customer/PaymentConfirmation.aspx");
                }
            }
        }
    }
}