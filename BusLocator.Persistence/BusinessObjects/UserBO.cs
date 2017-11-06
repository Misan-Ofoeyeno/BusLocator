using BusLocator.Domain.Entity;
using BusLocator.Persistence.IdentityServices.Managers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BusLocator.Persistence.BusinessObjects
{
    public class UserBO : User
    {
        public UserBO()
        {
            Id = Guid.NewGuid().ToString();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(BusLocatorUserManager manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("UserId", Id));
            userIdentity.AddClaim(new Claim("UserFullname", FullName ?? ""));
            return userIdentity;
        }

        [Key]
        public override string Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                base.Id = value;
            }
        }
    }
}
