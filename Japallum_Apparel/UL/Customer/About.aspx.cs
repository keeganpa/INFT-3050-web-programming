using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UL.Classes;

namespace UL
{
    public partial class about : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Just to initialize data since we don't have access to the database for now
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
    }
}