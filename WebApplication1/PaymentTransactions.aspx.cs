using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class PaymentsTransactions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPaymentTransactions();
            }
        }

        private void LoadPaymentTransactions()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DB3"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM AccountPayments";
                SqlCommand com = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader rdr = com.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        PaymentsGridView.DataSource = rdr;
                        PaymentsGridView.DataBind();
                    }
                    else
                    {
                        Message.Text = "No payment transactions found.";
                        PaymentsGridView.DataSource = null;
                        PaymentsGridView.DataBind();
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    Message.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}
