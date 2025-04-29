<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivePlanUsage.aspx.cs" Inherits="WebApplication1.ActivePlanUsage" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Active Plan Usage</title>
    <style>
        .error {
            color: red;
            font-weight: bold;
        }
        .info {
            color: green;
            font-weight: bold;
        }
        .table {
            width: 100%;
            border-collapse: collapse;
        }
        .table, .table th, .table td {
            border: 1px solid black;
        }
        .table th, .table td {
            padding: 8px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>View Active Plan Usage for Current Month</h1>

        <div>
            <label for="txtMobileNumber">Mobile Number:</label>
            <asp:TextBox ID="txtMobileNumber" runat="server" MaxLength="11"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="btnFetchUsage" runat="server" Text="View Usage" OnClick="btnFetchUsage_Click" />
        </div>

        <hr />

        <asp:GridView ID="GridViewUsage" runat="server" AutoGenerateColumns="true" 
                      CssClass="table" HeaderStyle-BackColor="#4CAF50" HeaderStyle-ForeColor="White">
        </asp:GridView>

        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </form>
</body>
</html>
