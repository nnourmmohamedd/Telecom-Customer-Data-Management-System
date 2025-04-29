using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class TotalUsage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnViewUsage_Click(object sender, EventArgs e)
        {
            string accountID = txtAccountID.Text;
            DateTime inputDate;

            if (DateTime.TryParse(txtDate.Text, out inputDate))
            {
                ShowTotalUsage(accountID, inputDate);
            }
            else
            {
                lblMsg.Text = "Please enter a valid date.";
                gvUsage.DataSource = null;
                gvUsage.DataBind();
            }
        }

        protected void ShowTotalUsage(string accountID, DateTime inputDate)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DB3"].ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM dbo.Account_Usage_Plan(@InputDate, @AccountID)";
                SqlCommand com = new SqlCommand(query, conn);

                com.Parameters.Add("@InputDate", SqlDbType.Date).Value = inputDate;
                com.Parameters.AddWithValue("@AccountID", accountID);

                try
                {
                    conn.Open();
                    SqlDataReader rdr = com.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        gvUsage.DataSource = rdr;
                        gvUsage.DataBind();
                        lblMsg.Text = "Total usage details fetched successfully.";
                    }
                    else
                    {
                        lblMsg.Text = "No usage records found for the given account and date.";
                        gvUsage.DataSource = null;
                        gvUsage.DataBind();
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}

