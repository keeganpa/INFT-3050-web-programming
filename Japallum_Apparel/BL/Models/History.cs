using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BL.Models
{
    public class History
    {
        OrderActions oA = new OrderActions();
        ProductActions pA = new ProductActions();

        //method to get the history of an user
        public List<Order> getHistory()
        {
            return oA.getHistory();
        }

        //method to get the products of an order
        public List<Product> getProducts(int id)
        {
            return pA.getProductsForHistory(id);
        }
    }
}