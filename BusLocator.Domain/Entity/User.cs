using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Domain.Entity
{
    public class User : IdentityUser<string, UserLogin, UserRole, UserClaim>
    {
        public string FullName { get; set; }
        public bool HasAcceptedTerms { get; set; }
        public Audit Audit { get; set; }
    }
}
