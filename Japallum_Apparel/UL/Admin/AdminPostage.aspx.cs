using System;
using DAL.Models;
using BL.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UL.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["log"] == null || Session["log"] == "notlogged")
            {
                Response.Redirect("AdminLogin.aspx");
            }
            if (!Request.IsSecureConnection)
            {
                string url =
                    ConfigurationManager.AppSettings["SecurePath"] + "Admin/AdminPostage.aspx";
                Response.Redirect(url);
            }
            btnAddPost.Click += new EventHandler(this.addPostage);
        }

        public List<Postage> GetPostageOptions()
        {
            PostageProcedures pP = new PostageProcedures();
            return pP.getPostage();
        }

        //method to use action in gridview
        //thanks https://stackoverflow.com/questions/14254880/how-to-get-row-data-by-clicking-a-button-in-a-row-in-an-asp-net-gridview for the help
        public void PostageList_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            //when the admin wan't to activate/desactivate a user account
            if (e.CommandName == "select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                List<Postage> postageOptions = GetPostageOptions();
                if (postageOptions[index].postageActive == false)
                {
                    postageOptions[index].postageActive = true;
                }
                else
                {
                    postageOptions[index].postageActive = false;
                }
                PostageProcedures pP = new PostageProcedures();
                pP.changeStatus(postageOptions[index].postageActive, postageOptions[index].postageID);
                Response.Redirect("~/Admin/AdminPostage.aspx");
            }
        }
        
        // Method used to add a new postage option
        public void addPostage(Object sender, EventArgs e)
        {
            PostageProcedures pP = new PostageProcedures();
            //BL use
            pP.setPostage(tbxPostName.Text, Convert.ToDouble(tbxPostageCost.Text), true);
            //when it's done we reload the page to have empty field (like that the manager know he actually pushed the button add)
            Response.Redirect("~/Admin/AdminPostage.aspx");
        }
    }
}