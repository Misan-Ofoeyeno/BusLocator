using BusLocator.Services.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusLocator.Web.Controllers
{
    public class AdminController : BaseController
    {
        public AdminController(IWindsor windsor)
            :base(windsor)
        {
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Drivers()
        {
            return View();
        }
    }
}