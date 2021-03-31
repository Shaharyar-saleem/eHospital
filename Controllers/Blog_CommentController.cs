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
    public class Blog_CommentController : Controller
    {
        private Model1 db = new Model1();

        // GET: Blog_Comment
        public ActionResult Index()
        {
            var blog_Comment = db.Blog_Comment.Include(b => b.Blog);
            return View(blog_Comment.ToList());
        }

        // GET: Blog_Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog_Comment blog_Comment = db.Blog_Comment.Find(id);
            if (blog_Comment == null)
            {
                return HttpNotFound();
            }
            return View(blog_Comment);
        }

        // GET: Blog_Comment/Create
        public ActionResult Create()
        {
            ViewBag.BLOG_FID = new SelectList(db.Blogs, "BLOG_ID", "BLOG_TITLE");
            return View();
        }

        // POST: Blog_Comment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COMMENT_ID,BLOG_FID,BLOG_DATE,COMMENT_NAME,COMMENT_EMAIL,COMMENT_MESSAGE")] Blog_Comment blog_Comment)
        {
            if (ModelState.IsValid)
            {
                blog_Comment.BLOG_DATE = DateTime.Now;
                db.Blog_Comment.Add(blog_Comment);
                db.SaveChanges();
                return RedirectToAction("SingleBlog", "Home", new { id = blog_Comment.BLOG_FID });
            }

            ViewBag.BLOG_FID = new SelectList(db.Blogs, "BLOG_ID", "BLOG_TITLE", blog_Comment.BLOG_FID);
            return View(blog_Comment);
        }

        // GET: Blog_Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog_Comment blog_Comment = db.Blog_Comment.Find(id);
            if (blog_Comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.BLOG_FID = new SelectList(db.Blogs, "BLOG_ID", "BLOG_TITLE", blog_Comment.BLOG_FID);
            return View(blog_Comment);
        }

        // POST: Blog_Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COMMENT_ID,BLOG_FID,BLOG_DATE,COMMENT_NAME,COMMENT_EMAIL,COMMENT_MESSAGE")] Blog_Comment blog_Comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog_Comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BLOG_FID = new SelectList(db.Blogs, "BLOG_ID", "BLOG_TITLE", blog_Comment.BLOG_FID);
            return View(blog_Comment);
        }

        // GET: Blog_Comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog_Comment blog_Comment = db.Blog_Comment.Find(id);
            if (blog_Comment == null)
            {
                return HttpNotFound();
            }
            return View(blog_Comment);
        }

        // POST: Blog_Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog_Comment blog_Comment = db.Blog_Comment.Find(id);
            db.Blog_Comment.Remove(blog_Comment);
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
