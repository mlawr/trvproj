using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using CustomerMaintanance.DataAccess;
using CustomerMaintanance.Entities;


namespace CustomerMaintanance.BLL
{
    public class CustomerBL
    {
        public void SaveCustomer(Customer cust)
        {

            List<String> errormesages = new List<string>();
            if (String.IsNullOrWhiteSpace(cust.Firstname))
            {
                errormesages.Add("First Name is required");

            }
            if (String.IsNullOrWhiteSpace(cust.LastName))
            {
                errormesages.Add("Last Name is required");
            }
            if (cust.DateofBirth == DateTime.MinValue)
            {
                errormesages.Add("Date of Birth is required");
            }

            if (errormesages.Count > 0)
            {
                string errorMsg = string.Join(". ", errormesages);
                BusinessLogicException blex = new BusinessLogicException(errorMsg);
                throw blex;
            }
            else
            {
                // Use tineout of 45 seconds.
                TransactionOptions tranOpts = new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                    Timeout = new TimeSpan(0, 0, 45)  
                };
                using (TransactionScope tranScope = new TransactionScope(TransactionScopeOption.Required, tranOpts))
                {
                    if (cust.Customerid > 0)
                    {
                        CustomerDA.UpdateCustomer(cust);
                    }
                    else
                    {
                        CustomerDA.InsertCustomer(cust);
                    }
                    tranScope.Complete();
                }
            }
        }

        public List<USState> GetStateList()
        {
            List<USState> StateList;
            StateList = CustomerDA.GetStateList();
            return StateList;
        }

        public List<Customer> GetCustomerList()
        {
            List<Customer> custList = CustomerDA.GetCustomerList();
            return custList;
        }
        public Customer GetCustomer(int customerID)
        {
            Customer customer = CustomerDA.GetCustomer(customerID);
            return customer;
        }

    }
}

    