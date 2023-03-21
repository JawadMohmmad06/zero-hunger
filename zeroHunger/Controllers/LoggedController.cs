using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeroHunger.Models;

namespace zeroHunger.Controllers
{
    public class LoggedController : Controller
    {
        // GET: Logged
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login) {
            var user = new Login();
            var db =new ZeroHungerContext();
            var log = (from item in db.Restaurants
                       where item.UserName.Equals(login.UserName)
                       && item.Password.Equals(login.Password)
                       select item).SingleOrDefault();
                var log2 = (from item in db.Employees
                           where item.UserName.Equals(login.UserName)
                           && item.Password.Equals(login.Password)
                           select item).SingleOrDefault();
               
                    var log3 = (from item in db.Admins
                                where item.UserName.Equals(login.UserName)
                                && item.Password.Equals(login.Password)
                                select item).SingleOrDefault();
                   if (log != null)
            {
                user.UserName= log.UserName;
                user.Password= log.Password;
                user.Type = "Restrurent";
                Session["user"] = user;
                return RedirectToAction("AddRequest", "Restrurent");
            }
                   else if(log3!=null){
                user.UserName = log3.UserName;
                user.Password = log3.Password;
                user.Type = "Admin";
                Session["user"] = user;
               
                return RedirectToAction("Dashboard", "Admin");

            }
                   else if (log2 != null) {
                user.UserName = log2.UserName;
                user.Password = log2.Password;
                user.Type = "Emplyoee";
              
                Session["user"] = user;
                return RedirectToAction("List", "Employee");
            }

            TempData["msg"] = "login Error";
            return View();
            
            


        }
        public ActionResult LogOut()
        {
            Session["user"] = null;
            return RedirectToAction("Login");
        }

    }
}