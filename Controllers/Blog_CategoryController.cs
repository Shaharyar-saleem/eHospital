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
    public class Blog_CategoryController : Controller
    {
        private Model1 db = new Model1();

        // GET: Blog_Category
        public ActionResult Index()
        {
            return View(db.Blog_Category.ToList());
        }

        // GET: Blog_Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog_Category blog_Category = db.Blog_Category.Find(id);
            if (blog_Category == null)
            {
                return HttpNotFound();
            }
            return View(blog_Category);
        }

        // GET: Blog_Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CATEGORY_ID,CATEGORY_NAME")] Blog_Category blog_Category)
        {
            if (ModelState.IsValid)
            {
                db.Blog_Category.Add(blog_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog_Category);
        }

        // GET: Blog_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog_Category blog_Category = db.Blog_Category.Find(id);
            if (blog_Category == null)
            {
                return HttpNotFound();
            }
            return View(blog_Category);
        }

        // POST: Blog_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CATEGORY_ID,CATEGORY_NAME")] Blog_Category blog_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog_Category);
        }

        // GET: Blog_Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog_Category blog_Category = db.Blog_Category.Find(id);
            if (blog_Category == null)
            {
                return HttpNotFound();
            }
            return View(blog_Category);
        }

        // POST: Blog_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog_Category blog_Category = db.Blog_Category.Find(id);
            db.Blog_Category.Remove(blog_Category);
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
