<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AvgTransactionAmt.aspx.cs" Inherits="WebApplication1.AvgTransactionAmt" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Average Transaction Amount</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Average Transaction Amount</h2>
            <label for="WalletIDInput">Enter Wallet ID:</label>
            <asp:TextBox ID="WalletIDInput" runat="server"></asp:TextBox>
            <br />
            <label for="StartDateInput">Enter Start Date (YYYY-MM-DD):</label>
            <asp:TextBox ID="StartDateInput" runat="server"></asp:TextBox>
            <br />
            <label for="EndDateInput">Enter End Date (YYYY-MM-DD):</label>
            <asp:TextBox ID="EndDateInput" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="SubmitButton" runat="server" Text="Get Average Amount" OnClick="SubmitButton_Click" />
            <br />
            <asp:Label ID="ResultLabel" runat="server" ForeColor="Blue"></asp:Label>
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
