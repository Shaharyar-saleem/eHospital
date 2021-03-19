using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eHospital.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult IndexCustomer()
        {
            return View();
        }

        public ActionResult IndexAdmin()
        {
            return View();
        }

        public ActionResult IndexDoctor()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult SingleBlog()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}