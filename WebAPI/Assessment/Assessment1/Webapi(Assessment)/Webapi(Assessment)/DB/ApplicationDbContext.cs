using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Webapi_Assessment_.Models;

namespace Webapi_Assessment_.DB
{
    public class ApplicationDbContext : DbContext
     {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Country> Country { get; set; }
    }
}