using Code_First_Approach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_First_Approach.Respostories
{
    public class MovieRepository : IMovieRepository
    {
        MoviesContext db = new MoviesContext();

        public List<Movies> GetAll()
        {
            return db.Movies.ToList();
        }

        public Movies GetById(int id)
        {
            return db.Movies.Find(id);
        }

        public void Insert(Movies m)
        {
            db.Movies.Add(m);
            db.SaveChanges();
        }

        public void Update(Movies m)
        {
            db.Entry(m).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Movies m = db.Movies.Find(id);
            db.Movies.Remove(m);
            db.SaveChanges();
        }

        public List<Movies> GetByYear(int year)
        {
            return db.Movies
                     .Where(x => x.DateOfRelease.Year == year)
                     .ToList();
        }

        public List<Movies> GetByDirector(string director)
        {
            return db.Movies.Where(x => x.DirectorName == director).ToList();
        }

    }
}