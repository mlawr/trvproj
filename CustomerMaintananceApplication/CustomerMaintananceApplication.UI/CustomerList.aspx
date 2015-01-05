<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="CustomerMaintananceApplication.UI.CustomerList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="stylesheets/Site.css"/>
</head>
<body>

    <form id="form1" runat="server">
        <div id="page">
            <h2>Customer List </h2>
            <asp:GridView ID="customerGridView" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found" Width="500px">
                <Columns>
                    <asp:HyperLinkField HeaderText="Last Name" SortExpression="LastName"  ItemStyle-Width="25%" DataTextField="LastName" DataNavigateUrlFields="Customerid" DataNavigateUrlFormatString="~/AddEditCustomer.aspx?Id={0}">
                       
                        <ItemStyle Width="25%"></ItemStyle>
                    </asp:HyperLinkField>
                    <asp:BoundField HeaderText="First Name" SortExpression="FirstName" DataField="FirstName" ItemStyle-Width="25%">
                        <ItemStyle Width="25%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="State" SortExpression="StateName" DataField="StateName" ItemStyle-Width="25%">
                        <ItemStyle Width="25%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="City" SortExpression="City" DataField="City" ItemStyle-Width="25%">
                        <ItemStyle Width="25%"></ItemStyle>
                    </asp:BoundField>
                    
                </Columns>
            </asp:GridView>

            <asp:HyperLink ID="addHyperLink" runat="server" NavigateUrl="~/AddEditCustomer.aspx">Add</asp:HyperLink>
        </div>

    </form>

</body>
</html>
