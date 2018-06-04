using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Admin
    {
        private int iD;
        private String firstName;
        private String lastName;
        private String emailAddress;
        private String password;
        private Boolean active;

        public Boolean Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
            }
        }
        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        public String fName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public String lName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public String eAdd
        {
            get
            {
                return emailAddress;
            }

            set
            {
                emailAddress = value;
            }
        }

        public String Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public Admin()
        {
            iD = 0;
            firstName = null;
            lastName = null;
            emailAddress = null;
            password = null;
            active = true;
        }

        public Admin(int id, String fN, String lN, String email, String pass)
        {
            iD = id;
            firstName = fN;
            lastName = lN;
            emailAddress = email;
            password = pass;
            active = true;
        }
    }
}