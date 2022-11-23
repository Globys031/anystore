namespace ActualTestProject.DAL
{
    using AnyStore.DAL;
    using System;
    using NUnit.Framework;
    using AnyStore.BLL;

    [TestFixture]
    public class loginDALTests
    {
        private loginDAL _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new loginDAL();
        }

        [Test]
        public void CanCallloginCheck()
        {
            // Arrange
            var l = new loginBLL { username = "TestValue565629177", password = "TestValue1922324144", user_type = "TestValue1956665659" };

            // Act
            var result = _testClass.loginCheck(l);

            // Assert
            //Assert.Fail("Create or modify test");
            Assert.IsTrue(result);
        }

        [Test]
        public void CannotCallloginCheckWithNullL()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.loginCheck(default(loginBLL)));
        }
    }
}