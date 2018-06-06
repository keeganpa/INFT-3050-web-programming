using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;

namespace BL.Models
{
    public class PostageProcedures
    {
        public List<Postage> getPostage()
        {
            PostageActions pA = new PostageActions();
            return pA.getPostage();
        }

        public void setPostage(String description, Double cost, Boolean active)
        {
            PostageActions pA = new PostageActions();
            pA.addPostage(description, cost, active);
        }
    }
}