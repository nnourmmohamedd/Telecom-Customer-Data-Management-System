<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentTransactions.aspx.cs" Inherits="WebApplication1.PaymentsTransactions" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payments Transactions</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Payments Transactions</h2>
            <asp:GridView ID="PaymentsGridView" runat="server" AutoGenerateColumns="true"></asp:GridView>
            <asp:Label ID="Message" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>

