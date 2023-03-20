using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace zeroHunger.Models
{
    public class CollectRequest
    {
        public int Id { get; set; }
        [ForeignKey("RequestDashboard")] 
        public int DashboardId { get; set; }
        [ForeignKey("RequestProcessing")]
        public int ProcessingId { get; set; }
        public int Qty { get; set; }
        public virtual RequestDashboard RequestDashboard { get; set; }
        public virtual RequestProcessing RequestProcessing { get; set; }
    }
}