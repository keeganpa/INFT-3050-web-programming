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
            btnPayment.Click += new EventHandler(this.GoToPayment);
            btnPayment.Text = "Payment: $" + getTotalAmount();
        }

        //method need by the gridview to construct its rows for each items
        public List<Clothes> GetShoppingCartItems()
        {
            return (List<Clothes>)Session["cart"];
        }

        //method to use action in gridview
        public void CartList_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            //when we wan't to remove an item of the cart from the shopping cart gridview
            //comented code is a obsolete version which had a problem
            if (e.CommandName == "Remove")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                //GridViewRow row = CartList.Rows[index];
                //String iDToRemove = row.Cells[0].Text;
                //int IDToRemove = int.Parse(iDToRemove);
                List<Clothes> clothes = (List<Clothes>)Session["cart"];
                clothes.RemoveAt(index);
                Session["cart"] = clothes;
                /*
                for (int i=0; i < clothes.Count; i++)
                {
                    if (clothes[i].ID == IDToRemove)
                    {
                        clothes.RemoveAt(i);
                        Session["cart"] = clothes;
                    }
                }*/
                Response.Redirect("~/Customer/ShoppingCart.aspx");
            }
        }

        //method to go to the payment page
        protected void GoToPayment(Object sender, EventArgs e)
        {
            List<Clothes> clothes = (List<Clothes>)Session["cart"];
            if (clothes != null && getTotalAmount() != 0)
            {
                Response.Redirect("~/Customer/Payment.aspx");
            }
        }

        //method to get the total amount of the cart
        protected double getTotalAmount()
        {
            double total = 0;
            List<Clothes> clothes = (List<Clothes>)Session["cart"];
            if (clothes == null)
            {
                total = 0;
            } else
            {
                for (int i = 0; i < clothes.Count; i++)
                {
                    total += clothes[i].Price;
                }
            }
            return total;
        }
    }
}