using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;

namespace BL.Models
{
    public class PostageProcedures
    {
        // Method used to connect with DAL and create a postage object for use
        public List<Postage> getPostage()
        {
            PostageActions pA = new PostageActions();
            return pA.getPostage();
        }

        // Method used to change the active status of a postage item
        public void changeStatus(Boolean active, int id)
        {
            PostageActions pA = new PostageActions();
            pA.updatePostageActive(active, id);
        }

        // Method used to add a new postage item to the database
        public void setPostage(String description, Double cost, Boolean active)
        {
            PostageActions pA = new PostageActions();
            pA.addPostage(description, cost, active);
        }
    }
}