<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResolvedTickets.aspx.cs" Inherits="WebApplication1.ResolvedTickets" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resolved Tickets</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Resolved Tickets</h2>
            <asp:GridView ID="ResolvedTicketsGridView" runat="server" AutoGenerateColumns="True"></asp:GridView>
            <asp:Label ID="Message" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>

