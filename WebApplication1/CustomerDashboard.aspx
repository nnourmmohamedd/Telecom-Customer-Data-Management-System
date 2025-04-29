<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerDashboard.aspx.cs" Inherits="WebApplication1.CustomerDashboard" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Customer Dashboard</title>
    <style>
        .dashboard {
            display: grid;
            grid-template-columns: repeat(3, 1fr);
            gap: 20px;
            margin: 20px;
        }
        .dashboard button {
            padding: 15px;
            font-size: 16px;
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 5px;
        }
        .dashboard button:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Customer Dashboard</h1>
        <div class="dashboard">
            <!-- Part 1 -->
            <asp:Button ID="btnViewPlans" runat="server" Text="View Service Plans" OnClick="btnViewPlans_Click" />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <asp:Button ID="btnViewConsumption" runat="server" Text="View Consumption" OnClick="btnViewConsumption_Click" />
            <asp:Button ID="btnUnsubscribedPlans" runat="server" Text="Unsubscribed Plans" OnClick="btnUnsubscribedPlans_Click" />
            <asp:Button ID="btnActiveUsage" runat="server" Text="Active Plan Usage" OnClick="btnActiveUsage_Click" />
            <asp:Button ID="btnCashbackTransactions" runat="server" Text="Cashback Transactions" OnClick="btnCashbackTransactions_Click" />
            
            <!-- Part 2 -->
            <asp:Button ID="btnActiveBenefits" runat="server" Text="View Active Benefits" OnClick="btnActiveBenefits_Click" />
            <asp:Button ID="btnUnresolvedTickets" runat="server" Text="Unresolved Tickets" OnClick="btnUnresolvedTickets_Click" />
            <asp:Button ID="btnHighestVoucher" runat="server" Text="Highest Value Voucher" OnClick="btnHighestVoucher_Click" />
            <asp:Button ID="btnRemainingAmount" runat="server" Text="Remaining Amount" OnClick="btnRemainingAmount_Click" />
            <asp:Button ID="btnExtraAmount" runat="server" Text="Extra Amount" OnClick="btnExtraAmount_Click" />
            <asp:Button ID="btnTopPayments" runat="server" Text="Top Payments" OnClick="btnTopPayments_Click" />
            
            <!-- Part 3 -->
            <asp:Button ID="btnViewShops" runat="server" Text="View Shops" OnClick="btnViewShops_Click" />
            <asp:Button ID="btnSubscribedPlans" runat="server" Text="Subscribed Plans (5 Months)" OnClick="btnSubscribedPlans_Click" />
            <asp:Button ID="btnRenewSubscription" runat="server" Text="Renew Subscription" OnClick="btnRenewSubscription_Click" />
            <asp:Button ID="btnCashbackReturn" runat="server" Text="Cashback Return" OnClick="btnCashbackReturn_Click" />
            <asp:Button ID="btnRechargeBalance" runat="server" Text="Recharge Balance" OnClick="btnRechargeBalance_Click" />
            <asp:Button ID="btnRedeemVoucher" runat="server" Text="Redeem Voucher" OnClick="btnRedeemVoucher_Click" />
        </div>
    </form>
</body>
</html>
