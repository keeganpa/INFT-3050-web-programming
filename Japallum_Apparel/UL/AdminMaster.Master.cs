using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UL
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Log(Object sender,
                          EventArgs e)
        {
            if (Session["log"] == null || Session["log"] == "notlogged")
            {
                Response.Redirect("~/Admin/AdminLogin.aspx");
            }
            else
            {
                Session["log"] = "notlogged";
                Response.Redirect("~/Admin/AdminLogout.aspx");
            }
        }
    }
}