using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeroHunger.Models;

namespace zeroHunger.Controllers
{
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
            var db = new ZeroHungerContext();
            db.RequestDashboards.Add(requestDashboard);
            db.SaveChanges();
            return View();
        }
    }
}