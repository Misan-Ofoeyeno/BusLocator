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
    public class BusLocatorUserManager : UserManager<UserBO, string>
    {
        public BusLocatorUserManager(IUserStore<UserBO, string> userStore)
            : base(userStore)
        {
        }

        public static BusLocatorUserManager Create(IdentityFactoryOptions<BusLocatorUserManager> options, IOwinContext context)
        {
            var manager = new BusLocatorUserManager(new BusLocatorUserStore(context.Get<BusLocatorContext>()));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<UserBO, string>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            // Configure user lockout defaults

            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 8;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.

            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<UserBO, string>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<UserBO, string>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });


            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<UserBO, string>(dataProtectionProvider.Create("Bus Locator Application"))
                    {
                        TokenLifespan = TimeSpan.FromHours(48)
                    };
            }
            return manager;
        }
    }
}
