<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnsubscribedPlans.aspx.cs" Inherits="WebApplication1.UnsubscribedPlans" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Unsubscribed Plans</title>
    <style>
        .error {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Unsubscribed Plans</h1>
        <table>
            <tr>
                <td><label for="txtMobileNumber">Mobile Number:</label></td>
                <td><asp:TextBox ID="txtMobileNumber" runat="server" MaxLength="11"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnFetchPlans" runat="server" Text="Fetch Unsubscribed Plans" OnClick="btnFetchPlans_Click" />
                </td>
            </tr>
        </table>
        <hr />
        <asp:GridView ID="GridViewUnsubscribedPlans" runat="server" AutoGenerateColumns="true" 
                      CssClass="table" HeaderStyle-BackColor="#4CAF50" HeaderStyle-ForeColor="White">
        </asp:GridView>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </form>
</body>
</html>
