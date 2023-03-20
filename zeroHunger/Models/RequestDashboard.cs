using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace zeroHunger.Models
{
    public class RequestDashboard
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Restaurant")]
        public int RId { get; set; }
        public String FoodName { get; set; }
        public int Qty { get; set; }
        public DateTime Expirydate { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<CollectRequest> CollectRequests { get; set; }
        public RequestDashboard() { 
            CollectRequests= new List<CollectRequest>();
        }

    }
}