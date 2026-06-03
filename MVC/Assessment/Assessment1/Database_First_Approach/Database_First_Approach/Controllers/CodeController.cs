using Database_First_Approach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Database_First_Approach.Controllers
{
    public class CodeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult GermanyCustomers()
        {
            var result = db.Customers.Where(c => c.Country == "Germany").ToList();

            return View(result);
        }
        public ActionResult CustomerByOrder()
        {
            var result = (from o in db.Orders
                          join c in db.Customers
                          on o.CustomerID equals c.CustomerID
                          where o.OrderID == 10248
                          select c).FirstOrDefault();

            return View(result);
        }
    }
}