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
        Mock<IDbConnection> connectionMock;
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

        // This test fails: i.e. we found a bug
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

        /// <summary>
        /// J. G. start
        /// </summary>
        ///////////////////////////////////////////////////////////////////////////////////////
        // naming conventio used: nameOfMethod_when_passedValue_return_returnedResult       //
        //////////////////////////////////////////////////////////////////////////////////////

        [Test]
        public void Update_when_passedCorrectParams_return_true()
        {
            // Prepare
            DeaCustBLL dc = new DeaCustBLL();
            dc.type = "user";
            dc.name = "user";
            dc.email = "user@email.com";
            dc.contact = "8972937278";
            dc.address = "address";
            dc.added_date = DateTime.Now;
            dc.added_by = 3;
            // Set up dependency injection
            var dependencyInjection = new Mock<IDependency>();
            dependencyInjection.Setup(d => d.AddValues(dc));
            dependencyInjection.Setup(d => d.ExecuteCommand()).Returns(1);
            dal = new DeaCustDAL(connectionMock.Object, dependencyInjection.Object);

            // Act
            bool result = dal.Update(dc);

            // Assert
            Assert.IsTrue(result);
        }

        // If updating, we should check if there's any value that isn't just an empty string
        // or 0. If nothing was set, it should return false (couldn't update).
        [Test]
        public void Update_when_passedEmptyParams_return_false()
        {
            // Prepare
            DeaCustBLL dc = new DeaCustBLL();
            dc.type = "";
            dc.name = "";
            dc.email = "";
            dc.contact = "";
            dc.address = "";
            dc.added_date = DateTime.Now;
            dc.added_by = 3;
            // Set up dependency injection
            var dependencyInjection = new Mock<IDependency>();
            dependencyInjection.Setup(d => d.AddValues(dc));
            dependencyInjection.Setup(d => d.ExecuteCommand()).Returns(0);
            dal = new DeaCustDAL(connectionMock.Object, dependencyInjection.Object);

            // Act
            bool result = dal.Update(dc);

            // Assert
            Assert.IsFalse(result);
        }

        // Can't use null as an update value
        [Test]
        public void Update_when_passed_null_return_false()
        {
            // Prepare
            DeaCustBLL dc = null;
            // Set up dependency injection
            var dependencyInjection = new Mock<IDependency>();
            dependencyInjection.Setup(d => d.AddValues(dc));
            dependencyInjection.Setup(d => d.ExecuteCommand()).Returns(0);
            dal = new DeaCustDAL(connectionMock.Object, dependencyInjection.Object);

            // Act
            bool result = dal.Update(dc);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Update_when_emailIncorrectFormat_return_false()
        {
            // Prepare
            DeaCustBLL dc = new DeaCustBLL();
            dc.type = "user";
            dc.name = "user";
            dc.email = "not a correct email format lmao";
            dc.contact = "8972937278";
            dc.address = "address";
            dc.added_date = DateTime.Now;
            dc.added_by = 3;
            // Set up dependency injection
            var dependencyInjection = new Mock<IDependency>();
            dependencyInjection.Setup(d => d.AddValues(dc));
            dependencyInjection.Setup(d => d.ExecuteCommand()).Returns(0);
            dal = new DeaCustDAL(connectionMock.Object, dependencyInjection.Object);

            // Act
            bool result = dal.Update(dc);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Update_when_addedByParamterIsEqualToZero_return_false()
        {
            // Prepare
            DeaCustBLL dc = new DeaCustBLL();
            dc.type = "user";
            dc.name = "user";
            dc.email = "user@email.com";
            dc.contact = "8972937278";
            dc.address = "address";
            dc.added_date = DateTime.Now;
            dc.added_by = 0;
            // Set up dependency injection
            var dependencyInjection = new Mock<IDependency>();
            dependencyInjection.Setup(d => d.AddValues(dc));
            dependencyInjection.Setup(d => d.ExecuteCommand()).Returns(0);
            dal = new DeaCustDAL(connectionMock.Object, dependencyInjection.Object);

            // Act
            bool result = dal.Update(dc);

            // Assert
            Assert.IsFalse(result);
        }
        //
        /// <summary>
        /// J. G. END
        /// </summary>

        /// <summary>
        /// T. S. start
        /// </summary>
        [Test]
        public void Search_when_keywordValueIsNull_returnsNullValue()
        {
            string keyword = null;
            DeaCustBLL dc = new DeaCustBLL { type = "Dealer", name = "Test1", email = "test@gmail.com", address = "Germany", contact = "12354", added_date = DateTime.Now, added_by = 7 };
            DeaCustBLL dc2 = new DeaCustBLL { type = "Dealer", name = "Test2", email = "test2@gmail.com", address = "Germany", contact = "1235467", added_date = DateTime.Now, added_by = 7 };
            // Set up dependency injection
            var dependencyInjection = new Mock<IDependency>();
            dependencyInjection.Setup(d => d.AddValues(dc));
            dependencyInjection.Setup(d => d.AddValues(dc2));
            dal = new DeaCustDAL(connectionMock.Object, dependencyInjection.Object);

            // Act
            DataTable result = dal.Search(keyword);
            // Assert
            Assert.IsNull(result);
        }
        [Test]
        public void Search_when_keywordValueMatch_returnSuccess()
        {
            string keyword = "Dealer";
            DeaCustBLL dc = new DeaCustBLL { type = "Dealer", name = "Test1", email = "test@gmail.com", address = "Germany", contact = "12354", added_date = DateTime.Now, added_by = 7 };
            DeaCustBLL dc2 = new DeaCustBLL { type = "Dealer", name = "Test2", email = "test2@gmail.com", address = "Germany", contact = "1235467", added_date = DateTime.Now, added_by = 7 };
            DataTable dt = new DataTable(); dt.Columns.Add();
            dt.Rows.Add(dc); dt.Rows.Add(dc2);
            // Set up dependency injection
            var dependencyInjection = new Mock<IDependency>();
            dependencyInjection.Setup(d => d.AddValues(dc));
            dependencyInjection.Setup(d => d.AddValues(dc2));
            dependencyInjection.Setup(d => d.FillTheTable()).Returns(dt);
            dal = new DeaCustDAL(connectionMock.Object, dependencyInjection.Object);

            // Act
            DataTable result = dal.Search(keyword);
            // Assert
            Assert.AreEqual(2,result.Rows.Count);
        }
        [Test]
        public void Search_when_QuerySuccessful_OpenAndCloseConnection()
        {
            // Prepare
            string keyword = "Dealer";
            // Set up dependency injection
            var dependencyInjection = new Mock<IDependency>();
            dal = new DeaCustDAL(connectionMock.Object, dependencyInjection.Object);

            // Act
            var dt = dal.Search(keyword);

            // Assert
            connectionMock.Verify(d => d.Open(), Times.Once());
            connectionMock.Verify(d => d.Close(), Times.Once());
        }
        [Test]
        public void SearchDealerCustomerForTransaction_when_MethodThrowsException_OpenAndCloseConnection()
        {
            //Prepare
            string keyword = "Dealer";
            // Set up dependency injection
            var dependencyInjection = new Mock<IDependency>();
            dal = new DeaCustDAL(connectionMock.Object, dependencyInjection.Object);

            //Act
            var dt = dal.SearchDealerCustomerForTransaction(keyword);

            //Assert
            connectionMock.Verify(d => d.Open(), Times.Once());
            connectionMock.Verify(d => d.Close(), Times.Once());
        }
        [Test]
        public void Search_when_ExceptionThrown_CloseConnection()
        {
            // Prepare
            string keyword = "Dealer";
            // Set up dependency injection
            var dependencyInjection = new Mock<IDependency>();
            dependencyInjection.Setup(d => d.FillTheTable()).Throws(new Exception());
            dal = new DeaCustDAL(connectionMock.Object, dependencyInjection.Object);

            // Act
            var dt = dal.Search(keyword);

            // Assert
            connectionMock.Verify(d => d.Close(), Times.Once());
        }
        ///
        /// <summary>
        /// T. S. END
        /// </summary>
        /// 


        [Test]
        public void Integration_Insert_QueryCorrectParams_ReturnsTrue()
        {
            // Prepare
            IDeaCustRepository repo = new DeaCustDAL(new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AnyStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"), new ConcreteDependencyForTestPurposes());

            DeaCustBLL dc = new DeaCustBLL();
            dc.type = "user";
            dc.name = "user";
            dc.email = "user@email.com";
            dc.contact = "8972937278";
            dc.address = "address";
            dc.added_date = DateTime.Now;
            dc.added_by = 3;

            // Act
            bool result = repo.Insert(dc);
            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Integration_Insert_QueryCorrectParams_ReturnsFalse()
        {
            // Prepare
            IDeaCustRepository repo = new DeaCustDAL(new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AnyStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"), new ConcreteDependencyForTestPurposes());

            DeaCustBLL dc = new DeaCustBLL();
            dc.type = null;
            dc.name = "user";
            dc.email = "useremail.com";
            dc.contact = "8972937-278";
            dc.address = "address";
            dc.added_date = DateTime.Now;
            dc.added_by = 3;

            // Act
            bool result = repo.Insert(dc);
            // Assert
            Assert.IsFalse(result);
        }
        /// <summary>
        /// T. S.
        /// </summary>
        [Test]
        public void Integration_Search_CorrectQuery_ReturnsTrue()
        {
            IDeaCustRepository repo = new DeaCustDAL(new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AnyStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"), 
                new ConcreteDependencyForTestPurposes());
            string keyword = "Dealer";
            DataTable dt = null;

            dt = repo.Search(keyword);

            Assert.IsTrue(dt != null);

        }
    }
}