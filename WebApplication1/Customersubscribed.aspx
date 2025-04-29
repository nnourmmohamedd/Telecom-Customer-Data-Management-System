<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customersubscribed.aspx.cs" Inherits="WebApplication1.Customersubscribed" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Plans</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Customer Plans by Date</h2>
            
            <label for="txtDate">Enter Date (YYYY-MM-DD):</label>
            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
            <br />

            <label for="txtPlanID">Enter Plan ID:</label>
            <asp:TextBox ID="txtPlanID" runat="server"></asp:TextBox>
            <br />

            <asp:Button ID="btnViewCustomers" runat="server" Text="View Customers" OnClick="btnViewCustomers_Click" />
            <br />

            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
            <br />

            <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="True"></asp:GridView>
        </div>
    </form>
</body>
</html>
