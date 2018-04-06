using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UL
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void userLogin(Object sender, EventArgs e)
        {
           Response.Redirect("Login.aspx");
        }
        protected void userLogout(object sender, EventArgs e)
        {
            Session["log"] = null;
            Response.Redirect("Logout.aspx");
        }

        }
    }
}