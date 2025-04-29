<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListSMSServices.aspx.cs" Inherits="WebApplication1.ListSMSServices" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List SMS Offers</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>List SMS Offers</h2>

            <!-- Account ID Input -->
            <label for="txtAccountID">Enter Account ID:</label>
            <asp:TextBox ID="txtAccountID" runat="server"></asp:TextBox>
            <br />

            <!-- Button to List SMS Offers -->
            <asp:Button ID="btnListSMSOffers" runat="server" Text="List SMS Offers" OnClick="btnListSMSOffers_Click" />
            <br />

            <!-- Label for Messages -->
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
            <br />

            <!-- GridView for Displaying SMS Offers -->
            <asp:GridView ID="gvSMSOffers" runat="server" AutoGenerateColumns="True"></asp:GridView>
        </div>
    </form>
</body>
</html>

