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
        public void RegisterByGenericArgument_WithValidSameGenericArguments_Succeeds()
        {
            // Arrange
            var container = ContainerFactory.New();

            // Act
            container.Register<SqlUserRepository, SqlUserRepository>();
        }

        [TestMethod]
        public void RegisterByGenericArgument_WithValidOneGenericArguments_Succeeds()
        {
            // Arrange
            var container = ContainerFactory.New();

            // Act
            container.Register<SqlUserRepository>();
        }

        [TestMethod]
        public void RegisterByGenericArgument_WithInValidOneGenericArgumentsInterface_Succeeds()
        {
            // Arrange
            var container = ContainerFactory.New();


            // Act
            Action action = () => container.Register<ITimeProvider>();

            // Assert
            CustomAssert.Throws<Exception>(action);
        }

        [TestMethod]
        public void RegisterByGenericArgument_WithInValidOneGenericArgumentsAbstract_Succeeds()
        {
            // Arrange
            var container = ContainerFactory.New();


            // Act
            Action action = () => container.Register<UserServiceBase>();

            // Assert
            CustomAssert.Throws<Exception>(action);
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
        public void Register_AlreadyRegisteredOneGeneric_ThrowsException()
        {
            // Arrange
            var container = ContainerFactory.New();

            container.Register<FakeUserService>();

            // Act
            Action action = () => container.Register<FakeUserService>();

            // Assert
            CustomAssert.Throws<Exception>(action);
        }

    }
}
