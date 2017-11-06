using BusLocator.Persistence.BusinessObjects;
using BusLocator.Persistence.Context;
using BusLocator.Persistence.IdentityServices.Store;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Persistence.IdentityServices.Managers
{
    public class BusLocatorRoleManager : RoleManager<RoleBO, string>
    {
        public BusLocatorRoleManager(IRoleStore<RoleBO, string> roleStore)
            : base(roleStore)
        {

        }

        public static BusLocatorRoleManager Create(IdentityFactoryOptions<BusLocatorRoleManager> options, IOwinContext context)
        {
            return new BusLocatorRoleManager(new BusLocatorRoleStore(context.Get<BusLocatorContext>()));
        }
    }
}
