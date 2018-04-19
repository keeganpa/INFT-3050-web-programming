using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UL.Classes;

namespace UL
{
    public partial class addBuy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //setting all the data label for the clothes
            Clothes clothes = (Clothes)Session["addCart"];
            img.ImageUrl = getPathName();
            //filling empty data if clothes not initialized
            if (clothes == null)
            {
                id.Text = "ID: ";
                name.Text = "name: ";
                price.Text = "price: $";
                size.Text = "size: ";
                type.Text = "type: ";
                description.Text = "description: ";
                gender.Text = "gender: ";
            }
            //if we have initialized the dummy data
            else
            {
                id.Text = "ID: " + clothes.ID;
                name.Text = "name: " + clothes.Name;
                price.Text = "price: $" + clothes.Price;
                size.Text = "size: " + clothes.Size;
                type.Text = "type: " + clothes.Type;
                description.Text = "description: " + clothes.Description;
                gender.Text = "gender: " + clothes.Gender;
            }


            //setting handler for addToCart button
            Add.Click += new EventHandler(this.AddToCart);
        }

        protected void AddToCart(Object sender, EventArgs e)
        {
            //if cart not set yet, initialize it
            if (Session["cart"] == null)
            {
                Session["cart"] = Session["addCart"];
            } else
            {
                //add a new element to cart
                List<Clothes> cart = (List<Clothes>)Session["cart"];
                Clothes clothes = (Clothes)Session["addCart"];
                cart.Add(clothes);
            }
            Response.Redirect("~/Customer/ShoppingCart.aspx");
        }

        // from https://stackoverflow.com/questions/29212447/dynamic-imageurl-in-asp-net-c-sharp
        //to get the path of the image we need
        public string getPathName()
        {
            Clothes clothes = (Clothes)Session["addCart"];
            if (clothes == null)
            {
                return "~/Images/no.png";
            }
            return clothes.ImagePath;
        }
    }
}