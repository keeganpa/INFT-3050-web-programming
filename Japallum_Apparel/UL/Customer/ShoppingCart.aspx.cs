using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UL.Classes;

namespace UL
{
    public partial class shoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Clothes clothes1 = new Clothes(1, "large", 25, "sweater", "sweater for students", "male");
            Clothes clothes2 = new Clothes(2, "large", 25, "sweater", "sweater for students", "male");
            Clothes clothes3 = new Clothes(3, "large", 25, "sweater", "sweater for students", "male");
            List<Clothes> clothes = new List<Clothes>();
            clothes.Add(clothes1);
            clothes.Add(clothes2);
            clothes.Add(clothes3);
            Session["cart"] = clothes;
        }

        public List<Clothes> GetShoppingCartItems()
        {
            return (List<Clothes>)Session["cart"];
        }
    }
}