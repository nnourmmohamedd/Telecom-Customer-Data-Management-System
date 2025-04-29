using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class NumCashback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNumCashbackTransactions();
            }
        }

        private void LoadNumCashbackTransactions()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DB3"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Num_of_cashback";
                SqlCommand com = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader rdr = com.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        CashbackGridView.DataSource = rdr;
                        CashbackGridView.DataBind();
                    }
                    else
                    {
                        Message.Text = "No cashback transactions found.";
                        CashbackGridView.DataSource = null;
                        CashbackGridView.DataBind();
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
