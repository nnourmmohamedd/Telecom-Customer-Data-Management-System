using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class HighestVoucher : System.Web.UI.Page
    {
        protected void btnFetchVoucher_Click(object sender, EventArgs e)
        {
            string mobileNumber = txtMobileNumber.Text.Trim();

            if (!string.IsNullOrEmpty(mobileNumber) && mobileNumber.Length == 11)
            {
                try
                {
                    ShowHighestVoucher(mobileNumber);
                }
                catch (Exception ex)
                {
                    lblVoucher.Text = "An unexpected error occurred. Please try again later.";
                    LogError(ex);
                }
            }
            else
            {
                lblVoucher.Text = "Please enter a valid 11-digit mobile number.";
            }
        }

        private void ShowHighestVoucher(string mobileNumber)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB3"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("Account_Highest_Voucher", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@mobile_num", mobileNumber);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string voucherID = reader["voucherID"].ToString();
                            lblVoucher.Text = $"Voucher with the highest value: {voucherID}";
                        }
                        else
                        {
                            lblVoucher.Text = "No vouchers found for the given mobile number.";
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    lblVoucher.Text = "A database error occurred. Please try again later.";
                    LogError(sqlEx);
                }
                catch (Exception ex)
                {
                    lblVoucher.Text = "An unexpected error occurred. Please try again later.";
                    LogError(ex);
                }
            }
        }

        private void LogError(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");
        }
    }
}
