<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TotalUsage.aspx.cs" Inherits="WebApplication1.TotalUsage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Total Usage by Account</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Total Usage by Account</h2>

            <label for="txtAccountID">Enter Account ID:</label>
            <asp:TextBox ID="txtAccountID" runat="server"></asp:TextBox>
            <br />

            <label for="txtDate">Enter Date (YYYY-MM-DD):</label>
            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
            <br />

            <asp:Button ID="btnViewUsage" runat="server" Text="View Usage" OnClick="btnViewUsage_Click" />
            <br />

            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
            <br />

            <asp:GridView ID="gvUsage" runat="server" AutoGenerateColumns="True"></asp:GridView>
        </div>
    </form>
</body>
</html>

