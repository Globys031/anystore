using NUnit.Framework;
using System;
using Moq;
using AnyStore.DAL;
using System.Data;
using AnyStore.BLL;
using System.Data.SqlClient;

namespace ActualTestProject
{
    // How to add unit tests:
    // 1. look at DeaCustDAL.cs
    // 2. Find method you want to test
    // 3. Follow examples below how to add test
    // 4. Add any dependencies to ConcreteDependency and use DependencyInjection!!!
    public class UnitTests
    {
        Mock<IDbConnection>             connectionMock;

        DeaCustBLL dc;
        DeaCustDAL dal;
        [SetUp]
        public void Setup()
        {
            // set up connection
            connectionMock = new Mock<IDbConnection>();
            connectionMock.Setup(d => d.Open()).Verifiable();
            connectionMock.Setup(d => d.Close()).Verifiable();

            // set up default user
            dc = new DeaCustBLL();
        }

        [Test]
        public void Insert_QuerySuccessful_ConnectionOpenedAndClosed()
        {
            // Prepare
            // Set up dependency injection
            var dependencyInjection = new Mock<IDependency>();
            dal = new DeaCustDAL(connectionMock.Object, dependencyInjection.Object);

            // Act
            bool result = dal.Insert(dc);

            // Assert
            connectionMock.Verify(d => d.Open(), Times.Once());
            connectionMock.Verify(d => d.Close(), Times.Once());
        }

        [Test]
        public void Insert_AnyExceptionThrown_ConnectionClosedBeforeExit()
        {
            // Prepare
            // Set up dependency injection
            var dependencyInjection = new Mock<IDependency>();
            dependencyInjection.Setup(d => d.ExecuteCommand()).Throws(new Exception());
            dal = new DeaCustDAL(connectionMock.Object, dependencyInjection.Object);

            // Act
            bool result = dal.Insert(dc);

            // Assert
            connectionMock.Verify(d => d.Close(), Times.Once());
        }

        [Test]
        public void Insert_QueryCommandAffectedRows_ReturnsSuccess()
        {
            // Prepare
            // Set up dependency injection
            var dependencyInjection = new Mock<IDependency>();
            dependencyInjection.Setup(d => d.ExecuteCommand()).Returns(1);
            dal = new DeaCustDAL(connectionMock.Object, dependencyInjection.Object);

            // Act
            bool result = dal.Insert(dc);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Insert_QueryCommandAffectedRows_ReturnsFailure()
        {
            // Prepare
            // Set up dependency injection
            var dependencyInjection = new Mock<IDependency>();
            dependencyInjection.Setup(d => d.ExecuteCommand()).Returns(0);
            dal = new DeaCustDAL(connectionMock.Object, dependencyInjection.Object);

            // Act
            bool result = dal.Insert(dc);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Insert_ShowingMessageThrowsException_ExceptionCaught()
        {
            // Prepare
            // Set up dependency injection
            var dependencyInjection = new Mock<IDependency>();
            dependencyInjection.Setup(d => d.ExecuteCommand()).Throws(new Exception());
            dependencyInjection.Setup(d => d.ShowMessage(It.IsAny<string>())).Throws(new Exception());
            dal = new DeaCustDAL(connectionMock.Object, dependencyInjection.Object);

            // Act
            Action act = () => dal.Insert(dc);

            // Assert
            Assert.DoesNotThrow(delegate { act.Invoke(); });
        }
    }
}