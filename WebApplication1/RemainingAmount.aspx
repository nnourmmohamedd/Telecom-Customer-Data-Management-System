<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemainingAmount.aspx.cs" Inherits="WebApplication1.RemainingAmount" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Remaining Amount for Last Payment</title>
    <style>
        .error {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Remaining Amount for Last Payment</h1>
        <table>
            <tr>
                <td><label for="txtMobileNumber">Mobile Number:</label></td>
                <td><asp:TextBox ID="txtMobileNumber" runat="server" MaxLength="11"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="txtPlanName">Plan Name:</label></td>
                <td><asp:TextBox ID="txtPlanName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnFetchAmount" runat="server" Text="Fetch Remaining Amount" OnClick="btnFetchAmount_Click" />
                </td>
            </tr>
        </table>
        <hr />
        <asp:Label ID="lblRemainingAmount" runat="server" Text="" CssClass="error"></asp:Label>
    </form>
</body>
</html>
