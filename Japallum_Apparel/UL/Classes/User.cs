using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UL.Classes
{
    public class User
    {
        private int iD;
        private String firstName;
        private String lastName;
        private Address rAddress;
        private Address bAddress;
        private String emailAddress;
        private String password;

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

        public Address rAdd
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

        public Address bAdd
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

        public User(int id, String fN, String lN, Address rA, Address bA, String email, String pass)
        {
            iD = id;
            firstName = fN;
            lastName = lN;
            rAddress = rA;
            bAddress = bA;
            emailAddress = email;
            password = pass;
        }
    }
}