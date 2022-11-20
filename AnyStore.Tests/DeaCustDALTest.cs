/*using System;
using Xunit;
using Moq;
using AnyStore.DAL;
using System.Data;
using AnyStore.BLL;
using AnyStore.TDD;
using System.Data;
using System.Data.SqlClient;

//////////////////////////////////////////////////////////////////////////////////////
// !!!! naming convention: nameOfMethod_when_passedValue_return_returnedResult !!!! //
//////////////////////////////////////////////////////////////////////////////////////

namespace AnyStore.Tests
{
    public class DeaCustDALTest
    {
        private IDeaCustRepository _inMemoryRepo;
        //private frmDeaCust _deaCustController;

        // Setup
        public DeaCustDALTest()
        {
            _inMemoryRepo = new InMemoryDeaCustRepository();
            //_deaCustController = new frmDeaCust(_inMemoryRepo);
        }

        // This function simply checks whether DataTable object is being returned.
        [Fact]
        public void Select_when_noParams_return_Datatable()
        {
            // Prepare
            DataTable expectedResult = new DataTable();
            // Act
            DataTable result = _inMemoryRepo.Select();
            // Assert
            Assert.Equal(expectedResult.Columns, result.Columns);
        }

        public partial class SqlCommand 
        {
            public void AddWithValue(string str, object o) { }
        }
        [Fact]
        public void Insert_when_connection_closed_return_false()
        {
            // Prepare
            // mock DB
            var connection = new Mock<IDbConnection>();
            connection.Setup(d => d.Open()).Verifiable();
            connection.Setup(d => d.State).Returns(ConnectionState.Closed);
            var db = new DeaCustDAL(connection.Object);

            var cmd = new Mock<SqlCommand>();
            cmd.Setup(d => d.Open()).Verifiable();
            cmd.Setup(d => d.State).Returns(ConnectionState.Closed);
            DeaCustBLL dc = new DeaCustBLL();

            // Act
            bool result = db.Insert(dc, cmd);

            // Assert
            Assert.Equal(false, result);
        }

        [Fact]
        public void Insert_when_connection_open_close_before_return()
        {
            // Prepare
            var connection = new Mock<IDbConnection>();
            connection.Setup(d => d.Open()).Verifiable();
            connection.Setup(d => d.State).Returns(ConnectionState.Open);
            var db = new DeaCustDAL(connection.Object);

            DeaCustBLL dc = new DeaCustBLL();

            // Act
            bool result = _inMemoryRepo.Insert(dc);

            // Assert
            Assert.Equal(true, result);
        }

        [Fact]
        public void Insert_when_NameEmptyString_return_false()
        {
            // Prepare
            bool expectedResult = false;

            DeaCustBLL dc = new DeaCustBLL();
            dc.type = "user";
            dc.name = "";
            dc.email = "user@email.com";
            dc.contact = "contact";
            dc.address = "address";
            dc.added_date = DateTime.Now;
            dc.added_by = 3;

            // Act
            bool result = _inMemoryRepo.Insert(dc);
            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Insert_when_emailIncorrectFormat_return_false()
        {
            // Prepare
            bool expectedResult = false;

            DeaCustBLL dc = new DeaCustBLL();
            dc.type = "user";
            dc.name = "user";
            dc.email = "user.email.com";
            dc.contact = "contact";
            dc.address = "address";
            dc.added_date = DateTime.Now;
            dc.added_by = 3;

            // Act
            bool result = _inMemoryRepo.Insert(dc);
            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Insert_when_correctParams_return_true()
        {
            // Prepare
            bool expectedResult = true;

            DeaCustBLL dc = new DeaCustBLL();
            dc.type = "user";
            dc.name = "user";
            dc.email = "user@email.com";
            dc.contact = "8972937278";
            dc.address = "address";
            dc.added_date = DateTime.Now;
            dc.added_by = 3;

            // Act
            bool result = _inMemoryRepo.Insert(dc);
            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void IntegrationTests_Insert_correctParams_return_true()
        {
            // Prepare
            bool expectedResult = true;

            IDeaCustRepository repo = new DeaCustDAL();

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
            Assert.Equal(expectedResult, result);
        }

        // Mato T parasyti testai:
        [Fact]
        public void Update_when_correctParams_return_true()
        {


            DeaCustBLL dc = new DeaCustBLL();
            dc.type = "user";
            dc.name = "user";
            dc.email = "user@email.com";
            dc.contact = "8972937278";
            dc.address = "address";
            dc.added_date = DateTime.Now;
            dc.added_by = 3;

            // Act
            bool result = _inMemoryRepo.Insert(dc);
            // Assert
           // Assert.Equal(expectedResult, result);
        }















        //////////
        /// DON'T REMOVE WHAT'S BELOW
        /// /////
        /// Pravers atsiskaitinejant man - J.G.



        //// naming convention: nameOfMethod_passedParameter_returnedResult
        //[Fact]
        //public void Select_NoParameters_ReturnsAll()
        //{
        //    //Prepare
        //    DataTable fakeDt = new DataTable(); // cia sugrizt ji uzpildyt fake'iniais duomenim, kad atrodytu kaip originalas
        //    // we setup our fake (mock) repository to return empty new datatable

        //    _mockRepository.Setup(x => x.Select()).Returns(new DataTable());

        //    DeaCustDAL realRepository = new DeaCustDAL();



        //    // Act
        //    var result = realRepository.Select();



        //    // Assert
        //    Assert.Equal(fakeDt, result);
        //}

        //[Fact]
        //public void btnAddClick_when_EmptyString_return_Failure()
        //{
        //    //Prepare
        //    var mockComboBox = new Mock<ComboBox>();
        //    mockComboBox.Setup(x => ""); // Checking what happens if "type" isn't selected
        //    var mockName = new Mock<TextBox>();
        //    mockName.Setup(x => "user");
        //    var mockEmail = new Mock<TextBox>();
        //    mockEmail.Setup(x => "user@email.com");
        //    var mockContact = new Mock<TextBox>();
        //    mockContact.Setup(x => "contact");
        //    var mockAddress = new Mock<TextBox>();
        //    mockAddress.Setup(x => "address");

        //    var mockMessageBox = new Mock<MessageBox>();

        //    // Act
        //    frmDeaCust _deaCustController = new frmDeaCust(_inMemoryRepo, mockComboBox.Object, mockName.Object, mockEmail.Object, mockContact.Object, mockAddress.Object, mockMessageBox.Object);
        //    _deaCustController.btnAdd_Click(new Object(), new EventArgs());



        //    // Assert if success (messagebox value was shown once)
        //    //Assert.Equal(true, result);
        //    mockMessageBox.Verify(x => MessageBox.Show("Dealer or Customer Added Successfully"), Times.Once);
        //}
    }
}
*/