<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanCashback.aspx.cs" Inherits="WebApplication1.PlanCashback" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Plan Cashback</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Plan Cashback Details</h2>
            <label for="WalletIDInput">Enter Wallet ID:</label>
            <asp:TextBox ID="WalletIDInput" runat="server"></asp:TextBox>
            <br />
            <label for="PlanIDInput">Enter Plan ID:</label>
            <asp:TextBox ID="PlanIDInput" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="SubmitButton" runat="server" Text="Get Cashback" OnClick="SubmitButton_Click" />
            <br />
            <asp:Label ID="ResultLabel" runat="server" ForeColor="Blue"></asp:Label>
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
