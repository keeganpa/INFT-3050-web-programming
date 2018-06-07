using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using DAL.Models;
using System.Net.Mail;

namespace BL.Models
{
    public class LoginProcedures
    {
        UserActions uA = new UserActions();
        AdminActions aA = new AdminActions();

        public Boolean checkPassword(String password)
        {
            User tempUser = (User)HttpContext.Current.Session["currentSession"];
            if (tempUser.Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Method checks if valid email address
        // checks if the string is empty or a null
        //if its not then it will see if it can convert it to Email context
        // if it cant then it returns false
        public bool IsValidEmail(String email)
        {
            if (String.IsNullOrEmpty(email)) return false;
            //tries to convert
            try
            {
                MailAddress to = new MailAddress(email);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //CUSTOMER SIDE
        //the method triggered when someone try to log as a customer
        public int tryToLog(String email, String password, String indicator)
        {
            String userOrAdmin = indicator;
            String tempEmail = email;
            String tempPassword = password;

            if (IsValidEmail(tempEmail))
            {
                //Is a valid email address
                Boolean temp = false;
                //Use a method to retieve User Data from database
                if (userOrAdmin == "user")
                {
                    temp = uA.getUserAccount(tempEmail, tempPassword);
                }
                else if (userOrAdmin == "admin")
                {
                    temp = aA.getAdminAccount(tempEmail, tempPassword);
                }
                //Pass email and password to DAL method to access account
                if (temp == true)
                {
                    return 0;
                }
                return 2;
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
            return 0;
        }
    }
}