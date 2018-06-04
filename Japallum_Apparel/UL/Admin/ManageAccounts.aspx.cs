using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Models;
using BL.Models;
using System.Configuration;

namespace UL
{
    public partial class manageAccounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //you need to be logged for this page, this is the redirection if your not
            if (Session["log"] == null)
            {
                Response.Redirect("AdminLogin.aspx");
            }
            if (!Request.IsSecureConnection)
            {
                string url =
                    ConfigurationManager.AppSettings["SecurePath"] + "Admin/ManageAccounts.aspx";
                Response.Redirect(url);
            }
        }

        //method need by the gridview to construct its rows for each items
        public List<User> getUserList()
        {
            UserProcedures uP = new UserProcedures();
            List<User> users = (List<User>)uP.displayUserList();
            return users;
        }

        //method to use action in gridview
        //thanks https://stackoverflow.com/questions/14254880/how-to-get-row-data-by-clicking-a-button-in-a-row-in-an-asp-net-gridview for the help
        public void SearchResult_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            //when the admin wan't to activate/desactivate a user account
            if (e.CommandName == "changeStatus")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                List<User> users = getUserList();
                if (users[index].Active == false)
                {
                    users[index].Active = true;
                }
                else
                {
                    users[index].Active = false;
                }
                UserProcedures uP = new UserProcedures();
                uP.changeStatus(users[index].Active, users[index].ID);
                Response.Redirect("~/Admin/ManageAccounts.aspx");
            }
        }
    }
}