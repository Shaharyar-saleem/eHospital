using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eHospital.Models;

namespace eHospital.Controllers
{
    public class ReportsController : Controller
    {
        Model1 db = new Model1();
        public ActionResult appointmentsReport(Models.Filter filter)
        {
            if(filter.DateFrom == null)
            {
                ViewBag.DateFrom = System.DateTime.Today.ToString("s");
            }
            else
            {
                ViewBag.DateFrom = Convert.ToDateTime(filter.DateFrom).ToString("s");
            }

            if(filter.DateTo == null)
            {
                ViewBag.DateTo = System.DateTime.Now.ToString("s");
                filter.DateTo = System.DateTime.Today;
            }
            else
            {
                ViewBag.DateTo = Convert.ToDateTime(filter.DateTo).ToString("s");
            }
            
            ViewBag.Department = db.Departments.Select(x=> new SelectListItem { Value =x.DEPARTMENT_ID.ToString() , Text=x.DEPARTMENT_NAME }).ToList();

            if(filter.Department == null)
            {
                ViewBag.Doctor = db.Doctors.Select(x => new SelectListItem { Value = x.DR_ID.ToString(), Text = x.DR_NAME }).ToList();
            }
            else
            {
                ViewBag.Doctor = db.Doctors.Where(x => x.DEPARTMENT_FID == filter.Department).Select(x => new SelectListItem { Value = x.DR_ID.ToString(), Text = x.DR_NAME }).ToList();
            }
            List<Appointment> app = db.Appointments.Where(x => x.STATUS == "COMPLETED").ToList();
            if(filter.Department != null)
            {
                app = db.Appointments.Where(x => x.Doctor_Schedule.Doctor.DEPARTMENT_FID == filter.Department && x.STATUS == "COMPLETED" && x.APPOINTMENT_DATE >= filter.DateFrom).ToList();
                if(filter.Doctor != null)
                {
                    app = db.Appointments.Where(x => x.Doctor_Schedule.Doctor.DR_ID == filter.Doctor && x.STATUS == "COMPLETED" && x.APPOINTMENT_DATE >= filter.DateFrom).ToList();
                }
            }
            
            //List<Appointment> appointments = db.Appointments.Where(x => x.STATUS != "PENDING").ToList();
            return View(app);
        }
    }
}