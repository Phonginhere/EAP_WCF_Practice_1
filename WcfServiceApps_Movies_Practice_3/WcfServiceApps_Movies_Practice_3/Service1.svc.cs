using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceApps_Movies_Practice_3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DbMoviesEntities db = new DbMoviesEntities();
        public void Add(Movie m)
        {
            db.Movies.Add(m);
            db.SaveChanges();

        }

        public void Delete(int Id)
        {
            Movie m = new Movie();
            m.MovieId = Id;
            db.Entry(m).State = System.Data.EntityState.Deleted;
            try
            {
                db.SaveChanges();
            }
            catch
            {

            }
        }

        public void Edit(Movie m)
        {
            db.Entry(m).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public List<Movies> GetAll()
        {
            List<Movies> movielist = new List<Movies>();
            var list = from m in db.Movies select m;
            foreach (var item in list)
            {
                Movies m = new Movies();
                m.MovieId = item.MovieId;
                m.Title = item.Title;
                m.RunningTime = item.RunningTime;
                m.ReleaseDate = item.ReleaseDate;
                m.BoxOffice = item.BoxOffice;
                m.GenreId = item.GenreId;
                movielist.Add(m);

            }
            return movielist;
        }

        public Movie GetById(int Id)
        {

            var list = from mv in db.Movies where mv.MovieId == Id select mv;
            Movie m = null;
            foreach (var item in list)
            {
                m = new Movie();
                m.MovieId = item.MovieId;
                m.Title = item.Title;
                m.RunningTime = item.RunningTime;
                m.ReleaseDate = item.ReleaseDate;
                m.BoxOffice = item.BoxOffice;
                m.GenreId = item.GenreId;

            }
            return m;
        }

        public List<Movies> Search(string Search)
        {
            List<Movies> movielist = new List<Movies>();
            var list = from m in db.Movies where m.Title.Contains(Search) select m;
            foreach (var item in list)
            {
                Movies m = new Movies();
                m.MovieId = item.MovieId;
                m.Title = item.Title;
                m.RunningTime = item.RunningTime;
                m.ReleaseDate = item.ReleaseDate;
                m.BoxOffice = item.BoxOffice;
                m.GenreId = item.GenreId;
                movielist.Add(m);

            }
            return movielist;
        }
    }
}
