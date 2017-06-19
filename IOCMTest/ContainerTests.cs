using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IOCM;

namespace IOCMTest
{
    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        public void Equals_OnSameInstance_ReturnsTrue()
        {
            // Arrange
            var container = ContainerFactory.New();

            // Act
            var result = container.Equals(container);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_OnDifferentInstance_ReturnsFalse()
        {
            // Arrange
            var container1 = ContainerFactory.New();
            var container2 = ContainerFactory.New();

            // Act
            var result = container1.Equals(container2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void String_Always_ReturnsExpectedValue()
        {
            // Arrange
            var container = ContainerFactory.New();

            // Act
            string result = container.ToString();

            // Assert
            Assert.AreEqual("IOCM.IoCContainer", result);
        }

        [TestMethod]
        public void HashCode_Always_Succeeds()
        {
            // Arrange
            var container = ContainerFactory.New();

            // Act
            container.GetHashCode();
        }

        [TestMethod]
        public void GetType_Always_ReturnsTheExpectedType()
        {
            // Arrange
            var container = ContainerFactory.New();

            // Act
            Type type = container.GetType();

            // Assert
            Assert.AreEqual(typeof(IoCContainer), type);
        }
    }
}
