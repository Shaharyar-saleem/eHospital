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
    public class Doctor_ScheduleController : Controller
    {
        private Model1 db = new Model1();

        // GET: Doctor_Schedule
        public ActionResult Index()
        {
            var doctor_Schedule = db.Doctor_Schedule.Include(d => d.Doctor);
            return View(doctor_Schedule.ToList());
        }

        // GET: Doctor_Schedule/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor_Schedule doctor_Schedule = db.Doctor_Schedule.Find(id);
            if (doctor_Schedule == null)
            {
                return HttpNotFound();
            }
            return View(doctor_Schedule);
        }

        // GET: Doctor_Schedule/Create
        public ActionResult Create()
        {
            ViewBag.DR_FID = new SelectList(db.Doctors, "DR_ID", "DR_NAME");
            return View();
        }

        // POST: Doctor_Schedule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SCHEDULE_ID,DR_FID,AVAILABLE_DAYS,START_TIME,END_TIME,MAX_APPOINTMENTS")] Doctor_Schedule doctor_Schedule)
        {
            if (ModelState.IsValid)
            {
                db.Doctor_Schedule.Add(doctor_Schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DR_FID = new SelectList(db.Doctors, "DR_ID", "DR_NAME", doctor_Schedule.DR_FID);
            return View(doctor_Schedule);
        }

        // GET: Doctor_Schedule/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor_Schedule doctor_Schedule = db.Doctor_Schedule.Find(id);
            if (doctor_Schedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.DR_FID = new SelectList(db.Doctors, "DR_ID", "DR_NAME", doctor_Schedule.DR_FID);
            return View(doctor_Schedule);
        }

        // POST: Doctor_Schedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SCHEDULE_ID,DR_FID,AVAILABLE_DAYS,START_TIME,END_TIME,MAX_APPOINTMENTS")] Doctor_Schedule doctor_Schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor_Schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DR_FID = new SelectList(db.Doctors, "DR_ID", "DR_NAME", doctor_Schedule.DR_FID);
            return View(doctor_Schedule);
        }

        // GET: Doctor_Schedule/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor_Schedule doctor_Schedule = db.Doctor_Schedule.Find(id);
            if (doctor_Schedule == null)
            {
                return HttpNotFound();
            }
            return View(doctor_Schedule);
        }

        // POST: Doctor_Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor_Schedule doctor_Schedule = db.Doctor_Schedule.Find(id);
            db.Doctor_Schedule.Remove(doctor_Schedule);
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
