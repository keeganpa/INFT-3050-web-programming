using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Product
    {
        private int iD;
        private String size;
        private decimal price;
        private String shortDesc;
        private String longDesc;
        private String gender;
        private Boolean active;
        private String imagePath;
        private int stock;
        private int lastEdited;
        private int quantity;

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
        public decimal Price
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
        public string ShortDesc
        {
            get
            {
                return shortDesc;
            }

            set
            {
                shortDesc = value;
            }
        }
        public string LongDesc
        {
            get
            {
                return longDesc;
            }

            set
            {
                longDesc = value;
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
        public bool Active
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
        public string ImagePath
        {
            get
            {
                return imagePath;
            }

            set
            {
                imagePath = value;
            }
        }
        public int Stock
        {
            get
            {
                return stock;
            }

            set
            {
                stock = value;
            }
        }
        public int LastEdited
        {
            get
            {
                return lastEdited;
            }

            set
            {
                lastEdited = value;
            }
        }
        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public Product(int id, String s, decimal p, String _short, String _long, String g, Boolean a, String path, int sck, int lEdit)
        {
            iD = id;
            size = s;
            price = p;
            shortDesc = _short;
            longDesc = _long;
            gender = g;
            active = a;
            imagePath = path;
            stock = sck;
            lastEdited = lEdit;
        }
    }
}