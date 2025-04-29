using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CustomerProfiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!IsPostBack)
            // {
            LoadCustomerAccounts();
           // }
        }

        private void LoadCustomerAccounts()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DB3"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            string query = "SELECT * FROM allCustomerAccounts";

            SqlCommand com = new SqlCommand(query, conn);

            try
            {
                conn.Open();

                SqlDataReader rdr = com.ExecuteReader();

                if (rdr.HasRows)
                {
                    CustomerAccountsGridView.DataSource = rdr;
                    CustomerAccountsGridView.DataBind();
                }
                else
                {
                    Message.Text = "No data found in the allCustomerAccounts view.";
                    CustomerAccountsGridView.DataSource = null;
                    CustomerAccountsGridView.DataBind();
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                Message.Text = "Error loading customer profiles: " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
