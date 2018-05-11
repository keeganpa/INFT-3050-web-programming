using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL.Models;

namespace UL
{
    public partial class adminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void adLogin(Object sender, EventArgs e)
        {
            //when we log, the session is changed and we are redirected to the main page
            LoginProcedures bl = new LoginProcedures();
            int logResult = bl.tryToLog(txtEmail.Text, txtPassword.Text, "admin");
            if (logResult == 2)
            {
                Session["log"] = "logged";
                Session["loggedemail"] = txtEmail.Text;
                Session["loggedpassword"] = txtPassword.Text;
                Response.Redirect("Main.aspx");
            }
            else if (logResult == 1)
            {
                errorMessage.Text = "password didn't match";
            }
            else if (logResult == 0)
            {
                errorMessage.Text = "Account not found";
            }
        }
    }
}