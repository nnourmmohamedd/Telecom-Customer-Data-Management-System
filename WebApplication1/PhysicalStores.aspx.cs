using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class PhysicalStores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load store data only on first page load (not on postbacks)
            // if (!IsPostBack)
            //{
            LoadPhysicalStoreVouchers();
            //}
        }

        private void LoadPhysicalStoreVouchers()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DB3"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            string query = "SELECT * FROM PhysicalStoreVouchers";

            SqlCommand com = new SqlCommand(query, conn);

            try
            {
                conn.Open();

                SqlDataReader rdr = com.ExecuteReader();

                if (rdr.HasRows)
                {
                    PhysicalStoreVouchersGridView.DataSource = rdr;
                    PhysicalStoreVouchersGridView.DataBind();
                }
                else
                {
                    Message.Text = "No data found in the PhysicalStoreVouchers view.";
                    PhysicalStoreVouchersGridView.DataSource = null;
                    PhysicalStoreVouchersGridView.DataBind();
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
