<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RenewSubscription.aspx.cs" Inherits="WebApplication1.RenewSubscription" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Renew Subscription</title>
    <style>
        .error {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Renew Subscription</h1>
        <table>
            <tr>
                <td><label for="txtMobileNumber">Mobile Number:</label></td>
                <td><asp:TextBox ID="txtMobileNumber" runat="server" MaxLength="11"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="txtPlanID">Plan ID:</label></td>
                <td><asp:TextBox ID="txtPlanID" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="txtAmount">Amount:</label></td>
                <td><asp:TextBox ID="txtAmount" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="txtPaymentMethod">Payment Method:</label></td>
                <td><asp:TextBox ID="txtPaymentMethod" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnRenewSubscription" runat="server" Text="Renew Subscription" OnClick="btnRenewSubscription_Click" />
                </td>
            </tr>
        </table>
        <hr />
        <asp:Label ID="lblResult" runat="server" Text="" CssClass="error"></asp:Label>
    </form>
</body>
</html>
