using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UL.Customer;
using BL.Models;

namespace UL
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // This method creates a new user based on the information input by the user on the client side
        protected void RegisterUser(object sender, EventArgs e)
        {
            string validCode = Convert.ToString(Session["validationCode"]);
            if (validCode.Equals(tbxValidation.Text)) { 
            if (IsValid)
            {

                String fName = txtFirstName.Text;
                String lName = txtLastName.Text;
                String email = txtEmail.Text;
                String password = txtPassword.Text;
                int rAddress = 0;
                int bAddress = 0;
                String sNum = txtStreetNumber.Text;
                String sName = txtStreetName.Text;
                String city = txtCity.Text;
                String state = txtState.Text;
                int pCode = Convert.ToInt32(txtPostcode.Text);
                RegistrationProcedures reg = new RegistrationProcedures();
                if (cbSameAddress.Checked)
                {
                    String billing_sNum = sNum;
                    String billing_sName = sName;
                    String billing_city = city;
                    String billing_state = state;
                    int billing_pCode = pCode;
                    rAddress = reg.createAddress(sNum, sName,city, state, pCode);
                    bAddress = rAddress;
                }
                else
                {
                    String billing_sNum = txtStreetNumberBill.Text;
                    String billing_sName = txtStreetNameBill.Text;
                    String billing_city = txtCityBill.Text;
                    String billing_state = txtStateBill.Text;
                    int billing_pCode = Convert.ToInt32(txtPostcodeBill.Text);
                    rAddress = reg.createAddress(sNum, sName, city, state, pCode);
                    bAddress = reg.createAddress(billing_sNum, billing_sName, billing_city, billing_state, billing_pCode);
                }
                reg.createUser(fName, lName, rAddress, bAddress, email, password);
                Response.Redirect("RegistrationConfirmation.aspx");
            }
            }
        }

        protected void sendValidation(object sender, EventArgs e)
        {
            string Email = txtEmail.Text;
            EmailProcedures bl = new EmailProcedures();
            string emailSent = bl.sendValidation(Email);
            Session["validationCode"] = emailSent;
        }

        
    }
}