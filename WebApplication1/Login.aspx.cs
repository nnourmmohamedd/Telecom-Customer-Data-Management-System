using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class login : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DB3"].ToString();

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameInput.Text.Trim();
            string password = PasswordInput.Text.Trim();

            if (username == "admin" && password == "admin123")
            {
                Response.Redirect("admin.aspx");
            }
            else
            {
                if (ValidateCustomerCredentials(username, password))
                {
                    Response.Redirect("CustomerDashboard.aspx"); 
                }
                else
                {
                    MessageLabel.Text = "Invalid mobile number or password.";
                }
            }
        }

        private bool ValidateCustomerCredentials(string mobileNo, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM customer_account WHERE mobileNo = @MobileNo AND pass = @Password";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@MobileNo", mobileNo);
                    cmd.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        con.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            return true; 
                        }
                        else
                        {
                            return false; 
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageLabel.Text = "Error while verifying credentials: " + ex.Message;
                        return false;
                    }
                }
            }
        }

        protected void btnFetchPlans_Click(object sender, EventArgs e)
        {
            string mobileNo = txtMobileNo.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(mobileNo) || string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "Please fill in both mobile number and password.";
                return;
            }

            if (mobileNo.Length != 11)
            {
                lblMessage.Text = "Mobile number must be exactly 11 digits.";
                return;
            }

            if (ValidateCustomerCredentials(mobileNo, password))
            {
                Response.Redirect("CustomerDashboard.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid mobile number or password.";
            }
        }
    }
}
