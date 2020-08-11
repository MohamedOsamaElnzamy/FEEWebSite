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
    public class StudentSubjectsController : Controller
    {
        private DB_A50C7A_FEEEntities db = new DB_A50C7A_FEEEntities();

        // GET: StudentSubjects
        public ActionResult Index()
        {
            var studentSubject = db.StudentSubject.Include(s => s.Students).Include(s => s.Subjects);
            return View(studentSubject.ToList());
        }

        // GET: StudentSubjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentSubject studentSubject = db.StudentSubject.Find(id);
            if (studentSubject == null)
            {
                return HttpNotFound();
            }
            return View(studentSubject);
        }

        // GET: StudentSubjects/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "ID", "SSN");
            ViewBag.SubjID = new SelectList(db.Subjects, "ID", "SubjectName");
            return View();
        }

        // POST: StudentSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SubjID,StudentID,CreatedAt,Mark")] StudentSubject studentSubject)
        {
            if (ModelState.IsValid)
            {
                db.StudentSubject.Add(studentSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "ID", "SSN", studentSubject.StudentID);
            ViewBag.SubjID = new SelectList(db.Subjects, "ID", "SubjectName", studentSubject.SubjID);
            return View(studentSubject);
        }

        // GET: StudentSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentSubject studentSubject = db.StudentSubject.Find(id);
            if (studentSubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "ID", "SSN", studentSubject.StudentID);
            ViewBag.SubjID = new SelectList(db.Subjects, "ID", "SubjectName", studentSubject.SubjID);
            return View(studentSubject);
        }

        // POST: StudentSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SubjID,StudentID,CreatedAt,Mark")] StudentSubject studentSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "ID", "SSN", studentSubject.StudentID);
            ViewBag.SubjID = new SelectList(db.Subjects, "ID", "SubjectName", studentSubject.SubjID);
            return View(studentSubject);
        }

        // GET: StudentSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentSubject studentSubject = db.StudentSubject.Find(id);
            if (studentSubject == null)
            {
                return HttpNotFound();
            }
            return View(studentSubject);
        }

        // POST: StudentSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentSubject studentSubject = db.StudentSubject.Find(id);
            db.StudentSubject.Remove(studentSubject);
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
