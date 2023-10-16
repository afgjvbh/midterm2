using midterm2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace midterm2.Controllers
{
    public class MoviesController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        // GET: Movies
        public ActionResult Index()
        {
            var list_movies = (from movie in db.Movies select movie).OrderBy(n => n.release_date);
            return View(list_movies);
        }
    }
}