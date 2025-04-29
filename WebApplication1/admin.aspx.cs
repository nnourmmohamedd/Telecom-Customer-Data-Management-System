using System;

namespace WebApplication1
{
    public partial class admin : System.Web.UI.Page
    {
        protected void NavigateToPage(object sender, EventArgs e)
        {
            var button = (System.Web.UI.WebControls.Button)sender;
            string pageUrl = button.CommandArgument;
            Response.Redirect(pageUrl);
        }
    }
}
