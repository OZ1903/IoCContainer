using IOCM.LifeTime;

namespace IOCM
{
    interface IRegister
    {
        void Register<I, C>()
            where I : class
            where C : class;

        void Register<I, C>(LifeTimeStyle lt)
            where I : class
            where C : class;
    }
}
