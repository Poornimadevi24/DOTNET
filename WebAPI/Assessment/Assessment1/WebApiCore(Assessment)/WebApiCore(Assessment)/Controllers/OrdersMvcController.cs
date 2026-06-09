using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApiCore_Assessment_.Models;

public class OrdersMvcController : Controller
{
    private readonly AppDbContext _context;

    public OrdersMvcController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult BuchananOrders()
    {
        var orders = _context.Orders
            .Where(o => o.EmployeeId == 5)
            .ToList();

        return View(orders);
    }
}