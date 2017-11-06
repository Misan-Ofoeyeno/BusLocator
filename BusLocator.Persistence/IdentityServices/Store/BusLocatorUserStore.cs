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
    public class BusLocatorUserStore : UserStore<UserBO, RoleBO, string, Domain.Entity.UserLogin, Domain.Entity.UserRole, Domain.Entity.UserClaim>, IUserStore<UserBO, string>, IDisposable
    {
        public BusLocatorUserStore()
            : this(new IdentityDbContext())
        {

        }

        public BusLocatorUserStore(DbContext context)
            : base(context)
        {

        }
    }
}
