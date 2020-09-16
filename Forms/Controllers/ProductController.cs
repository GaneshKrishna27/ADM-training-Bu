using Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forms.Controllers
{
    public class ProductController : Controller
    {
        loginDBEntities2 db = new loginDBEntities2();
        [HttpGet]
        public ActionResult flowers()
        {

            return View(from Flower in db.Flowers select Flower);
        }
    }
}