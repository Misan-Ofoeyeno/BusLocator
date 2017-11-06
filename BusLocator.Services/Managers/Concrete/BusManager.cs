using BusLocator.Services.Managers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusLocator.Persistence.UnitofWork.Abstract;
using BusLocator.Persistence.BusinessObjects;

namespace BusLocator.Services.Managers.Concrete
{
    public class BusManager : BaseManager, IBusManager
    {
        public BusManager(IDbFactory _db, IUnitofWork _unitofWork) 
            : base(_db, _unitofWork)
        {
        }

        #region Get Single Methods


        #endregion


        #region Add Entities

        public void Add(BusBO bus)
        {
            if(bus == null)
                throw new ArgumentNullException("bus");
            db.busRepository.Add(bus);
        }

        public void Add(BusDriverBO busDriver)
        {
            if (busDriver == null)
                throw new ArgumentNullException("busDriver");
            db.busDriverRepository.Add(busDriver);
        }

        public void Add(BusLocationBO busLocation)
        {
            if (busLocation == null)
                throw new ArgumentNullException("busLocation");
            db.busLocationRepository.Add(busLocation);
        }

        public void Add(CityBO city)
        {
            if (city == null)
                throw new ArgumentNullException("city");
            db.cityRepository.Add(city);
        }

        public void Add(DriverBO driver)
        {
            if (driver == null)
                throw new ArgumentNullException("driver");
            db.driverRepository.Add(driver);
        }

        public void Add(RouteBO route)
        {
            if (route == null)
                throw new ArgumentNullException("route");
            db.routeRepository.Add(route);
        }

        #endregion


        #region Update Entities


        #endregion


        #region Delete Entities


        #endregion


        #region Get Methods


        #endregion
    }
}
