using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class ViewActiveBenefits : System.Web.UI.Page
    {
        protected void btnViewBenefits_Click(object sender, EventArgs e)
        {
            try
            {
                BindActiveBenefits();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An unexpected error occurred. Please try again later.";
                LogError(ex); 
            }
        }

        private void BindActiveBenefits()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB3"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM allBenefits WHERE status = 'active'"; 
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            
                            if (dt.Rows.Count == 0)
                            {
                                lblNoResultsMessage.Text = "No active benefits found.";
                                GridViewBenefits.Visible = false; 
                            }
                            else
                            {
                                lblNoResultsMessage.Text = string.Empty; 
                                GridViewBenefits.Visible = true; 
                                GridViewBenefits.DataSource = dt;
                                GridViewBenefits.DataBind();
                            }
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        lblMessage.Text = "A database error occurred while fetching the active benefits. Please try again later.";
                        LogError(sqlEx); 
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "An unexpected error occurred while fetching the active benefits. Please try again later.";
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
