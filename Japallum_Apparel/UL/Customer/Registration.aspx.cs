using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UL.Classes;

namespace UL
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            int sNum = Convert.ToInt32(txtStreetNumber.Text);
            int sNum2 = Convert.ToInt32(txtStreetNumberBill.Text);
            int pCode = Convert.ToInt32(txtPostcode.Text);
            int pCode2 = Convert.ToInt32(txtPostcodeBill.Text);
            Address resAddress = new Address(000001, sNum, txtStreetName.Text, txtCity.Text, txtState.Text, pCode);
            Address billAddress = new Address(000002, sNum2, txtStreetNameBill.Text, txtCityBill.Text, txtStateBill.Text, pCode2);
            User user1 = new User(0000001, txtFirstName.Text, txtLastName.Text, resAddress, billAddress, txtEmail.Text, txtConfirmPassword.Text);
        }
    }
}