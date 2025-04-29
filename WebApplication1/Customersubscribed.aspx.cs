using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class Customersubscribed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnViewCustomers_Click(object sender, EventArgs e)
        {
            DateTime inputDate;
            int planId;

            if (!DateTime.TryParse(txtDate.Text, out inputDate))
            {
                lblMsg.Text = "Please enter a valid date in the format YYYY-MM-DD.";
                gvCustomers.DataSource = null;
                gvCustomers.DataBind();
                return;
            }

            if (!int.TryParse(txtPlanID.Text, out planId))
            {
                lblMsg.Text = "Please enter a valid Plan ID (numeric).";
                gvCustomers.DataSource = null;
                gvCustomers.DataBind();
                return;
            }

            ListCustomersByPlanAndDate(inputDate, planId);
        }

        protected void ListCustomersByPlanAndDate(DateTime inputDate, int planId)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DB3"].ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM dbo.Account_Plan_date(@InputDate, @PlanID)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.Add("@InputDate", SqlDbType.Date).Value = inputDate;
                cmd.Parameters.AddWithValue("@PlanID", planId);

                try
                {
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        gvCustomers.DataSource = rdr;
                        gvCustomers.DataBind();
                        lblMsg.Text = "Customer list fetched successfully.";
                    }
                    else
                    {
                        lblMsg.Text = "No customers found for the selected plan and date.";
                        gvCustomers.DataSource = null;
                        gvCustomers.DataBind();
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
