using Code_First_Approach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_First_Approach.Respostories
{
    public interface IMovieRepository
    {
        List<Movies> GetAll();
        Movies GetById(int id);
        void Insert(Movies m);
        void Update(Movies m);
        void Delete(int id);

        List<Movies> GetByYear(int year);
        List<Movies> GetByDirector(string director);
    }
}