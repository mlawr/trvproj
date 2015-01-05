using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerMaintanance.BLL;
using CustomerMaintanance.Entities;

namespace CustomerMaintananceApplication.UI
{
    public partial class CustomerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerBL custBL = new CustomerBL();

            List<Customer> custList = custBL.GetCustomerList();
            customerGridView.DataSource = custList;
            customerGridView.DataBind();
        }
    }
}