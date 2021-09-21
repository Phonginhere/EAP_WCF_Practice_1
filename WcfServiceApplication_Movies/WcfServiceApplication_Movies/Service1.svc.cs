using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceApplication_Movies
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        MoviesEntities db = new MoviesEntities();
        public void Add(Movie m)
        {
            Movie mve = new Movie();
            mve.Title = m.Title;
            mve.ReleaseDate = m.ReleaseDate;
            mve.RunningTime = m.RunningTime;
            mve.GenreId = m.GenreId;
            mve.BoxOffice = m.BoxOffice;
            db.Movies.Add(mve);

            db.SaveChanges();
            
        }

        public void Delete(int id)
        {
            Movie mve = new Movie();
            mve.MovieId = id;
            db.Entry(mve).State = EntityState.Deleted;
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
            db.Entry(m).State = EntityState.Modified;
            db.SaveChanges();


            //Movie mve = new Movie();
            //mve.MovieId = m.MovieId;
            //mve.ReleaseDate = m.ReleaseDate;
            //mve.RunningTime = m.RunningTime;
            //mve.GenreId = m.GenreId;
            //mve.BoxOffice = m.BoxOffice;
            //db.Entry(mve).State = EntityState.Modified;
            //db.SaveChanges();
        }

        public List<Movies> GetAll()
        {
            
            List<Movies> movie_list = new List<Movies>();
            var list = from m in db.Movies select m;
            foreach (var item in list)
            {
                Movies mve = new Movies();
                mve.MovieId = item.MovieId;
                mve.Title = item.Title;
                mve.ReleaseDate = item.ReleaseDate;
                mve.RunningTime = item.RunningTime;
                mve.GenreId = item.GenreId;
                mve.BoxOffice = item.BoxOffice;
                movie_list.Add(mve);
            }
            return movie_list;
        }

        public Movie GetById(int id)
        {
            var list = from m in db.Movies where m.MovieId == id select m;
            List<Movie> movie_list = new List<Movie>();
            Movie mve = null;
            foreach (var item in list)
            {
                mve = new Movie();
                mve.MovieId = item.MovieId;
                mve.Title = item.Title;
                mve.ReleaseDate = item.ReleaseDate;
                mve.RunningTime = item.RunningTime;
                mve.GenreId = item.GenreId;
                mve.BoxOffice = item.BoxOffice;
                movie_list.Add(mve);
            }
            return mve;
        }

        public List<Movies> Search(string Search)
        {
            List<Movies> movie_list = new List<Movies>();
            var list = from m in db.Movies where m.Title.Contains(Search) select m;
            foreach(var item in list)
            {
                Movies mve = new Movies();
                mve.MovieId = item.MovieId;
                mve.Title = item.Title;
                mve.ReleaseDate = item.ReleaseDate;
                mve.RunningTime = item.RunningTime;
                mve.GenreId = item.GenreId;
                mve.BoxOffice = item.BoxOffice;
                movie_list.Add(mve);
            }
            return movie_list;
        }
    }
}
