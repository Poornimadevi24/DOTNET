using System.Linq;
using System.Web.Http;
using Webapi_Assessment_.DB;
using Webapi_Assessment_.Models;

namespace Web_API_Assessment.Controllers
{
    public class CountryController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/country
        [HttpGet]
        public IHttpActionResult GetCountries()
        {
            return Ok(db.Country.ToList());
        }

        // GET: api/country/1
        [HttpGet]
        public IHttpActionResult GetCountry(int id)
        {
            var country = db.Country.Find(id);

            if (country == null)
                return NotFound();

            return Ok(country);
        }

        // POST: api/country
        [HttpPost]
        public IHttpActionResult PostCountry(Country country)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Country.Add(country);
            db.SaveChanges();

            return Ok("Country Added Successfully");
        }

        // PUT: api/country/1
        [HttpPut]
        public IHttpActionResult PutCountry(int id, Country country)
        {
            var existing = db.Country.Find(id);

            if (existing == null)
                return NotFound();

            existing.CountryName = country.CountryName;
            existing.Capital = country.Capital;

            db.SaveChanges();

            return Ok("Country Updated Successfully");
        }

        // DELETE: api/country/1
        [HttpDelete]
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = db.Country.Find(id);

            if (country == null)
                return NotFound();

            db.Country.Remove(country);
            db.SaveChanges();

            return Ok("Country Deleted Successfully");
        }
    }
}