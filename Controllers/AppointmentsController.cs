using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eHospital.Models;

namespace eHospital.Controllers
{
    public class AppointmentsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.Doctor_Schedule).Include(a => a.Patient);
            return View(appointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.SCHEDULE_FID = new SelectList(db.Doctor_Schedule, "SCHEDULE_ID", "AVAILABLE_DAYS");
            ViewBag.PATIENT_FID = new SelectList(db.Patients, "PATIENT_ID", "PATIENT_NAME");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                Patient pat = (Patient)Session["Patient"];
                appointment.PATIENT_FID = pat.PATIENT_ID;
                appointment.STATUS = "PENDING";
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Confirmation", "Home");
            }

            ViewBag.SCHEDULE_FID = new SelectList(db.Doctor_Schedule, "SCHEDULE_ID", "AVAILABLE_DAYS", appointment.SCHEDULE_FID);
            ViewBag.PATIENT_FID = new SelectList(db.Patients, "PATIENT_ID", "PATIENT_NAME", appointment.PATIENT_FID);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.SCHEDULE_FID = new SelectList(db.Doctor_Schedule, "SCHEDULE_ID", "AVAILABLE_DAYS", appointment.SCHEDULE_FID);
            ViewBag.PATIENT_FID = new SelectList(db.Patients, "PATIENT_ID", "PATIENT_NAME", appointment.PATIENT_FID);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "APPOINTMENT_ID,SCHEDULE_FID,PATIENT_FID,APPOINTMENT_DATE,TIME_SLOT,STATUS")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SCHEDULE_FID = new SelectList(db.Doctor_Schedule, "SCHEDULE_ID", "AVAILABLE_DAYS", appointment.SCHEDULE_FID);
            ViewBag.PATIENT_FID = new SelectList(db.Patients, "PATIENT_ID", "PATIENT_NAME", appointment.PATIENT_FID);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
