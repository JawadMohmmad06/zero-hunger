using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace zeroHunger.Models
{
    public class RequestProcessing
    {
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EId { get; set; }
        public String Status { get; set; }
        public String Location { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<CollectRequest> CollectRequests { get; set; }
        public RequestProcessing() { 
            CollectRequests= new List<CollectRequest>();    
           
        }
    }
}