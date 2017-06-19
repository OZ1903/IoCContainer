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
        
    }
}
