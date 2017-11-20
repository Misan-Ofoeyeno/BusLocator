using BusLocator.Persistence.BusinessObjects;
using BusLocator.Services.Managers;
using BusLocator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace BusLocator.Web.Controllers
{
    [Authorize(Roles = "Admin")]
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
            IEnumerable<DriverViewModel> drivers = windsor.busManager.Drivers(d => d.Audit.RecordStateType == Domain.Enum.RecordStateType.Active)
                .Include(d => d.User)
                .OrderByDescending(d => d.Audit.CreatedDate)
                .Select(d => new DriverViewModel
                {
                    UserId = d.UserId,
                    Fullname = d.User.FullName,
                    EmployeeId = d.EmployeeId,
                    Email = d.User.Email
                }).ToList();
            return View(drivers);
        }

        public ActionResult AddDriver()
        {
            return View(new DriverViewModel());
        }

        [HttpPost]
        public ActionResult AddDriver(DriverViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserBO newDriver = new UserBO
                {
                    UserName = model.EmployeeId.Trim(),
                    Email = model.Email.Trim(),
                    FullName = model.Fullname.Trim(),
                    LockoutEnabled = true,
                    EmailConfirmed = true,
                    Audit = new Domain.Entity.Audit(),
                    HasAcceptedTerms = true,
                };
                var result = UserManager.Create(newDriver, "password1");

                if(result == IdentityResult.Success)
                {
                    DriverBO driver = new DriverBO(newDriver.Id)
                    {
                        EmployeeId = model.EmployeeId.Trim(),
                        Audit = new Domain.Entity.Audit()
                    };
                    windsor.busManager.Add(driver);
                    var addToRoleResult = UserManager.AddToRole(newDriver.Id, "Driver");
                }
                return RedirectToAction("Drivers");
            }
            return View(model);
        }


        public ActionResult EditDriver(Guid id)
        {
            return View();
        }

        public ActionResult Buses()
        {
            var buses = windsor.busManager.Buses(b => b.Audit.RecordStateType == Domain.Enum.RecordStateType.Active)
                .OrderBy(b => b.BusId)
                .Select(b => new BusViewModel
                {
                    Id = b.Id,
                    BusId = b.BusId,
                    HasAccessibility = b.HasAccessibility,
                }).ToList();
            return View(buses);
        }

        public ActionResult AddBus()
        {
            return View(new BusViewModel());
        }

        [HttpPost]
        public ActionResult AddBus(BusViewModel model)
        {
            BusBO bus = new BusBO
            {
                BusId = model.BusId,
                HasAccessibility = model.HasAccessibility,
                Audit =  new Domain.Entity.Audit()
            };
            windsor.busManager.Add(bus);
            return RedirectToAction("Buses");
        }

        public ActionResult EditBus()
        {
            return View();
        }

        public ActionResult Routes()
        {
            var routes = windsor.busManager.Routes(r => r.Audit.RecordStateType == Domain.Enum.RecordStateType.Active)
                .OrderBy(r => r.ShortName)
                .Select(r => new RouteViewModel
                {
                    RouteId = r.Id,
                    RouteName = r.RouteName,
                    ShortName = r.ShortName
                }).ToList();
            return View(routes);
        }

        public ActionResult AddRoute()
        {
            return View(new RouteViewModel());
        }

        [HttpPost]
        public ActionResult AddRoute(RouteViewModel model)
        {
            RouteBO route = new RouteBO
            {
                RouteName = model.RouteName,
                ShortName = model.ShortName,
                Audit = new Domain.Entity.Audit()
            };
            windsor.busManager.Add(route);
            return RedirectToAction("Routes");
        }


        public ActionResult EditRoute()
        {
            return View();
        }
    }
}