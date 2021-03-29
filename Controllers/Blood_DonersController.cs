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
    public class Blood_DonersController : Controller
    {
        private Model1 db = new Model1();

        // GET: Blood_Doners
        public ActionResult Index()
        {
            var blood_Doners = db.Blood_Doners.Include(b => b.Admin).Where(x=> x.DONER_STATUS == "Pending");
            return View(blood_Doners.ToList());
        }

        public ActionResult IndexApproved()
        {
            var blood_Doners = db.Blood_Doners.Include(b => b.Admin).Where(x => x.DONER_STATUS == "Approved");
            return View(blood_Doners.ToList());
        }

        // GET: Blood_Doners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_Doners blood_Doners = db.Blood_Doners.Find(id);
            if (blood_Doners == null)
            {
                return HttpNotFound();
            }
            return View(blood_Doners);
        }

        // GET: Blood_Doners/Create
        public ActionResult Create()
        {
            ViewBag.ADMIN_FID = new SelectList(db.Admins, "ADMIN_ID", "ADMIN_NAME");
            return View();
        }

        // POST: Blood_Doners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DONER_ID,ADMIN_FID,DONER_NAME,DONER_EMAIL,DONER_CONTACT,DONER_DOB,BLOOD_GROUP,DONER_GENDER,DONER_CITY,DONER_STATUS")] Blood_Doners blood_Doners)
        {
            if (ModelState.IsValid)
            {
                db.Blood_Doners.Add(blood_Doners);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Thanks");
            }

            ViewBag.ADMIN_FID = new SelectList(db.Admins, "ADMIN_ID", "ADMIN_NAME", blood_Doners.ADMIN_FID);
            return View(blood_Doners);
            
        }

        // GET: Blood_Doners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_Doners blood_Doners = db.Blood_Doners.Find(id);
            if (blood_Doners == null)
            {
                return HttpNotFound();
            }
            ViewBag.ADMIN_FID = new SelectList(db.Admins, "ADMIN_ID", "ADMIN_NAME", blood_Doners.ADMIN_FID);
            return View(blood_Doners);
        }

        // POST: Blood_Doners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DONER_ID,ADMIN_FID,DONER_NAME,DONER_EMAIL,DONER_CONTACT,DONER_DOB,BLOOD_GROUP,DONER_GENDER,DONER_CITY,DONER_STATUS")] Blood_Doners blood_Doners)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blood_Doners).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ADMIN_FID = new SelectList(db.Admins, "ADMIN_ID", "ADMIN_NAME", blood_Doners.ADMIN_FID);
            return View(blood_Doners);
        }

        // GET: Blood_Doners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_Doners blood_Doners = db.Blood_Doners.Find(id);
            if (blood_Doners == null)
            {
                return HttpNotFound();
            }
            return View(blood_Doners);
        }

        // POST: Blood_Doners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blood_Doners blood_Doners = db.Blood_Doners.Find(id);
            db.Blood_Doners.Remove(blood_Doners);
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

        public ActionResult Thanks()
        {
            return View();
        }

        
        public ActionResult Approve(int? id)
        {
            Blood_Doners donor = db.Blood_Doners.Where(x => x.DONER_ID == id).FirstOrDefault();
            donor.DONER_STATUS = "Approved";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
