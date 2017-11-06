using BusLocator.Persistence.BusinessObjects;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Persistence.IdentityServices.Store
{
    public class BusLocatorRoleStore : RoleStore<RoleBO, string, Domain.Entity.UserRole>, IQueryableRoleStore<RoleBO, string>, IRoleStore<RoleBO, string>, IDisposable
    {
        public BusLocatorRoleStore()
            : this(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public BusLocatorRoleStore(DbContext context)
            : base(context)
        {

        }
    }
}
