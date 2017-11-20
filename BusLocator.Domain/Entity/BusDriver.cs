using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Domain.Entity
{
    public class BusDriver :  BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual Guid BusId { get; set; }
        public virtual string DriverUserId { get; set; }
        public DateTime TripStartTime { get; set; }
        public DateTime? TripEndTime { get; set; }
    }
}