using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CustomerAccounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load customer accounts and subscribed plans only on the first page load (not on postbacks)
           // if (!IsPostBack)
            //{
                LoadCustomerAccounts();
          //  }
        }

        private void LoadCustomerAccounts()
        {
            try
            {
               
                string connStr = WebConfigurationManager.ConnectionStrings["DB3"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                
                SqlCommand com = new SqlCommand("Account_Plan", conn);
                com.CommandType = CommandType.StoredProcedure; 
                conn.Open();
                SqlDataReader rdr = com.ExecuteReader();
                if (rdr.HasRows)
                {
                    
                    CustomerA.DataSource = rdr;
                    CustomerA.DataBind();
                }
                else
                {
                    Message.Text = "No customer accounts found.";
                    CustomerA.DataSource = null;
                    CustomerA.DataBind();
                }

                
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                
                Message.Text = "Error loading customer accounts: " + ex.Message;
            }
        }
    }
}
