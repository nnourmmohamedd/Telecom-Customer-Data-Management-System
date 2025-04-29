using System;

namespace WebApplication1
{
    public partial class CustomerDashboard : System.Web.UI.Page
    {
        protected void btnViewPlans_Click(object sender, EventArgs e) => Response.Redirect("ViewServicePlans.aspx");
        protected void btnLogin_Click(object sender, EventArgs e) => Response.Redirect("Login.aspx");
        protected void btnViewConsumption_Click(object sender, EventArgs e) => Response.Redirect("ViewConsumption.aspx");
        protected void btnUnsubscribedPlans_Click(object sender, EventArgs e) => Response.Redirect("UnsubscribedPlans.aspx");
        protected void btnActiveUsage_Click(object sender, EventArgs e) => Response.Redirect("ActivePlanUsage.aspx");
        protected void btnCashbackTransactions_Click(object sender, EventArgs e) => Response.Redirect("CashbackTransactions.aspx");

        protected void btnActiveBenefits_Click(object sender, EventArgs e) => Response.Redirect("ViewActiveBenefits.aspx");
        protected void btnUnresolvedTickets_Click(object sender, EventArgs e) => Response.Redirect("TechnicalSupportTickets.aspx");
        protected void btnHighestVoucher_Click(object sender, EventArgs e) => Response.Redirect("HighestVoucher.aspx");
        protected void btnRemainingAmount_Click(object sender, EventArgs e) => Response.Redirect("RemainingAmount.aspx");
        protected void btnExtraAmount_Click(object sender, EventArgs e) => Response.Redirect("ExtraAmount.aspx");
        protected void btnTopPayments_Click(object sender, EventArgs e) => Response.Redirect("TopPayments.aspx");

        protected void btnViewShops_Click(object sender, EventArgs e) => Response.Redirect("ViewAllShops.aspx");
        protected void btnSubscribedPlans_Click(object sender, EventArgs e) => Response.Redirect("ViewSubscribedPlans.aspx");
        protected void btnRenewSubscription_Click(object sender, EventArgs e) => Response.Redirect("RenewSubscription.aspx");
        protected void btnCashbackReturn_Click(object sender, EventArgs e) => Response.Redirect("GetCashback.aspx");
        protected void btnRechargeBalance_Click(object sender, EventArgs e) => Response.Redirect("RechargeBalance.aspx");
        protected void btnRedeemVoucher_Click(object sender, EventArgs e) => Response.Redirect("RedeemVoucher.aspx");
    }
}
