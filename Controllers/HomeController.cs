using eHospital.Models;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Confirmation()
        {
            return View();
        }

        //Doctor related actions
        public ActionResult todayAppointments()
        {
            return View();
        }

        public ActionResult upcomingAppointments()
        {
            return View();
        }
        public ActionResult viewAppointment(int id)
        {
            Appointment app = db.Appointments.Where(x => x.APPOINTMENT_ID == id).FirstOrDefault();
            app.STATUS = "COMPLETED";
            db.SaveChanges();
            return View(app);
        }
        public ActionResult addTreatment(Patient_Treatment treatment)
        {
            db.Patient_Treatment.Add(treatment);
            db.SaveChanges();
            return RedirectToAction("viewAppointment", "Home", new { id = treatment.P_ID });
        }

        public ActionResult treatmentHistory()
        {
            return View();
        }
        public ActionResult postFeedback(Feedback review)
        {
            db.Feedbacks.Add(review);
            db.SaveChanges();
            return RedirectToAction("indexPatient");
        }

        public ActionResult donors(Blood_Doners donor)
        {
            if(donor.BLOOD_GROUP != null)
            {
                List<Blood_Doners> doner = db.Blood_Doners.Where(d => d.BLOOD_GROUP == donor.BLOOD_GROUP && d.DONER_STATUS == "Approved").ToList();
                return View(doner);
            }
            else
            {
                List<Blood_Doners> doner = db.Blood_Doners.Where(d => d.DONER_STATUS == "Approved").ToList();
                return View(doner);
            }
            
        }

        public ActionResult bookDonation(Blood_Doners donors)
        {
          if(donors != null)
            {
                List<Blood_Doners> doner = db.Blood_Doners.Where(d => d.BLOOD_GROUP == donors.BLOOD_GROUP && d.DONER_STATUS == "Approved").ToList();
                return View(doner);
            }
            else
            {
                List<Blood_Doners> doner = db.Blood_Doners.Where(d => d.DONER_STATUS == "Approved").ToList();
                return View();
            }
            
        }

        public ActionResult confirumDonation(Blood_Donation donation)
        {
            db.Blood_Donation.Add(donation);
            db.SaveChanges();
            return View();
        }

        public ActionResult registeredPatients()
        {
            return View();
        }

        public ActionResult checkout()
        {
            return View();
        }
    }
}