namespace ActualTestProject.BLL
{
    using AnyStore.BLL;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class categoriesBLLTests
    {
        private categoriesBLL _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new categoriesBLL();
        }

        [Test]
        public void CanSetAndGetid()
        {
            // Arrange
            var testValue = 1547528053;

            // Act
            _testClass.id = testValue;

            // Assert
            Assert.That(_testClass.id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGettitle()
        {
            // Arrange
            var testValue = "TestValue31793798";

            // Act
            _testClass.title = testValue;

            // Assert
            Assert.That(_testClass.title, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetdescription()
        {
            // Arrange
            var testValue = "TestValue723010365";

            // Act
            _testClass.description = testValue;

            // Assert
            Assert.That(_testClass.description, Is.EqualTo(testValue));
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
            var testValue = 102932040;

            // Act
            _testClass.added_by = testValue;

            // Assert
            Assert.That(_testClass.added_by, Is.EqualTo(testValue));
        }
    }
}