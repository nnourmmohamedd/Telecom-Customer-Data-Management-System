<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewServicePlans.aspx.cs" Inherits="WebApplication1.ViewServicePlans" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>View Service Plans</title>
    <style>
        .error {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Service Plans</h1>
        <asp:GridView ID="GridViewServicePlans" runat="server" AutoGenerateColumns="true" 
                      CssClass="table" HeaderStyle-BackColor="#4CAF50" HeaderStyle-ForeColor="White">
        </asp:GridView>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </form>
</body>
</html>
