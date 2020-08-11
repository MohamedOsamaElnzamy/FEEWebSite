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
    public class StaffMembersController : Controller
    {
        private DB_A50C7A_FEEEntities db = new DB_A50C7A_FEEEntities();

        // GET: StaffMembers
        public ActionResult Index()
        {
            var staffMembers = db.StaffMembers.Include(s => s.Departments);
            return View(staffMembers.ToList());
        }

        // GET: StaffMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffMembers staffMembers = db.StaffMembers.Find(id);
            if (staffMembers == null)
            {
                return HttpNotFound();
            }
            return View(staffMembers);
        }

        // GET: StaffMembers/Create
        public ActionResult Create()
        {
            ViewBag.DeptID = new SelectList(db.Departments, "ID", "DeptName");
            return View();
        }

        // POST: StaffMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SSN,AcademicNumber,FullName,Degree,Profession,PhoneNumber,City,FullAddress,Gender,CreatedAt,DateOfBirth,DeptID")] StaffMembers staffMembers)
        {
            if (ModelState.IsValid)
            {
                db.StaffMembers.Add(staffMembers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptID = new SelectList(db.Departments, "ID", "DeptName", staffMembers.DeptID);
            return View(staffMembers);
        }

        // GET: StaffMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffMembers staffMembers = db.StaffMembers.Find(id);
            if (staffMembers == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptID = new SelectList(db.Departments, "ID", "DeptName", staffMembers.DeptID);
            return View(staffMembers);
        }

        // POST: StaffMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SSN,AcademicNumber,FullName,Degree,Profession,PhoneNumber,City,FullAddress,Gender,CreatedAt,DateOfBirth,DeptID")] StaffMembers staffMembers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staffMembers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptID = new SelectList(db.Departments, "ID", "DeptName", staffMembers.DeptID);
            return View(staffMembers);
        }

        // GET: StaffMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffMembers staffMembers = db.StaffMembers.Find(id);
            if (staffMembers == null)
            {
                return HttpNotFound();
            }
            return View(staffMembers);
        }

        // POST: StaffMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StaffMembers staffMembers = db.StaffMembers.Find(id);
            db.StaffMembers.Remove(staffMembers);
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
