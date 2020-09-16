using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forms.Controllers
{
    [TestClass]
    public class TestUserController : Controller
    {
        
        // GET: TestUser
        public ActionResult Index()
        {
            return View();
        }
    }
}