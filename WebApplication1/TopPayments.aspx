<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopPayments.aspx.cs" Inherits="WebApplication1.TopPayments" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Top Successful Payments</title>
    <style>
        .error {
            color: red;
            font-weight: bold;
        }
        .info {
            color: green;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Top Successful Payments</h1>
        <table>
            <tr>
                <td><label for="txtMobileNumber">Mobile Number:</label></td>
                <td><asp:TextBox ID="txtMobileNumber" runat="server" MaxLength="11"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnFetchPayments" runat="server" Text="Fetch Top Payments" OnClick="btnFetchPayments_Click" />
                </td>
            </tr>
        </table>
        <hr />
        <asp:GridView ID="GridViewTopPayments" runat="server" AutoGenerateColumns="true" 
                      CssClass="table" HeaderStyle-BackColor="#4CAF50" HeaderStyle-ForeColor="White">
        </asp:GridView>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
        <asp:Label ID="lblNoResultsMessage" runat="server" CssClass="info"></asp:Label>
    </form>
</body>
</html>
