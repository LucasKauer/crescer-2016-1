using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaReforcoAuth.Filters
{
    public class GlobalController : Controller
    {
        // GET: Global
        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}