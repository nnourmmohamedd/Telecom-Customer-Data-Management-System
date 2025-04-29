<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechnicalSupportTickets.aspx.cs" Inherits="WebApplication1.TechnicalSupportTickets" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Unresolved Technical Support Tickets</title>
    <style>
        .error {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Unresolved Technical Support Tickets</h1>
        <table>
            <tr>
                <td><label for="txtNationalID">National ID:</label></td>
                <td><asp:TextBox ID="txtNationalID" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnFetchTickets" runat="server" Text="Fetch Unresolved Ticket Count" OnClick="btnFetchTickets_Click" />
                </td>
            </tr>
        </table>
        <hr />
        <asp:Label ID="lblTicketCount" runat="server" Text="" CssClass="error"></asp:Label>
    </form>
</body>
</html>
