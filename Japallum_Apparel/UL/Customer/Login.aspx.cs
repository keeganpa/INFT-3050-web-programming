using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL.Models;

namespace UL
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void userLogin(Object sender,
                           EventArgs e)
        {
            //when we log, the session is changed and we are redirected to the main page
            LoginProcedures bl = new LoginProcedures();
            int logResult = bl.tryToLog(txtEmail.Text, txtPassword.Text, "user");
            // Succesfully logged in
            if (logResult == 0)
            {
                Session["log"] = "logged";
                Session["loggedemail"] = txtEmail.Text;
                Session["loggedpassword"] = txtPassword.Text;
                Response.Redirect("Main.aspx");
            }
            // Password is incorrect
            else if (logResult == 1)
            {
                errorMessage.Text = "Password is not valid";
            }
            // Email is not valid
            else if (logResult == 2)
            {
                errorMessage.Text = "Email is not valid";
            }

            Session["log"] = "logged";
            Session["loggedemail"] = txtEmail.Text;
            Session["loggedpassword"] = txtPassword.Text;
            Response.Redirect("Main.aspx");
        }
    }
}