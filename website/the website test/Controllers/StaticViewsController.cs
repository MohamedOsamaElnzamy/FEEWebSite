using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace the_website_test.Controllers
{
    public class StaticViewsController : Controller
    {
        // GET: StaticViews
        public ActionResult contact()
        {
            return View();
        }
        public ActionResult Degrees()
        {
            return View();
        }
        public ActionResult Goals()
        {
            return View();
        }
        public ActionResult History()
        {
            return View();
        }
        public ActionResult Mission()
        {
            return View();
        }

    }
}