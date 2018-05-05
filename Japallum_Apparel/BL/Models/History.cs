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
        public List<Order> getHistory(String email, String password)
        {
            List<Order> orders = null;
            checkLogin log = new checkLogin();
            if (log.checkLog(email, password)){
                //todo use DAL

            }
            return orders;
        }
    }
}