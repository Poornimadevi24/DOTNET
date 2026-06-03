using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Code_First_Approach.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext() : base("MoviesDB")
        {
        }

        public DbSet<Movies> Movies { get; set; }
    }
}