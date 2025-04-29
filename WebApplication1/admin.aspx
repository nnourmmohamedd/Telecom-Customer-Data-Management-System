<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="WebApplication1.admin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signed in: as Admin</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Admin Dashboard</h1>
            <asp:Panel ID="MenuPanel" runat="server">
                <asp:Button ID="CustomerProfilesButton" runat="server" Text="CustomerProfiles" OnClick="NavigateToPage" CommandArgument="CustomerProfiles.aspx" />
                <asp:Button ID="PhysicalStoresButton" runat="server" Text="PhysicalStores" OnClick="NavigateToPage" CommandArgument="PhysicalStores.aspx" />
                <asp:Button ID="ResolvedTicketsButton" runat="server" Text="ResolvedTickets" OnClick="NavigateToPage" CommandArgument="ResolvedTickets.aspx" />
                <asp:Button ID="CustomerAccountsButton" runat="server" Text="CustomerAccounts" OnClick="NavigateToPage" CommandArgument="CustomerAccounts.aspx" />
                <asp:Button ID="CustomersubscribedButton" runat="server" Text="Customersubscribed" OnClick="NavigateToPage" CommandArgument="Customersubscribed.aspx" />
                <asp:Button ID="TotalUsageButton" runat="server" Text="TotalUsage" OnClick="NavigateToPage" CommandArgument="TotalUsage.aspx" />
                <asp:Button ID="RemoveBenefitsButton" runat="server" Text="RemoveBenefits" OnClick="NavigateToPage" CommandArgument="RemoveBenefits.aspx" />
                <asp:Button ID="ListSMSservicesButton" runat="server" Text="ListSMSservices" OnClick="NavigateToPage" CommandArgument="ListSMSservices.aspx" />
                <asp:Button ID="CustomerNAmesWalletsButton" runat="server" Text="CustomerNAmesWallets" OnClick="NavigateToPage" CommandArgument="CustomerNAmesWallets.aspx" />
                <asp:Button ID="EshopVouchersButton" runat="server" Text="EshopVouchers" OnClick="NavigateToPage" CommandArgument="EshopVouchers.aspx" />
                <asp:Button ID="PaymentTransactionsButton" runat="server" Text="PaymentTransactions" OnClick="NavigateToPage" CommandArgument="PaymentTransactions.aspx" />
                <asp:Button ID="NumCashbackButton" runat="server" Text="NumCashback" OnClick="NavigateToPage" CommandArgument="NumCashback.aspx" />
                <asp:Button ID="AcceptedPaymentsButton" runat="server" Text="AcceptedPayments" OnClick="NavigateToPage" CommandArgument="AcceptedPayments.aspx" />
                <asp:Button ID="PlanCashbackButton" runat="server" Text="PlanCashback" OnClick="NavigateToPage" CommandArgument="PlanCashback.aspx" />
                <asp:Button ID="AvgTransactionAmtButton" runat="server" Text="AvgTransactionAmt" OnClick="NavigateToPage" CommandArgument="AvgTransactionAmt.aspx" />
                <asp:Button ID="MobileNumWalletButton" runat="server" Text="MobileNumWallet" OnClick="NavigateToPage" CommandArgument="MobileNumWallet.aspx" />
                <asp:Button ID="UpdatePointsButton" runat="server" Text="UpdatePoints" OnClick="NavigateToPage" CommandArgument="UpdatePoints.aspx" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
