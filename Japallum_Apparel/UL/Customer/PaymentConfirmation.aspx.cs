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
            //listener for the button
            Return.Click += new EventHandler(this.GoBackHome);
        }

        //just a redirection to home page
        protected void GoBackHome(Object sender, EventArgs e)
        {
            Response.Redirect("~/Customer/Main.aspx");
        }
    }
}