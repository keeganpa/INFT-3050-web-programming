using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL.Models;
using System.Configuration;

namespace UL
{
    public partial class adminRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsSecureConnection)
            {
                string url =
                    ConfigurationManager.AppSettings["SecurePath"] + "Admin/AdminRegistration.aspx";
                Response.Redirect(url);
            }
        }

        protected void RegisterAdmin(object sender, EventArgs e)
        {
            if (IsValid)
            {
                String fName = txtFirstName.Text;
                String lName = txtLastName.Text;
                String email = txtEmail.Text;
                String password = txtPassword.Text;
                RegistrationProcedures reg = new RegistrationProcedures();
                reg.createAdmin(fName, lName, password, email);
                Response.Redirect("adminLogin.aspx");
            }
        }
    }
}