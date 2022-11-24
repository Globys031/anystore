namespace ActualTestProject.DAL
{
    using AnyStore.DAL;
    using System;
    using NUnit.Framework;
    using AnyStore.BLL;
    using System.Configuration;

    [TestFixture]
    public class categoriesDALTests
    {
        categoriesDAL _testClass;
        [SetUp]
        public void SetUp()
        {
            _testClass = new categoriesDAL();      
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
            var c = new categoriesBLL { id = 230538137, title = "TestValue1472584055", description = "TestValue1082245102", added_date = DateTime.UtcNow, added_by = 2099317858 };

            // Act
            var result = _testClass.Insert(c);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsTrue(result);
        }

        [Test]
        public void CannotCallInsertWithNullC()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Insert(default(categoriesBLL)));
        }

        [Test]
        public void CanCallUpdate()
        {
            // Arrange
            var c = new categoriesBLL { id = 176969113, title = "TestValue14781052", description = "TestValue858674087", added_date = DateTime.UtcNow, added_by = 1363750575 };

            // Act
            var result = _testClass.Update(c);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsTrue(result);
        }

        [Test]
        public void CannotCallUpdateWithNullC()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Update(default(categoriesBLL)));
        }

        [Test]
        public void CanCallDelete()
        {
            // Arrange
            var c = new categoriesBLL { id = 414987108, title = "TestValue1680620962", description = "TestValue654066231", added_date = DateTime.UtcNow, added_by = 675890761 };

            // Act
            var result = _testClass.Delete(c);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsTrue(result);
        }

        [Test]
        public void CannotCallDeleteWithNullC()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Delete(default(categoriesBLL)));
        }

        [Test]
        public void CanCallSearch()
        {
            // Arrange
            var keywords = "TestValue48383534";

            // Act
            var result = _testClass.Search(keywords);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallSearchWithInvalidKeywords(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Search(value));
        }
    }
}