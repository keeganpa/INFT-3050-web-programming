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

        //todo, useless
        public List<Order> getOrderForGridView()
        {
            return getOrderHistory();
        }
    }
}