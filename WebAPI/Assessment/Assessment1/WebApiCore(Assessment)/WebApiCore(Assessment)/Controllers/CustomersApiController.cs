using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApiCore_Assessment_.Models;

[Route("api/[controller]")]
[ApiController]
public class CustomersApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public CustomersApiController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("GetByCountry")]
    public IActionResult GetByCountry(string country)
    {
        var param = new SqlParameter("@Country", country);

        var result = _context.Customers
            .FromSqlRaw("EXEC GetCustomersByCountry @Country", param)
            .ToList();

        return Ok(result);
    }
}
