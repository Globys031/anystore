namespace ActualTestProject.BLL
{
    using AnyStore.BLL;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DeaCustBLLTests
    {
        private DeaCustBLL _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new DeaCustBLL();
        }

        [Test]
        public void CanSetAndGetid()
        {
            // Arrange
            var testValue = 720003343;

            // Act
            _testClass.id = testValue;

            // Assert
            Assert.That(_testClass.id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGettype()
        {
            // Arrange
            var testValue = "TestValue2034770879";

            // Act
            _testClass.type = testValue;

            // Assert
            Assert.That(_testClass.type, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetname()
        {
            // Arrange
            var testValue = "TestValue1733668466";

            // Act
            _testClass.name = testValue;

            // Assert
            Assert.That(_testClass.name, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetemail()
        {
            // Arrange
            var testValue = "TestValue581418402";

            // Act
            _testClass.email = testValue;

            // Assert
            Assert.That(_testClass.email, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetcontact()
        {
            // Arrange
            var testValue = "TestValue1051089814";

            // Act
            _testClass.contact = testValue;

            // Assert
            Assert.That(_testClass.contact, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetaddress()
        {
            // Arrange
            var testValue = "TestValue2032814049";

            // Act
            _testClass.address = testValue;

            // Assert
            Assert.That(_testClass.address, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetadded_date()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.added_date = testValue;

            // Assert
            Assert.That(_testClass.added_date, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetadded_by()
        {
            // Arrange
            var testValue = 987716132;

            // Act
            _testClass.added_by = testValue;

            // Assert
            Assert.That(_testClass.added_by, Is.EqualTo(testValue));
        }
    }
}