using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem_Entity;

namespace StudentManagementSystem_Entity.Controllers
{
    public class Tbl_StudentController : Controller
    {
        private StudEntities db = new StudEntities();

        // GET: Tbl_Student
        //public ActionResult Index()
        //{
        //    var tbl_Student = db.Tbl_Student.Include(t => t.Tbl_Course).Include(t => t.Tbl_Dept);
        //    return View(tbl_Student.ToList());
        //}

        public JsonResult getCourse(int id)
        {
            var tbl_course = new SelectList(db.Tbl_Course.Where(x => x.Dept_id == id), "Course_id", "Course_name");
            return Json(new SelectList(tbl_course, "Value", "Text", JsonRequestBehavior.AllowGet));
        }

        // GET: Student
        public ActionResult Index(int Dept = 0)
        {
            ViewBag.Dept = new SelectList(db.Tbl_Dept, "Dept_id", "Dept_name");
            if (Dept != 0)
            {
                ModelState.Clear();
                var data = db.Tbl_Student.Where(x => x.Dept_id == Dept).ToList();
                return View(data);
            }
            else
            {
                ModelState.Clear();
                return View(db.Tbl_Student.Include(t => t.Tbl_Course).Include(t => t.Tbl_Dept));
            }


            //var tbl_Student = db.tbl_Student.Include(t => t.tbl_Course).Include(t => t.tbl_Department);
            //return View(tbl_Student.ToList());
        }

        // GET: Tbl_Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Student tbl_Student = db.Tbl_Student.Find(id);
            if (tbl_Student == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Student);
        }

        // GET: Tbl_Student/Create
        public ActionResult Create()
        {
            ViewBag.Course_id = new SelectList(db.Tbl_Course, "Course_id", "Course_name");
            ViewBag.Dept_id = new SelectList(db.Tbl_Dept, "Dept_id", "Dept_name");
            return View();
        }

        // POST: Tbl_Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stud_ID,Stud_name,Email,Phone,Dept_id,Course_id")] Tbl_Student tbl_Student)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Student.Add(tbl_Student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_id = new SelectList(db.Tbl_Course, "Course_id", "Course_name", tbl_Student.Course_id);
            ViewBag.Dept_id = new SelectList(db.Tbl_Dept, "Dept_id", "Dept_name", tbl_Student.Dept_id);
            return View(tbl_Student);
        }

        // GET: Tbl_Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Student tbl_Student = db.Tbl_Student.Find(id);
            if (tbl_Student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_id = new SelectList(db.Tbl_Course, "Course_id", "Course_name", tbl_Student.Course_id);
            ViewBag.Dept_id = new SelectList(db.Tbl_Dept, "Dept_id", "Dept_name", tbl_Student.Dept_id);
            return View(tbl_Student);
        }

        // POST: Tbl_Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stud_ID,Stud_name,Email,Phone,Dept_id,Course_id")] Tbl_Student tbl_Student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_id = new SelectList(db.Tbl_Course, "Course_id", "Course_name", tbl_Student.Course_id);
            ViewBag.Dept_id = new SelectList(db.Tbl_Dept, "Dept_id", "Dept_name", tbl_Student.Dept_id);
            return View(tbl_Student);
        }

        // GET: Tbl_Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Student tbl_Student = db.Tbl_Student.Find(id);
            if (tbl_Student == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Student);
        }

        // POST: Tbl_Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Student tbl_Student = db.Tbl_Student.Find(id);
            db.Tbl_Student.Remove(tbl_Student);
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
