using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication_WCF_Movies_Prc2.Controllers
{
    public class MoviesapiController : ApiController
    {
        public static ServiceReference1.Service1Client db = new ServiceReference1.Service1Client();
        // GET: api/Moviesapi
        //public IEnumerable<ServiceReference1.Movies> Get()
        //{
        //    ServiceReference1.Service1Client db = new ServiceReference1.Service1Client();

        //    return db.GetAll().AsEnumerable();
        //}

        public JToken Get()
        {
            return JToken.FromObject(db.GetAll());
        }


        // GET: api/Moviesapi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Moviesapi
        public void Post(ServiceReference1.Movie value)
        {
            db.Add(value);
        }

        // PUT: api/Moviesapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Moviesapi/5
        public void Delete(int id)
        {
        }
    }
}
