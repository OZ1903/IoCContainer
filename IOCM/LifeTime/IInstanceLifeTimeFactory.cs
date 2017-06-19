using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCM.LifeTime
{
    interface IInstanceLifeTimeFactory
    {
        IInstanceLifeTime Create(Type t, LifeTimeStyle lt, object o);
    }
}
