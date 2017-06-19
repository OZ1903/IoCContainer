using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IOCM.LifeTime;

namespace IOCM
{
    public partial class IoCContainer : IResolve
    {
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type contract)
        {
            // Find the registered type
            if (!types.ContainsKey(contract))
                throw new KeyNotFoundException(string.Format("Can't resolve {0}. Type is not registered.", contract.FullName));

            IInstanceLifeTime implementation = types[contract];

            // If LifeTimeStyle is Singleton and there is already an instance created then return the created instance.
            if (implementation.cLifeTimeStyle == LifeTimeStyle.Singleton && implementation.InstanceValue != null)
                return implementation.InstanceValue;
            
            ConstructorInfo constructor = implementation.ResolvedType.GetConstructors()[0];

            List<ParameterInfo> constructorParameters = constructor.GetParameters().ToList();
            
            List<object> resolvedParameters = new List<object>();
            foreach (var parameterInfo in constructorParameters)
            {
                //Recursive step
                resolvedParameters.Add(Resolve(parameterInfo.ParameterType));
            }

            // Use reflection invoke constructor to create the object
            object retObject = constructor.Invoke(resolvedParameters.ToArray());

            implementation.InstanceValue = retObject;
            return retObject;

        }

    }
}
