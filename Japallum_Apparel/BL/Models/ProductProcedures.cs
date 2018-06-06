using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using System.Web;

namespace BL.Models
{
    public class ProductProcedures
    {
        ProductActions pA = new ProductActions();
        AdminActions aA = new AdminActions();
        public List<Clothes> getClothes(String gen)
        {
            List<Clothes> tempClothes = (List<Clothes>)pA.getGenderProducts(gen);
            return tempClothes;
        }

        //method triggered when we want to add an item to the DB
        public void addItem(String size, String txtPrice, String shortDesc, String longDesc, String gender, String imagePath, String txtStock)
        {
            //default value, -1 if not given
            decimal price;
            int stock;
            if (txtPrice == "") { price = -1; } else { price = Convert.ToDecimal(txtPrice); }
            if (txtStock == "") { stock = -1; } else { stock = int.Parse(txtStock); }

            //we prefer to have null than "" for sql
            if (size == "") { size = null; }
            if (shortDesc == "") { shortDesc = null; }
            if (longDesc == "") { longDesc = null; }
            if (gender == "") { gender = null; }
            if (imagePath == "") { imagePath = null; }

            //DAL use
            int adminID = aA.getAdminID();
            pA.addItem(size, price, shortDesc, longDesc, gender, imagePath, stock, adminID);
        }
    }
}