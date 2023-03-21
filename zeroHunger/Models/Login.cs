using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zeroHunger.Models
{
    public class Login
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }
}