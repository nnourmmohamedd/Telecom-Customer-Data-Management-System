using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class UpdatePoints : System.Web.UI.Page
    {
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            UpdateEarnedPoints();
        }

        private void UpdateEarnedPoints()
        {
            if (string.IsNullOrWhiteSpace(MobileNumberInput.Text))
            {
                ErrorLabel.Text = "Please enter a valid mobile number.";
                ResultLabel.Text = string.Empty;
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["DB3"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand com = new SqlCommand("Total_Points_Account", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                com.Parameters.AddWithValue("@mobile_num", MobileNumberInput.Text);

                try
                {
                    conn.Open();

                    com.ExecuteNonQuery();

                    ResultLabel.Text = "Earned points updated successfully.";
                    ErrorLabel.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    ErrorLabel.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}
