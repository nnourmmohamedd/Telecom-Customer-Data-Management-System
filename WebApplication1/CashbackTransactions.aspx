<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashbackTransactions.aspx.cs" Inherits="WebApplication1.CashbackTransactions" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Cashback Transactions</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Cashback Transactions for Wallet</h1>
        <table>
            <tr>
                <td><label for="txtNationalID">National ID:</label></td>
                <td><asp:TextBox ID="txtNationalID" runat="server" MaxLength="20"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnFetchTransactions" runat="server" Text="View Transactions" OnClick="btnFetchTransactions_Click" />
                </td>
            </tr>
        </table>
        <hr />
        <asp:GridView ID="GridViewTransactions" runat="server" AutoGenerateColumns="true" 
                      CssClass="table" HeaderStyle-BackColor="#4CAF50" HeaderStyle-ForeColor="White">
        </asp:GridView>
    </form>
</body>
</html>
