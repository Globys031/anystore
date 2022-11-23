namespace ActualTestProject.DAL
{
    using AnyStore.DAL;
    using System;
    using NUnit.Framework;
    using AnyStore.BLL;

    [TestFixture]
    public class transactionDetailDALTests
    {
        private transactionDetailDAL _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new transactionDetailDAL();
        }

        [Test]
        public void CanCallInsertTransactionDetail()
        {
            // Arrange
            var td = new transactionDetailBLL { id = 1344693851, product_id = 1677193205, rate = 999535377.06M, qty = 1517748598.08M, total = 2020271273.46M, dea_cust_id = 614753552, added_date = DateTime.UtcNow, added_by = 729175932 };

            // Act
            var result = _testClass.InsertTransactionDetail(td);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsTrue(result);
        }

        [Test]
        public void CannotCallInsertTransactionDetailWithNullTd()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.InsertTransactionDetail(default(transactionDetailBLL)));
        }
    }
}