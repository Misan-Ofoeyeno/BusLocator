using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Domain.Entity
{
    public class BusLocation : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual Guid BusId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
