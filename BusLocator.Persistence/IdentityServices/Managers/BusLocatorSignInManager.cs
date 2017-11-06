using BusLocator.Persistence.BusinessObjects;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Persistence.IdentityServices.Managers
{
    public class BusLocatorSignInManager : SignInManager<UserBO, string>
    {
        public BusLocatorSignInManager(BusLocatorUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(UserBO user)
        {
            return user.GenerateUserIdentityAsync((BusLocatorUserManager)UserManager);
        }

        public static BusLocatorSignInManager Create(IdentityFactoryOptions<BusLocatorSignInManager> options, IOwinContext context)
        {
            return new BusLocatorSignInManager(context.GetUserManager<BusLocatorUserManager>(), context.Authentication);
        }
    }
}
