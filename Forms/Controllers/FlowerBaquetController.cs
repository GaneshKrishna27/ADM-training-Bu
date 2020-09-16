using Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forms.Controllers
{
    public class FlowerBaquetController : Controller
    {
        loginDBEntities2 db = new loginDBEntities2();
        public ActionResult book(string fid)
        {
        
                var selectedBoquet = db.Flowers.Where(x => x.flowerId == fid).FirstOrDefault();
                ViewBag.boquet = selectedBoquet;
                return View();
            
        }
    }
}