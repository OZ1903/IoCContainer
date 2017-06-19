using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCM
{
    class ResolvedTypeWithLifeStyleType
    {

        public Type ResolvedType { get; set; }
        public LifestyleType _lifestyleType { get; set; }
        public object InstanceValue { get; set; }

        public ResolvedTypeWithLifeStyleType(Type resolvedType)
        {
            ResolvedType = resolvedType;
            _lifestyleType = LifestyleType.Transient;
            InstanceValue = null;
        }

        public ResolvedTypeWithLifeStyleType(Type resolvedType, LifestyleType lifestyleType)
        {
            ResolvedType = resolvedType;
            _lifestyleType = lifestyleType;
            InstanceValue = null;
        }
    }
}
