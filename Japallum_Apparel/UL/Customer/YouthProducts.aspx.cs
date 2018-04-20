using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UL.Classes;

namespace UL.Customer
{
    public partial class YouthProducts : System.Web.UI.Page
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
            //    // Shirt image sourced from - http://cdn.sweatband.com/Mr%20Strong%20Kids%20T-Shirt_Mr_Strong_Kids_T-Shirt_2000x2000.jpg
            //    Clothes shirt1 = new Clothes("Playful shirt", 000007, "Large", 5.00, "shirt" ,"fun in the sun with this awesome shirt!", "male", "~/Images/Youth_shirt.jpg");
            //    // Pants image sourced from - http://robinsjean.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/s/p/sp2024-fuch-b.jpg
            //    Clothes pants1 = new Clothes("Happy pants", 000008, "36", 10.00, "pants", "These pants will make you play all day!", "female", "~/Images/Youth_pants.jpg");
            //    // Footwear image sourced from - http://fallinginstyle.net/wp-content/uploads/2013/08/Reebok-Kids-ATV19-shoes-2.jpg
            //    Clothes footwear1 = new Clothes("Kids shoes", 000009, "11", 25.00, "footwear", "You'll be the coolest kid in school with these!", "male", "~/Images/Youth_footwear.jpg");
            //    List<Clothes> youthClothes = new List<Clothes>();
            //    youthClothes.Add(shirt1);
            //    youthClothes.Add(pants1);
            //    youthClothes.Add(footwear1);
            //    Session["YouthClothing"] = youthClothes;
            //}
        }

        // Method is used to display a gridview of products
        public List<Clothes> GetYouthClothes()
        {
            return (List<Clothes>)Session["YouthClothing"];
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
                List<Clothes> tempClothes = (List<Clothes>)Session["YouthClothing"];
                List<Clothes> tempCart = (List<Clothes>)Session["cart"];
                tempCart.Add(tempClothes[index]);
                Session["cart"] = tempCart;
                Response.Redirect("YouthProducts.aspx");
            }
        }
    }
}