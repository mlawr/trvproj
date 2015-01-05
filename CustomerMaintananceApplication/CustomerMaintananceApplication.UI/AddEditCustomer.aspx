<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditCustomer.aspx.cs" Inherits="CustomerMaintananceApplication.UI.AddEditCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="stylesheets/Site.css"/>
    <style type="text/css">
        .auto-style1
        {
            height: 26px;
        }
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <asp:HiddenField ID="customerIdHidden" runat="server" />
    <div id="page">
        <table>
            <tr>
               <td colspan="2" >
                   <h2>Customer Maintanance Application</h2>
               </td>

            </tr>
            <tr>
               <td colspan="2" >
                   <asp:Label ID="messageLabel" runat= "server" Text=""></asp:Label>
               </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="firstnmeLabel" runat="server" Text="First Name"></asp:Label><span class="errormessage">*</span></td>
                <td>
                    <asp:TextBox ID="firstnmeTextBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server" ErrorMessage="First Name Is Required." ControlToValidate="firstnmeTextBox"  CssClass="errormessage"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lastnmeLabel" runat="server" Text ="Last Name"></asp:Label><span class="errormessage">*</span>
                </td>
                <td>
                    <asp:TextBox ID="lastnameTextBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server" ErrorMessage="Last Name Is Required." ControlToValidate="lastnameTextBox" CssClass="errormessage"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="DOBlbl" runat ="server" Text ="Date Of Birth"></asp:Label><span class="errormessage">*</span>
                </td>
                <td>
                    <asp:TextBox ID="DOBtxtBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDOB" runat="server" ErrorMessage="Date of Birth Is Required." ControlToValidate="DOBtxtBox"  CssClass="errormessage"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID ="emailLbl" runat="server" Text="Email"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="addressLbl" runat="server" Text="Address"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="addressTextbox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="citylbl" runat="server" Text="City"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="cityTextBox" runat ="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="statelbl" runat="server" Text="State"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="stateDropDownList" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="zipcodelbl" runat="server" Text="Zip Code"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID= "zipcodeTxtbox" runat= "server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td colspan="2">
                    <asp:Button ID ="addButton" runat="server" Text ="Save" OnClick="addButton_Click" Width="40%"  />
                </td>
                
            </tr>
        </table>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CustomerList.aspx">Back to Customer List</asp:HyperLink>
    </div>
    </form>

</body>
</html>
