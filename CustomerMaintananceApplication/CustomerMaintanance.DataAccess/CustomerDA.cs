using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using CustomerMaintanance.Entities;

namespace CustomerMaintanance.DataAccess
{
    public class CustomerDA
    {
        private static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["Customer_DB"].ConnectionString;
        }

        public static void InsertCustomer(Customer customer)
        {
            string connectionStr = GetConnectionString();
            using (SqlConnection sqlConnect = new SqlConnection(connectionStr))
            {
                sqlConnect.Open();

                SqlCommand sqlcmmd = new SqlCommand("InsertCustomer", sqlConnect);
                sqlcmmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pLastName = new SqlParameter("@lastName", SqlDbType.VarChar, 200);
                pLastName.Direction = ParameterDirection.Input;
                pLastName.Value = customer.Firstname;
                sqlcmmd.Parameters.Add(pLastName);

                SqlParameter pFirstName = new SqlParameter("@firstName", SqlDbType.VarChar, 200);
                pFirstName.Direction = ParameterDirection.Input;
                pFirstName.Value = customer.LastName;
                sqlcmmd.Parameters.Add(pFirstName);

                SqlParameter pDOB = new SqlParameter("@DOB",SqlDbType.Date);
                pDOB.Direction = ParameterDirection.Input;
                pDOB.Value = customer.DateofBirth;
                sqlcmmd.Parameters.Add(pDOB);

                SqlParameter pEmail = new SqlParameter("@email",SqlDbType.VarChar,150);
                pEmail.Direction= ParameterDirection.Input;
                pEmail.Value = customer.CustEmail;
                sqlcmmd.Parameters.Add(pEmail);

                SqlParameter pAddress = new SqlParameter("@address",SqlDbType.VarChar,200);
                pAddress.Direction = ParameterDirection.Input;
                pAddress.Value = customer.Address;
                sqlcmmd.Parameters.Add(pAddress);

                SqlParameter pCity = new SqlParameter("@city", SqlDbType.VarChar, 150);
                pCity.Direction = ParameterDirection.Input;
                pCity.Value = customer.City;
                sqlcmmd.Parameters.Add(pCity);

                SqlParameter pState = new SqlParameter("@state", SqlDbType.VarChar, 2);
                pState.Direction = ParameterDirection.Input;
                pState.Value = customer.Statecode;
                sqlcmmd.Parameters.Add(pState);

                SqlParameter pZipcode = new SqlParameter("@zipcode", SqlDbType.VarChar, 10);
                pZipcode.Direction = ParameterDirection.Input;
                pZipcode.Value = customer.Zipcode;
                sqlcmmd.Parameters.Add(pZipcode);

                SqlParameter pCustomerid = new SqlParameter("@customerID", SqlDbType.Int);
                pCustomerid.Direction = ParameterDirection.Output;
                sqlcmmd.Parameters.Add(pCustomerid);

                SqlParameter returnval = new SqlParameter();
                returnval.Direction = ParameterDirection.ReturnValue;
                returnval.DbType = DbType.Int32;

                sqlcmmd.ExecuteNonQuery(); 

            }


        }
        public static void UpdateCustomer(Customer customer)
        {
            string connectionStr = GetConnectionString();
            using (SqlConnection sqlConnect = new SqlConnection(connectionStr))
            {
                sqlConnect.Open();

                SqlCommand sqlcmmd = new SqlCommand("UpdateCustomer", sqlConnect);
                sqlcmmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pLastName = new SqlParameter("@lastName", SqlDbType.VarChar, 200);
                pLastName.Direction = ParameterDirection.Input;
                pLastName.Value = customer.Firstname;
                sqlcmmd.Parameters.Add(pLastName);

                SqlParameter pFirstName = new SqlParameter("@firstName", SqlDbType.VarChar, 200);
                pFirstName.Direction = ParameterDirection.Input;
                pFirstName.Value = customer.LastName;
                sqlcmmd.Parameters.Add(pFirstName);

                SqlParameter pDOB = new SqlParameter("@DOB", SqlDbType.Date);
                pDOB.Direction = ParameterDirection.Input;
                pDOB.Value = customer.DateofBirth;
                sqlcmmd.Parameters.Add(pDOB);

                SqlParameter pEmail = new SqlParameter("@email", SqlDbType.VarChar, 150);
                pEmail.Direction = ParameterDirection.Input;
                pEmail.Value = customer.CustEmail;
                sqlcmmd.Parameters.Add(pEmail);

                SqlParameter pAddress = new SqlParameter("@address", SqlDbType.VarChar, 200);
                pAddress.Direction = ParameterDirection.Input;
                pAddress.Value = customer.Address;
                sqlcmmd.Parameters.Add(pAddress);

                SqlParameter pCity = new SqlParameter("@city", SqlDbType.VarChar, 150);
                pCity.Direction = ParameterDirection.Input;
                pCity.Value = customer.City;
                sqlcmmd.Parameters.Add(pCity);

                SqlParameter pState = new SqlParameter("@state", SqlDbType.VarChar, 2);
                pState.Direction = ParameterDirection.Input;
                pState.Value = customer.Statecode;
                sqlcmmd.Parameters.Add(pState);

                SqlParameter pZipcode = new SqlParameter("@zipcode", SqlDbType.VarChar, 10);
                pZipcode.Direction = ParameterDirection.Input;
                pZipcode.Value = customer.Zipcode;
                sqlcmmd.Parameters.Add(pZipcode);

                SqlParameter pCustomerid = new SqlParameter("@customerID", SqlDbType.Int);
                pCustomerid.Direction = ParameterDirection.Input;
                pCustomerid.Value = customer.Customerid;
                sqlcmmd.Parameters.Add(pCustomerid);

                SqlParameter returnval = new SqlParameter();
                returnval.Direction = ParameterDirection.ReturnValue;
                returnval.DbType = DbType.Int32;

                sqlcmmd.ExecuteNonQuery();

            }


        }

        public static List<USState> GetStateList()
        {
            string sqlconnect = GetConnectionString();
            List<USState> statelistobj = new List<USState>(); 
            using (SqlConnection sqlcnnt = new SqlConnection(sqlconnect))
            {
                sqlcnnt.Open();

                SqlCommand sqlcmd = new SqlCommand("GetStateList", sqlcnnt);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dtaReader = sqlcmd.ExecuteReader();

                while (dtaReader.Read())
                {
                    if (!dtaReader.IsDBNull(0) && !dtaReader.IsDBNull(1))
                    {
                        USState usState = new USState();
                        usState.Statecode = dtaReader[0].ToString();
                        usState.Statename = dtaReader[1].ToString();
                        statelistobj.Add(usState);
                    }
                }
                dtaReader.Close();
            }
            
            return statelistobj; 


        }
        public static List<Customer> GetCustomerList()
        {
            List<Customer> customerListobj = new List<Customer>();
            string sqlconnection = GetConnectionString();
            using (SqlConnection sqlcnnect = new SqlConnection(sqlconnection))
            {
                sqlcnnect.Open();

                SqlCommand sqlcommand = new SqlCommand("GetCustomerList", sqlcnnect);
                sqlcommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    Customer customer = new Customer();
                    customer.Customerid = Convert.ToInt16(sqldatareader[0]);
                    if (sqldatareader["FirstName"] != DBNull.Value) customer.Firstname = sqldatareader["FirstName"].ToString();
                    if (sqldatareader["LastName"] != DBNull.Value) customer.LastName = sqldatareader["LastName"].ToString();
                    if (sqldatareader["StateName"] != DBNull.Value) customer.StateName = sqldatareader["StateName"].ToString();
                    if (sqldatareader["City"] != DBNull.Value) customer.City = sqldatareader["City"].ToString();

                    customerListobj.Add(customer);
                }
            }
            return customerListobj;
        }

        public static Customer GetCustomer(int customerID)
        {
            Customer customerobj = new Customer();
            string sqlconnection = GetConnectionString();
            using (SqlConnection sqlcnnect = new SqlConnection(sqlconnection))
            {
                sqlcnnect.Open();

                SqlCommand sqlcommand = new SqlCommand("GetCustomer", sqlcnnect);
                sqlcommand.CommandType = CommandType.StoredProcedure;

                SqlParameter pCustomerID = new SqlParameter("@CustomerID", SqlDbType.Int);
                pCustomerID.Direction = ParameterDirection.Input;
                pCustomerID.Value = customerID;
                sqlcommand.Parameters.Add(pCustomerID);

                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    customerobj.Customerid = Convert.ToInt16(sqldatareader["CustomerID"]);
                    if (sqldatareader["FirstName"] != DBNull.Value) customerobj.Firstname = sqldatareader["FirstName"].ToString();
                    if (sqldatareader["LastName"] != DBNull.Value) customerobj.LastName = sqldatareader["LastName"].ToString();
                    if (sqldatareader["StateCode"] != DBNull.Value) customerobj.Statecode = sqldatareader["StateCode"].ToString();
                    if (sqldatareader["City"] != DBNull.Value) customerobj.City = sqldatareader["City"].ToString();
                    if (sqldatareader["DateOfBirth"] != DBNull.Value) customerobj.DateofBirth = (DateTime)sqldatareader["DateOfBirth"];
                    if (sqldatareader["Email"] != DBNull.Value) customerobj.CustEmail = sqldatareader["Email"].ToString();
                    if (sqldatareader["StreetAddress"] != DBNull.Value) customerobj.Address = sqldatareader["StreetAddress"].ToString();
                    if (sqldatareader["ZipCode"] != DBNull.Value) customerobj.Zipcode = sqldatareader["ZipCode"].ToString();

                }
            }
            return customerobj;
        }
    }
 
}