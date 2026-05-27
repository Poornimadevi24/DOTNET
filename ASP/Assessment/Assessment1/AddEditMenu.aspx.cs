using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodOrderManagement
{
    public partial class AddEditMenu : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["FoodDBConnection"].ConnectionString;
        int menuId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Request.QueryString["MenuId"] != null)
            {
                menuId = Convert.ToInt32(Request.QueryString["MenuId"]);
            }

            if (!IsPostBack)
            {
                if (menuId > 0)
                {
                    LoadMenuById(menuId);
                }
            }
        }
        private void LoadMenuById(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "SELECT * FROM MenuItems WHERE MenuId=@MenuId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MenuId", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtItemName.Text = dr["ItemName"].ToString();
                    ddlCategory.SelectedValue = dr["Category"].ToString();
                    ddlFoodType.SelectedValue = dr["FoodType"].ToString();
                    txtPrice.Text = dr["Price"].ToString();
                    txtQuantity.Text = dr["AvailableQuantity"].ToString();
                    chkAvailable.Checked = Convert.ToBoolean(dr["IsAvailable"]);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query;

                if (Request.QueryString["MenuId"] == null)
                {

                    query = @"INSERT INTO MenuItems(ItemName, Category, FoodType, Price, AvailableQuantity, IsAvailable)VALUES
                            (@ItemName, @Category, @FoodType, @Price, @Quantity, @Available)";
                }
                else
                {

                    query = @"UPDATE MenuItems SET
                    ItemName=@ItemName,
                    Category=@Category,
                    FoodType=@FoodType,
                    Price=@Price,
                    AvailableQuantity=@Quantity,
                    IsAvailable=@Available
                    WHERE MenuId=@MenuId";
                }
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text);
                cmd.Parameters.AddWithValue("@Category", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@FoodType", ddlFoodType.SelectedValue);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@Available", chkAvailable.Checked);

                if (Request.QueryString["MenuId"] != null)
                {
                    cmd.Parameters.AddWithValue("@MenuId", menuId);
                }

                con.Open();
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("MenuList.aspx");
        }
    }
    
}