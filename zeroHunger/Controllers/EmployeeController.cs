using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using zeroHunger.Auth;
using zeroHunger.Models;

namespace zeroHunger.Controllers
{
    [LoginCheck]
    [EmployeeCHeck]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var user = (Login)Session["user"];
            
            var db = new ZeroHungerContext();
            var employee = (from item in db.Employees
                            where item.UserName.Equals(user.UserName) &&
                            item.Password.Equals(user.Password)
                            select item).SingleOrDefault();


            var list = (from r in db.RequestProcessings
                        where r.EId == employee.Id
                        select r
                      ).ToList();
            return View(list);
        }
        public ActionResult ReqDet(int id)
        {
            var db = new ZeroHungerContext();
            var list = (from r in db.RequestProcessings
                        where r.Id == id
                        select r
                      ).ToList();
            return View(list);
        }
        public ActionResult RecievedFood(int id)
        {
            var db = new ZeroHungerContext();
            var request = db.RequestProcessings.Find(id);
            request.Status = "Order Recived";
            
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult DeliveredFood(int id)
        {
            var user = (Login)Session["user"];

            var db = new ZeroHungerContext();
            var employee = (from item in db.Employees
                            where item.UserName.Equals(user.UserName) &&
                            item.Password.Equals(user.Password)
                            select item).SingleOrDefault();
            var request = db.RequestProcessings.Find(id);
            request.Status = "Order Delivered";
            employee.Status = "Free";
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            var db = new ZeroHungerContext();
            employee.Status = "Free";
            db.Employees.Add(employee);
            db.SaveChanges();
            TempData["msg"] = "Account Created";
            return RedirectToAction("Login", "Logged");
        }

    }
}