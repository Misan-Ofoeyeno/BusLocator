using BusLocator.Persistence.BusinessObjects;
using BusLocator.Services.Managers;
using BusLocator.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusLocator.Web.Controllers
{
    public class DriverController : BaseController
    {
        public DriverController(IWindsor windsor)
            : base(windsor)
        {
        }
    

        public ActionResult StartTrip()
        {
            //Check if Driver is on trip

            DriverTripViewModel model = new DriverTripViewModel();

            SelectListItem defaultItem = new SelectListItem { Value = null, Text = "Select one" };
            model.RouteList.Add(defaultItem);
            model.BusList.Add(defaultItem);

            var routelist = windsor.busManager.Routes(r => r.Audit.RecordStateType == Domain.Enum.RecordStateType.Active)
                .OrderBy(r => r.ShortName)
                .Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.RouteName
                }).ToList();

            var buslist = windsor.busManager.Buses(b => b.Audit.RecordStateType == Domain.Enum.RecordStateType.Active)
                .OrderBy(b => b.BusId)
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.BusId
                }).ToList();

            model.RouteList.AddRange(routelist);
            model.BusList.AddRange(buslist);

            return View(model);
        }

        [HttpPost]
        public ActionResult StartTrip(DriverTripViewModel model)
        {
            BusDriverBO busDriver = new BusDriverBO
            {
                BusId = model.BusId,
                DriverUserId = CurrentUserId,
                TripStartTime = DateTime.Now,
                Audit = new Domain.Entity.Audit(CurrentUserId)
            };

            windsor.busManager.Add(busDriver);


            return RedirectToAction("Trip", new { routeId = model.RouteId, busId = model.BusId });
        }

        public ActionResult Trip(Guid routeId, Guid busId, long latitude, long longitude)
        {

            return View();
        }
    }
}