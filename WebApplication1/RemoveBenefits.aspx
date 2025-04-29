<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoveBenefits.aspx.cs" Inherits="WebApplication1.RemoveBenefits" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Remove Benefits</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Remove Benefits</h2>

            <label for="txtAccountID">Enter Mobile Number:</label>
            <asp:TextBox ID="txtAccountID" runat="server"></asp:TextBox>
            <br />

            <label for="txtPlanID">Enter Plan ID:</label>
            <asp:TextBox ID="txtPlanID" runat="server"></asp:TextBox>
            <br />

            <asp:Button ID="btnRemoveBenefits" runat="server" Text="Remove Benefits" OnClick="btnRemoveBenefits_Click" />
            <br />

            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
