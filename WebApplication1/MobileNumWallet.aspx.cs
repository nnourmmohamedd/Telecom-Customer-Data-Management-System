using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class MobileNumWallet : System.Web.UI.Page
    {
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            CheckMobileNumberWalletLink();
        }

        private void CheckMobileNumberWalletLink()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DB3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand com = new SqlCommand("SELECT dbo.Wallet_MobileNo(@MobileNumber)", conn);

            com.Parameters.AddWithValue("@MobileNumber", MobileNumberInput.Text);

            try
            {
                conn.Open();

                var result = com.ExecuteScalar();

                if (result != null && result is bool linked)
                {
                    ResultLabel.Text = linked ? "Wallet Link Status: Linked" : "Wallet Link Status: Not Linked";
                    ErrorLabel.Text = string.Empty;
                }
                else
                {
                    ResultLabel.Text = "Unable to determine wallet link status.";
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
