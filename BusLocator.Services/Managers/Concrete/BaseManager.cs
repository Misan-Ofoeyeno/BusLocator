using BusLocator.Persistence.UnitofWork.Abstract;
using BusLocator.Services.Managers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Services.Managers.Concrete
{
    public class BaseManager : IBaseManager
    {
        public IUnitofWork unitofWork;
        public IDbFactory db;

        public BaseManager(IDbFactory _db, IUnitofWork _unitofWork)
        {
            db = _db;
            unitofWork = _unitofWork;
        }


        #region Get Single Methods


        #endregion


        #region Add Entities



        #endregion


        #region Update Entities


        #endregion


        #region Delete Entities


        #endregion


        #region Get Methods


        #endregion
    }
}
