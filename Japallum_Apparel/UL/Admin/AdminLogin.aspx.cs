using System;
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
            //when we log, the session is changed and we are redirected to the manageItem page
            Session["log"] = "logged";
            Response.Redirect("ManageItem.aspx");
        }
    }
}