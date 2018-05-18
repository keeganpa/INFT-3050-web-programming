using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using DAL.Models;

namespace BL.Models
{
    public class LoginProcedures
    {
        //Method checks if valid email address
        public bool IsValidEmail(String email)
        {
            Regex emailRegex = new Regex(@"\w + ([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            if (emailRegex.IsMatch(email))
            {
                //Email is valid
                return true;
            }
            //Email is invalid
            return false;
        }

        //CUSTOMER SIDE
        //the method triggered when someone try to log as a customer
        public int tryToLog(String email, String password, String indicator)
        {
            //todo use DAL to get database id linked to email and password CUSTOMER
            String userOrAdmin = indicator;
            String tempEmail = email;
            String tempPassword = password;

            if (IsValidEmail(tempEmail))
            {
                //Is a valid email address
                //Create instance of DAL CheckLogin
                RetrieveAccount rA = new RetrieveAccount();
                Boolean temp = false;
                //Use a method to retieve User Data from database
                if (userOrAdmin == "user")
                {
                    temp = rA.getUserAccount(tempEmail, tempPassword);
                }
                else if (userOrAdmin == "admin")
                {
                    temp = rA.getAdminAccount(tempEmail, tempPassword);
                }
                //Pass email and password to DAL method to access account
                if (temp == false)
                {
                    return 1;
                }
                return 0;
            }
            else if (tempPassword == null || tempPassword != password)
            {
                //Password is empty
                return 1;
            }
            else if (!IsValidEmail(tempEmail))
            {
                //Email is not valid
                return 2;
            }
            //in any other case, by security you can't log
            return 3;
        }
    }
}