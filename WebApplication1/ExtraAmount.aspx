<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExtraAmount.aspx.cs" Inherits="WebApplication1.ExtraAmount" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Extra Amount for Last Payment</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Extra Amount for Last Payment</h1>
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
                    <asp:Button ID="btnFetchExtraAmount" runat="server" Text="Fetch Extra Amount" OnClick="btnFetchExtraAmount_Click" />
                </td>
            </tr>
        </table>
        <hr />
        <asp:Label ID="lblExtraAmount" runat="server" Text="" Font-Bold="True" Font-Size="Large"></asp:Label>
    </form>
</body>
</html>
