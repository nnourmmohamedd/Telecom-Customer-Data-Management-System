<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetCashback.aspx.cs" Inherits="WebApplication1.GetCashback" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Get Cashback</title>
    <style>
        .error {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Get Cashback Amount</h1>
        <table>
            <tr>
                <td><label for="txtMobileNumber">Mobile Number:</label></td>
                <td><asp:TextBox ID="txtMobileNumber" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="txtPaymentID">Payment ID:</label></td>
                <td><asp:TextBox ID="txtPaymentID" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="txtBenefitID">Benefit ID:</label></td>
                <td><asp:TextBox ID="txtBenefitID" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnGetCashback" runat="server" Text="Get Cashback Amount" OnClick="btnGetCashback_Click" />
                </td>
            </tr>
        </table>
        <hr />
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="error"></asp:Label>
    </form>
</body>
</html>
