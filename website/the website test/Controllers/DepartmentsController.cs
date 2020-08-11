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
    public class DepartmentsController : Controller
    {
        private DB_A50C7A_FEEEntities db = new DB_A50C7A_FEEEntities();

        // GET: Departments
        public ActionResult Index()
        {
            var departments = db.Departments.Include(d => d.StaffMembers1);
            return View(departments.ToList());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departments = db.Departments.Find(id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            return View(departments);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            ViewBag.Head = new SelectList(db.StaffMembers, "ID", "SSN");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DeptName,Code,About,Head")] Departments departments)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(departments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Head = new SelectList(db.StaffMembers, "ID", "SSN", departments.Head);
            return View(departments);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departments = db.Departments.Find(id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            ViewBag.Head = new SelectList(db.StaffMembers, "ID", "SSN", departments.Head);
            return View(departments);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DeptName,Code,About,Head")] Departments departments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Head = new SelectList(db.StaffMembers, "ID", "SSN", departments.Head);
            return View(departments);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departments = db.Departments.Find(id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            return View(departments);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departments departments = db.Departments.Find(id);
            db.Departments.Remove(departments);
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
        // GET: Departments/About/5
        public ActionResult About(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departments = db.Departments.Find(id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            return View(departments);
        }
        // GET: Departments/Head/5
        public ActionResult Head(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departments = db.Departments.Find(id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            StaffMembers head = db.StaffMembers.Find(departments.Head);
            if (head == null)
            {
                return HttpNotFound();
            }
            return View(head);
        }
        // GET: Departments/Staff/5
        public ActionResult Staff(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departments = db.Departments.Find(id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            var staffMembers = db.StaffMembers.Include(i=> i.DeptID== id).ToList();
            if (staffMembers == null)
            {
                return HttpNotFound();
            }
            return View(staffMembers);
        }
        // GET: Departments/Courses/5
        public ActionResult Courses(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departments = db.Departments.Find(id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            var courses = db.Subjects.Include(i => i.DeptID == id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }
    }
}
