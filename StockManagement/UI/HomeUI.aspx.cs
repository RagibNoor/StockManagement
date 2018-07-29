using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagement.UI
{
    public partial class HomeUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CategorySetupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategorySetupUI.aspx");
        }

        protected void companySetupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanySetupUI.aspx");
        }
    }
}