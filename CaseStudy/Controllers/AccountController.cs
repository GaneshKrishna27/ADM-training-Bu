using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseStudy.Controllers
{
    public class AccountController : Controller
    {
        CarservicingDBEntities2 db = new CarservicingDBEntities2();
        [HttpGet]
        public ActionResult userSignin()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult userSignin(User user)
        {
            
            var ss = db.Users.Where(x => x.userEmail == user.userEmail && x.userPwd == user.userPwd).FirstOrDefault();
            TempData["id"] = ss.userId;
            TempData.Keep();
            if (ss == null)
            {
                
                ViewBag.Message = "wrong email password";
                return View("userSignin", user);
            }
            else
            {
                
                //Session["userId"] = ss.userId;
                return RedirectToAction("UserPage","User");
            }
        }
        [HttpGet]
        public ActionResult userSignup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult userSignup(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var matchingcontactNumber = db.Users.Where(x => x.contactNumber == user.contactNumber).FirstOrDefault();
                    var matchinguserId = db.Users.Where(x => x.userId == user.userId).FirstOrDefault();
                    var matchinguserEmail = db.Users.Where(x => x.userEmail == user.userEmail).FirstOrDefault();
                    if (matchingcontactNumber != null)
                    {
                        ViewBag.numberExists = "Contact Number is already regitered.Try to login";
                    }
                    else if (matchinguserId != null)
                    {
                        ViewBag.idExists = "User ID already exists. Please select another UserId or try to login";
                    }
                    else if (matchinguserEmail != null)
                    {
                        ViewBag.emailExists = "User Email already exists. Please select another User Email or try to login";
                    }
                    else
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                        ViewBag.message =" Account has got successfully Registered";
                        return RedirectToAction("userSignin");
                    }
                }
                return View();
            }
            catch (Exception e)
            {
                ViewBag.message = user.userEmail + " Registered failed";
                return View();
            }
        }
        [HttpGet]
        public ActionResult vendorSignin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult vendorSignin(Vendor vendor)
        {
            var ss = db.Vendors.Where(x => x.vendorEmail == vendor.vendorEmail && x.vendorPwd == vendor.vendorPwd).FirstOrDefault();
            if (ss == null)
            {
                ViewBag.Message = "Wrong Email Password";
                return View();
            }
            else
            {
                Session["vendorId"] = ss.vendorId;
                return RedirectToAction("Index","BookServices");
            }
        }
        [HttpGet]
        public ActionResult vendorSignup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult vendorSignup(Vendor vendor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var matchingcontactNumber = db.Vendors.Where(x => x.contactNumber == vendor.contactNumber).FirstOrDefault();
                    var matchinguserId = db.Vendors.Where(x => x.vendorId == vendor.vendorId).FirstOrDefault();
                    var matchinguserEmail = db.Vendors.Where(x => x.vendorEmail == vendor.vendorEmail).FirstOrDefault();
                    if (matchingcontactNumber != null)
                    {
                        ViewBag.numberExists = "Contact Number is already regitered.Try to login";
                    }
                    else if (matchinguserId != null)
                    {
                        ViewBag.idExists = "User ID already exists. Please select another UserId or try to login";
                    }
                    else if (matchinguserEmail != null)
                    {
                        ViewBag.idExists = "User Email already exists. Please select another User Email or try to login";
                    }
                    else
                    {
                        db.Vendors.Add(vendor);
                        db.SaveChanges();
                        ViewBag.message = vendor.vendorEmail + " has got successfully Registered";
                        return RedirectToAction("vendorSignin");
                    }
                }
                return View();
            }
            catch (Exception e)
            {
                ViewBag.message = vendor.vendorEmail + " Registered failed";
                return View();
            }
        }
    }
}