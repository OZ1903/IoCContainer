using System;
using System.Collections.Generic;
using IOCM.LifeTime;

namespace IOCM
{
    
    public partial class IoCContainer
    {
        private static readonly IDictionary<Type, IInstanceLifeTime> types = new Dictionary<Type, IInstanceLifeTime>();
        
    }
}
