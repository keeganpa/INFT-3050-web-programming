using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UL.Classes;

namespace BL.Models
{
    public class ValidateOrder
    {
        private double tax = 0.14;

        public void createOrder()
        {
            UserActions uA = new UserActions();
            AddressActions aA = new AddressActions();
            OrderActions oA = new OrderActions();
            JunctionActions jA = new JunctionActions();
            DateTime date = DateTime.Now;
            double subTotal = getSubTotalAmount();
            double total = getTotalAmount();
            int customerID = uA.getUserID();
            int customerAddress = aA.getAddressID((String)HttpContext.Current.Session["loggedemail"]);
            oA.addOrder(date, subTotal, total, customerID, customerAddress, tax);
            int orderID = oA.getOrderID(date, subTotal, total, customerID, customerAddress, tax);
            foreach (Clothes clothes in (List<Clothes>)HttpContext.Current.Session["cart"])
            {
                jA.addJunction(orderID, clothes.ID, clothes.Price, 1);
            }
        }

        //compute the total amount in the cart
        public double getSubTotalAmount()
        {
            double total = 0;
            List<Clothes> clothes = (List<Clothes>)HttpContext.Current.Session["cart"];
            //of course if the cart isn't initialized, we consider it's empty and the amount is 0
            if (clothes == null)
            {
                total = 0;
            }
            else
            {
                for (int i = 0; i < clothes.Count; i++)
                {
                    total += clothes[i].Price;
                }
            }
            return total;
        }

        public double getTotalAmount()
        {
            double total = getSubTotalAmount();
            total = total * (1 + tax);
            return total;
        }
    }
}