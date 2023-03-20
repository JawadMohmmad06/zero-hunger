using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zeroHunger.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public string Location { get; set; }
        public virtual  ICollection<RequestDashboard> RequestDashboards { get; set; }
        public Restaurant() {

            RequestDashboards=new List<RequestDashboard>();
        }
    }
   
}