using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Domain.Entity
{
    public class Driver : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public string EmployeeId { get; set; }
    }
}
