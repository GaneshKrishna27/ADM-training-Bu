using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaseStudyonSms.Models;

namespace CaseStudyonSms.Controllers
{
    public class CoursController : Controller
    {
        private StudentDBEntities db = new StudentDBEntities();

        // GET: Cours
        public ActionResult Index(string option,string search)
        {
            if (option == "courseName")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(db.Courses.Where(x => x.courseName == search || search == null).ToList());
            }
            else
            {
                return View(db.Courses.Where(x => x.courseName.StartsWith(search) || search == null).ToList());
            }
        }

        // GET: Cours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // GET: Cours/Create
        public ActionResult Create()
        {
            ViewBag.stuId = new SelectList(db.Students, "stdId", "stdName");
            return View();

        }

        // POST: Cours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "courseId,stuId,courseName,courseDuration")] Cours cours)
        {
           
            if (ModelState.IsValid)
            {
                var checkCourse = db.Courses.Where(x => x.courseName == cours.courseName && x.stuId==cours.stuId).FirstOrDefault();
                if (checkCourse != null)
                {
                    ViewBag.message= "Already you joined this Course";
                }
                else 
                {
                    db.Courses.Add(cours);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            ViewBag.stuId = new SelectList(db.Students, "stdId", "stdName", cours.stuId);
            return View(cours);
        }

        // GET: Cours/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            ViewBag.stuId = new SelectList(db.Students, "stdId", "stdName", cours.stuId);
            
            return View(cours);
        }

        // POST: Cours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "courseId,stuId,courseName,courseDuration")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.stuId = new SelectList(db.Students, "stdId", "stdName", cours.stuId);
            return View(cours);
        }

        // GET: Cours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // POST: Cours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cours cours = db.Courses.Find(id);
            db.Courses.Remove(cours);
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
