using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Postage
    {
        private int iD;
        private String Desc;
        private Double Cost;
        private Boolean Active;

        public int postageID
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

        public String postageDesc
        {
            get
            {
                return Desc;
            }
            set
            {
                Desc = value;
            }
        }

        public Double postageCost
        {
            get
            {
                return Cost;
            }
            set
            {
                Cost = value;
            }
        }

        public Boolean postageActive
        {
            get
            {
                return Active;
            }
            set
            {
                Active = value;
            }
        }

        public Postage(int id, String desc, Double cost, Boolean active)
        {
            iD = id;
            postageDesc = desc;
            postageCost = cost;
            postageActive = active;
        }
    }
}