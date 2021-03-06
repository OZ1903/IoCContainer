﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCM.LifeTime
{
    public class SingletonLifeTime : IInstanceLifeTime
    {
        public LifeTimeStyle cLifeTimeStyle
        {
            get { return LifeTimeStyle.Singleton; }
        }

        public object InstanceValue { get; set; }

        public Type ResolvedType { get; set; }
    }
}
