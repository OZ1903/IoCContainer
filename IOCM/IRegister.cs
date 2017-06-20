using IOCM.LifeTime;

namespace IOCM
{
    interface IRegister
    {
        void Register<C>()
            where C : class;

        void Register<C>(LifeTimeStyle lt)
            where C : class;

        void Register<I, C>()
            where C : class
            where I : class;

        void Register<I, C>(LifeTimeStyle lt)
            where C : class
            where I : class;
    }
}
