using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Models;
using System.Configuration;
using BL.Models;

namespace UL
{
    public partial class manageItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //you need to be logged for this page, this is the redirection if your not
            if (Session["log"] == null || Session["log"] == "notlogged")
            {
                Response.Redirect("AdminLogin.aspx");
            }
            if (!Request.IsSecureConnection)
            {
                string url =
                    ConfigurationManager.AppSettings["SecurePath"] + "Admin/ManageItems.aspx";
                Response.Redirect(url);
            }

            //listener to add item
            Add.Click += new EventHandler(this.addItem);
        }

        //method to add an item to the shop
        public void addItem(Object sender, EventArgs e)
        {
            /*try
            {*/
                String size = txtSize.Text;
                decimal price;
                if (txtPrice.Text == "") { price = -1; } else { price = Convert.ToDecimal(txtPrice.Text); }
                String shortDesc = txtDescription.Text;
                String gender = txtGender.Text;
                String imagePath = txtPath.Text;
                int stock;
                if (txtStock.Text == "") { stock = -1; } else { stock = int.Parse(txtStock.Text); }
                if (size == "") { size = null; }
                if (shortDesc == "") { shortDesc = null; }
                if (gender == "") { gender = null; }
                if (imagePath == "") { imagePath = null; }
                ProductProcedures pP = new ProductProcedures();
                pP.addItem(size, price, shortDesc, gender, imagePath, stock);
                Response.Redirect("~/Admin/ManageItem.aspx");
            /*}
            catch
            {

            }*/
        }

        //method need by the gridview to construct its rows for each items
        public List<Clothes> GetSearchResult()
        {
            List<Clothes> tempClothes = new List<Clothes>();
            ProductProcedures pP = new ProductProcedures();
            List<Clothes> tempMens = (List<Clothes>)pP.getClothes("M");
            List<Clothes> tempWomens = (List<Clothes>)pP.getClothes("F");
            List<Clothes> tempYouth = (List<Clothes>)pP.getClothes("Y");
            tempClothes.AddRange(tempMens);
            tempClothes.AddRange(tempWomens);
            tempClothes.AddRange(tempYouth);
            return tempClothes;
        }

        //method to use action in gridview
        //thanks https://stackoverflow.com/questions/14254880/how-to-get-row-data-by-clicking-a-button-in-a-row-in-an-asp-net-gridview for the help
        public void SearchResult_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            //when the admin wan't to activate/desactivate a product
            if (e.CommandName == "Remove")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                List<Clothes> clothes = (List<Clothes>)Session["adminSearch"];
                if (clothes[index].Active == false)
                {
                    clothes[index].Active = true;
                    foreach(Clothes element in (List<Clothes>)Session["YouthClothing"])
                    {
                        if (element.ID == clothes[index].ID)
                        {
                            element.Active = true;
                        }
                    }
                    foreach (Clothes element in (List<Clothes>)Session["MensClothing"])
                    {
                        if (element.ID == clothes[index].ID)
                        {
                            element.Active = true;
                        }
                    }
                    foreach (Clothes element in (List<Clothes>)Session["WomensClothing"])
                    {
                        if (element.ID == clothes[index].ID)
                        {
                            element.Active = true;
                        }
                    }
                } else
                {
                    clothes[index].Active = false;
                    foreach (Clothes element in (List<Clothes>)Session["YouthClothing"])
                    {
                        if (element.ID == clothes[index].ID)
                        {
                            element.Active = false;
                        }
                    }
                    foreach (Clothes element in (List<Clothes>)Session["MensClothing"])
                    {
                        if (element.ID == clothes[index].ID)
                        {
                            element.Active = false;
                        }
                    }
                    foreach (Clothes element in (List<Clothes>)Session["WomensClothing"])
                    {
                        if (element.ID == clothes[index].ID)
                        {
                            element.Active = false;
                        }
                    }
                }
                Session["adminSearch"] = clothes;

                Response.Redirect("~/Admin/ManageItem.aspx");
            }
        }
    }
}