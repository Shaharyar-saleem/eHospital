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
    public class PatientsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Patients
        public ActionResult Index(int id)
        {
            return View(db.Patients.Where(x=>x.PATIENT_ID == id).ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                if(patient.PATIENT_PASSWORD == patient.PATIENT_PASSWORD_REPEAT)
                {
                    patient.PATIENT_IMAGE.SaveAs(Server.MapPath("~/Account_Images/" + patient.PATIENT_IMAGE.FileName));
                    patient.PATIENT_PIC = "~/Account_Images/" + patient.PATIENT_IMAGE.FileName;
                    db.Patients.Add(patient);
                    db.SaveChanges();
                    return RedirectToAction("LogIn", "Home");
                    
                }

                else
                {
                    ViewBag.Message = "Both Passwords are not same";
                    return View();
                }
            }
            return RedirectToAction("IndexCustomer", "Home");

        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                if(patient.PATIENT_IMAGE != null)
                {
                    patient.PATIENT_IMAGE.SaveAs(Server.MapPath("~/Account_Images/" + patient.PATIENT_IMAGE.FileName));
                    patient.PATIENT_PIC = "~/Account_Images/" + patient.PATIENT_IMAGE.FileName;
                    db.Entry(patient).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
