namespace ActualTestProject.BLL
{
    using AnyStore.BLL;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class userBLLTests
    {
        private userBLL _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new userBLL();
        }

        [Test]
        public void CanSetAndGetid()
        {
            // Arrange
            var testValue = 1424819487;

            // Act
            _testClass.id = testValue;

            // Assert
            Assert.That(_testClass.id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetfirst_name()
        {
            // Arrange
            var testValue = "TestValue1956627678";

            // Act
            _testClass.first_name = testValue;

            // Assert
            Assert.That(_testClass.first_name, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetlast_name()
        {
            // Arrange
            var testValue = "TestValue324740746";

            // Act
            _testClass.last_name = testValue;

            // Assert
            Assert.That(_testClass.last_name, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetemail()
        {
            // Arrange
            var testValue = "TestValue260522974";

            // Act
            _testClass.email = testValue;

            // Assert
            Assert.That(_testClass.email, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetusername()
        {
            // Arrange
            var testValue = "TestValue556397701";

            // Act
            _testClass.username = testValue;

            // Assert
            Assert.That(_testClass.username, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetpassword()
        {
            // Arrange
            var testValue = "TestValue457627937";

            // Act
            _testClass.password = testValue;

            // Assert
            Assert.That(_testClass.password, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetcontact()
        {
            // Arrange
            var testValue = "TestValue833281704";

            // Act
            _testClass.contact = testValue;

            // Assert
            Assert.That(_testClass.contact, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetaddress()
        {
            // Arrange
            var testValue = "TestValue1586077753";

            // Act
            _testClass.address = testValue;

            // Assert
            Assert.That(_testClass.address, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetgender()
        {
            // Arrange
            var testValue = "TestValue458109544";

            // Act
            _testClass.gender = testValue;

            // Assert
            Assert.That(_testClass.gender, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetuser_type()
        {
            // Arrange
            var testValue = "TestValue238029557";

            // Act
            _testClass.user_type = testValue;

            // Assert
            Assert.That(_testClass.user_type, Is.EqualTo(testValue));
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
            var testValue = 589871235;

            // Act
            _testClass.added_by = testValue;

            // Assert
            Assert.That(_testClass.added_by, Is.EqualTo(testValue));
        }
    }
}