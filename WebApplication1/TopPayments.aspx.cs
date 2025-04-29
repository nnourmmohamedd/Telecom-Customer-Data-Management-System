using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class TopPayments : System.Web.UI.Page
    {
        protected void btnFetchPayments_Click(object sender, EventArgs e)
        {
            string mobileNumber = txtMobileNumber.Text.Trim();

            if (!string.IsNullOrEmpty(mobileNumber) && mobileNumber.Length == 11)
            {
                try
                {
                    BindTopPayments(mobileNumber);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An unexpected error occurred while fetching the payments. Please try again later.";
                    LogError(ex); 
                }
            }
            else
            {
                Response.Write("<script>alert('Please enter a valid 11-digit mobile number.');</script>");
            }
        }

        private void BindTopPayments(string mobileNumber)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB3"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "Top_Successful_Payments";
                using (SqlCommand cmd = new SqlCommand(query, conn))
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

                            if (dt.Rows.Count == 0)
                            {
                                lblNoResultsMessage.Text = "No successful payments found for this mobile number.";
                                GridViewTopPayments.Visible = false; 
                            }
                            else
                            {
                                lblNoResultsMessage.Text = string.Empty; 
                                GridViewTopPayments.Visible = true; 
                                GridViewTopPayments.DataSource = dt;
                                GridViewTopPayments.DataBind();
                            }
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        lblMessage.Text = "A database error occurred while fetching the payments. Please try again later.";
                        LogError(sqlEx); 
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "An unexpected error occurred while fetching the payments. Please try again later.";
                        LogError(ex); 
                    }
                }
            }
        }

        private void LogError(Exception ex)
        {
            
            System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");
        }
    }
}
