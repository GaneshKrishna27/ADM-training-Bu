using CarServicing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarServicing.Controllers
{
    public class UserController : Controller
    {
        CarservicingDBEntities db = new CarservicingDBEntities();
        [HttpGet]
        public ActionResult DisplayVendorServices()
        {
            var dvs = db.Vendors.ToList();
            ViewBag.DVS =dvs ;
            return View();
        }
    }
}