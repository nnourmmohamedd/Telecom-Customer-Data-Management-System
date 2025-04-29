using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class GetCashback : System.Web.UI.Page
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB3"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGetCashback_Click(object sender, EventArgs e)
        {
            string mobileNumber = txtMobileNumber.Text.Trim();
            string paymentIDText = txtPaymentID.Text.Trim();
            string benefitIDText = txtBenefitID.Text.Trim();

            if (string.IsNullOrWhiteSpace(mobileNumber) || string.IsNullOrWhiteSpace(paymentIDText) || string.IsNullOrWhiteSpace(benefitIDText))
            {
                lblMessage.Text = "All fields are required.";
                return;
            }

            if (!int.TryParse(paymentIDText, out int paymentID) || !int.TryParse(benefitIDText, out int benefitID))
            {
                lblMessage.Text = "Payment ID and Benefit ID must be valid integers.";
                return;
            }

            try
            {
                GetCashbackAmount(mobileNumber, paymentID, benefitID);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred while retrieving the cashback amount. Please try again later.";
                LogError(ex);  
            }
        }

        private void GetCashbackAmount(string mobileNumber, int paymentID, int benefitID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("Payment_wallet_cashback", con)) 
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mobile_num", mobileNumber);
                cmd.Parameters.AddWithValue("@payment_id", paymentID);
                cmd.Parameters.AddWithValue("@benefit_id", benefitID);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar(); 

                    if (result != null)
                    {
                        lblMessage.Text = $"Cashback Amount: {result.ToString()}";
                    }
                    else
                    {
                        lblMessage.Text = "No cashback amount found for the provided details.";
                    }
                }
                catch (SqlException sqlEx)
                {
                    
                    lblMessage.Text = "A database error occurred while fetching the cashback amount. Please try again later.";
                    LogError(sqlEx); 
                }
                catch (Exception ex)
                {
                    
                    lblMessage.Text = "An unexpected error occurred. Please try again later.";
                    LogError(ex); 
                }
            }
        }

        private void LogError(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error: {ex.Message} \nStackTrace: {ex.StackTrace}");
        }
    }
}
