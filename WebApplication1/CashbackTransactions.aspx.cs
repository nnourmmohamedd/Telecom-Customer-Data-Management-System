using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class CashbackTransactions : System.Web.UI.Page
    {
        protected void btnFetchTransactions_Click(object sender, EventArgs e)
        {
            string nationalID = txtNationalID.Text.Trim();

            if (!string.IsNullOrEmpty(nationalID) && int.TryParse(nationalID, out int nid))
            {
                try
                {
                    BindCashbackTransactions(nid);
                }
                catch (Exception ex)
                {
                   
                    ShowErrorMessage("An error occurred while fetching the cashback transactions. Please try again later.");
                    LogError(ex);
                }
            }
            else
            {
                ShowErrorMessage("Please enter a valid numeric National ID.");
            }
        }

        private void BindCashbackTransactions(int nationalID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB3"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Cashback_Wallet_Customer(@NID)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NID", nationalID);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                GridViewTransactions.DataSource = dt;
                                GridViewTransactions.DataBind();
                            }
                            else
                            {
                                ShowErrorMessage("No cashback transactions found for the provided National ID.");
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    ShowErrorMessage("A database error occurred while fetching the cashback transactions. Please try again later.");
                    LogError(sqlEx);
                }
                catch (Exception ex)
                {
                    throw; 
                }
            }
        }

        private void ShowErrorMessage(string message)
        {
            Response.Write($"<script>alert('{message}');</script>");
        }

        private void LogError(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
        }
    }
}
