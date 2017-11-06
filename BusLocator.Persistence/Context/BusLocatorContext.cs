using BusLocator.Persistence.BusinessObjects;
using BusLocator.Persistence.Configurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Persistence.Context
{
    public class BusLocatorContext : IdentityDbContext<UserBO, RoleBO, string, Domain.Entity.UserLogin, Domain.Entity.UserRole, Domain.Entity.UserClaim>
    {
        public BusLocatorContext()
            : base("BusLocatorConnection")
        {
        }

        public IDbSet<BusBO> Bus { get; set; }
        public IDbSet<BusDriverBO> BusDriver { get; set; }
        public IDbSet<BusLocationBO> BusLocation { get; set; }
        public IDbSet<CityBO> City { get; set; }
        public IDbSet<DriverBO> Driver { get; set; }
        public IDbSet<RouteBO> Route { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public virtual async Task CommitAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new AuditConfig());

            //other custom configs
            modelBuilder.Configurations.Add(new BusLocationConfig());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserBO>()
                .ToTable("User");
            modelBuilder.Entity<RoleBO>()
                .ToTable("Role");
            modelBuilder.Entity<Domain.Entity.UserLogin>()
                .ToTable("UserLogin");
            modelBuilder.Entity<Domain.Entity.UserRole>()
                .ToTable("UserRole");
            modelBuilder.Entity<Domain.Entity.UserClaim>()
                .ToTable("UserClaim");
        }

        public static BusLocatorContext Create()
        {
            return new BusLocatorContext();
        }
    }
}
