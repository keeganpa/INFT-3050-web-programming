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
        RetrieveProduct rP = new RetrieveProduct();
        public List<Clothes> getClothes(String gen)
        {
            List<Clothes> tempClothes = (List<Clothes>)rP.getGenderProducts(gen);
            return tempClothes;
        }

        public void addItem(String size, decimal price, String shortDesc, String gender, String imagePath, int stock)
        {
            int adminID = aA.getAdminID();
            pA.addItem(size, price, shortDesc, gender, imagePath, stock, adminID);
        }
    }
}