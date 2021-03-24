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
    public class BlogsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Blogs
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Admin).Include(b => b.Blog_Category);
            return View(blogs.ToList());
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            ViewBag.ADMIN_FID = new SelectList(db.Admins, "ADMIN_ID", "ADMIN_NAME");
            ViewBag.CATEGORY_FID = new SelectList(db.Blog_Category, "CATEGORY_ID", "CATEGORY_NAME");
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BLOG_ID,CATEGORY_FID,ADMIN_FID,BLOG_TITLE,BLOG_DISCRIPTION,BLOG_PIC,BLOG_DATE")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ADMIN_FID = new SelectList(db.Admins, "ADMIN_ID", "ADMIN_NAME", blog.ADMIN_FID);
            ViewBag.CATEGORY_FID = new SelectList(db.Blog_Category, "CATEGORY_ID", "CATEGORY_NAME", blog.CATEGORY_FID);
            return View(blog);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.ADMIN_FID = new SelectList(db.Admins, "ADMIN_ID", "ADMIN_NAME", blog.ADMIN_FID);
            ViewBag.CATEGORY_FID = new SelectList(db.Blog_Category, "CATEGORY_ID", "CATEGORY_NAME", blog.CATEGORY_FID);
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BLOG_ID,CATEGORY_FID,ADMIN_FID,BLOG_TITLE,BLOG_DISCRIPTION,BLOG_PIC,BLOG_DATE")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ADMIN_FID = new SelectList(db.Admins, "ADMIN_ID", "ADMIN_NAME", blog.ADMIN_FID);
            ViewBag.CATEGORY_FID = new SelectList(db.Blog_Category, "CATEGORY_ID", "CATEGORY_NAME", blog.CATEGORY_FID);
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
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
