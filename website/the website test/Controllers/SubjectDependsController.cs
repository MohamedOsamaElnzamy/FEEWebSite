using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using the_website_test.Models;

namespace the_website_test.Controllers
{
    public class SubjectDependsController : Controller
    {
        private DB_A50C7A_FEEEntities db = new DB_A50C7A_FEEEntities();

        // GET: SubjectDepends
        public ActionResult Index()
        {
            var subjectDepend = db.SubjectDepend.Include(s => s.Subjects).Include(s => s.Subjects1);
            return View(subjectDepend.ToList());
        }

        // GET: SubjectDepends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectDepend subjectDepend = db.SubjectDepend.Find(id);
            if (subjectDepend == null)
            {
                return HttpNotFound();
            }
            return View(subjectDepend);
        }

        // GET: SubjectDepends/Create
        public ActionResult Create()
        {
            ViewBag.SubjectID = new SelectList(db.Subjects, "ID", "SubjectName");
            ViewBag.DependID = new SelectList(db.Subjects, "ID", "SubjectName");
            return View();
        }

        // POST: SubjectDepends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SubjectID,DependID")] SubjectDepend subjectDepend)
        {
            if (ModelState.IsValid)
            {
                db.SubjectDepend.Add(subjectDepend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectID = new SelectList(db.Subjects, "ID", "SubjectName", subjectDepend.SubjectID);
            ViewBag.DependID = new SelectList(db.Subjects, "ID", "SubjectName", subjectDepend.DependID);
            return View(subjectDepend);
        }

        // GET: SubjectDepends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectDepend subjectDepend = db.SubjectDepend.Find(id);
            if (subjectDepend == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectID = new SelectList(db.Subjects, "ID", "SubjectName", subjectDepend.SubjectID);
            ViewBag.DependID = new SelectList(db.Subjects, "ID", "SubjectName", subjectDepend.DependID);
            return View(subjectDepend);
        }

        // POST: SubjectDepends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SubjectID,DependID")] SubjectDepend subjectDepend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectDepend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectID = new SelectList(db.Subjects, "ID", "SubjectName", subjectDepend.SubjectID);
            ViewBag.DependID = new SelectList(db.Subjects, "ID", "SubjectName", subjectDepend.DependID);
            return View(subjectDepend);
        }

        // GET: SubjectDepends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectDepend subjectDepend = db.SubjectDepend.Find(id);
            if (subjectDepend == null)
            {
                return HttpNotFound();
            }
            return View(subjectDepend);
        }

        // POST: SubjectDepends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectDepend subjectDepend = db.SubjectDepend.Find(id);
            db.SubjectDepend.Remove(subjectDepend);
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
