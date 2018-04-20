using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UL.Classes;

namespace UL
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Just to initialize dummy data since we don't have access to the database for now
            adding: 
            - 3 sweaters to the cart
            - 1 sweater to add to the cart in the AddBuy page
            - 3 sweaters for the search in admin manageItem page*/
            Clothes clothes1 = new Clothes("sweater", 4, "large", 25, "sweater", "sweater for students", "male", "~/Images/sweater.png");
            Clothes clothes2 = new Clothes("sweater", 5, "large", 25, "sweater", "sweater for students", "male", "~/Images/sweater.png");
            Clothes clothes3 = new Clothes("sweater", 6, "large", 25, "sweater", "sweater for students", "male", "~/Images/sweater.png");
            List<Clothes> clothes = new List<Clothes>();
            clothes.Add(clothes1);
            clothes.Add(clothes2);
            clothes.Add(clothes3);
            Session["cart"] = clothes;
            Session["addCart"] = clothes1;
            Session["adminSearch"] = new List<Clothes>();

            // Adding dummy data to the mens product page
            if (Session["MensClothing"] == null)
            {
                // Shirt image sourced from - https://www.metroswimshop.com/images/tee_black.jpg
                Clothes mensShirt1 = new Clothes("Generic Shirt", 000001, "Large", 10.00, "shirts", "This shirt has a new style that is in fashion at the moment!", "male", "~/Images/Mens_shirt.png");
                // Pants image sourced from - https://thegenericclothingstore.weebly.com/uploads/6/3/9/9/6399250/s974624006995353717_p5_i1_w640.jpeg
                Clothes mensPants1 = new Clothes("Generic Pants", 000002, "36", 20.00, "pants", "These pants are the hottest on the market right now!", "male", "~/Images/Mens_pants.png");
                // Footwear image sourced from - http://i.stpost.com/generic-surplus-klein-wool-shoes-lace-ups-for-men-in-charcoal-grey~p~5185y_01~1500.3.jpg
                Clothes mensFootwear1 = new Clothes("Generic Shoes", 000003, "11", 50.00, "footwear", "You'll be running everywhere with these bad boys!", "male", "~/Images/Mens_footwear.png");
                List<Clothes> mensClothes = new List<Clothes>();
                mensClothes.Add(mensShirt1);
                mensClothes.Add(mensPants1);
                mensClothes.Add(mensFootwear1);
                Session["MensClothing"] = mensClothes;
            }

            if (Session["WomensClothing"] == null)
            {
                // Adding dummy data to the Womens product page
                // Shirt image sourced from - http://picture-cdn.wheretoget.it/js2w97-i.jpg
                Clothes womensShirt1 = new Clothes("Pretty Shirt", 000004, "small", 10.00, "shirts", "A very pretty shirt!", "female", "~/Images/Womens_shirt.png");
                // Pants image sourced from - https://assets.mountainkhakis.com/spree/images/1115/product/W-Sadie-Chino-Classic-Khaki.jpg?1453213882
                Clothes womensPants1 = new Clothes("Sexy Pants", 000005, "small", 20.00, "pants", "These pants are the hottest on the market right now!", "female", "~/Images/Womens_pants.png");
                // Footwear image sourced from - http://heelsme.com/wp-content/uploads/2016/09/Womens-Red-High-Heels-5orhlmxgze2.jpg
                Clothes womensFootwear1 = new Clothes("High Heel Shoes", 000006, "6", 50.00, "footwear", "Very fancy high heels!", "female", "~/Images/Womens_footwear.png");
                List<Clothes> womensClothes = new List<Clothes>();
                womensClothes.Add(womensShirt1);
                womensClothes.Add(womensPants1);
                womensClothes.Add(womensFootwear1);
                Session["WomensClothing"] = womensClothes;
            }

            if (Session["YouthClothing"] == null)
            {
                // Adding dummy data to the Youth product page
                // Shirt image sourced from - http://cdn.sweatband.com/Mr%20Strong%20Kids%20T-Shirt_Mr_Strong_Kids_T-Shirt_2000x2000.jpg
                Clothes youthShirt1 = new Clothes("Playful shirt", 000007, "Large", 5.00, "shirt", "fun in the sun with this awesome shirt!", "male", "~/Images/Youth_shirt.png");
                // Pants image sourced from - http://robinsjean.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/s/p/sp2024-fuch-b.jpg
                Clothes youthPants1 = new Clothes("Happy pants", 000008, "36", 10.00, "pants", "These pants will make you play all day!", "female", "~/Images/Youth_pants.png");
                // Footwear image sourced from - http://fallinginstyle.net/wp-content/uploads/2013/08/Reebok-Kids-ATV19-shoes-2.jpg
                Clothes youthFootwear1 = new Clothes("Kids shoes", 000009, "11", 25.00, "footwear", "You'll be the coolest kid in school with these!", "male", "~/Images/Youth_footwear.png");
                List<Clothes> youthClothes = new List<Clothes>();
                youthClothes.Add(youthShirt1);
                youthClothes.Add(youthPants1);
                youthClothes.Add(youthFootwear1);
                Session["YouthClothing"] = youthClothes;
            }

            //adding 3 users (with there address) for the search in admin manageAccount page
            Address address = new Address(1, 63, "milkyroad", "Newcastle", "NSW", 76560);
            User users1 = new User(4, "Paul", "Dubot", address, address, "keeganpa76@hotmail.fr", "yolo");
            User users2 = new User(5, "James", "Baley", address, address, "keeganpa76@hotmail.fr", "yolo");
            User users3 = new User(6, "Callum", "Findlay", address, address, "keeganpa76@hotmail.fr", "yolo");
            List<User> users = new List<User>();
            users.Add(users1);
            users.Add(users2);
            users.Add(users3);
            Session["adminUserSearch"] = users;
        }

        protected void imgBtnMainMens_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MenProducts.aspx");
        }

        protected void imgBtnMainWomens_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("WomenProducts.aspx");
        }

        protected void imgBtnMainKids_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("YouthProducts.aspx");
        }
    }
}