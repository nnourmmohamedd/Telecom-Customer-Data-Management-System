<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerNamesWallets.aspx.cs" Inherits="WebApplication1.CustomerNamesWallets" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Wallet Details</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Customer Names with their Wallet Details</h2>
            <asp:GridView ID="CustomerWalletGridView" runat="server" AutoGenerateColumns="true"></asp:GridView>
            <asp:Label ID="Message" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
