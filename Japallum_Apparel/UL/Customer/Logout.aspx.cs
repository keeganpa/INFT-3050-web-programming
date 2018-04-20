using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UL
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // When user logs out the the cart is emptied
            if (Session["log"] == null)
            {
                Session["cart"] = null;
            }
        }
    }
}