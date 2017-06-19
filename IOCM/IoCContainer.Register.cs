using System;
using System.Runtime.InteropServices.WindowsRuntime;
using IOCM.LifeTime;

namespace IOCM
{
    
    public partial class IoCContainer : IRegister
    {
        /// <summary>
        /// Registers Interface with the corresponding class. Default LifeTime is Transient. 
        /// </summary>
        public void Register<TContract, TImplementation>() 
            where TContract : class 
            where TImplementation : class
        {
            Register<TContract, TImplementation>(LifeTimeStyle.Transient);
        }

        /// <summary>
        /// Registers Interface with the corresponding class. LifeTime options can be used.
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
