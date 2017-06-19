using IOCM;

namespace IOCMTest
{
    internal static class ContainerFactory
    {
        public static IoCContainer New()
        {
            var container = new IoCContainer();

            return container;
        }
    }
}
