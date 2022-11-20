using AnyStore.BLL;
using AnyStore.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStore.UI
{
    public partial class frmDeaCust : Form
    {
        private IDeaCustRepository _deaCustRepository;
        private DeaCustBLL _dc;

        // Constructor used for production
        public frmDeaCust()
        {
            this._deaCustRepository = new DeaCustDAL(new ConcreteDependencyForTestPurposes());
            this._dc = new DeaCustBLL();

            InitializeComponent();
        }

        ////////////////////////////////
        // Constructors used for testing start
        ////////////////////////////////
        public frmDeaCust(IDeaCustRepository deaCustRepository)
        {
            this._deaCustRepository = deaCustRepository;
            this._dc = new DeaCustBLL();

            InitializeComponent();
        }

        //public frmDeaCust(IDeaCustRepository deaCustRepository, ComboBox mockComboBox, TextBox mockName, TextBox mockEmail, TextBox mockContact, TextBox mockAddress, MessageBox mockMessageBox)
        //{
        //    this._deaCustRepository = deaCustRepository;

        //    DeaCustBLL _dc = new DeaCustBLL();
        //    _dc.type = mockComboBox.Text;
        //    _dc.name = mockName.Text;
        //    _dc.email = mockEmail.Text;
        //    _dc.contact = mockContact.Text;
        //    _dc.address = mockAddress.Text;

        //    _messageBox = mockMessageBox;

        //    InitializeComponent();
        //}
        ////////////////////////////////
        // Constructors used for testing end
        ////////////////////////////////


        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            //Write the code to close this form
            this.Hide();
        }

        userDAL uDal = new userDAL();
        public void btnAdd_Click(object sender, EventArgs e)
        {
            _dc.type = cmbDeaCust.Text;
            _dc.name = txtName.Text;
            _dc.email = txtEmail.Text;
            _dc.contact = txtContact.Text;
            _dc.address = txtAddress.Text;
            _dc.added_date = DateTime.Now;
            //Getting the ID to Logged in user and passign its value in dealer or cutomer module
            string loggedUsr = frmLogin.loggedIn;
            userBLL usr = uDal.GetIDFromUsername(loggedUsr);
            _dc.added_by = usr.id;

            //Creating boolean variable to check whether the dealer or cutomer is added or not
            bool success = _deaCustRepository.Insert(_dc);

            if(success==true)
            {
                //Dealer or Cutomer inserted successfully 
                MessageBox.Show("Dealer or Customer Added Successfully");
                Clear();
                //Refresh Data Grid View
                DataTable dt = _deaCustRepository.Select();
                dgvDeaCust.DataSource = dt;

                return;
            }
            //failed to insert dealer or customer
        }
        public void Clear()
        {
            txtDeaCustID.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            txtSearch.Text = "";
        }

        private void frmDeaCust_Load(object sender, EventArgs e)
        {
            //Refresh Data Grid View
            DataTable dt = _deaCustRepository.Select();
            dgvDeaCust.DataSource = dt;
        }

        private void dgvDeaCust_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //int variable to get the identityof row clicked
            int rowIndex = e.RowIndex;

            txtDeaCustID.Text = dgvDeaCust.Rows[rowIndex].Cells[0].Value.ToString();
            cmbDeaCust.Text = dgvDeaCust.Rows[rowIndex].Cells[1].Value.ToString();
            txtName.Text = dgvDeaCust.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvDeaCust.Rows[rowIndex].Cells[3].Value.ToString();
            txtContact.Text = dgvDeaCust.Rows[rowIndex].Cells[4].Value.ToString();
            txtAddress.Text = dgvDeaCust.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get the values from Form
            _dc.id = int.Parse(txtDeaCustID.Text);
            _dc.type = cmbDeaCust.Text;
            _dc.name = txtName.Text;
            _dc.email = txtEmail.Text;
            _dc.contact = txtContact.Text;
            _dc.address = txtAddress.Text;
            _dc.added_date = DateTime.Now;
            //Getting the ID to Logged in user and passign its value in dealer or cutomer module
            string loggedUsr = frmLogin.loggedIn;
            userBLL usr = uDal.GetIDFromUsername(loggedUsr);
            _dc.added_by = usr.id;

            //create boolean variable to check whether the dealer or customer is updated or not
            bool success = _deaCustRepository.Update(_dc);
            
            if(success==true)
            {
                //Dealer and Customer update Successfully
                MessageBox.Show("Dealer or Customer updated Successfully");
                Clear();
                //Refresh the Data Grid View
                DataTable dt = _deaCustRepository.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                //Failed to udate Dealer or Customer
                MessageBox.Show("Failed to Udpate Dealer or Customer");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get the id of the user to be deleted from form
            _dc.id = int.Parse(txtDeaCustID.Text);

            //Create boolean variable to check wheteher the dealer or customer is deleted or not
            bool success = _deaCustRepository.Delete(_dc);

            if(success==true)
            {
                //Dealer or Customer Deleted Successfully
                MessageBox.Show("Dealer or Customer Deleted Successfully");
                Clear();
                //Refresh the Data Grid View
                DataTable dt = _deaCustRepository.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                //Dealer or Customer Failed to Delete
                MessageBox.Show("Failed to Delete Dealer or Customer");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the keyowrd from text box
            string keyword = txtSearch.Text;

            if(keyword!=null)
            {
                //Search the Dealer or Customer
                DataTable dt = _deaCustRepository.Search(keyword);
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                //Show all the Dealer or Customer
                DataTable dt = _deaCustRepository.Select();
                dgvDeaCust.DataSource = dt;
            }
        }
    }
}
