using BusLocator.Services.Managers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Services.Managers
{
    public interface IWindsor
    {
        IBusManager busManager { get; }
    }
}
