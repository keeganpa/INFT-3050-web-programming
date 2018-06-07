using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

            //create the order
            DateTime date = DateTime.Now;
            double subTotal = getSubTotalAmount();
            double total = getTotalAmount();
            int customerID = uA.getUserID();
            int customerAddress = aA.getAddressID((String)HttpContext.Current.Session["loggedemail"]);
            oA.addOrder(date, subTotal, total, customerID, customerAddress, tax);
            int orderID = oA.getOrderID(date, subTotal, total, customerID, customerAddress, tax);

            //for each clothes in the cart, we create a junction between the order and the product
            foreach (Clothes clothes in (List<Clothes>)HttpContext.Current.Session["cart"])
            {
                jA.addJunction(orderID, clothes.ID, clothes.Price, 1);
            }

        }

        //compute the total amount in the cart
        public double getSubTotalAmount()
        {
            double total = getTotalAmount();
            double taxAmount = getTaxAmount();
            double postage = getPostageAmount();
            double subTotal = total + taxAmount + postage;
            return subTotal;
        }


        //to compute the total amount of the products in the order
        public double getTotalAmount()
        {
            double total = (Double)HttpContext.Current.Session["total"];
            return total;
        }

        //to compute the amount of the taxes
        public double getTaxAmount()
        {
            double taxAmount = getTotalAmount() * tax;
            return taxAmount;
        }

        //to get the amount of the postage
        public double getPostageAmount()
        {
            double postage = (Double)HttpContext.Current.Session["postage"];
            return postage;
        }
    }
}