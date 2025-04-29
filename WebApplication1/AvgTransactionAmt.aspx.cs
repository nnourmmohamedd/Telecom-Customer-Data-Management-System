using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class AvgTransactionAmt : System.Web.UI.Page
    {
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            LoadAverageTransactionAmount();
        }

        private void LoadAverageTransactionAmount()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DB3"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // Use a SELECT query to call the scalar function
                string query = "SELECT dbo.Wallet_Transfer_Amount(@WalletID, @StartDate, @EndDate)";
                SqlCommand com = new SqlCommand(query, conn);

                // Add parameters for the function
                com.Parameters.AddWithValue("@WalletID", WalletIDInput.Text);
                com.Parameters.AddWithValue("@StartDate", StartDateInput.Text);
                com.Parameters.AddWithValue("@EndDate", EndDateInput.Text);

                try
                {
                    conn.Open();

                    var result = com.ExecuteScalar();

                    if (result != null && !DBNull.Value.Equals(result))
                    {
                        ResultLabel.Text = $"Average Transaction Amount: {result} units";
                        ErrorLabel.Text = string.Empty;
                    }
                    else
                    {
                        ResultLabel.Text = "No transactions found for the given Wallet ID and date range.";
                        ErrorLabel.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    ErrorLabel.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}
