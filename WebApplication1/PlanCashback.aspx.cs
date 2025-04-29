using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class PlanCashback : System.Web.UI.Page
    {
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            LoadPlanCashback();
        }

        private void LoadPlanCashback()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DB3"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand com = new SqlCommand("SELECT dbo.Wallet_Cashback_Amount(@WalletID, @PlanID)", conn);

            com.Parameters.AddWithValue("@WalletID", WalletIDInput.Text);
            com.Parameters.AddWithValue("@PlanID", PlanIDInput.Text);

            try
            {
                conn.Open();

                var result = com.ExecuteScalar();

                if (result != null)
                {
                    ResultLabel.Text = $"Total Cashback: {result} units";
                    ErrorLabel.Text = string.Empty;
                }
                else
                {
                    ResultLabel.Text = "No cashback data found for the given Wallet ID and Plan ID.";
                }
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = "Error: " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
