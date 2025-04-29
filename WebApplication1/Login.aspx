<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>
    <style>
        .error {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Login as Admin</h2>
        <div>
            <label for="UsernameInput">Username:</label>
            <asp:TextBox ID="UsernameInput" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="PasswordInput">Password:</label>
            <asp:TextBox ID="PasswordInput" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
        </div>
        <hr />
        <asp:Label ID="MessageLabel" runat="server" ForeColor="Red"></asp:Label>

        <div>
            <h3>Login as Customer</h3>
            <label for="txtMobileNo">Mobile Number:</label>
            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="11"></asp:TextBox>
        </div>
        <div>
            <label for="txtPassword">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnFetchPlans" runat="server" Text="Login" OnClick="btnFetchPlans_Click" />
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
    </form>
</body>
</html>
