using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ResolvedTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load resolved tickets only on the first page load (not on postbacks)
            //if (!IsPostBack)
            //{
                LoadResolvedTickets();
            //}
        }

        private void LoadResolvedTickets()
        {
            
            string connStr = WebConfigurationManager.ConnectionStrings["DB3"].ToString();

           
            SqlConnection conn = new SqlConnection(connStr);

           
            string query = "SELECT * FROM allResolvedTickets";

            SqlCommand com = new SqlCommand(query, conn);

            try
            {
                
                conn.Open();

                
                SqlDataReader rdr = com.ExecuteReader();

                if (rdr.HasRows)
                {
                    ResolvedTicketsGridView.DataSource = rdr;
                    ResolvedTicketsGridView.DataBind();
                }
                else
                {
                    Message.Text = "No resolved tickets found in the allResolvedTickets view.";
                    ResolvedTicketsGridView.DataSource = null;
                    ResolvedTicketsGridView.DataBind();
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                Message.Text = "Error loading resolved tickets: " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
