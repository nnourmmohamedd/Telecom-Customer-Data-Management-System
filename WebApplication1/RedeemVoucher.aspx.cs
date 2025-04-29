using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class RedeemVoucher : System.Web.UI.Page
    {
        protected void btnRedeemVoucher_Click(object sender, EventArgs e)
        {
            string mobileNumber = txtMobileNumber.Text.Trim();
            string voucherIDText = txtVoucherID.Text.Trim();

            // Validate input fields
            if (!string.IsNullOrEmpty(mobileNumber) && mobileNumber.Length == 11 &&
                !string.IsNullOrEmpty(voucherIDText))
            {
                int voucherID;

                if (int.TryParse(voucherIDText, out voucherID))
                {
                    try
                    {
                        RedeemVoucherPoints(mobileNumber, voucherID);
                    }
                    catch (Exception ex)
                    {
                        lblResult.Text = "An unexpected error occurred. Please try again later.";
                        LogError(ex); 
                    }
                }
                else
                {
                    lblResult.Text = "Please enter a valid Voucher ID.";
                }
            }
            else
            {
                lblResult.Text = "Please fill in both Mobile Number and Voucher ID with valid data.";
            }
        }

        private void RedeemVoucherPoints(string mobileNumber, int voucherID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB3"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Redeem_voucher_points", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mobile_num", mobileNumber);
                    cmd.Parameters.AddWithValue("@voucher_id", voucherID);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        lblResult.Text = "Voucher redeemed successfully!";
                    }
                    catch (SqlException sqlEx)
                    {
                        lblResult.Text = "A database error occurred while redeeming the voucher. Please try again later.";
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
            System.Diagnostics.Debug.WriteLine($"Error: {ex.Message} \nStackTrace: {ex.StackTrace}");
        }
    }
}
