using AnyStore.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStore.DAL
{
    // We must abstract away all dependencies so we can test ONLY this class (purpose of unit test)
    // Then we can use dependency injection to mock all dependencies
    public interface IDependency
    {
        void MakeNewCommand(string query, IDbConnection dbConnection);

        void AddValues(DeaCustBLL dc);

        void AddDeleteValues(DeaCustBLL dc);

        int ExecuteCommand();

        void ShowMessage(string msg);
        DataTable FillTheTable();
    }

    public class ConcreteDependencyForTestPurposes : IDependency
    {
        SqlCommand cmd;
        public void MakeNewCommand(string query, IDbConnection dbConnection)
        {
            cmd = new SqlCommand(query, (SqlConnection)dbConnection);
        }

        public void AddValues(DeaCustBLL dc)
        {
            cmd.Parameters.AddWithValue("@type", dc.type);
            cmd.Parameters.AddWithValue("@name", dc.name);
            cmd.Parameters.AddWithValue("@email", dc.email);
            cmd.Parameters.AddWithValue("@contact", dc.contact);
            cmd.Parameters.AddWithValue("@address", dc.address);
            cmd.Parameters.AddWithValue("@added_date", dc.added_date);
            cmd.Parameters.AddWithValue("@added_by", dc.added_by);
        }

        public void AddDeleteValues(DeaCustBLL dc)
        {
            cmd.Parameters.AddWithValue("@id", dc.id);
        }

        public int ExecuteCommand()
        {
            return cmd.ExecuteNonQuery();
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }
        public DataTable FillTheTable()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
    }

    public class DeaCustDAL : IDeaCustRepository
    {
        public IDbConnection _dbConnection;
        public IDependency dep;
        public SqlCommand cmd;

        public DeaCustDAL(IDependency dep) {
            _dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString);
            this.dep = dep;
        }

        public DeaCustDAL(IDbConnection connection, IDependency dep)
        {
            this.dep = dep;
            _dbConnection = connection;
        }


        #region SELECT MEthod for Dealer and Customer
        public DataTable Select()
        {
            //DataTble to hold the value from database and return it
            DataTable dt = new DataTable();

            try
            {
                //Write SQL Query t Select all the DAta from dAtabase
                string sql = "SELECT * FROM tbl_dea_cust";

                //Creating SQL Command to execute Query
                SqlCommand cmd = new SqlCommand(sql, (SqlConnection)_dbConnection);

                //Creting SQL Data Adapter to Store Data From Database Temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
                //conn.Open();
                _dbConnection.Open();
                //Passign the value from SQL Data Adapter to DAta table
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //conn.Close();
                _dbConnection.Close();
            }

            return dt;
        }
        #endregion
        #region INSERT Method to Add details fo Dealer or Customer
        public bool Insert(DeaCustBLL dc)
        {
            bool isSuccess = false;

            try
            {
                //Write SQL Query to Insert Details of Dealer or Customer
                string sql = "INSERT INTO tbl_dea_cust (type, name, email, contact, address, added_date, added_by) VALUES (@type, @name, @email, @contact, @address, @added_date, @added_by)";

                //SQl Command to Pass the values to query and execute
                dep.MakeNewCommand(sql, _dbConnection);
                //Passing the calues using Parameters
                dep.AddValues(dc);

                //Open DAtabaseConnection
                _dbConnection.Open();

                //Int variable to check whether the query is executed successfully or not
                int rows = dep.ExecuteCommand();

                //If the query is executed successfully then the value of rows will be greater than 0 else it will be less than 0
                if(rows>0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                }
                else
                {
                    //Failed to Execute Query
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {
                dep.ShowMessage(ex.Message);
            }
            finally
            {
                _dbConnection.Close();
            }

            return isSuccess;
        }
        #endregion
        #region UPDATE method for Dealer and Customer Module
        public bool Update(DeaCustBLL dc)
        {
            bool isSuccess = false;

            try
            {
                //SQL Query to update data in database
                string sql = "UPDATE tbl_dea_cust SET type=@type, name=@name, email=@email, contact=@contact, address=@address, added_date=@added_date, added_by=@added_by WHERE id=@id";
                //Create SQL Command to pass the value in sql
                dep.MakeNewCommand(sql, _dbConnection);

                //Passing the values through parameters
                dep.AddValues(dc);

                //open the Database Connection
                _dbConnection.Open();

                //Int varialbe to check if the query executed successfully or not
                int rows = dep.ExecuteCommand();
                if(rows>0)
                {
                    //Query Executed Successfully 
                    isSuccess = true;
                }
                else
                {
                    //Failed to Execute Query
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {
                dep.ShowMessage(ex.Message);
            }
            finally
            {
                _dbConnection.Close();
            }

            return isSuccess;
        }
        #endregion
        #region DELETE Method for Dealer and Customer Module
        public bool Delete(DeaCustBLL dc)
        {
            bool isSuccess = false;

            try
            {
                //SQL Query to Delete Data from dAtabase
                string sql = "DELETE FROM tbl_dea_cust WHERE id=@id";

                //SQL command to pass the value
                dep.MakeNewCommand(sql, _dbConnection);
                //Passing the value
                dep.AddDeleteValues(dc);

                //Open DB Connection
                _dbConnection.Open();
                //integer variable
                var rows = dep.ExecuteCommand();
                if(rows>0)
                {
                    //Query Executed Successfully 
                    isSuccess = true;
                }
                else
                {
                    //Failed to Execute Query
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {
                dep.ShowMessage(ex.Message);
            }
            finally
            {
                _dbConnection.Close();
            }

            return isSuccess;
        }
        #endregion
        #region SEARCH METHOD for Dealer and Customer Module
        public DataTable Search(string keyword)
        {
            DataTable dt = null;

            try
            {
                //Write the Query to Search Dealer or Customer Based in id, type and name
                string sql = "SELECT * FROM tbl_dea_cust WHERE id LIKE '%"+keyword+"%' OR type LIKE '%"+keyword+"%' OR name LIKE '%"+keyword+"%'";
                
                //SQL command to pass the value
                dep.MakeNewCommand(sql, _dbConnection);
                
                //Open DB Connection
                _dbConnection.Open();
                var rows = dep.ExecuteCommand();

                dt = dep.FillTheTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _dbConnection.Close();
            }

            return dt;
           
        }
        #endregion
        #region METHOD TO SAERCH DEALER Or CUSTOMER FOR TRANSACTON MODULE
        public DeaCustBLL SearchDealerCustomerForTransaction(string keyword)
        {
            //Create an object for DeaCustBLL class
            DeaCustBLL dc = new DeaCustBLL();

            //Create a DAta Table to hold the value temporarily
            DataTable dt = new DataTable();

            try
            {
                //Open the DAtabase Connection
                _dbConnection.Open();
                //Write a SQL Query to Search Dealer or Customer Based on Keywords
                string sql = "SELECT name, email, contact, address from tbl_dea_cust WHERE id LIKE '%"+keyword+"%' OR name LIKE '%"+keyword+"%'";

                //Create a Sql Data Adapter to Execute the Query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, (SqlConnection)_dbConnection);
                //new SqlDataAdapter()


                //Transfer the data from SqlData Adapter to DAta Table
                adapter.Fill(dt);

                //If we have values on dt we need to save it in dealerCustomer BLL
                if(dt.Rows.Count>0)
                {
                    dc.name = dt.Rows[0]["name"].ToString();
                    dc.email = dt.Rows[0]["email"].ToString();
                    dc.contact = dt.Rows[0]["contact"].ToString();
                    dc.address = dt.Rows[0]["address"].ToString();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close Database connection
                _dbConnection.Close();
            }

            return dc;
        }
        #endregion
        #region METHOD TO GET ID OF THE DEALER OR CUSTOMER BASED ON NAME
        public DeaCustBLL GetDeaCustIDFromName(string Name)
        {
            //First Create an Object of DeaCust BLL and REturn it
            DeaCustBLL dc = new DeaCustBLL();

            //Data TAble to Holdthe data temporarily
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to Get id based on Name
                string sql = "SELECT id FROM tbl_dea_cust WHERE name='"+Name+"'";
                //Create the SQL Data Adapter to Execute the Query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, (SqlConnection)_dbConnection);

                _dbConnection.Open();

                //Passing the CAlue from Adapter to DAtatable
                adapter.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    //Pass the value from dt to DeaCustBLL dc
                    dc.id = int.Parse(dt.Rows[0]["id"].ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _dbConnection.Close();
            }

            return dc;
        }
        #endregion

    }
}
