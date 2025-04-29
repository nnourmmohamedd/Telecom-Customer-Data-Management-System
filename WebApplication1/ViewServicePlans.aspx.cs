using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class ViewServicePlans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    BindServicePlans();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An unexpected error occurred while loading the service plans. Please try again later.";
                    LogError(ex);
                }
            }
        }

        private void BindServicePlans()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB3"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM allServicePlans"; 
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt); 

                            GridViewServicePlans.DataSource = dt;
                            GridViewServicePlans.DataBind();

                            if (dt.Rows.Count == 0)
                            {
                                lblMessage.Text = "No service plans available.";
                            }
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        lblMessage.Text = "A database error occurred while loading the service plans. Please try again later.";
                        LogError(sqlEx);
                    }
                    catch (Exception ex)
                    {
                        
                        lblMessage.Text = "An unexpected error occurred while loading the service plans. Please try again later.";
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
