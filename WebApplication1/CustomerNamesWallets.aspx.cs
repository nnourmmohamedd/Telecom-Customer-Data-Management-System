using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CustomerNamesWallets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if (!IsPostBack)
            //{
            LoadCustomerWallet();
           // }
        }

        private void LoadCustomerWallet()
        {
            
            string connStr = WebConfigurationManager.ConnectionStrings["DB3"].ToString();

            
            SqlConnection conn = new SqlConnection(connStr);

            
            string query = "SELECT * FROM CustomerWallet";

            SqlCommand com = new SqlCommand(query, conn);

            try
            {
               
                conn.Open();

                
                SqlDataReader rdr = com.ExecuteReader();

                
                if (rdr.HasRows)
                {
                    
                    CustomerWalletGridView.DataSource = rdr;
                    CustomerWalletGridView.DataBind();
                }
                else
                {
                    
                    Message.Text = "No data found in the CustomerWallet view.";
                    CustomerWalletGridView.DataSource = null;
                    CustomerWalletGridView.DataBind();
                }

                
                rdr.Close();
            }
            catch (Exception ex)
            {
                
                Message.Text = "Error: " + ex.Message;
            }
            finally
            {
                
                conn.Close();
            }
        }

    }
}
