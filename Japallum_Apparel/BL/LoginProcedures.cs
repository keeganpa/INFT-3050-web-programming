using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BL
{
    public class LoginProcedures
    {

        //the method triggered when someone try to log as a customer
        public int tryToLog(String email, String password)
        {
            //todo use DAL to get database id linked to email and password
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

        //method triggered to check if you can create the account
        public Boolean tryRegistration(String email)
        {
            //return true if email is free to use
            //todo use DAL to get data about the email
            Boolean isAlreadyUsedEmail = true;
            return !isAlreadyUsedEmail;
        }

        //method triggered when someone try to create an account
        public Boolean createAccount(String firstName, String lastName, String email, String password//,
                                    //todo address 1
                                    //todo address 2
                                    )
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
    }
}