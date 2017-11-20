using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Domain.Entity
{
    public class Bus : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public string BusId { get; set; }
        public bool HasAccessibility { get; set; }
    }
}
