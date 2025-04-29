using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class ActivePlanUsage : System.Web.UI.Page
    {
        protected void btnFetchUsage_Click(object sender, EventArgs e)
        {
            string mobileNumber = txtMobileNumber.Text.Trim();

            if (!string.IsNullOrEmpty(mobileNumber) && mobileNumber.Length == 11)
            {
                try
                {
                    BindActivePlanUsage(mobileNumber);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An error occurred while fetching the active plan usage: " + ex.Message;
                    LogError(ex);
                }
            }
            else
            {
                lblMessage.Text = "Please enter a valid 11-digit mobile number.";
            }
        }

        private void BindActivePlanUsage(string mobileNumber)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB3"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Usage_Plan_CurrentMonth(@mobile_num)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mobile_num", mobileNumber);

                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            
                            if (dt.Rows.Count > 0)
                            {
                                GridViewUsage.DataSource = dt;
                                GridViewUsage.DataBind();
                                lblMessage.Text = ""; 
                            }
                            else
                            {
                                
                                GridViewUsage.DataSource = null;
                                GridViewUsage.DataBind();
                                lblMessage.Text = "No active plan usage found for the given mobile number in the current month.";
                            }
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        
                        lblMessage.Text = "A database error occurred while fetching the active plan usage. Please try again later.";
                        LogError(sqlEx); 
                    }
                    catch (Exception ex)
                    {
                        
                        lblMessage.Text = "An unexpected error occurred while fetching the active plan usage. Please try again later.";
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
