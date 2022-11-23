namespace ActualTestProject.DAL
{
    using AnyStore.DAL;
    using System;
    using NUnit.Framework;
    using AnyStore.BLL;

    [TestFixture]
    public class userDALTests
    {
        private userDAL _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new userDAL();
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
            var u = new userBLL { id = 909364778, first_name = "TestValue1447080685", last_name = "TestValue1763552149", email = "TestValue337768140", username = "TestValue382722797", password = "TestValue671863760", contact = "TestValue568069419", address = "TestValue926406190", gender = "TestValue468032909", user_type = "TestValue1208012583", added_date = DateTime.UtcNow, added_by = 1691905719 };

            // Act
            var result = _testClass.Insert(u);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsTrue(result);
        }

        [Test]
        public void CannotCallInsertWithNullU()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Insert(default(userBLL)));
        }

        [Test]
        public void CanCallUpdate()
        {
            // Arrange
            var u = new userBLL { id = 1699902572, first_name = "TestValue1292638797", last_name = "TestValue601904735", email = "TestValue433540838", username = "TestValue1802494843", password = "TestValue222718488", contact = "TestValue1268840803", address = "TestValue1713494970", gender = "TestValue719092833", user_type = "TestValue2026353665", added_date = DateTime.UtcNow, added_by = 925789520 };

            // Act
            var result = _testClass.Update(u);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsTrue(result);
        }

        [Test]
        public void CannotCallUpdateWithNullU()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Update(default(userBLL)));
        }

        [Test]
        public void CanCallDelete()
        {
            // Arrange
            var u = new userBLL { id = 732860611, first_name = "TestValue1405771528", last_name = "TestValue592819804", email = "TestValue1052627357", username = "TestValue547010026", password = "TestValue1151966871", contact = "TestValue545708372", address = "TestValue110016474", gender = "TestValue1816166006", user_type = "TestValue976735175", added_date = DateTime.UtcNow, added_by = 1457442910 };

            // Act
            var result = _testClass.Delete(u);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsTrue(result);
        }

        [Test]
        public void CannotCallDeleteWithNullU()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Delete(default(userBLL)));
        }

        [Test]
        public void CanCallSearch()
        {
            // Arrange
            var keywords = "TestValue1554862711";

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
        public void CanCallGetIDFromUsername()
        {
            // Arrange
            var username = "TestValue1980907985";

            // Act
            var result = _testClass.GetIDFromUsername(username);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.That(result.username, Is.SameAs(username));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallGetIDFromUsernameWithInvalidUsername(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.GetIDFromUsername(value));
        }

        [Test]
        public void GetIDFromUsernamePerformsMapping()
        {
            // Arrange
            var username = "TestValue1944055329";

            // Act
            var result = _testClass.GetIDFromUsername(username);

            // Assert
            Assert.That(result.username, Is.SameAs(username));
        }
    }
}