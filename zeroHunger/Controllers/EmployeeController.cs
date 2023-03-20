using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeroHunger.Models;

namespace zeroHunger.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var db = new ZeroHungerContext();
            var list = (from r in db.RequestProcessings
                        where r.EId == 1
                        select r
                      ).ToList();
            return View(list);
        }

    }
}