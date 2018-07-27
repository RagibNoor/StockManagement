using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagement.BLL;
using StockManagement.Model;

namespace StockManagement.UI
{
    public partial class LogInUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            LoginBLL loginBll = new LoginBLL();
            Users user = new Users();
            user.UserName = userNameTextBox.Text;
            user.Password = PasswordTextBox.Text;

            if (loginBll.CheckUserNamePassword(user))
            {
                Response.Redirect("HomeUI.aspx");
            }
            Response.Write("<script>alert('Invalid UserName or Password');</script>");
            
        }

       
    }
}