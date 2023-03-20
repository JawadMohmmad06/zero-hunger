using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zeroHunger.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Status { get; set; }
        public virtual ICollection<RequestProcessing> RequestProcessings { get; set; }
        public Employee()
        {
            RequestProcessings= new List<RequestProcessing>();
        }
    }
}