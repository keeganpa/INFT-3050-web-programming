﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UL
{
    public partial class adminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void adLogin(Object sender,
                           EventArgs e)
        {
            Session["log"] = "logged";
            Response.Redirect("ManageItem.aspx");
        }
    }
}