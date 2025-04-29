using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class TechnicalSupportTickets : System.Web.UI.Page
    {
        protected void btnFetchTickets_Click(object sender, EventArgs e)
        {
            string nationalID = txtNationalID.Text.Trim();

            if (!string.IsNullOrEmpty(nationalID) && int.TryParse(nationalID, out int nid))
            {
                try
                {
                    ShowUnresolvedTicketCount(nid);
                }
                catch (Exception ex)
                {
                    lblTicketCount.Text = "An unexpected error occurred. Please try again later.";
                    LogError(ex); 
                }
            }
            else
            {
                lblTicketCount.Text = "Please enter a valid National ID.";
            }
        }

        private void ShowUnresolvedTicketCount(int nationalID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB3"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Ticket_Account_Customer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NID", nationalID);

                    try
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        int count = result != null ? Convert.ToInt32(result) : 0;

                        lblTicketCount.Text = $"Number of unresolved tickets: {count}";
                    }
                    catch (SqlException sqlEx)
                    {
                        lblTicketCount.Text = "A database error occurred while fetching the ticket count. Please try again later.";
                        LogError(sqlEx); 
                    }
                    catch (Exception ex)
                    {
                        
                        lblTicketCount.Text = "An unexpected error occurred. Please try again later.";
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
