﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UL.Classes
{
    public class Clothes
    {
        private int iD;
        private String size;
        private double price;
        private String type;
        private String description;
        private String gender;
        private String name;
        private Boolean active;
        private String imagePath;

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

        public Clothes(String n, int id, String s, double p, String typ, String descr, String gend, String path)
        {
            ID = id;
            Size = s;
            Price = p;
            Type = typ;
            Description = descr;
            Gender = gend;
            Active = true;
            Name = n;
            ImagePath = path;
        }

        
    }
}