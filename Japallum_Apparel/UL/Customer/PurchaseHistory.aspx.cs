using DAL.Models;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL.Models;
using UL.Classes;

namespace UL
{
    public partial class purchaseHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //you need to be logged for this page, this is the redirection if your not
            if (Session["log"] == null || Session["log"] == "notlogged")
            {
                Response.Redirect("Login.aspx");
            }
        }

        public List<Order> getOrderHistory()
        {
            History h = new History();
            List<Order> history = h.getHistory();
            return history;
        }

        public List<Product> getOrderDetails()
        {
            History h = new History();
            List<Product> products = new List<Product>();
            if (Session["prodID"] != null)
            {
                products = h.getProducts((int)Session["prodID"]);
            }
            return products;
        }

        //method to use action in gridview
        //thanks https://stackoverflow.com/questions/14254880/how-to-get-row-data-by-clicking-a-button-in-a-row-in-an-asp-net-gridview for the help
        public void History_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Session["prodID"] = Convert.ToInt32(grdOrderHistory.Rows[index].Cells[0].Text);

                Response.Redirect("~/Customer/PurchaseHistory.aspx");
            }
        }
    }
}