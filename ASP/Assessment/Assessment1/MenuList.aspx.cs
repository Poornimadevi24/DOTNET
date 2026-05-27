using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace FoodOrderManagement
{
    public partial class MenuList : System.Web.UI.Page
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
                LoadMenuItems();
            }
        }

        private void LoadMenuItems()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "SELECT * FROM MenuItems ORDER BY MenuId ";

                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gvMenu.DataSource = dt;
                    gvMenu.DataBind();
                }
            }
        }

        protected void gvMenu_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int menuId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "ViewMenu")
            {
                Response.Redirect("MenuDetails.aspx?MenuId=" + menuId);
            }

            else if (e.CommandName == "EditMenu")
            {
                Response.Redirect("AddEditMenu.aspx?MenuId=" + menuId);
            }

            else if (e.CommandName == "DeleteMenu")
            {
                DeleteMenu(menuId);
                LoadMenuItems();
            }
        }

        private void DeleteMenu(int menuId)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "DELETE FROM MenuItems WHERE MenuId=@MenuId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@MenuId", menuId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}