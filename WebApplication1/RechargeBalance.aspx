<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RechargeBalance.aspx.cs" Inherits="WebApplication1.RechargeBalance" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Recharge Balance</title>
    <style>
        .error {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Recharge Account Balance</h1>
        <table>
            <tr>
                <td><label for="txtMobileNumber">Mobile Number:</label></td>
                <td><asp:TextBox ID="txtMobileNumber" runat="server" MaxLength="11"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="txtAmount">Amount to Recharge:</label></td>
                <td><asp:TextBox ID="txtAmount" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="txtPaymentMethod">Payment Method:</label></td>
                <td><asp:TextBox ID="txtPaymentMethod" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnRechargeBalance" runat="server" Text="Recharge Balance" OnClick="btnRechargeBalance_Click" />
                </td>
            </tr>
        </table>
        <hr />
        <asp:Label ID="lblResult" runat="server" Text="" CssClass="error"></asp:Label>
    </form>
</body>
</html>
