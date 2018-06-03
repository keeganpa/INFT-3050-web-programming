using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using System.Web;

namespace BL.Models
{
    public class ProductProcedures
    {
        RetrieveProduct rP = new RetrieveProduct();
        public IEnumerable<Clothes> getClothes(String gen)
        {
            List<Clothes> tempClothes = (List<Clothes>)rP.getGenderProducts(gen);
            return tempClothes;
        }
    }
}