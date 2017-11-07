using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusLocator.Web.Controllers
{
    public class DriverController : Controller
    {
        // GET: Driver
        public ActionResult Login()
        {
            return View();
        }
    }
}