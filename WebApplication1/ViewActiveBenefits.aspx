<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewActiveBenefits.aspx.cs" Inherits="WebApplication1.ViewActiveBenefits" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>View Active Benefits</title>
    <style>
        .error {
            color: red;
            font-weight: bold;
        }
        .info {
            color: green;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Active Benefits</h1>
        <asp:Button ID="btnViewBenefits" runat="server" Text="View Active Benefits" OnClick="btnViewBenefits_Click" />
        <hr />
        <asp:GridView ID="GridViewBenefits" runat="server" AutoGenerateColumns="true" 
                      CssClass="table" HeaderStyle-BackColor="#4CAF50" HeaderStyle-ForeColor="White">
        </asp:GridView>
        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
        <asp:Label ID="lblNoResultsMessage" runat="server" CssClass="info"></asp:Label>
    </form>
</body>
</html>
