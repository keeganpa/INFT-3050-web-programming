using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UL
{
    public partial class paymentConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Return.Click += new EventHandler(this.GoBackHome);
        }

        protected void GoBackHome(Object sender, EventArgs e)
        {
            Response.Redirect("~/Customer/Main.aspx");
        }
    }
}