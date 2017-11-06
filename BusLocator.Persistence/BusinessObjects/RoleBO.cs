using BusLocator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Persistence.BusinessObjects
{
    public class RoleBO : Role
    {
        public RoleBO()
        {
            Id = Guid.NewGuid().ToString();
        }

        public RoleBO(string name)
            : this()
        {
            Name = name;
        }
    }
}
