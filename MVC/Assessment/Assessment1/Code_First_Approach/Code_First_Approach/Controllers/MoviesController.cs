using Code_First_Approach.Models;
using Code_First_Approach.Respostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code_First_Approach.Controllers
{
    public class MoviesController : Controller
    {
        IMovieRepository repo = new MovieRepository();

        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movies m)
        {
            repo.Insert(m);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Movies m)
        {
            repo.Update(m);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }

        public ActionResult MoviesByYear(int year)
        {
            return View(repo.GetByYear(year));
        }

        public ActionResult MoviesByDirector(string director)
        {
            return View(repo.GetByDirector(director));
        }

    }
}