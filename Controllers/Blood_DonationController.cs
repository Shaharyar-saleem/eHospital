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
    public class Blood_DonationController : Controller
    {
        private Model1 db = new Model1();

        // GET: Blood_Donation
        public ActionResult Index()
        {
            var blood_Donation = db.Blood_Donation.Include(b => b.Appointment).Include(b => b.Blood_Doners);
            return View(blood_Donation.ToList());
        }

        // GET: Blood_Donation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_Donation blood_Donation = db.Blood_Donation.Find(id);
            if (blood_Donation == null)
            {
                return HttpNotFound();
            }
            return View(blood_Donation);
        }

        // GET: Blood_Donation/Create
        public ActionResult Create()
        {
            ViewBag.APPOINTMENT_FID = new SelectList(db.Appointments, "APPOINTMENT_ID", "TIME_SLOT");
            ViewBag.DONER_FID = new SelectList(db.Blood_Doners, "DONER_ID", "DONER_NAME");
            return View();
        }

        // POST: Blood_Donation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DONATION_ID,DONER_FID,APPOINTMENT_FID")] Blood_Donation blood_Donation)
        {
            if (ModelState.IsValid)
            {
                db.Blood_Donation.Add(blood_Donation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.APPOINTMENT_FID = new SelectList(db.Appointments, "APPOINTMENT_ID", "TIME_SLOT", blood_Donation.APPOINTMENT_FID);
            ViewBag.DONER_FID = new SelectList(db.Blood_Doners, "DONER_ID", "DONER_NAME", blood_Donation.DONER_FID);
            return View(blood_Donation);
        }

        // GET: Blood_Donation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_Donation blood_Donation = db.Blood_Donation.Find(id);
            if (blood_Donation == null)
            {
                return HttpNotFound();
            }
            ViewBag.APPOINTMENT_FID = new SelectList(db.Appointments, "APPOINTMENT_ID", "TIME_SLOT", blood_Donation.APPOINTMENT_FID);
            ViewBag.DONER_FID = new SelectList(db.Blood_Doners, "DONER_ID", "DONER_NAME", blood_Donation.DONER_FID);
            return View(blood_Donation);
        }

        // POST: Blood_Donation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DONATION_ID,DONER_FID,APPOINTMENT_FID")] Blood_Donation blood_Donation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blood_Donation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.APPOINTMENT_FID = new SelectList(db.Appointments, "APPOINTMENT_ID", "TIME_SLOT", blood_Donation.APPOINTMENT_FID);
            ViewBag.DONER_FID = new SelectList(db.Blood_Doners, "DONER_ID", "DONER_NAME", blood_Donation.DONER_FID);
            return View(blood_Donation);
        }

        // GET: Blood_Donation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_Donation blood_Donation = db.Blood_Donation.Find(id);
            if (blood_Donation == null)
            {
                return HttpNotFound();
            }
            return View(blood_Donation);
        }

        // POST: Blood_Donation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blood_Donation blood_Donation = db.Blood_Donation.Find(id);
            db.Blood_Donation.Remove(blood_Donation);
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
