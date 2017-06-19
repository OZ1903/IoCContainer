using System.Threading;
using IOCM.LifeTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IOCMTest
{
    [TestClass]
    public class ResolveTests
    {
        [TestMethod]
        public void Resolve_SingletonLifeTime_TwoInstancesEqual()
        {
            //Arrange
            var container = ContainerFactory.New();
            container.Register<ITimeProvider, RealTimeProvider>(LifeTimeStyle.Singleton);

            //Act
            var instance1 = container.Resolve<ITimeProvider>();
            Thread.Sleep(2000);
            var instance2 = container.Resolve<ITimeProvider>();

            //Assert
            Assert.AreEqual(instance1.GetCreatedOn(), instance2.GetCreatedOn());
        }

        [TestMethod]
        public void Resolve_TransientLifeTime_TwoInstancesNotEqual()
        {
            //Arrange
            var container = ContainerFactory.New();
            container.Register<ITimeProvider, RealTimeProvider>();

            //Act
            var instance1 = container.Resolve<ITimeProvider>();
            Thread.Sleep(2000);
            var instance2 = container.Resolve<ITimeProvider>();

            //Assert
            Assert.AreNotEqual(instance1.GetCreatedOn(), instance2.GetCreatedOn());
        }
    }
}
