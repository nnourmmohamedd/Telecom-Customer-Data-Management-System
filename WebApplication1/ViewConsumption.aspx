<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewConsumption.aspx.cs" Inherits="WebApplication1.ViewConsumption" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>View Consumption</title>
    <style>
        .error {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>View Consumption</h1>
        <table>
            <tr>
                <td><label for="txtPlanName">Plan Name:</label></td>
                <td><asp:TextBox ID="txtPlanName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="txtStartDate">Start Date:</label></td>
                <td><asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="txtEndDate">End Date:</label></td>
                <td><asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnViewConsumption" runat="server" Text="View Consumption" OnClick="btnViewConsumption_Click" />
                </td>
            </tr>
        </table>
        <hr />
        <asp:GridView ID="GridViewConsumption" runat="server" AutoGenerateColumns="true" 
                      CssClass="table" HeaderStyle-BackColor="#4CAF50" HeaderStyle-ForeColor="White">
        </asp:GridView>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </form>
</body>
</html>
