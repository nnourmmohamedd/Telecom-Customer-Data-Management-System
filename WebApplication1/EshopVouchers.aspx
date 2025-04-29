<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EshopVouchers.aspx.cs" Inherits="WebApplication1.EshopVouchers" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Voucher Data</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>E-Shop Voucher Data</h2>
            <asp:GridView ID="EShopVoucherGridView" runat="server" AutoGenerateColumns="true"></asp:GridView>
            <asp:Label ID="Message" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>

