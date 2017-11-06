using BusLocator.Persistence.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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


        #endregion
    }
}
