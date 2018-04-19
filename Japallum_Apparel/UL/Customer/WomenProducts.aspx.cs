using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UL.Classes;

namespace UL.Customer
{
    public partial class WomenProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Re-directs to login page if there is no user logged in
            if (Session["log"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                // Shirt image sourced from - http://picture-cdn.wheretoget.it/js2w97-i.jpg
                Clothes shirt1 = new Clothes("Pretty Shirt", 000004, "small", 10.00, "shirts", "A very pretty shirt!", "female", "~/Images/Womens_shirt.jpg");
                // Pants image sourced from - https://assets.mountainkhakis.com/spree/images/1115/product/W-Sadie-Chino-Classic-Khaki.jpg?1453213882
                Clothes pants1 = new Clothes("Sexy Pants", 000005, "small", 20.00, "pants", "These pants are the hottest on the market right now!", "female", "~/Images/Womens_pants.jpg");
                // Footwear image sourced from - http://heelsme.com/wp-content/uploads/2016/09/Womens-Red-High-Heels-5orhlmxgze2.jpg
                Clothes footwear1 = new Clothes("High Heel Shoes", 000006, "6", 50.00, "footwear", "Very fancy high heels!", "female", "~/Images/Womens_footwear.jpg");
                List<Clothes> womensClothes = new List<Clothes>();
                womensClothes.Add(shirt1);
                womensClothes.Add(pants1);
                womensClothes.Add(footwear1);
                Session["WomensClothing"] = womensClothes;
            }
        }

        // Method is used to display a gridview of products
        public List<Clothes> GetWomensClothes()
        {
            return (List<Clothes>)Session["WomensClothing"];
        }

        public void SearchResult_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            //when the user clicks to add the product to their cart
            if (e.CommandName == "AddToCart")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                List<Clothes> tempClothes = (List<Clothes>)Session["WoensClothing"];
                List<Clothes> tempCart = (List<Clothes>)Session["cart"];
                tempCart.Add(tempClothes[index]);
                Session["cart"] = tempCart;
                Response.Redirect("WomenProducts.aspx");
            }
        }
    }
}