using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_WCF_Movies.Controllers
{
    public class GenresController : Controller
    {
        // GET: Genre
        public ActionResult Index()
        {
            return View();
        }
    }
}