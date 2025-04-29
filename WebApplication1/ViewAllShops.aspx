<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAllShops.aspx.cs" Inherits="WebApplication1.ViewAllShops" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>View All Shops</title>
    <style>
        .error {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Shop Details</h1>
        <asp:GridView ID="gvShops" runat="server" AutoGenerateColumns="true" 
                      CssClass="table" HeaderStyle-BackColor="#4CAF50" HeaderStyle-ForeColor="White">
        </asp:GridView>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </form>
</body>
</html>
