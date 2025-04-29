using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class ExtraAmount : System.Web.UI.Page
    {
        protected void btnFetchExtraAmount_Click(object sender, EventArgs e)
        {
            string mobileNumber = txtMobileNumber.Text.Trim();
            string planName = txtPlanName.Text.Trim();

            if (!string.IsNullOrEmpty(mobileNumber) && mobileNumber.Length == 11 && !string.IsNullOrEmpty(planName))
            {
                try
                {
                    ShowExtraAmount(mobileNumber, planName);
                }
                catch (Exception ex)
                {
                    lblExtraAmount.Text = "An unexpected error occurred. Please try again later.";
                    LogError(ex);
                }
            }
            else
            {
                lblExtraAmount.Text = "Please enter valid Mobile Number and Plan Name.";
            }
        }

        private void ShowExtraAmount(string mobileNumber, string planName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB3"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("Extra_plan_amount", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@mobile_num", mobileNumber);
                        cmd.Parameters.AddWithValue("@plan_name", planName);

                        conn.Open();
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            int extraAmount = Convert.ToInt32(result);
                            lblExtraAmount.Text = $"Extra amount for the last payment: {extraAmount}";
                        }
                        else
                        {
                            lblExtraAmount.Text = "No extra amount found for the given mobile number and plan.";
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    lblExtraAmount.Text = "A database error occurred. Please try again later.";
                    LogError(sqlEx);
                }
                catch (Exception ex)
                {
                    lblExtraAmount.Text = "An unexpected error occurred. Please try again later.";
                    LogError(ex);
                }
            }
        }

        private void LogError(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
        }
    }
}
