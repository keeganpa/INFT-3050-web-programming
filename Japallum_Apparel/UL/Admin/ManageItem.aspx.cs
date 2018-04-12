using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UL.Classes;

namespace UL
{
    public partial class manageItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["log"] == null || Session["log"] == "notlogged")
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }

        //method need by the gridview to construct its rows for each items
        public List<Clothes> GetSearchResult()
        {
            return (List<Clothes>)Session["adminSearch"];
        }

        //method to use action in gridview
        public void SearchResult_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            //when the admin wan't to activate/desactivate a product
            if (e.CommandName == "Remove")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                List<Clothes> clothes = (List<Clothes>)Session["adminSearch"];
                if (clothes[index].Active == false)
                {
                    clothes[index].Active = true;
                } else
                {
                    clothes[index].Active = false;
                }
                Session["adminSearch"] = clothes;

                Response.Redirect("~/Admin/ManageItem.aspx");
            }
        }
    }
}