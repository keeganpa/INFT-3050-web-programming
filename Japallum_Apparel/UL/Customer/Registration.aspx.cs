using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UL.Classes;
using UL.Customer;

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
            if (IsValid)
            {
                int sNum = Convert.ToInt32(txtStreetNumber.Text);
                int sNum2 = Convert.ToInt32(txtStreetNumberBill.Text);
                int pCode = Convert.ToInt32(txtPostcode.Text);
                int pCode2 = Convert.ToInt32(txtPostcodeBill.Text);
                // Creating new residential address and billing address for user
                // Will need to create a method that checks if address already exists before adding it to database
                Address resAddress = new Address(000001, sNum, txtStreetName.Text, txtCity.Text, txtState.Text, pCode);
                Address billAddress = new Address(000002, sNum2, txtStreetNameBill.Text, txtCityBill.Text, txtStateBill.Text, pCode2);
                // New User is created using user inputs and address objects created
                User user1 = new User(0000001, txtFirstName.Text, txtLastName.Text, resAddress, billAddress, txtEmail.Text, txtConfirmPassword.Text);
                Response.Redirect("RegistrationConfirmation.aspx");
            }
        }
    }
}