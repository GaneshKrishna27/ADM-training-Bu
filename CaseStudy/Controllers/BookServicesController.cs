using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaseStudy.Models;

namespace CaseStudy.Controllers
{
    public class BookServicesController : Controller
    {
        private CarservicingDBEntities2 db = new CarservicingDBEntities2();

        // GET: BookServices
        public ActionResult Index()
        {
            return View(db.BookServices.ToList());
        }

        // GET: BookServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookService bookService = db.BookServices.Find(id);
            if (bookService == null)
            {
                return HttpNotFound();
            }
            return View(bookService);
        }

        // GET: BookServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "custId,custName,vehicleNo,bookingDate,contactNumber,bookStutus")] BookService bookService)
        {
            if (ModelState.IsValid)
            {
                db.BookServices.Add(bookService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookService);
        }

        // GET: BookServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookService bookService = db.BookServices.Find(id);
            if (bookService == null)
            {
                return HttpNotFound();
            }
            ViewBag.message = "Data Saved";
            return View(bookService);
            
        }

        // POST: BookServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "custId,custName,vehicleNo,bookingDate,contactNumber,bookStutus")] BookService bookService)
        {
            //var date = Convert.ToDateTime(bookService.bookingDate);
            //bookService.bookingDate = date;
            if (ModelState.IsValid)
            {
                db.Entry(bookService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookService);
        }

        // GET: BookServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookService bookService = db.BookServices.Find(id);
            if (bookService == null)
            {
                return HttpNotFound();
            }
            return View(bookService);
        }

        // POST: BookServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookService bookService = db.BookServices.Find(id);
            db.BookServices.Remove(bookService);
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
