using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UL.Classes
{
    public class Address
    {
        private int iD;
        private int streetNumber;
        private String streetName;
        private String city;
        private String state;
        private int postCode;

        public int addressID
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

        public int addressNumber
        {
            get
            {
                return streetNumber;
            }

            set
            {
                streetNumber = value;
            }
        }

        public String addressName
        {
            get
            {
                return streetName;
            }

            set
            {
                streetName = value;
            }
        }

        public String addressCity
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        public String addressState
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }

        public int addressPostcode
        {
            get
            {
                return postCode;
            }

            set
            {
                postCode = value;
            }
        }

        public Address(int id, int sNum, String sName, String c, String s, int pCode)
        {
            iD = id;
            streetNumber = sNum;
            streetName = sName;
            city = c;
            state = s;
            postCode = pCode;
        }
}