using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashcollectorProject.Models;

namespace TrashcollectorProject.Controllers
{
    public class DayController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Day
        public ActionResult Index()
        {
            return View ();
        }
    }
}