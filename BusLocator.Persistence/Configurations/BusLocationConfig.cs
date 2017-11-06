using BusLocator.Persistence.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Persistence.Configurations
{
    public class BusLocationConfig : EntityBaseConfig<BusLocationBO>
    {
        public BusLocationConfig()
        {
            Property(e => e.Longitude).HasPrecision(11, 10);
            Property(e => e.Latitude).HasPrecision(11, 10);
        }
    }
}