using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UL.Classes
{
    public class Clothes
    {
        private int iD;
        private String size;
        private int price;
        private String type;
        private String description;
        private String gender;

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
        public string Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }
        public int Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public Clothes(int id, String s, int p, String typ, String descr, String gend)
        {
            ID = id;
            Size = s;
            Price = p;
            Type = typ;
            Description = descr;
            Gender = gend;
        }

        
    }
}