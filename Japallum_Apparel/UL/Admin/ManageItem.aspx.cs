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
        ProductProcedures pP = new ProductProcedures();

        protected void Page_Load(object sender, EventArgs e)
        {
            //to set up the maxlength of the multiline textbox because the MaxLength attribut won't work for this one
            if (!IsPostBack) {
                txtLongDescription.Attributes.Add("maxlength", txtLongDescription.MaxLength.ToString());
            }

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

            //listener to add item and search them
            Add.Click += new EventHandler(this.addItem);
            Search.Click += new EventHandler(this.searchItem);
        }

        //method to add an item to the shop
        public void addItem(Object sender, EventArgs e)
        {
            try
            {
                //BL use
                pP.addItem(txtSize.Text, txtPrice.Text, txtDescription.Text, txtLongDescription.Text, txtGender.Text, txtPath.Text, txtStock.Text);

                //when it's done we reload the page to have empty field (like that the manager know he actually pushed the button add)
                Response.Redirect("~/Admin/ManageItem.aspx");
            }
            catch
            {
                //if there is a bug this message appear
                errorMessage.Text = "There were a problem adding the item, is you item short desciption unique or is it already in the database?";
            }
        }

        //method to search an item from the shop
        public void searchItem(Object sender, EventArgs e)
        {
            try
            {
            //BL use
            Session["adminsearch"] = pP.searchItem(txtID.Text, txtSize.Text, txtPrice.Text, txtDescription.Text, txtLongDescription.Text, txtGender.Text, txtPath.Text, txtStock.Text);

            //when it's done we reload the page to have empty field (like that the manager know he actually pushed the button add)
            Response.Redirect("~/Admin/ManageItem.aspx");
        }
            catch
            {
                //if there is a bug this message appear (there will be a bug if there is no item corresponding to the textbox)
                errorMessage.Text = "There were a problem searching the item, are you sure an item correspond to those data?";
            }
        }

        //method need by the gridview to construct its rows for each items
        public List<Product> GetSearchResults()
        {
            List<Product> tempProd = (List<Product>)Session["adminsearch"];
            return tempProd;
        }

        //method need by the gridview to construct its rows for each items
        public List<Clothes> GetAllProducts()
        {
            //we get clothes of each categories and add them one after the others
            List<Clothes> tempClothes = new List<Clothes>();
            //using BL
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