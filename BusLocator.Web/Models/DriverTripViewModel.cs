using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusLocator.Web.Controllers
{
    public class DriverTripViewModel
    {
        public DriverTripViewModel()
        {
            RouteList = new List<SelectListItem>();
            BusList = new List<SelectListItem>();
        }
        public Guid RouteId { get; set; }
        public Guid BusId { get; set; }

        public List<SelectListItem> RouteList { get; set; }
        public List<SelectListItem> BusList { get; set; }
    }
}