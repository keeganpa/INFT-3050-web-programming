using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Clothes
    {
        private int iD;
        private String size;
        private double price;
        private String description;
        private String gender;
        private String name;
        private Boolean active;
        private String imagePath;
        private int stockCount;
        private int lastEdit;

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

        public int StockCount
        {
            get
            {
                return stockCount;
            }

            set
            {
                stockCount = value;
            }
        }

        public int LastEdit
        {
            get
            {
                return lastEdit;
            }

            set
            {
                lastEdit = value;
            }
        }

        public String Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
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
        public double Price
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

        public Clothes()
        {
            iD = 0;
            size = null;
            price = 0.0;
            description = null;
            gender = null;
            active = true;
            name = null;
            imagePath = null;
            stockCount = 0;
            lastEdit = 0;
        }

        public Clothes(String n, int id, String s, double p, String descr, String gend, String path, int stock, int last)
        {
            iD = id;
            size = s;
            price = p;
            description = descr;
            gender = gend;
            active = true;
            name = n;
            imagePath = path;
            stockCount = stock;
            lastEdit = last;
        }

        
    }
}