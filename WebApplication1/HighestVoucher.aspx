<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HighestVoucher.aspx.cs" Inherits="WebApplication1.HighestVoucher" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Highest Voucher</title>
    <style>
        .error {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Highest Value Voucher</h1>
        <table>
            <tr>
                <td><label for="txtMobileNumber">Mobile Number:</label></td>
                <td><asp:TextBox ID="txtMobileNumber" runat="server" MaxLength="11"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnFetchVoucher" runat="server" Text="Fetch Highest Voucher" OnClick="btnFetchVoucher_Click" />
                </td>
            </tr>
        </table>
        <hr />
        <asp:Label ID="lblVoucher" runat="server" Text="" CssClass="error"></asp:Label>
    </form>
</body>
</html>
