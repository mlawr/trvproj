using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerMaintanance.Entities
{
    public class Customer
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public int Customerid { get; set; }
        public DateTime DateofBirth { get; set; }
        public string CustEmail { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Statecode { get; set; }
        public string StateName { get; set; }
        public string Zipcode { get; set; }

    }
}