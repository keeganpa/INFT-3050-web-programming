using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Models;
using BL.Models;

namespace UL.Customer
{
    public partial class MenProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Re-directs to login page if there is no user logged in
            if (Session["log"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        public List<Clothes> getMensClothes()
        {
            ProductProcedures product = new ProductProcedures();
            List<Clothes> tempClothes = (List<Clothes>)product.getClothes("M");
            return tempClothes;
        }

        public void SearchResult_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            //when the user clicks to view item
            if (e.CommandName == "ViewProductPage")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                List<Clothes> tempClothes = getMensClothes();
                Clothes tempProduct = tempClothes[index];
                Session["selectedProduct"] = tempProduct;
                Response.Redirect("ProductPage.aspx");
            }
        }
    }
}