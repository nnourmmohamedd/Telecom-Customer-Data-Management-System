using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class ViewSubscribedPlans : System.Web.UI.Page
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB3"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnFetchPlans_Click(object sender, EventArgs e)
        {
            string mobileNo = txtMobileNo.Text.Trim();

            if (string.IsNullOrWhiteSpace(mobileNo))
            {
                lblMessage.Text = "Please enter a valid mobile number.";
                return;
            }

            if (mobileNo.Length != 11)
            {
                lblMessage.Text = "Mobile number must be exactly 11 digits.";
                return;
            }

            try
            {
                FetchSubscribedPlans(mobileNo);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred while fetching subscribed plans: " + ex.Message;
                LogError(ex); 
            }
        }

        private void FetchSubscribedPlans(string mobileNo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Subscribed_plans_5_Months(@MobileNo)", con)) 
            {
                cmd.Parameters.AddWithValue("@MobileNo", mobileNo);

                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt); 

                    if (dt.Rows.Count > 0)
                    {
                        gvSubscribedPlans.DataSource = dt;
                        gvSubscribedPlans.DataBind();
                        lblMessage.Text = ""; 
                    }
                    else
                    {
                        gvSubscribedPlans.DataSource = null;
                        gvSubscribedPlans.DataBind();
                        lblMessage.Text = "No subscribed plans found for the given mobile number in the past 5 months.";
                    }
                }
                catch (SqlException sqlEx)
                {
                    lblMessage.Text = "A database error occurred while fetching subscribed plans. Please try again later.";
                    LogError(sqlEx); 
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An unexpected error occurred while fetching subscribed plans. Please try again later.";
                    LogError(ex); 
                }
            }
        }

        private void LogError(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");
        }
    }
}
