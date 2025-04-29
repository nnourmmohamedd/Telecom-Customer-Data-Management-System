using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class RemoveBenefits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRemoveBenefits_Click(object sender, EventArgs e)
        {
            string accountID = txtAccountID.Text;
            string planID = txtPlanID.Text;

            if (string.IsNullOrWhiteSpace(accountID) || string.IsNullOrWhiteSpace(planID))
            {
                lblMsg.Text = "Please enter both Account ID (Mobile Number) and Plan ID.";
                return;
            }

            RemoveBenefitsForAccountAndPlan(accountID, planID);
        }

        protected void RemoveBenefitsForAccountAndPlan(string accountID, string planID)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DB3"].ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand com = new SqlCommand("Benefits_Account", conn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@mobile_num", accountID); 
                com.Parameters.AddWithValue("@plan_id", planID);       

                try
                {
                    conn.Open();
                    int rowsAffected = com.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMsg.Text = "Benefits removed successfully.";
                    }
                    else
                    {
                        lblMsg.Text = "No benefits found to remove for the specified mobile number and plan.";
                    }
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}
