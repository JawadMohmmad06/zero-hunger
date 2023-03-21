using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeroHunger.Models;

namespace zeroHunger.Auth
{
    public class RestrurentCheck: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (Login)httpContext.Session["user"];
            if (user != null && user.Type.Equals("Restrurent")) return true;
            return false;
        }
    }
}