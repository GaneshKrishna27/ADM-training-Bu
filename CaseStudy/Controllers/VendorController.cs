using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseStudy.Controllers
{
    public class VendorController : Controller
    {
        CarservicingDBEntities2 db = new CarservicingDBEntities2();
        public ActionResult Services()
        {
            //ViewBag.Model = db.BookServices.ToList();
            return View(from BookService in db.BookServices select BookService);
        }
        [HttpGet]
        public ActionResult DisplayStatus(int? id)
        {
            var status = db.BookServices.Where(x => x.custId == id).FirstOrDefault();
            ViewBag.model = status;
            return View();

            
        }
        [HttpPost]
        public ActionResult DisplayStatus(BookService bookService)
        {
            
            
            var date = Convert.ToDateTime(bookService.bookingDate);
            bookService.bookingDate = date;
            var status = db.BookServices.Where(x => x.custId == bookService.custId).FirstOrDefault();
            if (status != null)
            {
                bookService.custName = status.custName;
                bookService.vehicleNo = status.vehicleNo;
                bookService.contactNumber = status.contactNumber;
                bookService.bookingDate = status.bookingDate;
                bookService.bookStutus = status.bookStutus;
                db.Entry(status).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.updatedmssg = "Updated Service Successfully";
                return View();
            }
            ViewBag.updateError = "Update Failed.Please Enter values correctly";
            return View();

        }
        public ActionResult Details(int? id)
        {
            var status = db.BookServices.Where(x => x.custId == id).ToList();
            ViewBag.model = status;
            return View();
        }
       
        public ActionResult DeleteService(int? id)
        {
            try
            {
                var deleteService = db.BookServices.Find(id);
                db.BookServices.Remove(deleteService);
                db.SaveChanges();
                ViewBag.serviceDeleted = "Service is successfully deleted";

            }
            catch (Exception e)
            {
                ViewBag.errorDelete = "Error Occured !" + e;
            }
            return RedirectToAction("Services", "Vendor");

        }
    }
}