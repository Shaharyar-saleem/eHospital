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
    public class AdminsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admins
        public ActionResult Index()
        {
            var admins = db.Admins.Include(a => a.Admin_Role);
            return View(admins.ToList());
        }

        // GET: Admins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: Admins/Create
        public ActionResult Create()
        {
            ViewBag.ROLE_FID = new SelectList(db.Admin_Role, "ROLE_ID", "ROLE_NAME");
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {

                admin.ADMIN_IMAGE.SaveAs(Server.MapPath("~/Account_Images/" + admin.ADMIN_IMAGE.FileName));
                admin.ADMIN_PIC = "~/Account_Images/" + admin.ADMIN_IMAGE.FileName;

                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ROLE_FID = new SelectList(db.Admin_Role, "ROLE_ID", "ROLE_NAME", admin.ROLE_FID);
            return View(admin);
        }

        // GET: Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            ViewBag.ROLE_FID = new SelectList(db.Admin_Role, "ROLE_ID", "ROLE_NAME", admin.ROLE_FID);
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Admin admin)
        {
            if (ModelState.IsValid)
            {
                if(admin.ADMIN_IMAGE!=null)
                {
                    admin.ADMIN_IMAGE.SaveAs(Server.MapPath("~/Account_Images/" + admin.ADMIN_IMAGE.FileName));
                    admin.ADMIN_PIC = "~/Account_Images/" + admin.ADMIN_IMAGE.FileName;
                }
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ROLE_FID = new SelectList(db.Admin_Role, "ROLE_ID", "ROLE_NAME", admin.ROLE_FID);
            return View(admin);
        }

        // GET: Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
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
