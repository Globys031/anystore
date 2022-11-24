namespace ActualTestProject.DAL
{
    using AnyStore.DAL;
    using System;
    using NUnit.Framework;
    using AnyStore.BLL;

    [TestFixture]
    public class productsDALTests
    {
        private productsDAL _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new productsDAL();
        }

        [Test]
        public void CanCallSelect()
        {
            // Act
            var result = _testClass.Select();

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsNotNull(result, "DataTable is empty");
        }

        [Test]
        public void CanCallInsert()
        {
            // Arrange
            var p = new productsBLL { id = 594502902, name = "TestValue674317828", category = "TestValue605232562", description = "TestValue257785929", rate = 126534977.91M, qty = 1914296435.37M, added_date = DateTime.UtcNow, added_by = 1867216138 };

            // Act
            var result = _testClass.Insert(p);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsTrue(result);
        }

        [Test]
        public void CannotCallInsertWithNullP()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Insert(default(productsBLL)));
        }

        [Test]
        public void CanCallUpdate()
        {
            // Arrange
            var p = new productsBLL { id = 1978001566, name = "TestValue2018011511", category = "TestValue911101486", description = "TestValue1391862545", rate = 2102232164.67M, qty = 1628993522.97M, added_date = DateTime.UtcNow, added_by = 2141713916 };

            // Act
            var result = _testClass.Update(p);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsTrue(result);
        }

        [Test]
        public void CannotCallUpdateWithNullP()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Update(default(productsBLL)));
        }

        [Test]
        public void CanCallDelete()
        {
            // Arrange
            var p = new productsBLL { id = 1645001710, name = "TestValue1222194398", category = "TestValue951593005", description = "TestValue838459263", rate = 898302905.28M, qty = 112156405.02M, added_date = DateTime.UtcNow, added_by = 916473433 };

            // Act
            var result = _testClass.Delete(p);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsTrue(result);
        }

        [Test]
        public void CannotCallDeleteWithNullP()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Delete(default(productsBLL)));
        }

        [Test]
        public void CanCallSearch()
        {
            // Arrange
            var keywords = "TestValue1397292698";

            // Act
            var result = _testClass.Search(keywords);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsNotNull(result, "DataTable is empty");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallSearchWithInvalidKeywords(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Search(value));
        }

        [Test]
        public void CanCallGetProductsForTransaction()
        {
            // Arrange
            var keyword = "TestValue1144608270";

            // Act
            var result = _testClass.GetProductsForTransaction(keyword);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.That(keyword, Is.SameAs(result.id).Or.SameAs(result.name));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallGetProductsForTransactionWithInvalidKeyword(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.GetProductsForTransaction(value));
        }

        [Test]
        public void CanCallGetProductIDFromName()
        {
            // Arrange
            var ProductName = "TestValue1743084515";

            // Act
            var result = _testClass.GetProductIDFromName(ProductName);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.AreEqual(result.name, ProductName);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallGetProductIDFromNameWithInvalidProductName(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.GetProductIDFromName(value));
        }

        [Test]
        public void CanCallGetProductQty()
        {
            // Arrange
            var ProductID = 872190184;

            // Act
            var result = _testClass.GetProductQty(ProductID);

            // Assert
            Assert.Fail("Create or modify test");
            //Assert.AreEqual(result, ProductID);
        }

        [Test]
        public void CanCallUpdateQuantity()
        {
            // Arrange
            var ProductID = 234618702;
            var Qty = 1305690418.89M;

            // Act
            var result = _testClass.UpdateQuantity(ProductID, Qty);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsTrue(result);
        }

        [Test]
        public void CanCallIncreaseProduct()
        {
            // Arrange
            var ProductID = 1138040206;
            var IncreaseQty = 1685313271.62M;

            // Act
            var result = _testClass.IncreaseProduct(ProductID, IncreaseQty);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsTrue(result);
        }

        [Test]
        public void CanCallDecreaseProduct()
        {
            // Arrange
            var ProductID = 125389060;
            var Qty = 306645194.79M;

            // Act
            var result = _testClass.DecreaseProduct(ProductID, Qty);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsTrue(result);
        }

        [Test]
        public void CanCallDisplayProductsByCategory()
        {
            // Arrange
            var category = "TestValue619467030";

            // Act
            var result = _testClass.DisplayProductsByCategory(category);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsNotNull(result, "DataTable is empty");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallDisplayProductsByCategoryWithInvalidCategory(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.DisplayProductsByCategory(value));
        }
    }
}