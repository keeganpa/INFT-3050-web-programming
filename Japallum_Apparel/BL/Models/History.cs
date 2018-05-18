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
            List<Order> orders = null;
            RetrieveHistory hist = new RetrieveHistory();
            orders = hist.getHistory();
            return orders;
        }
    }
}