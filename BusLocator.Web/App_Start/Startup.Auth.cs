using BusLocator.Persistence.BusinessObjects;
using BusLocator.Persistence.Context;
using BusLocator.Persistence.IdentityServices.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BusLocator.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(BusLocatorContext.Create);
            app.CreatePerOwinContext<BusLocatorUserManager>(BusLocatorUserManager.Create);
            app.CreatePerOwinContext<BusLocatorSignInManager>(BusLocatorSignInManager.Create);
            app.CreatePerOwinContext<BusLocatorRoleManager>(BusLocatorRoleManager.Create);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BusLocatorContext, Persistence.Migrations.Configuration>());
            BusLocatorContext context = new BusLocatorContext();
            context.Database.Initialize(false);

            int authTimeSpan = 48; // Convert.ToInt32(ConfigurationManager.AppSettings["AuthTimeSpan"]);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/account/login"),
                LogoutPath = new PathString("/account/logout"),
                ExpireTimeSpan = TimeSpan.FromHours(authTimeSpan),
                SlidingExpiration = true,
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<BusLocatorUserManager, UserBO>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {

                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
#if DEBUG
                AllowInsecureHttp = true,
#endif
            });

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            //app.UseWebApi(config);

            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(10));
        }
    }
}