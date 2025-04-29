using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class ViewConsumption : System.Web.UI.Page
    {
        protected void btnViewConsumption_Click(object sender, EventArgs e)
        {
            string planName = txtPlanName.Text.Trim();
            string startDate = txtStartDate.Text.Trim();
            string endDate = txtEndDate.Text.Trim();

            if (!string.IsNullOrEmpty(planName) && !string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                try
                {
                    BindConsumption(planName, startDate, endDate);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An unexpected error occurred while fetching consumption data. Please try again later.";
                    LogError(ex); 
                }
            }
            else
            {
                
                lblMessage.Text = "Please fill in all fields.";
            }
        }

        private void BindConsumption(string planName, string startDate, string endDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB3"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Consumption(@Plan_name, @Start_date, @End_date)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Plan_name", planName);
                    cmd.Parameters.AddWithValue("@Start_date", startDate);
                    cmd.Parameters.AddWithValue("@End_date", endDate);

                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            
                            if (dt.Rows.Count > 0)
                            {
                                GridViewConsumption.DataSource = dt;
                                GridViewConsumption.DataBind();
                                lblMessage.Text = ""; 
                            }
                            else
                            {
                                GridViewConsumption.DataSource = null;
                                GridViewConsumption.DataBind();
                                lblMessage.Text = "No consumption data found for the given plan and dates.";
                            }
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        
                        lblMessage.Text = "Invalid data. Please enter valid data.";
                        LogError(sqlEx); 
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "Invalid data. Please enter valid data.";
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
