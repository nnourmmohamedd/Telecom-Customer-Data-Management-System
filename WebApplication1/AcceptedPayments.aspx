<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcceptedPayments.aspx.cs" Inherits="WebApplication1.AcceptedPayments" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Accepted Payments</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Accepted Payments</h2>
            
            <label for="AccountIDInput">Enter Mobile Number:</label>
            <asp:TextBox ID="AccountIDInput" runat="server" CssClass="input"></asp:TextBox>
            <br />

            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
            <br />

            <asp:Label ID="Message" runat="server" ForeColor="Red"></asp:Label>
            <br />

            <asp:GridView ID="AcceptedPaymentsGridView" runat="server" AutoGenerateColumns="True" CssClass="table"></asp:GridView>
        </div>
    </form>
</body>
</html>
