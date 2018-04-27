using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

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
            int logResult = bl.tryToLog(txtEmail.Text, txtPassword.Text);
            if (logResult == 2)
            {
                Session["log"] = "logged";
                Session["loggedemail"] = txtEmail.Text;
                Session["loggedpassword"] = txtPassword.Text;
                Response.Redirect("Main.aspx");
            } else if (logResult == 1)
            {
                errorMessage.Text = "password didn't match";
            }
            else if (logResult == 0)
            {
                errorMessage.Text = "Account not found";
            }

            //todo temporary will login isn't fully fonctional
            Session["log"] = "logged";
            Response.Redirect("Main.aspx");
        }
    }
}