namespace ActualTestProject.BLL
{
    using AnyStore.BLL;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class productsBLLTests
    {
        private productsBLL _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new productsBLL();
        }

        [Test]
        public void CanSetAndGetid()
        {
            // Arrange
            var testValue = 1670793865;

            // Act
            _testClass.id = testValue;

            // Assert
            Assert.That(_testClass.id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetname()
        {
            // Arrange
            var testValue = "TestValue147026789";

            // Act
            _testClass.name = testValue;

            // Assert
            Assert.That(_testClass.name, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetcategory()
        {
            // Arrange
            var testValue = "TestValue535648755";

            // Act
            _testClass.category = testValue;

            // Assert
            Assert.That(_testClass.category, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetdescription()
        {
            // Arrange
            var testValue = "TestValue2107212768";

            // Act
            _testClass.description = testValue;

            // Assert
            Assert.That(_testClass.description, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetrate()
        {
            // Arrange
            var testValue = 1069826671.98M;

            // Act
            _testClass.rate = testValue;

            // Assert
            Assert.That(_testClass.rate, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetqty()
        {
            // Arrange
            var testValue = 1654789832.19M;

            // Act
            _testClass.qty = testValue;

            // Assert
            Assert.That(_testClass.qty, Is.EqualTo(testValue));
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
            var testValue = 2062432977;

            // Act
            _testClass.added_by = testValue;

            // Assert
            Assert.That(_testClass.added_by, Is.EqualTo(testValue));
        }
    }
}