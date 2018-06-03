using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL.Models;
using System.Configuration;

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
        }

        //method need by the gridview to construct its rows for each items
        public List<Clothes> GetSearchResult()
        {
            List<Clothes> tempClothes = new List<Clothes>();
            List<Clothes> tempMens = (List<Clothes>)Session["MensClothing"];
            List<Clothes> tempWomens = (List<Clothes>)Session["WomensClothing"];
            List<Clothes> tempYouth = (List<Clothes>)Session["YouthClothing"];
            tempClothes.AddRange(tempMens);
            tempClothes.AddRange(tempWomens);
            tempClothes.AddRange(tempYouth);
            Session["adminSearch"] = tempClothes;
            return (List<Clothes>)Session["adminSearch"];
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