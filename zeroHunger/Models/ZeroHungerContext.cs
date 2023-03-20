using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace zeroHunger.Models
{
    public class ZeroHungerContext:DbContext
    {

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RequestDashboard> RequestDashboards { get; set; }
        public DbSet<RequestProcessing> RequestProcessings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CollectRequest> CollectRequests { get; set; }
    }
}