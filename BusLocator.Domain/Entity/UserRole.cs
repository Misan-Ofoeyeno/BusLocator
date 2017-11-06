using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Domain.Entity
{
    public class UserRole : IdentityUserRole<string>
    {
    }

    public class UserLogin : IdentityUserLogin<string>
    {
    }

    public class UserClaim : IdentityUserClaim<string>
    {
    }
}
