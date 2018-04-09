using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UL
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgBtnMainMens_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MenProducts.aspx");
        }

        protected void imgBtnMainWomens_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("WomenProducts.aspx");
        }

        protected void imgBtnMainKids_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("YouthProducts.aspx");
        }
    }
}