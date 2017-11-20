using BusLocator.Persistence.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Services.Managers.Abstract
{
    public interface IBusManager : IBaseManager
    {
        #region Get Single Methods


        #endregion


        #region Add Entities

        void Add(BusBO bus);
        void Add(BusDriverBO busDriver);
        void Add(BusLocationBO busLocation);
        void Add(CityBO city);
        void Add(DriverBO driver);
        void Add(RouteBO route);

        #endregion


        #region Update Entities


        #endregion


        #region Delete Entities


        #endregion


        #region Get Methods

        IQueryable<DriverBO> Drivers(Expression<Func<DriverBO, bool>> predicate);
        IQueryable<RouteBO> Routes(Expression<Func<RouteBO, bool>> predicate);
        IQueryable<BusBO> Buses(Expression<Func<BusBO, bool>> predicate);
        IQueryable<BusDriverBO> BusDrivers(Expression<Func<BusDriverBO, bool>> predicate);

        #endregion
    }
}
