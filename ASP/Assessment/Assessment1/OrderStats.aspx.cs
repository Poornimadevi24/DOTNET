using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FoodOrderManagement
{
    public partial class OrderStats : System.Web.UI.Page
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
                LoadApplicationState();
                LoadCategoryStats();
            }
        }

        private void LoadApplicationState()
        {
            lblTotalVisitors.Text = "Total Visitors: " + Application["TotalVisitors"];
            lblActiveUsers.Text = "Active Users: " + Application["ActiveUsers"];
        }

        private void LoadCategoryStats()
        {
            DataTable dt;

        
            if (Cache["FoodCategoryStats"] == null)
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    string query = @"
                        SELECT Category, COUNT(*) AS TotalItems
                        FROM MenuItems
                        GROUP BY Category";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    dt = new DataTable();
                    da.Fill(dt);
                }

                
                Cache.Insert("FoodCategoryStats", dt, null,
                    DateTime.Now.AddMinutes(5),
                    System.Web.Caching.Cache.NoSlidingExpiration);
            }
            else
            {
                dt = (DataTable)Cache["FoodCategoryStats"];
            }

            gvCategoryStats.DataSource = dt;
            gvCategoryStats.DataBind();
        }
    }
}