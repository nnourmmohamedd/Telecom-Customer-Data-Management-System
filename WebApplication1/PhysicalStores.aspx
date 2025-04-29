<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhysicalStores.aspx.cs" Inherits="WebApplication1.PhysicalStores" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Physical Store Vouchers</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Physical Store Vouchers</h2>
            <asp:GridView ID="PhysicalStoreVouchersGridView" runat="server" AutoGenerateColumns="True"></asp:GridView>
            <asp:Label ID="Message" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>

