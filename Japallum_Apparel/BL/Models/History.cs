using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BL.Models
{
    public class History
    {
        //method to get the history of an user
        public List<Order> getHistory()
        {
            RetrieveHistory hist = new RetrieveHistory();
            return hist.getHistory();
        }

        //method to get the product of an order
        public List<Product> getProducts(int id)
        {
            RetrieveHistory prod = new RetrieveHistory();
            return prod.getProducts(id);
        }
    }
}