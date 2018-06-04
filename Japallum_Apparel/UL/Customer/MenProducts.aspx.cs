using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Models;
using BL.Models;

namespace UL.Customer
{
    public partial class MenProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Re-directs to login page if there is no user logged in
            if (Session["log"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        public List<Clothes> getMensClothes()
        {
            ProductProcedures product = new ProductProcedures();
            List<Clothes> tempClothes = (List<Clothes>)product.getClothes("mens");
            return tempClothes;
        }

        public void SearchResult_RowCommand(Object sender, GridViewCommandEventArgs e)
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
                List<Clothes> tempClothes = (List<Clothes>)Session["MensClothing"];
                List<Clothes> tempCart = (List<Clothes>)Session["cart"];
                tempCart.Add(tempClothes[index]);
                Session["cart"] = tempCart;
                Response.Redirect("MenProducts.aspx");
            }
        }
    }
}