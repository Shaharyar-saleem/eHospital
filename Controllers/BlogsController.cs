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
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.BLOG_IMAGE.SaveAs(Server.MapPath("~/Blog_Images/" + blog.BLOG_IMAGE.FileName));
                blog.BLOG_PIC = "~/Blog_Images/" + blog.BLOG_IMAGE.FileName;
                Admin adm = (Admin)Session["Admin"];
                blog.ADMIN_FID = adm.ADMIN_ID;
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
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                if(blog.BLOG_IMAGE != null)
                {
                    blog.BLOG_IMAGE.SaveAs(Server.MapPath("~/Blog_Images/" + blog.BLOG_IMAGE.FileName));
                    blog.BLOG_PIC = "~/Blog_Images/" + blog.BLOG_IMAGE.FileName;
                    Admin admm = (Admin)Session["Admin"];
                    blog.ADMIN_FID = admm.ADMIN_ID;
                }
                Admin adm = (Admin)Session["Admin"];
                blog.ADMIN_FID = adm.ADMIN_ID;
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
