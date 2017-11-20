using BusLocator.Persistence.BusinessObjects;
using BusLocator.Persistence.Context;
using BusLocator.Persistence.IdentityServices.Managers;
using BusLocator.Persistence.IdentityServices.Store;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Persistence.Migrations
{
    public class Configuration : DbMigrationsConfiguration<BusLocatorContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = false;
            AutomaticMigrationsEnabled = true;
            ContextKey = "ScrumPost.Persistence.Context.ScrumPostContext";
        }

        protected override void Seed(BusLocatorContext context)
        {
            BusLocatorUserManager userManager = new BusLocatorUserManager(new BusLocatorUserStore(context));
            BusLocatorRoleManager roleManager = new BusLocatorRoleManager(new BusLocatorRoleStore(context));

            //System.Web.HttpContext.Current.GetOwinContext().

            const string name = "admin@buslocator.ca";
            string password = "buslocator1";

            string[] roles = { "Admin", "User", "Driver" };

            foreach (string rolename in roles)
            {
                var role = roleManager.FindByName(rolename);
                if (role == null)
                {
                    role = new RoleBO(rolename);
                    var roleresult = roleManager.Create(role);
                }
            }

            RoleBO role1 = roleManager.FindByName(roles[0]);
            RoleBO role2 = roleManager.FindByName(roles[1]);

            var user = userManager.FindByName(name);

            if (user == null)
            {
                user = new UserBO
                {
                    UserName = name,
                    Email = name,
                    FullName = "Global Admin",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    Audit = new Domain.Entity.Audit(),
                    HasAcceptedTerms = true,
                };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            var rolesForUser = userManager.GetRoles(user.Id);

            if (!rolesForUser.Contains("Admin"))
            {
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
