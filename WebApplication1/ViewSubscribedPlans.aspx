<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSubscribedPlans.aspx.cs" Inherits="WebApplication1.ViewSubscribedPlans" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>View Subscribed Plans</title>
    <style>
        .error {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Subscribed Plans</h1>
        <table>
            <tr>
                <td><label for="txtMobileNo">Mobile Number:</label></td>
                <td><asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnFetchPlans" runat="server" Text="Fetch Subscribed Plans" OnClick="btnFetchPlans_Click" />
                </td>
            </tr>
        </table>
        <hr />
        <asp:GridView ID="gvSubscribedPlans" runat="server" AutoGenerateColumns="true" 
                      CssClass="table" HeaderStyle-BackColor="#4CAF50" HeaderStyle-ForeColor="White">
        </asp:GridView>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </form>
</body>
</html>
