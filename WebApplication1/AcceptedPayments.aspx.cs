using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class AcceptedPayments : System.Web.UI.Page
    {
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            LoadAcceptedPayments();
        }

        private void LoadAcceptedPayments()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DB3"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand com = new SqlCommand("Account_Payment_Points", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                com.Parameters.AddWithValue("@mobile_num", AccountIDInput.Text);

                try
                {
                    conn.Open();
                    SqlDataReader rdr = com.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        AcceptedPaymentsGridView.DataSource = rdr;
                        AcceptedPaymentsGridView.DataBind();
                    }
                    else
                    {
                        Message.Text = "No data found for the provided mobile number.";
                        AcceptedPaymentsGridView.DataSource = null;
                        AcceptedPaymentsGridView.DataBind();
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
