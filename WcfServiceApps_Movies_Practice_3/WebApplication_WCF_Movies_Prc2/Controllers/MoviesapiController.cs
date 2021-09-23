using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication_WCF_Movies_Prc2.Models;

namespace WebApplication_WCF_Movies_Prc2.Controllers
{
    public class MoviesapiController : ApiController
    {
        public static ServiceReference1.Service1Client db = new ServiceReference1.Service1Client();
        // GET: api/Moviesapi
        public IEnumerable<ServiceReference1.Movies> Get()
        {
            ServiceReference1.Service1Client db = new ServiceReference1.Service1Client();

            return db.GetAll().AsEnumerable();
        }

        //public JToken Get()
        //{
        //    return JToken.FromObject(db.GetAll());
        //}


        // GET: api/Moviesapi/5
        public IHttpActionResult Get(int id)
        {
            var item = db.GetById(id);
            Moviess m = new Moviess();
            m.MovieId = item.MovieId;
            m.Title = item.Title;
            m.RunningTime = item.RunningTime;
            m.ReleaseDate = item.ReleaseDate;
            m.BoxOffice = item.BoxOffice;
            m.GenreId = item.GenreId;
            return Ok(m);
        }

        // POST: api/Moviesapi
        public void Post(ServiceReference1.Movie value)
        {
            db.Add(value);
        }

        // PUT: api/Moviesapi/5
        public void Put(int id, ServiceReference1.Movie value)
        {
            db.Edit(value);
        }

        // DELETE: api/Moviesapi/5
        public void Delete(int id)
        {
            db.Delete(id);
        }
    }
}
