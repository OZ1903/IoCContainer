using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IOCMTest
{
    [TestClass]
    public class RegisterByGenericsTests
    {

        [TestMethod]
        public void RegisterByGenericArgument_WithValidGenericArguments_Succeeds()
        {
            // Arrange
            var container = ContainerFactory.New();

            // Act
            container.Register<IUserRepository, SqlUserRepository>();
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

        [TestMethod]
        public void Register_AlreadyRegistered_ThrowsException()
        {
            // Arrange
            var container = ContainerFactory.New();

            container.Register<UserServiceBase, FakeUserService>();
            
            // Act
            Action action = () => container.Register<UserServiceBase, FakeUserService>();

            // Assert
            CustomAssert.Throws<Exception>(action);
        }

        [TestMethod]
        public void Resolve_OnRegisteredType_ReturnsANewInstanceOnEachCall()
        {
            // Arrange
            var container = ContainerFactory.New();

            container.Register<IUserRepository, InMemoryUserRepository>();

            // Act
            var instance1 = container.Resolve<IUserRepository>();
            var instance2 = container.Resolve<IUserRepository>();

            // Assert
            Assert.AreNotEqual(instance1, instance2, "Register<TService, TImplementation>() should " +
                "return transient objects.");
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
    }
}
