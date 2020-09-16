using Forms.Models;
using System;
using System.Linq;
using System.Web.Mvc;


namespace Forms.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult userSignup()
        {
            signup s = new signup();
            return View(s);
        }
        [HttpPost]

        public ActionResult userSignup(signup s)
        {
            using (loginDBEntities2 l = new loginDBEntities2())
            {
                if (l.signups.Any(x => x.uName == s.uName))
                {
                    ViewBag.DuplicateMessage = "Username exists";
                    return View("userSignup", s);
                }
                l.signups.Add(s);
                l.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Signup successfull";
            //bool Status = false;
            //string message = "";
            return View("userSignup", new signup());
        }
        [HttpGet]
        public ActionResult userSignin()
        {

            signup s = new signup();
            return View(s);
        }
        [HttpPost]
        public ActionResult userSignin(signup s)
        {
            using (loginDBEntities2 l = new loginDBEntities2())
            {
                var ss = l.signups.Where(x => x.uName == s.uName && x.uPwd == s.uPwd).FirstOrDefault();
                if (ss == null)
                {
                    ViewBag.Message = "wrong username password";
                    return View("userSignin", s);
                }
                else
                {
                    Session["uId"] = ss.uId;
                    return RedirectToAction("flowers","Product");
                }

            }


        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("userSignin", "User");
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        
    }
}