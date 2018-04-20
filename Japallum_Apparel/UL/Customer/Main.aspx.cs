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
            Session["adminSearch"] = clothes;

            //adding 3 users (with there address) for the search in admin manageAccount page
            Address address = new Address(1, 63, "milkyroad", "Newcastle", "NSW", 76560);
            User users1 = new Classes.User(4, "Paul", "Dubot", address, address, "keeganpa76@hotmail.fr", "yolo");
            User users2 = new Classes.User(5, "James", "Baley", address, address, "keeganpa76@hotmail.fr", "yolo");
            User users3 = new Classes.User(6, "Callum", "Findlay", address, address, "keeganpa76@hotmail.fr", "yolo");
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