using BusLocator.Persistence.BusinessObjects;
using BusLocator.Persistence.Context;
using BusLocator.Persistence.Repository.Abstract;
using BusLocator.Persistence.Repository.Concrete;
using BusLocator.Persistence.UnitofWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Persistence.UnitofWork.Concrete
{
    public class DbFactory : Disposable, IDbFactory
    {
        BusLocatorContext dbContext;

        public BusLocatorContext Init()
        {
            return dbContext ?? (dbContext = new BusLocatorContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

        private IBaseRepository<BusBO> _busRepository;
        private IBaseRepository<BusDriverBO> _busDriverRepository;
        private IBaseRepository<BusLocationBO> _busLocationRepository;
        private IBaseRepository<CityBO> _cityRepository;
        private IBaseRepository<DriverBO> _driverRepository;
        private IBaseRepository<RouteBO> _routeRepository;

        public IBaseRepository<BusBO> busRepository
        {
            get
            {
                return _busRepository ?? (_busRepository = new BaseRepository<BusBO>(Init()));
            }
        }

        public IBaseRepository<BusDriverBO> busDriverRepository
        {
            get
            {
                return _busDriverRepository ?? (_busDriverRepository = new BaseRepository<BusDriverBO>(Init()));
            }
        }

        public IBaseRepository<BusLocationBO> busLocationRepository
        {
            get
            {
                return _busLocationRepository ?? (_busLocationRepository = new BaseRepository<BusLocationBO>(Init()));
            }
        }

        public IBaseRepository<CityBO> cityRepository
        {
            get
            {
                return _cityRepository ?? (_cityRepository = new BaseRepository<CityBO>(Init()));
            }
        }

        public IBaseRepository<DriverBO> driverRepository
        {
            get
            {
                return _driverRepository ?? (_driverRepository = new BaseRepository<DriverBO>(Init()));
            }
        }

        public IBaseRepository<RouteBO> routeRepository
        {
            get
            {
                return _routeRepository ?? (_routeRepository = new BaseRepository<RouteBO>(Init()));
            }
        }
    }
}
