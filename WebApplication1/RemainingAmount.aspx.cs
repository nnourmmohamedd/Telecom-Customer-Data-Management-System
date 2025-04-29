using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class RemainingAmount : System.Web.UI.Page
    {
        protected void btnFetchAmount_Click(object sender, EventArgs e)
        {
            string mobileNumber = txtMobileNumber.Text.Trim();
            string planName = txtPlanName.Text.Trim();

            if (!string.IsNullOrEmpty(mobileNumber) && mobileNumber.Length == 11 && !string.IsNullOrEmpty(planName))
            {
                try
                {
                    ShowRemainingAmount(mobileNumber, planName);
                }
                catch (Exception ex)
                {
                    lblRemainingAmount.Text = "An unexpected error occurred. Please try again later.";
                    LogError(ex); 
                }
            }
            else
            {
                lblRemainingAmount.Text = "Please enter valid Mobile Number and Plan Name.";
            }
        }

        private void ShowRemainingAmount(string mobileNumber, string planName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB3"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Remaining_plan_amount", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mobile_num", mobileNumber);
                    cmd.Parameters.AddWithValue("@plan_name", planName);

                    try
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();

                        int remainingAmount = result != null ? Convert.ToInt32(result) : 0;
                        lblRemainingAmount.Text = $"Remaining amount for the last payment: {remainingAmount}";
                    }
                    catch (SqlException sqlEx)
                    {
                        
                        lblRemainingAmount.Text = "A database error occurred while fetching the remaining amount. Please try again later.";
                        LogError(sqlEx); 
                    }
                    catch (Exception ex)
                    {
                       
                        lblRemainingAmount.Text = "An unexpected error occurred. Please try again later.";
                        LogError(ex); 
                    }
                }
            }
        }

        private void LogError(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error: {ex.Message} \nStackTrace: {ex.StackTrace}");
        }
    }
}
