using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeroHunger.Auth;
using zeroHunger.Models;

namespace zeroHunger.Controllers
{
    [LoginCheck]
    [RestrurentCheck]
    public class RestrurentController : Controller
    {
        
        // GET: Restrurent
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddRequest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRequest(RequestDashboard requestDashboard)
        {
            var user = (Login)Session["user"];

            var db = new ZeroHungerContext();
            var employee = (from item in db.Restaurants
                            where item.UserName.Equals(user.UserName) &&
                            item.Password.Equals(user.Password)
                            select item).SingleOrDefault();
            requestDashboard.RId= employee.Id;
            db.RequestDashboards.Add(requestDashboard);
            db.SaveChanges();
            TempData["msg"] = "Item Adeed";
            return View();
        }
        public ActionResult List()
        {
            var user = (Login)Session["user"];

            var db = new ZeroHungerContext();
            var res = (from item in db.Restaurants
                            where item.UserName.Equals(user.UserName) &&
                            item.Password.Equals(user.Password)
                            select item).SingleOrDefault();
            var list=(from item in db.RequestDashboards
                      where item.RId==res.Id
                      select item).ToList();
            return View(list);
        }
    }
}