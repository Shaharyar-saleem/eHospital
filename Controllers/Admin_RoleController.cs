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
    public class Admin_RoleController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admin_Role
        public ActionResult Index()
        {
            return View(db.Admin_Role.ToList());
        }

        // GET: Admin_Role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin_Role admin_Role = db.Admin_Role.Find(id);
            if (admin_Role == null)
            {
                return HttpNotFound();
            }
            return View(admin_Role);
        }

        // GET: Admin_Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin_Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ROLE_ID,ROLE_NAME")] Admin_Role admin_Role)
        {
            if (ModelState.IsValid)
            {
                db.Admin_Role.Add(admin_Role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin_Role);
        }

        // GET: Admin_Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin_Role admin_Role = db.Admin_Role.Find(id);
            if (admin_Role == null)
            {
                return HttpNotFound();
            }
            return View(admin_Role);
        }

        // POST: Admin_Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ROLE_ID,ROLE_NAME")] Admin_Role admin_Role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin_Role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin_Role);
        }

        // GET: Admin_Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin_Role admin_Role = db.Admin_Role.Find(id);
            if (admin_Role == null)
            {
                return HttpNotFound();
            }
            return View(admin_Role);
        }

        // POST: Admin_Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin_Role admin_Role = db.Admin_Role.Find(id);
            db.Admin_Role.Remove(admin_Role);
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
