using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCM.LifeTime
{
    public class InstanceLifeTimeFactory : IInstanceLifeTimeFactory
    {
        public IInstanceLifeTime Create(Type t, LifeTimeStyle lt, object o)
        {
            switch (lt)
            {
                case LifeTimeStyle.Singleton:
                    return new SingletonLifeTime()
                    {
                        ResolvedType = t,
                        InstanceValue = o
                    };
                default:
                    return new TransientLifeTime()
                    {
                        ResolvedType = t,
                        InstanceValue = null
                    };
                
            }
        }
    }
}
