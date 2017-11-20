using BusLocator.Persistence.IdentityServices.Managers;
using BusLocator.Services.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BusLocator.Web.API
{
    public class BaseApiController : ApiController
    {
        public IWindsor windsor;
        private BusLocatorUserManager _userManager;

        public BaseApiController(IWindsor windsor)
        {
            this.windsor = windsor;
        }
    }
}