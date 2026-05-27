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
    public partial class MenuDetails : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["FoodDBConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["MenuId"] != null)
                {
                    int menuId = Convert.ToInt32(Request.QueryString["MenuId"]);
                    LoadDetails(menuId);
                }
            }
        }
        private void LoadDetails(int id)
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
                    lblMenuId.Text = dr["MenuId"].ToString();
                    lblItemName.Text = dr["ItemName"].ToString();
                    lblCategory.Text = dr["Category"].ToString();
                    lblFoodType.Text = dr["FoodType"].ToString();
                    lblPrice.Text = dr["Price"].ToString();
                    lblQuantity.Text = dr["AvailableQuantity"].ToString();
                    lblAvailable.Text = Convert.ToBoolean(dr["IsAvailable"]) ? "Yes" : "No";
                    lblDate.Text = dr["CreatedDate"].ToString();
                }
            }
        }
        
    }
}