using eHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        public ActionResult availableDoctors()
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

        public ActionResult checkout(int id)
        {
            Doctor_Schedule schedule = db.Doctor_Schedule.Where(x => x.SCHEDULE_ID == id).FirstOrDefault();
            return View(schedule);
        }

        public ActionResult createAppointment(Appointment app)
        {
            Session["Booking"] = app;
            if(app.PaymentMethod == "Cash-on-Appointment")
            {
                db.Appointments.Add(app);
                db.SaveChanges();
                return RedirectToAction("thanks");
            }
            else
            {
                string price = app.DR_FEE.ToString();
                return Redirect("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=marketingmaster113@gmail.com&item_name=eHospital&return=https://localhost:44301/Home/thanks&amount=" + price);
            }
        }

        public ActionResult thanks(string str)
        {
            Appointment appointment = (Appointment)Session["Booking"];
            //1. Sending email
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            Patient pat = db.Patients.Where(x => x.PATIENT_ID == appointment.PATIENT_FID).FirstOrDefault();
            mail.From = new MailAddress("shaharyarsaleem71@gmail.com");
            mail.To.Add(pat.PATIENT_EMAIL);
            mail.Subject = "Appointment Confirmation";
            mail.Body = "<b>eHospital</b><br> Your Appointment reserved successfully!";
            mail.IsBodyHtml = true;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("ehospital.bt1732@gmail.com", "pakistan17215@");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);

            //2. Send Sms to client


            //String api = "http://lifetimesms.com/json?api_token=9999d26657b5e2e2586841fed4b99199df75864338&api_secret=WalthamsFlorist&to=" + pat.PATIENT_CONTACT + "&from=8584&message=Appointment Confirmation. Thank you for Trust. Your Appointment has been Received.";
            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(api);
            //var httpResponse = (HttpWebResponse)req.GetResponse();



            //3. Save appointment
            if (appointment.PaymentMethod == "Paypal")
            {
                appointment.STATUS = "PAID";
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return View();
            }
            else
            {
                return View();
            }
           
        }
    }
}