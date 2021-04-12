using eHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eHospital.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult IndexCustomer()
        {
            var blog = db.Blogs.Take(3).ToList();
            return View(blog);
        }

        public ActionResult IndexAdmin()
        {
            return View();
        }

        public ActionResult IndexDoctor()
        {
            return View();
        }

        public ActionResult IndexPatient()
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

        public ActionResult Blog(int? id)
        {
            if(id != null)
            {
                var blog = db.Blogs.Where(x => x.BLOG_ID == id).ToList();
                return View(blog);
            }
            else
            {
                var blog = db.Blogs.Where(X => X.BLOG_PIC != null).ToList();
                return View(blog);
            }
            return View();
        }

        public ActionResult SingleBlog(int id)
        {
            Blog blog = db.Blogs.Where(x=> x.BLOG_ID == id).FirstOrDefault();
            return View(blog);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Admin a)
        {
            // if admin is trying to log in
            if(a.lOGIN_AS == "Admin")
            {
                Admin adm = db.Admins.Where(x => x.ADMIN_EMAIL == a.ADMIN_EMAIL && x.ADMIN_PASSWORD == a.ADMIN_PASSWORD).FirstOrDefault();
                if (adm != null)
                {
                    Session["Admin"] = adm;
                    return RedirectToAction("IndexAdmin", "Home");
                }
                else
                {
                    ViewBag.Message = "Email or Password is wrong";
                    return View();
                }
            }

            // if Doctor is trying to log in

            if (a.lOGIN_AS == "Doctor")
            {
                Doctor doc = db.Doctors.Where(x => x.DR_EMAIL == a.ADMIN_EMAIL && x.DR_PASSWORD == a.ADMIN_PASSWORD).FirstOrDefault();
                if (doc != null)
                {
                    Session["Doctor"] = doc;
                    return RedirectToAction("IndexDoctor", "Home");
                }
                else
                {
                    ViewBag.Message = "Email or Password is wrong";
                    return View();
                }
            }

            // if Patient is trying to log in

            if (a.lOGIN_AS == "Patient")
            {
                Patient pat = db.Patients.Where(x => x.PATIENT_EMAIL == a.ADMIN_EMAIL && x.PATIENT_PASSWORD == a.ADMIN_PASSWORD).FirstOrDefault();
                if (pat != null)
                {
                    Session["Patient"] = pat;
                    return RedirectToAction("IndexPatient", "Home");
                }
                else
                {
                    ViewBag.Message = "Email or Password is wrong";
                    return View();
                }
            }

            else
            {
                return View();
            }
        }

        public ActionResult LogOut(Admin adm)
        {
            Session["Admin"] = null;
            Session["Patient"] = null;
            Session["Doctor"] = null;
            return RedirectToAction("LogIn","Home");
        }

        public ActionResult Booking(int id)
        {
            Doctor dr = db.Doctors.Where(x => x.DR_ID == id).FirstOrDefault();
            return View(dr);
        }
    }
}