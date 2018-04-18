using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UL.Classes;

namespace UL
{
    public partial class adminRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterAdmin(object sender, EventArgs e)
        {
            if (IsValid)
            {
                UL.Classes.Admin admin1 = new UL.Classes.Admin(000001, txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtConfirmPassword.Text);
                Response.Redirect("adminLogin.aspx");
            }
        }
    }
}