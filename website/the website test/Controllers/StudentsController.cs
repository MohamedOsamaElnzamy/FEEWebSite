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
   
    public class StudentsController : Controller
    {
        private DB_A50C7A_FEEEntities db = new DB_A50C7A_FEEEntities();
       
        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Departments);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.DeptID = new SelectList(db.Departments, "ID", "DeptName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SSN,AcademicNumber,FullName,City,FullAddress,Gender,CreatedAt,DateOfBirth,DeptID")] Students students)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptID = new SelectList(db.Departments, "ID", "DeptName", students.DeptID);
            return View(students);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptID = new SelectList(db.Departments, "ID", "DeptName", students.DeptID);
            return View(students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SSN,AcademicNumber,FullName,City,FullAddress,Gender,CreatedAt,DateOfBirth,DeptID")] Students students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptID = new SelectList(db.Departments, "ID", "DeptName", students.DeptID);
            return View(students);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students students = db.Students.Find(id);
            db.Students.Remove(students);
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

        // GET: Students/PersonalInformation/5
        public ActionResult PersonalInformation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }
        // GET: Students/SubjectRegisteration/5
        public ActionResult SubjectRegisteration(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            // Get Subjects that student had been Finished by Details
            IEnumerable<Subjects> finished = GetFinishedSubjects(id);
            ViewData["finished"] = finished.ToList();

            // Get Subjects that student had been Finished and the GPA
            List<subjectsWithMark> f = GetSubjectsWithGPA(id);
            ViewData["finished1"] = f;


            // Get Subjects that student had been Finished by Details
            IEnumerable<Subjects> unfinished = from subject in db.Subjects select subject;
            ViewData["unfinished"] = unfinished.Except(finished).ToList();
            /////////
            List<Subjects> EnabledSubjects = GetEnabledSubjects(unfinished, id);
            ViewData["Enabled"] = EnabledSubjects.Except(finished).ToList();
            return View(students);
        }
        private List<Subjects> GetEnabledSubjects(IEnumerable<Subjects> subjects, int? id)
        {
            List<Subjects> EnabledSubjects = new List<Subjects>();
            foreach (Subjects item in subjects)
            {
                IEnumerable<GetRequiredSubjects_Result> required = db.GetRequiredSubjects(item.ID);
                if (required == null) continue;
                int accepted = 0;
                foreach (GetRequiredSubjects_Result i in required)
                {
                    IEnumerable<Subjects> FinishedSubjects = GetFinishedSubjects(id);
                    foreach (Subjects l in FinishedSubjects)
                    {
                        if (l.ID == i.ID)
                            accepted++;
                    }
                }
                if (accepted == required.Count())
                    EnabledSubjects.Add(item);
            }
            return EnabledSubjects;

        }

        //private List<subject> GetEnabledSubjects(IEnumerable<subject> subjects, int? id)
        //{
        //    List<subject> EnabledSubjects = new List<subject>();
        //    foreach (subject item in subjects)
        //    {
        //        IEnumerable<subject> required = db.GetRequiredSubjects(item.subID);
        //        if (required == null) continue;
        //        int accepted = 0;
        //        foreach (subject i in required)
        //        {
        //            if (GetFinishedSubjects(id).Contains(i))
        //                accepted = 1;
        //            else
        //            {
        //                accepted = 0;
        //            }
        //        }
        //        if (accepted == 1)
        //            EnabledSubjects.Add(item);
        //    }
        //    return EnabledSubjects;

        //}

        private List<subjectsWithMark> GetSubjectsWithGPA(int? id)
        {
            var finished1 = from subject in db.Subjects
                            join StudentSubject in db.StudentSubject
                            on subject.ID equals StudentSubject.ID
                            where StudentSubject.StudentID == id
                            select new { subject.SubjectName, subject.Code, StudentSubject.Mark };
            List<subjectsWithMark> f = new List<subjectsWithMark>();
            foreach (var item in finished1)
            {
                subjectsWithMark strfinished = new subjectsWithMark();
                strfinished.name = item.SubjectName;
                strfinished.code = item.Code;
                strfinished.Mark = item.Mark;
                f.Add(strfinished);

            }

            return f;
        }

        private IEnumerable<Subjects> GetFinishedSubjects(int? id)
        {
            return from subject in db.Subjects
                   join StudentSubject in db.StudentSubject
                   on subject.ID equals StudentSubject.ID
                   where StudentSubject.StudentID == id
                   select subject;
            
        }



    }
}
