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
    public partial class StockOutUI : System.Web.UI.Page
    {
        ItemSetupBLL itemSetupBll = new ItemSetupBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                companyDropDownList.DataSource = itemSetupBll.GetCompanies();
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "CompanyName";
                companyDropDownList.DataBind();



            }
        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write("<script>alert('" + companyDropDownList.SelectedValue + "');</script>");


            itemDropDownList.DataSource = itemSetupBll.GetItems(companyDropDownList.SelectedValue);
            itemDropDownList.DataTextField = "ItemName";
            itemDropDownList.DataValueField = "ItemId";
            itemDropDownList.DataBind();
        }

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemID = Convert.ToInt32(itemDropDownList.SelectedValue);
            Item item = itemSetupBll.GetReorderAndAmmount(itemID);
            reorderLevelTextBox.Text = item.Reorder.ToString();
            quantityTextBox.Text = item.StockIn.ToString();
            
        }
    }
}