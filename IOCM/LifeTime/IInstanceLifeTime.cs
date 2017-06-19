using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCM.LifeTime
{
    public interface IInstanceLifeTime
    {
        Type ResolvedType { get; set; }
        LifeTimeStyle cLifeTimeStyle { get; }
        object InstanceValue { get; set; }
    }
}
