﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        public List<Order> getOrderHistory(String email, String password)
        {
            //todo get orderHistory from BL
            return null;
        }

        public List<Order> getOrderForGridView()
        {
            return getOrderHistory((String)Session["loggedemail"], (String)Session["loggedpassword"]);
        }
    }
}