using System;
using System.Web.Routing;

namespace FoodOrderManagement
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
            Application["TotalVisitors"] = 0;
            Application["ActiveUsers"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application["TotalVisitors"] =
                (int)Application["TotalVisitors"] + 1;

            Application["ActiveUsers"] =
                (int)Application["ActiveUsers"] + 1;
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application["ActiveUsers"] =
                (int)Application["ActiveUsers"] - 1;
        }
        

        void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("LoginRoute", "Login", "~/Login.aspx");
            routes.MapPageRoute("OrderStatsRoute", "OrderStats", "~/OrderStats.aspx");
            
        }
    }
}