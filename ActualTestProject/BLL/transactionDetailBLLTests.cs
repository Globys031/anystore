namespace ActualTestProject.BLL
{
    using AnyStore.BLL;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class transactionDetailBLLTests
    {
        private transactionDetailBLL _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new transactionDetailBLL();
        }

        [Test]
        public void CanSetAndGetid()
        {
            // Arrange
            var testValue = 1552550661;

            // Act
            _testClass.id = testValue;

            // Assert
            Assert.That(_testClass.id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetproduct_id()
        {
            // Arrange
            var testValue = 1729660261;

            // Act
            _testClass.product_id = testValue;

            // Assert
            Assert.That(_testClass.product_id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetrate()
        {
            // Arrange
            var testValue = 1088049355.47M;

            // Act
            _testClass.rate = testValue;

            // Assert
            Assert.That(_testClass.rate, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetqty()
        {
            // Arrange
            var testValue = 577200196.98M;

            // Act
            _testClass.qty = testValue;

            // Assert
            Assert.That(_testClass.qty, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGettotal()
        {
            // Arrange
            var testValue = 1464113763.09M;

            // Act
            _testClass.total = testValue;

            // Assert
            Assert.That(_testClass.total, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetdea_cust_id()
        {
            // Arrange
            var testValue = 147350185;

            // Act
            _testClass.dea_cust_id = testValue;

            // Assert
            Assert.That(_testClass.dea_cust_id, Is.EqualTo(testValue));
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
            var testValue = 1129155216;

            // Act
            _testClass.added_by = testValue;

            // Assert
            Assert.That(_testClass.added_by, Is.EqualTo(testValue));
        }
    }
}