using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class ViewAllShops : System.Web.UI.Page
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB3"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadShopDetails();
            }
        }

        private void LoadShopDetails()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM allShops", con)) 
            {
                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt); 

                    if (dt.Rows.Count > 0)
                    {
                        gvShops.DataSource = dt;
                        gvShops.DataBind();
                        lblMessage.Text = ""; 
                    }
                    else
                    {
                        gvShops.DataSource = null;
                        gvShops.DataBind();
                        lblMessage.Text = "No shops available.";
                    }
                }
                catch (SqlException sqlEx)
                {
                    
                    lblMessage.Text = "A database error occurred while loading shop details. Please try again later.";
                    LogError(sqlEx); 
                }
                catch (Exception ex)
                {
                    
                    lblMessage.Text = "An unexpected error occurred while loading shop details. Please try again later.";
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
