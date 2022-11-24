namespace ActualTestProject.BLL
{
    using AnyStore.BLL;
    using System;
    using NUnit.Framework;
    using System.Data;

    [TestFixture]
    public class transactionsBLLTests
    {
        private transactionsBLL _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new transactionsBLL();
        }

        [Test]
        public void CanSetAndGetid()
        {
            // Arrange
            var testValue = 708289182;

            // Act
            _testClass.id = testValue;

            // Assert
            Assert.That(_testClass.id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGettype()
        {
            // Arrange
            var testValue = "TestValue1648256286";

            // Act
            _testClass.type = testValue;

            // Assert
            Assert.That(_testClass.type, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetdea_cust_id()
        {
            // Arrange
            var testValue = 1965867219;

            // Act
            _testClass.dea_cust_id = testValue;

            // Assert
            Assert.That(_testClass.dea_cust_id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetgrandTotal()
        {
            // Arrange
            var testValue = 1822785594.3M;

            // Act
            _testClass.grandTotal = testValue;

            // Assert
            Assert.That(_testClass.grandTotal, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGettransaction_date()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.transaction_date = testValue;

            // Assert
            Assert.That(_testClass.transaction_date, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGettax()
        {
            // Arrange
            var testValue = 1928924704.08M;

            // Act
            _testClass.tax = testValue;

            // Assert
            Assert.That(_testClass.tax, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetdiscount()
        {
            // Arrange
            var testValue = 1206966408.12M;

            // Act
            _testClass.discount = testValue;

            // Assert
            Assert.That(_testClass.discount, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetadded_by()
        {
            // Arrange
            var testValue = 1351811491;

            // Act
            _testClass.added_by = testValue;

            // Assert
            Assert.That(_testClass.added_by, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGettransactionDetails()
        {
            // Arrange
            var testValue = new DataTable();

            // Act
            _testClass.transactionDetails = testValue;

            // Assert
            Assert.That(_testClass.transactionDetails, Is.SameAs(testValue));
        }
    }
}