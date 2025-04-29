<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePoints.aspx.cs" Inherits="WebApplication1.UpdatePoints" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Earned Points</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Update Earned Points</h2>
            <label for="MobileNumberInput">Enter Mobile Number:</label>
            <asp:TextBox ID="MobileNumberInput" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="SubmitButton" runat="server" Text="Update Points" OnClick="SubmitButton_Click" />
            <br />
            <asp:Label ID="ResultLabel" runat="server" ForeColor="Blue"></asp:Label>
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>

