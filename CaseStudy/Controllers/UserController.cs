using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CaseStudy.Controllers
{
    public class UserController : Controller
    {
        CarservicingDBEntities2 db = new CarservicingDBEntities2();
        [HttpGet]
        public ActionResult DisplayVendorServices()
        {
            var dvs = db.Vendors.ToList();
            ViewBag.DVS = dvs;
            return View();
        }
        [HttpGet]
        public ActionResult Booking()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Booking(BookService bookService)
        {
            try
            {
                //var date = Convert.ToDateTime(bookService.bookingDate);
                //bookService.bookingDate = date;
                if (ModelState.IsValid)
                {
                    var matchingcontactNumber = db.BookServices.Where(x => x.contactNumber == bookService.contactNumber).FirstOrDefault();
                    
                    
                    if (matchingcontactNumber != null)
                    {
                        ViewBag.numberExists = "Contact Number is already regitered.Try to login";
                    }             
                   else
                    {
                        db.BookServices.Add(bookService);
                        db.SaveChanges();
                        ViewBag.message = bookService.vehicleNo + " has got successfully booked and wait for status";
                        return View();
                    }
                }
                return View();
            }
            catch (Exception e)
            {
                ViewBag.message = bookService.vehicleNo + " Registered failed";
                return View();
            }
        }

        public ActionResult BookingDetails()
        {
            
            return View(from BookService in db.BookServices select BookService);
        }
        //public ActionResult BookingDetails(int? id) 
        //{
        //    BookService bookService = db.BookServices.Find(id);
        //    ViewBag.model = bookService;
        //    return View();
        //}
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            
            var u = db.Users.Where(x => x.userId == id).FirstOrDefault();
                if (u != null)
                {
                    TempData["id"] = id;
                    TempData.Keep();
                    return View(u);
                }
            
            return View();
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            
            int id = (int)TempData["id"];
            var uData = db.Users.Where(x => x.userId == id).FirstOrDefault();
            if (uData != null)
            {
                //uData.userId = uData.userId;
                uData.firstName = uData.firstName;
                uData.lastName = uData.lastName;
                uData.contactNumber = uData.contactNumber;
                uData.userEmail = uData.userEmail;
                uData.userPwd = uData.userPwd;
                db.Entry(uData).State = EntityState.Modified;
                db.SaveChanges();               
                return View();
            }        
            return View();
        }
        public ActionResult UserPage()
        {
            int id = (int)TempData["id"];
            return View(id);
        }
    }
    
}