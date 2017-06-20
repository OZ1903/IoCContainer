using System;
using System.Runtime.InteropServices.WindowsRuntime;
using IOCM.LifeTime;

namespace IOCM
{
    
    public partial class IoCContainer : IRegister
    {

        /// <summary>
        /// Registers single generic Type. Default LifeTime is Transient. 
        /// </summary>
        public void Register<TImplementation>()
        where TImplementation : class
        {
            if (!typeof(TImplementation).IsClass || typeof(TImplementation).IsAbstract)
                throw new Exception(string.Format("Single generics needs to be only concrete classes. Name: {0}",
                    typeof(TImplementation).FullName));

            Register<TImplementation, TImplementation>(LifeTimeStyle.Transient);
        }

        /// <summary>
        /// Registers single generic Type.  LifeTime options can be used.
        /// </summary>
        public void Register<TImplementation>(LifeTimeStyle lsType)
        where TImplementation : class
        {
            if (!typeof(TImplementation).IsClass || typeof(TImplementation).IsAbstract)
                throw new Exception(string.Format("Single generics needs to be only concrete classes. Name: {0}",
                    typeof(TImplementation).FullName));

            Register<TImplementation, TImplementation>(lsType);
        }

        /// <summary>
        /// Registers Type with the concrete implementation. Default LifeTime is Transient. 
        /// </summary>
        public void Register<TContract, TImplementation>()
        where TContract : class
        where TImplementation : class 
        {
            Register<TContract, TImplementation>(LifeTimeStyle.Transient);
        }

        /// <summary>
        /// Registers Type with the concrete implementation. LifeTime options can be used.
        /// </summary>
        public void Register<TContract, TImplementation>(LifeTimeStyle lsType)
        where TContract : class
        where TImplementation : class
        {
            if (types.ContainsKey(typeof(TContract)))
                throw new Exception(string.Format("Type {0} already registered.", typeof(TContract).FullName));
            
            IInstanceLifeTimeFactory lifeTimeFactory = new InstanceLifeTimeFactory();

            types[typeof(TContract)] = lifeTimeFactory.Create(typeof(TImplementation), lsType, null);
        }
    }
}
