using BusLocator.Persistence.BusinessObjects;
using BusLocator.Persistence.Context;
using BusLocator.Persistence.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Persistence.UnitofWork.Abstract
{
    public interface IDbFactory
    {
        BusLocatorContext Init();

        IBaseRepository<BusBO> busRepository { get; }
        IBaseRepository<BusDriverBO> busDriverRepository { get; }
        IBaseRepository<BusLocationBO> busLocationRepository { get; }
        IBaseRepository<CityBO> cityRepository { get; }
        IBaseRepository<DriverBO> driverRepository { get; }
        IBaseRepository<RouteBO> routeRepository { get; }
    }
}
