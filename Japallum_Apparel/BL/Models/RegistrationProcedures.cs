using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;

namespace BL.Models
{
    public class RegistrationProcedures
    {
        UserActions usac = new UserActions();
        AddressActions adac = new AddressActions();
        public int createAddress(String sNum, String sName, String city, String state, int pCode)
        {
            adac.addAddress(sNum, sName, city, state, pCode);
            int tempID = adac.getAddressID(sNum, sName, pCode);
            return tempID;
        }

        public void createUser(String fName, String lName, int rAddress, int bAddress, String emailAddress, String password, Boolean active)
        {
            usac.addUser(fName, lName, rAddress, bAddress, emailAddress, password, true);
        }
    }
}