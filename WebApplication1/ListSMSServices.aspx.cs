using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class ListSMSServices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnListSMSOffers_Click(object sender, EventArgs e)
        {
            string accountID = txtAccountID.Text;

            if (string.IsNullOrWhiteSpace(accountID))
            {
                lblMsg.Text = "Please enter an Account ID.";
                gvSMSOffers.DataSource = null;
                gvSMSOffers.DataBind();
                return;
            }

            ListSMSOffers(accountID);
        }

        protected void ListSMSOffers(string accountID)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DB3"].ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM dbo.Account_SMS_Offers(@AccountID)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@AccountID", accountID);

                try
                {
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        gvSMSOffers.DataSource = rdr;
                        gvSMSOffers.DataBind();
                        lblMsg.Text = ""; 
                    }
                    else
                    {
                        lblMsg.Text = "No SMS offers found for the given account.";
                        gvSMSOffers.DataSource = null;
                        gvSMSOffers.DataBind();
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
