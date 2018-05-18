using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Order
    {
        private int iD;
        private DateTime date;
        private decimal total;
        private int postage;
        private double tax;
        private decimal subtotal;
        private int addressID;

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
        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }
        public decimal Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }
        public int Postage
        {
            get
            {
                return postage;
            }

            set
            {
                postage = value;
            }
        }
        public double Tax
        {
            get
            {
                return tax;
            }

            set
            {
                tax = value;
            }
        }
        public decimal Subtotal
        {
            get
            {
                return subtotal;
            }

            set
            {
                subtotal = value;
            }
        }
        public int AddressID
        {
            get
            {
                return addressID;
            }

            set
            {
                addressID = value;
            }
        }

        public Order(int id, DateTime date, decimal total, int postage, double tax, decimal subtotal, int addressid)
        {
            iD = id;
            Date = date;
            Total = total;
            Postage = postage;
            Tax = tax;
            Subtotal = subtotal;
            AddressID = addressid;
        }

    }
}