using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagement.BLL;
using StockManagement.GateWay;
using StockManagement.Model;

namespace StockManagement.UI
{
    public partial class ItemSetupUI : System.Web.UI.Page
    {
        ItemSetupBLL itemSetupBll = new ItemSetupBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                companyDropDownList.DataSource = itemSetupBll.GetCompanies();
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "CompanyId";
                companyDropDownList.DataBind();

                categoryDropDownList.DataSource = itemSetupBll.GetCategories();
                categoryDropDownList.DataTextField = "CategoryName";
                categoryDropDownList.DataValueField = "CategoryID";
                categoryDropDownList.DataBind();
                reorderTextBox.Text = "0";

            }
            


        }

        protected void itemSaveButton_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            item.ItemName = itemNameTextBox.Text;
            item.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            item.CategoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
            item.Reorder = Convert.ToInt32(reorderTextBox.Text);
            if (itemSetupBll.AddItem(item)>0)
            {
                Response.Write("<script>alert('Save');</script>");
            }
        }
    }
}