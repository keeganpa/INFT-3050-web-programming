using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL.Models;

namespace UL.Customer
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // Passes the given email to check for validity and to send that email its password if found to require one
        // if true then one text bok will show up
        //if false a different one will show/
        protected void btnPasswordRecover_Click(object sender, EventArgs e)
        {
            string txtEmail = tbxEmail.Text;
            EmailProcedures bl = new EmailProcedures();
            bool validEmail = bl.checkEmail(txtEmail);
            if (validEmail == true)
            {
                TbxSentEmail.Visible = true;
            }
            else if(validEmail == false)
            {
                tbxInvalidEmail.Visible = true;
            }
        }
    }
}