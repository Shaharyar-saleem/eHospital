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
    public class DoctorsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Doctors
        public ActionResult Index()
        {
            var doctors = db.Doctors.Include(d => d.Department);
            return View(doctors.ToList());
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            ViewBag.DEPARTMENT_FID = new SelectList(db.Departments, "DEPARTMENT_ID", "DEPARTMENT_NAME");
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                doctor.DR_IMAGE.SaveAs(Server.MapPath("~/Account_Images/" + doctor.DR_IMAGE.FileName));
                doctor.DR_PIC = "~/Account_Images/" + doctor.DR_IMAGE.FileName;
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEPARTMENT_FID = new SelectList(db.Departments, "DEPARTMENT_ID", "DEPARTMENT_NAME", doctor.DEPARTMENT_FID);
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEPARTMENT_FID = new SelectList(db.Departments, "DEPARTMENT_ID", "DEPARTMENT_NAME", doctor.DEPARTMENT_FID);
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                if(doctor.DR_IMAGE != null)
                {
                    doctor.DR_IMAGE.SaveAs(Server.MapPath("~/Account_Images/" + doctor.DR_IMAGE.FileName));
                    doctor.DR_PIC = "~/Account_Images/" + doctor.DR_IMAGE.FileName;
                }
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEPARTMENT_FID = new SelectList(db.Departments, "DEPARTMENT_ID", "DEPARTMENT_NAME", doctor.DEPARTMENT_FID);
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
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
