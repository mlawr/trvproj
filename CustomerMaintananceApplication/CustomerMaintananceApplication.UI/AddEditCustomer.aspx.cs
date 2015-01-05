using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerMaintanance.Entities;
using CustomerMaintanance.BLL;

namespace CustomerMaintananceApplication.UI
{
    public partial class AddEditCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDowns();
                string custID = Request.QueryString["Id"];
                if (!string.IsNullOrWhiteSpace(custID))
                {
                    BindCustomer(custID);
                }
            }
        }

        private void BindCustomer(string custID)
        {
            int customerID = 0;
            Int32.TryParse(custID, out customerID);
            if (customerID > 0)
            {
                CustomerBL custBL = new CustomerBL();
                Customer custObj = custBL.GetCustomer(customerID);

                firstnmeTextBox.Text = custObj.Firstname;
                lastnameTextBox.Text = custObj.LastName;
                DOBtxtBox.Text = custObj.DateofBirth.ToShortDateString();
                if (custObj.CustEmail != null) emailTextBox.Text = custObj.CustEmail;
                if (custObj.Address != null) addressTextbox.Text = custObj.Address;
                if (custObj.City != null) cityTextBox.Text = custObj.City;
                if (custObj.Statecode != null) stateDropDownList.SelectedValue = custObj.Statecode;
                if (custObj.Zipcode != null) zipcodeTxtbox.Text = custObj.Zipcode;

                customerIdHidden.Value = custObj.Customerid.ToString();
            }
        }

        private void BindDropDowns()
        {
            CustomerBL custBL = new CustomerBL();
            List<USState> stateList = custBL.GetStateList();
            stateDropDownList.DataSource = stateList;
            stateDropDownList.DataTextField = "Statename";
            stateDropDownList.DataValueField = "Statecode";
            stateDropDownList.DataBind();
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Firstname = firstnmeTextBox.Text;
            customer.LastName = lastnameTextBox.Text;
            string dob = DOBtxtBox.Text;
            DateTime DOB;
            if(DateTime.TryParse(dob,out DOB))
            {
                customer.DateofBirth = DOB; 
            }

            customer.CustEmail = emailTextBox.Text;
            customer.Address = addressTextbox.Text;
            customer.City = cityTextBox.Text;
            customer.Statecode = stateDropDownList.SelectedItem.Value;
            customer.Zipcode = zipcodeTxtbox.Text;
            if (customerIdHidden.Value.Length > 0)
            {
                customer.Customerid = Convert.ToInt32(customerIdHidden.Value);
            }
            try
            {
                CustomerBL customrBL = new CustomerBL();
                customrBL.SaveCustomer(customer);

                messageLabel.Text = "Successfully Saved.";
                messageLabel.CssClass = "successmessage";
            }
            catch (BusinessLogicException bex)
            {
                messageLabel.Text = bex.Message;
                messageLabel.CssClass = "errormessage";
            }
            catch (Exception ex)
            {
                messageLabel.Text = "System Error.";
                messageLabel.CssClass = "errormessage";
            }
        }
    }
}