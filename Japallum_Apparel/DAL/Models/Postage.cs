using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Postage
    {
        private int id;
        private String description;
        private double cost;
        private Boolean active;

        public int postageID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public String postageDescription
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

        public double postageCost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }

        public Boolean postageActive
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

        public Postage()
        {
            id = 0;
            description = null;
            cost = 0.0;
            active = true;
        }

        public Postage(int ID, String pDesc, Double pCost, Boolean act)
        {
            id = ID;
            description = pDesc;
            cost = pCost;
            active = act;
        }

    }
}