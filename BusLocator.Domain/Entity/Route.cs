using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Domain.Entity
{
    public class Route : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public string RouteName { get; set; }
    }
}
