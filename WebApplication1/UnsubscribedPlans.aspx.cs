using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class UnsubscribedPlans : System.Web.UI.Page
    {
        protected void btnFetchPlans_Click(object sender, EventArgs e)
        {
            string mobileNumber = txtMobileNumber.Text.Trim();

            if (!string.IsNullOrEmpty(mobileNumber) && mobileNumber.Length == 11 && IsNumeric(mobileNumber))
            {
                try
                {
                    BindUnsubscribedPlans(mobileNumber);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An unexpected error occurred. Please try again later.";
                    LogError(ex); 
                }
            }
            else
            {
                Response.Write("<script>alert('Please enter a valid 11-digit mobile number with only numeric characters.');</script>");
            }
        }

        private bool IsNumeric(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c)) 
                {
                    return false;
                }
            }
            return true; 
        }

        private void BindUnsubscribedPlans(string mobileNumber)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB3"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Unsubscribed_Plans", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mobile_num", mobileNumber);

                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            GridViewUnsubscribedPlans.DataSource = dt;
                            GridViewUnsubscribedPlans.DataBind();

                            if (dt.Rows.Count == 0)
                            {
                                lblMessage.Text = "No unsubscribed plans found for the given mobile number.";
                            }
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        lblMessage.Text = "A database error occurred while fetching the unsubscribed plans. Please try again later.";
                        LogError(sqlEx); 
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "An unexpected error occurred while fetching the unsubscribed plans. Please try again later.";
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
