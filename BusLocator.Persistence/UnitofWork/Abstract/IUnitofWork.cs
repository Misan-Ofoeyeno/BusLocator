using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Persistence.UnitofWork.Abstract
{
    public interface IUnitofWork
    {
        void Commit();
        Task CommitAsync();
    }
}
