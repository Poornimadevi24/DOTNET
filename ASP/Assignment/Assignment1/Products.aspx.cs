using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Assignemt
{
    public partial class Products : System.Web.UI.Page
    {
        class Product
        {
            public string ImageUrl { get; set; }
            public string Price { get; set; }
        }
        static Dictionary<string, Product> products = new Dictionary<string, Product>()
        {
            { "phone", new Product { ImageUrl = "images/phone.jpg", Price = "₹60,000" } },
            { "laptop", new Product { ImageUrl = "images/laptop.png", Price = "₹90,000" } },
            { "headphones", new Product { ImageUrl = "images/headphones.jpg", Price = "₹5,000" } },
            { "watch", new Product { ImageUrl = "images/watch.jpg", Price = "₹15,000" } }
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducts.Items.Add("Phone");
                ddlProducts.Items.Add("Laptop");
                ddlProducts.Items.Add("Headphones");
                ddlProducts.Items.Add("Watch");

                ddlProducts.SelectedIndex = 0;
                UpdateImage();
            }
        }
        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateImage();
            lblPrice.Text = "Price: ";
        }
        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            string key = ddlProducts.SelectedValue.ToLower();

            if (products.ContainsKey(key))
            {
                lblPrice.Text = "Price: " + products[key].Price;
            }
        }
        private void UpdateImage()
        {
            string key = ddlProducts.SelectedValue.ToLower();

            if (products.ContainsKey(key))
            {
                imgProduct.ImageUrl = products[key].ImageUrl;
            }
        }
    }
}