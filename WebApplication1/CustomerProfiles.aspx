<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerProfiles.aspx.cs" Inherits="WebApplication1.CustomerProfiles" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Profiles</title>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:Label ID="Message" runat="server" ForeColor="Red"></asp:Label>

       
       <asp:GridView ID="CustomerAccountsGridView" runat="server" AutoGenerateColumns="True">
</asp:GridView>

    </form>
</body>
</html>
