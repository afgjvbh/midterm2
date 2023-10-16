using midterm2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace midterm2.Controllers
{
    public class ShowTimeController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        // GET: ShowTime
        public ActionResult Index()
        {
            var all_show_time = from showtime in db.Showtimes select showtime;
            return View(all_show_time);
        }
    }
}