using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UL.Classes;

namespace UL
{
    public partial class manageAccounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //method need by the gridview to construct its rows for each items
        public List<User> GetSearchResult()
        {
            return (List<User>)Session["adminUserSearch"];
        }

        //method to use action in gridview
        public void SearchResult_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            //when the admin wan't to activate/desactivate a user account
            if (e.CommandName == "Remove")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                List<User> users = (List<User>)Session["adminUserSearch"];
                if (users[index].Active == false)
                {
                    users[index].Active = true;
                }
                else
                {
                    users[index].Active = false;
                }
                Session["adminUserSearch"] = users;

                Response.Redirect("~/Admin/ManageAccounts.aspx");
            }
        }
    }
}