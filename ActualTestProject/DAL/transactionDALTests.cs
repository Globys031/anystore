namespace ActualTestProject.DAL
{
    using AnyStore.DAL;
    using System;
    using NUnit.Framework;
    using AnyStore.BLL;
    using System.Data;

    [TestFixture]
    public class transactionDALTests
    {
        private transactionDAL _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new transactionDAL();
        }

        [Test]
        public void CanCallInsert_Transaction()
        {
            // Arrange
            var t = new transactionsBLL { id = 1839994807, type = "TestValue1966121472", dea_cust_id = 654503582, grandTotal = 2027955154.5M, transaction_date = DateTime.UtcNow, tax = 384579376.83M, discount = 1692219797.73M, added_by = 1610265098, transactionDetails = new DataTable() };

            // Act
            var result = _testClass.Insert_Transaction(t, out var transactionID);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsTrue(result);
        }

        [Test]
        public void CannotCallInsert_TransactionWithNullT()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Insert_Transaction(default(transactionsBLL), out _));
        }

        [Test]
        public void CanCallDisplayAllTransactions()
        {
            // Act
            var result = _testClass.DisplayAllTransactions();

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsNotNull(result, "DataTable is empty");
        }

        [Test]
        public void CanCallDisplayTransactionByType()
        {
            // Arrange
            var @type = "TestValue270136982";

            // Act
            var result = _testClass.DisplayTransactionByType(type);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsNotNull(result, "DataTable is empty");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallDisplayTransactionByTypeWithInvalidType(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.DisplayTransactionByType(value));
        }
    }
}