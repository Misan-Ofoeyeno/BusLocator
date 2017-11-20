using BusLocator.Persistence.BusinessObjects;
using BusLocator.Services.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BusLocator.Web.API
{
    public class TripController : BaseApiController
    {

        public TripController(IWindsor windsor)
            :base(windsor)
        {
        }

        public IHttpActionResult SendLocation(Guid routeId, Guid busId)
        {
            BusLocationBO location = new BusLocationBO
            {
                BusId = busId,
                RouteId = routeId,
                UpdateTime = DateTime.Now
            };
            return Ok();
        }
    }
}
