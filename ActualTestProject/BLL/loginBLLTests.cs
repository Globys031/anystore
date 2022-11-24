namespace ActualTestProject.BLL
{
    using AnyStore.BLL;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class loginBLLTests
    {
        private loginBLL _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new loginBLL();
        }

        [Test]
        public void CanSetAndGetusername()
        {
            // Arrange
            var testValue = "TestValue503310729";

            // Act
            _testClass.username = testValue;

            // Assert
            Assert.That(_testClass.username, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetpassword()
        {
            // Arrange
            var testValue = "TestValue100391727";

            // Act
            _testClass.password = testValue;

            // Assert
            Assert.That(_testClass.password, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetuser_type()
        {
            // Arrange
            var testValue = "TestValue237975573";

            // Act
            _testClass.user_type = testValue;

            // Assert
            Assert.That(_testClass.user_type, Is.EqualTo(testValue));
        }
    }
}