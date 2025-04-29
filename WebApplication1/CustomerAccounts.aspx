<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerAccounts.aspx.cs" Inherits="WebApplication1.CustomerAccounts" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Accounts and Subscribed Plans</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:Label ID="Message" runat="server" ForeColor="Red"></asp:Label>

           
            <asp:GridView ID="CustomerA" runat="server" AutoGenerateColumns="True" CssClass="table" Width="100%">
</asp:GridView>

        </div>
    </form>
</body>
</html>
