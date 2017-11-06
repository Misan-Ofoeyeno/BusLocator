using BusLocator.Persistence.UnitofWork.Abstract;
using BusLocator.Services.Managers.Abstract;
using BusLocator.Services.Managers.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Services.Managers
{
    public class Windsor : IWindsor
    {
        IDbFactory db;
        IUnitofWork unitofWork;

        public Windsor(IDbFactory _db, IUnitofWork _unitofWork)
        {
            db = _db;
            unitofWork = _unitofWork;
        }

        private IBusManager _busManager;

        public IBusManager busManager
        {
            get
            {
                return _busManager ?? (_busManager = new BusManager(db, unitofWork));
            }
        }
    }
}
