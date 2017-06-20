using IOCM.LifeTime;

namespace IOCM
{
    interface IRegister
    {
        void Register<I, C>()
            where C : I;

        void Register<I, C>(LifeTimeStyle lt)
            where C : I;
    }
}
