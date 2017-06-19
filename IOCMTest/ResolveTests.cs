using System.Threading;
using IOCM.LifeTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
        
        [TestMethod]
        public void Resolve_MissingDependency_ThrowsMissingRegistration()
        {
            // Arrange
            var container = ContainerFactory.New();

            container.Register<UserServiceBase, FakeUserService>();

            // Act
            Action action = () => container.Resolve<UserServiceBase>();

            // Assert
            CustomAssert.Throws<KeyNotFoundException>(action);
        }

        [TestMethod]
        public void Resolve_OnRegisteredType_ReturnsInstanceOfExpectedType()
        {
            // Arrange
            var container = ContainerFactory.New();

            container.Register<IUserRepository, SqlUserRepository>();

            // Act
            var instance = container.Resolve<IUserRepository>();

            // Assert
            Assert.IsInstanceOfType(instance, typeof(SqlUserRepository));
        }
    }
}
