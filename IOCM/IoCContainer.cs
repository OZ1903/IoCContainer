using System;
using System.Collections.Generic;
using IOCM.LifeTime;

namespace IOCM
{
    
    public partial class IoCContainer : IDisposable
    {
        private readonly IDictionary<Type, IInstanceLifeTime> types = new Dictionary<Type, IInstanceLifeTime>();

        public void Dispose()
        {
            this.types.Clear();
        }
    }
}
