<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RedeemVoucher.aspx.cs" Inherits="WebApplication1.RedeemVoucher" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Redeem Voucher</title>
    <style>
        .error {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Redeem Voucher</h1>
        <table>
            <tr>
                <td><label for="txtMobileNumber">Mobile Number:</label></td>
                <td><asp:TextBox ID="txtMobileNumber" runat="server" MaxLength="11"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="txtVoucherID">Voucher ID:</label></td>
                <td><asp:TextBox ID="txtVoucherID" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnRedeemVoucher" runat="server" Text="Redeem Voucher" OnClick="btnRedeemVoucher_Click" />
                </td>
            </tr>
        </table>
        <hr />
        <asp:Label ID="lblResult" runat="server" Text="" CssClass="error"></asp:Label>
    </form>
</body>
</html>
