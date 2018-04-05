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
            
        }

        public List<Clothes> GetShoppingCartItems()
        {
            return (List<Clothes>)Session["cart"];
        }

        public void CartList_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = CartList.Rows[index];
                String iDToRemove = row.Cells[0].Text;
                int IDToRemove = int.Parse(iDToRemove);
                System.Diagnostics.Debug.WriteLine("ID", iDToRemove);
                List<Clothes> clothes = (List<Clothes>)Session["cart"];
                System.Diagnostics.Debug.WriteLine("bug", Session["cart"]);
                for (int i=0; i < clothes.Count; i++)
                {
                    if (clothes[i].ID == IDToRemove)
                    {
                        clothes.RemoveAt(i);
                        Session["cart"] = clothes;
                    }
                }
                Response.Redirect("~/Customer/ShoppingCart.aspx");
            }
        }
    }
}