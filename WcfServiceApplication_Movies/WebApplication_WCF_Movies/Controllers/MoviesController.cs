using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_WCF_Movies.Models;
using WebApplication_WCF_Movies.ServiceReference1;

namespace WebApplication_WCF_Movies.Controllers
{
    public class MoviesController : Controller
    {
        ServiceReference1.Service1Client db = new ServiceReference1.Service1Client();
        // GET: Movies
        [HttpGet]
        public ActionResult Index()
        {
            List<Movie> mve_list = new List<Movie>();

            var list = db.GetAll();

            foreach(var item in list)
            {
                Movie mve = new Movie();
                mve.MovieId = item.MovieId;
                mve.Title = item.Title;
                mve.ReleaseDate = item.ReleaseDate;
                mve.RunningTime = item.RunningTime;
                mve.GenreId = item.GenreId;
                mve.BoxOffice = item.BoxOffice;
                mve_list.Add(mve);
            }
            return View(mve_list);
        }
        public ActionResult Details (int id)
        {
            var list = db.GetById(id);
            Movie cls = new Movie();
            cls.MovieId = list.MovieId;
            cls.Title = list.Title;
            cls.ReleaseDate = list.ReleaseDate;
            cls.RunningTime = list.RunningTime;
            cls.GenreId = list.GenreId;
            cls.BoxOffice = list.BoxOffice;
            return View(cls);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie item)
        {
            if (ModelState.IsValid)
            {
                Movies mve = new Movies();
                mve.Title = item.Title;
                mve.ReleaseDate = item.ReleaseDate;
                mve.RunningTime = item.RunningTime;
                mve.GenreId = item.GenreId;
                mve.BoxOffice = item.BoxOffice;

                db.Add(mve);

                return RedirectToAction("Index", "Movies");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var item = db.GetById(id);
            Movie mve = new Movie();
            mve.MovieId = item.MovieId;
            mve.Title = item.Title;
            mve.ReleaseDate = item.ReleaseDate;
            mve.RunningTime = item.RunningTime;
            mve.GenreId = item.GenreId;
            mve.BoxOffice = item.BoxOffice;
            //mve.Genre.GenreId = item.GenreId;
            return View(mve);
        }

        [HttpPost]
        public ActionResult Edit(Movie item)
        {
            if (ModelState.IsValid)
            {

                Movies ms = new Movies();

                ms.MovieId = item.MovieId;
                ms.Title = item.Title;
                ms.ReleaseDate = item.ReleaseDate;
                ms.RunningTime = item.RunningTime;
                ms.GenreId = item.GenreId;
                ms.BoxOffice = item.BoxOffice;
                //ms.GenreId = item.Genre.GenreId;
                
                int i = 0;
                i++;
                db.Edit(ms);
                return RedirectToAction("Index", "Movies");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                db.Delete(id);
                return RedirectToAction("Index", "Movies");
            }
            return View();
        }
    }
}