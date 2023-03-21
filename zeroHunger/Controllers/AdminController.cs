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
    [AdminCheck]
    public class AdminController : Controller
    {
        // GET: Admin
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            var db = new ZeroHungerContext();
            var list = db.RequestDashboards.ToList();
            
            return View(list);
        }
        public ActionResult Request(int id)
        {
            var db = new ZeroHungerContext();
            List<RequestDashboard> request = null;
            if (Session["request"]==null)
            {
                request = new List<RequestDashboard>();
            }
            else
            {
                request = (List<RequestDashboard>)Session["request"];
            }
            var dashboard=db.RequestDashboards.Find(id);
                request.Add(dashboard);
            Session["request"]=request;
            Session["count"] = request.Count;
            TempData["msg"] = "Request Adedd";
            return RedirectToAction("Dashboard");
        }
        public ActionResult Requests() {
            var request = (List<RequestDashboard>)Session["request"];
            if(request==null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View(request);
            }
        }
        public ActionResult GetEmployee()
        {
            var db = new ZeroHungerContext();
            var employee = db.Employees.ToList();
            return View(employee);

        }
        
            public ActionResult AssignEmployee(int id)
        {
            var db=new ZeroHungerContext();
            var request = (List<RequestDashboard>)Session["Request"];
            var rp = new RequestProcessing();
            rp.Status = "Assigned";
            rp.EId= id;
            string r = "";
            foreach(var item in request)
            {
                if (r == "")
                {
                    r = r + item.Restaurant.Location;
                }
                else
                {
                    r = r + " ," + item.Restaurant.Location;
                }
                
            }
            rp.Location = r;
            db.RequestProcessings.Add(rp);
            db.SaveChanges();
            foreach(var dsb in request)
            {
                var collect=new CollectRequest();
                collect.DashboardId=dsb.Id;
                collect.ProcessingId=rp.Id;
                collect.Qty=1;
                collect.Location = rp.Location;
                db.CollectRequests.Add(collect);
                var req = db.RequestDashboards.Find(dsb.Id);
                req.Qty-=1;
            }
            var employee = (from em in db.Employees.ToList()
                            where em.Id == id
                            select em).SingleOrDefault();
            employee.Status = "Busy";
            Session["request"] = null;
            db.SaveChanges();
            
            return RedirectToAction("Dashboard");

            

        }
        public ActionResult GetProcess()
        {
            var db = new ZeroHungerContext();
            var pr = db.RequestProcessings.ToList();
            return View(pr);

        }
    }
}