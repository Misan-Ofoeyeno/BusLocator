using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Domain.Entity
{
    public class City : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
