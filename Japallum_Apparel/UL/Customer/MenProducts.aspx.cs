using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            //else
            //{
            //    // Shirt image sourced from - https://www.metroswimshop.com/images/tee_black.jpg
            //    Clothes shirt1 = new Clothes("Generic Shirt", 000001, "Large", 10.00, "shirts", "This shirt has a new style that is in fashion at the moment!", "male", "~/Images/Mens_shirt.jpg");
            //    // Pants image sourced from - https://thegenericclothingstore.weebly.com/uploads/6/3/9/9/6399250/s974624006995353717_p5_i1_w640.jpeg
            //    Clothes pants1 = new Clothes("Generic Pants", 000002, "36", 20.00, "pants", "These pants are the hottest on the market right now!", "male", "~/Images/Mens_pants.jpg");
            //    // Footwear image sourced from - http://i.stpost.com/generic-surplus-klein-wool-shoes-lace-ups-for-men-in-charcoal-grey~p~5185y_01~1500.3.jpg
            //    Clothes footwear1 = new Clothes("Generic Shoes", 000003, "11", 50.00, "footwear", "You'll be running everywhere with these bad boys!", "male", "~/Images/Mens_footwear.jpg");
            //    List<Clothes> mensClothes = new List<Clothes>();
            //    mensClothes.Add(shirt1);
            //    mensClothes.Add(pants1);
            //    mensClothes.Add(footwear1);
            //    Session["MensClothing"] = mensClothes;
            //}
        }

        // Method is used to display a gridview of products
        ProductProcedures product = new ProductProcedures();
        public List<Clothes> GetMensClothes()
        {
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