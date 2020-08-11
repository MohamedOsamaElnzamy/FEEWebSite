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
    public class LecturesTablesController : Controller
    {
        private DB_A50C7A_FEEEntities db = new DB_A50C7A_FEEEntities();

        // GET: LecturesTables
        public ActionResult Index()
        {
            var lecturesTable = db.LecturesTable.Include(l => l.StaffMembers).Include(l => l.StaffMembers1).Include(l => l.Subjects);
            return View(lecturesTable.ToList());
        }

        // GET: LecturesTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LecturesTable lecturesTable = db.LecturesTable.Find(id);
            if (lecturesTable == null)
            {
                return HttpNotFound();
            }
            return View(lecturesTable);
        }

        // GET: LecturesTables/Create
        public ActionResult Create()
        {
            ViewBag.StaffMemeberID1 = new SelectList(db.StaffMembers, "ID", "SSN");
            ViewBag.StaffMemeberID2 = new SelectList(db.StaffMembers, "ID", "SSN");
            ViewBag.SubjectID = new SelectList(db.Subjects, "ID", "SubjectName");
            return View();
        }

        // POST: LecturesTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SubjectID,StaffMemeberID1,StaffMemeberID2,Time")] LecturesTable lecturesTable)
        {
            if (ModelState.IsValid)
            {
                db.LecturesTable.Add(lecturesTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StaffMemeberID1 = new SelectList(db.StaffMembers, "ID", "SSN", lecturesTable.StaffMemeberID1);
            ViewBag.StaffMemeberID2 = new SelectList(db.StaffMembers, "ID", "SSN", lecturesTable.StaffMemeberID2);
            ViewBag.SubjectID = new SelectList(db.Subjects, "ID", "SubjectName", lecturesTable.SubjectID);
            return View(lecturesTable);
        }

        // GET: LecturesTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LecturesTable lecturesTable = db.LecturesTable.Find(id);
            if (lecturesTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaffMemeberID1 = new SelectList(db.StaffMembers, "ID", "SSN", lecturesTable.StaffMemeberID1);
            ViewBag.StaffMemeberID2 = new SelectList(db.StaffMembers, "ID", "SSN", lecturesTable.StaffMemeberID2);
            ViewBag.SubjectID = new SelectList(db.Subjects, "ID", "SubjectName", lecturesTable.SubjectID);
            return View(lecturesTable);
        }

        // POST: LecturesTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SubjectID,StaffMemeberID1,StaffMemeberID2,Time")] LecturesTable lecturesTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecturesTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StaffMemeberID1 = new SelectList(db.StaffMembers, "ID", "SSN", lecturesTable.StaffMemeberID1);
            ViewBag.StaffMemeberID2 = new SelectList(db.StaffMembers, "ID", "SSN", lecturesTable.StaffMemeberID2);
            ViewBag.SubjectID = new SelectList(db.Subjects, "ID", "SubjectName", lecturesTable.SubjectID);
            return View(lecturesTable);
        }

        // GET: LecturesTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LecturesTable lecturesTable = db.LecturesTable.Find(id);
            if (lecturesTable == null)
            {
                return HttpNotFound();
            }
            return View(lecturesTable);
        }

        // POST: LecturesTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LecturesTable lecturesTable = db.LecturesTable.Find(id);
            db.LecturesTable.Remove(lecturesTable);
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
