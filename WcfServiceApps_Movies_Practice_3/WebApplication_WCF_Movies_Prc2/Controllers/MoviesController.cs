using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_WCF_Movies_Prc2.Models;
using WebApplication_WCF_Movies_Prc2.ServiceReference1;

namespace WebApplication_WCF_Movies_Prc2.Controllers
{
    public class MoviesController : Controller
    {
        ServiceReference1.Service1Client db = new ServiceReference1.Service1Client();
        // GET: Movies
        public ActionResult Index(string String)
        {
            List<Moviess> mve_list = new List<Moviess>();
            if (!(String.IsNullOrEmpty(String)))
            {
                var list_Search = db.Search(String);
                foreach (var item in list_Search)
                {
                    Moviess m = new Moviess();
                    m.MovieId = item.MovieId;
                    m.Title = item.Title;
                    m.RunningTime = item.RunningTime;
                    m.ReleaseDate = item.ReleaseDate;
                    m.BoxOffice = item.BoxOffice;
                    m.GenreId = item.GenreId;
                    mve_list.Add(m);
                }
                return View(mve_list);
            }

            var list = db.GetAll();
            foreach (var item in list)
            {
                Moviess m = new Moviess();
                m.MovieId = item.MovieId;
                m.Title = item.Title;
                m.RunningTime = item.RunningTime;
                m.ReleaseDate = item.ReleaseDate;
                m.BoxOffice = item.BoxOffice;
                m.GenreId = item.GenreId;
                mve_list.Add(m);
            }
            return View(mve_list);
        }

        public ActionResult Details(int id)
        {
            var item = db.GetById(id);
            Moviess m = new Moviess();
            m.MovieId = item.MovieId;
            m.Title = item.Title;
            m.RunningTime = item.RunningTime;
            m.ReleaseDate = item.ReleaseDate;
            m.BoxOffice = item.BoxOffice;
            m.GenreId = item.GenreId;

            return View(m);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Moviess m)
        {
            if (ModelState.IsValid)
            {
                Movie mm = new Movie();
                mm.MovieId = m.MovieId;
                mm.Title = m.Title;
                mm.RunningTime = m.RunningTime;
                mm.ReleaseDate = m.ReleaseDate;
                mm.BoxOffice = m.BoxOffice;
                mm.GenreId = m.GenreId;
                db.Add(mm);
                return RedirectToAction("Index");
            }
            return View(m);
        }

        public ActionResult Edit(int id)
        {
            var item = db.GetById(id);
            Moviess mm = new Moviess();
            mm.MovieId = item.MovieId;
            mm.Title = item.Title;
            mm.RunningTime = item.RunningTime;
            mm.ReleaseDate = item.ReleaseDate;
            mm.BoxOffice = item.BoxOffice;
            mm.GenreId = item.GenreId;
            return View(mm);
        }

        [HttpPost]
        public ActionResult Edit(Moviess m)
        {
            if (ModelState.IsValid)
            {
                Movie mm = new Movie();
                mm.MovieId = m.MovieId;
                mm.Title = m.Title;
                mm.RunningTime = m.RunningTime;
                mm.ReleaseDate = m.ReleaseDate;
                mm.BoxOffice = m.BoxOffice;
                mm.GenreId = m.GenreId;
                db.Edit(mm);
                return RedirectToAction("Index");
            }
            return View(m);
        }

        public ActionResult Deleted(int id)
        {
            var item = db.GetById(id);
            Moviess mm = new Moviess();
            mm.MovieId = item.MovieId;
            mm.Title = item.Title;
            mm.RunningTime = item.RunningTime;
            mm.ReleaseDate = item.ReleaseDate;
            mm.BoxOffice = item.BoxOffice;
            mm.GenreId = item.GenreId;
            return View(mm);
        }

        [HttpPost, ActionName("Deleted")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}