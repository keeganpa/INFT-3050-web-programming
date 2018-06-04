using System;
using System.Collections.Generic;
using DAL.Models;
using BL.Models;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UL.Customer
{
    public partial class ProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Re-directs to login page if there is no user logged in
            if (Session["log"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        public Clothes getProductDetails()
        {
            ProductProcedures product = new ProductProcedures();
            Clothes selectedProduct = (Clothes)Session["selectedProduct"];
            return selectedProduct;
        }

        public void SelectedProduct_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            //when the user clicks to add the product to their cart
            if (e.CommandName == "AddToCart")
            {
                if (Session["cart"] == null)
                {
                    List<Clothes> cart = new List<Clothes>();
                    Session["cart"] = cart;
                }
                int index = Convert.ToInt32(e.CommandArgument);
                List<Clothes> tempCart = (List<Clothes>)Session["cart"];
                Clothes tempProduct = (Clothes)Session["selectedProduct"]; 
                tempCart.Add(tempProduct);
                Session["cart"] = tempCart;
                if (tempProduct.Gender == "M  ")
                {
                    Response.Redirect("MenProducts.aspx");
                }
                else if (tempProduct.Gender == "F  ")
                {
                    Response.Redirect("WomenProducts.aspx");
                }
                else if (tempProduct.Gender == "Y  ")
                {
                    Response.Redirect("YouthProducts.aspx");
                }
            }
        }
    }
}