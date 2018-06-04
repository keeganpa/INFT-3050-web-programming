using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class User
    {
        private int iD;
        private String firstName;
        private String lastName;
        private int rAddress;
        private int bAddress;
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

        public int rAdd
        {
            get
            {
                return rAddress;
            }

            set
            {
                rAddress = value;
            }
        }

        public int bAdd
        {
            get
            {
                return bAddress;
            }

            set
            {
                bAddress = value;
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

        public User()
        {
            iD = 0;
            firstName = null;
            lastName = null;
            rAddress = 0;
            bAddress = 0;
            emailAddress = null;
            password = null;
            active = true;
        }

        public User(int id, String fN, String lN, int rA, int bA, String email, String pass, Boolean act)
        {
            iD = id;
            firstName = fN;
            lastName = lN;
            rAddress = rA;
            bAddress = bA;
            emailAddress = email;
            password = pass;
            active = act;
        }
    }
}