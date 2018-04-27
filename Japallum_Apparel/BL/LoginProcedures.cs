using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UL.Classes;

namespace BL
{
    public class LoginProcedures
    {
        //CUSTOMER SIDE
        //the method triggered when someone try to log as a customer
        public int tryToLog(String email, String password)
        {
            //todo use DAL to get database id linked to email and password CUSTOMER
            int IDEmail = -1;
            String PasswordFromID = null;

            if (IDEmail == -1)
            {
                //no matching account
                return 0;
            }
            else if (PasswordFromID == null || PasswordFromID != password)
            {
                //the password doesn't match
                return 1;
            }
            else if (password == PasswordFromID)
            {
                //login is ok
                return 2;
            }
            //in any other case, by security you can't log
            return 0;
        }

        //method triggered to check if you can create the account CUSTOMER
        public Boolean tryRegistration(String email)
        {
            //return true if email is free to use
            //todo use DAL to get data about the email
            Boolean isAlreadyUsedEmail = true;
            return !isAlreadyUsedEmail;
        }

        //method triggered when someone try to create an account CUSTOMER
        public Boolean createAccount(String firstName, String lastName, Address address1, Address address2, String email, String password)
        {
            Boolean canCreate = tryRegistration(email);
            if (canCreate == false)
            {
                return false;
            }
            else
            {
                //todo make creation via DAL
                return true;
            }
        }









        //ADMIN SIDE
        //the method triggered when someone try to log as a customer
        public int adminTryToLog(String email, String password)
        {
            //todo use DAL to get database id linked to email and password ADMIN
            int IDEmail = -1;
            String PasswordFromID = null;

            if (IDEmail == -1)
            {
                //no matching account
                return 0;
            }
            else if (PasswordFromID == null || PasswordFromID != password)
            {
                //the password doesn't match
                return 1;
            }
            else if (password == PasswordFromID)
            {
                //login is ok
                return 2;
            }
            //in any other case, by security you can't log
            return 0;
        }

        //method triggered to check if you can create the account ADMIN
        public Boolean adminTryRegistration(String email)
        {
            //return true if email is free to use
            //todo use DAL to get data about the email
            Boolean isAlreadyUsedEmail = true;
            return !isAlreadyUsedEmail;
        }

        //method triggered when someone try to create an account ADMIN
        public Boolean adminCreateAccount(String firstName, String lastName, String email, String password)
        {
            Boolean canCreate = adminTryRegistration(email);
            if (canCreate == false)
            {
                return false;
            }
            else
            {
                //todo make creation via DAL
                return true;
            }
        }
    }
}