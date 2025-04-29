<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NumCashback.aspx.cs" Inherits="WebApplication1.NumCashback" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cashback Transactions</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Cashback Transactions Per Wallet</h2>
            <asp:GridView ID="CashbackGridView" runat="server" AutoGenerateColumns="true"></asp:GridView>
            <asp:Label ID="Message" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>

