using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class RechargeBalance : System.Web.UI.Page
    {
        protected void btnRechargeBalance_Click(object sender, EventArgs e)
        {
            string mobileNumber = txtMobileNumber.Text.Trim();
            string amountText = txtAmount.Text.Trim();
            string paymentMethod = txtPaymentMethod.Text.Trim();

            if (!string.IsNullOrEmpty(mobileNumber) && mobileNumber.Length == 11 &&
                !string.IsNullOrEmpty(amountText) && !string.IsNullOrEmpty(paymentMethod))
            {
                decimal amount;

                if (decimal.TryParse(amountText, out amount))
                {
                    try
                    {
                        RechargeAccountBalance(mobileNumber, amount, paymentMethod);
                    }
                    catch (Exception ex)
                    {
                        lblResult.Text = "An error occurred while recharging your balance. Please try again later.";
                        LogError(ex); 
                    }
                }
                else
                {
                    lblResult.Text = "Please enter a valid amount.";
                }
            }
            else
            {
                lblResult.Text = "Please enter valid data.";
            }
        }

        private void RechargeAccountBalance(string mobileNumber, decimal amount, string paymentMethod)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB3"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Initiate_balance_payment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mobile_num", mobileNumber);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@payment_method", paymentMethod);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        lblResult.Text = $"Balance recharged successfully! {amount:C} has been added to your account.";
                    }
                    catch (SqlException sqlEx)
                    {
                        lblResult.Text = "A database error occurred. Please try again later.";
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
