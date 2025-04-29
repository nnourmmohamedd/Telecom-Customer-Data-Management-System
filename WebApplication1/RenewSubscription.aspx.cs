using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class RenewSubscription : System.Web.UI.Page
    {
        protected void btnRenewSubscription_Click(object sender, EventArgs e)
        {
            string mobileNumber = txtMobileNumber.Text.Trim();
            string planIDText = txtPlanID.Text.Trim();
            string amountText = txtAmount.Text.Trim();
            string paymentMethod = txtPaymentMethod.Text.Trim();

            if (!string.IsNullOrEmpty(mobileNumber) && mobileNumber.Length == 11 &&
                !string.IsNullOrEmpty(planIDText) && !string.IsNullOrEmpty(amountText) && !string.IsNullOrEmpty(paymentMethod))
            {
                int planID;
                decimal amount;

                if (int.TryParse(planIDText, out planID) && decimal.TryParse(amountText, out amount))
                {
                    try
                    {
                        RenewSubscriptionPlan(mobileNumber, planID, amount, paymentMethod);
                    }
                    catch (Exception ex)
                    {
                        lblResult.Text = "An unexpected error occurred. Please try again later.";
                        LogError(ex); 
                    }
                }
                else
                {
                    lblResult.Text = "Please enter valid Plan ID and Amount.";
                }
            }
            else
            {
                lblResult.Text = "Please fill all fields with valid data.";
            }
        }

        private void RenewSubscriptionPlan(string mobileNumber, int planID, decimal amount, string paymentMethod)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB3"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Initiate_plan_payment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mobile_num", mobileNumber);
                    cmd.Parameters.AddWithValue("@plan_id", planID);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@payment_method", paymentMethod);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        lblResult.Text = "Subscription renewed successfully!";
                    }
                    catch (SqlException sqlEx)
                    {
                        lblResult.Text = "A database error occurred while renewing the subscription. Please try again later.";
                        LogError(sqlEx); 
                    }
                    catch (Exception ex)
                    {
                        lblResult.Text = "An unexpected error occurred. Please try again later.";
                        LogError(ex); 
                    }
                }
            }
        }

        private void LogError(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");
        }
    }
}
