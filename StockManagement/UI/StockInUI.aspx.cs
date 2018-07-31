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
    public partial class StockInUI : System.Web.UI.Page
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
            Response.Write("<script>alert('"+companyDropDownList.SelectedValue+"');</script>");


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
            IDHiddenField.Value = itemID.ToString();
        }

        protected void stockInSaveButton_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            item.StockIn = Convert.ToInt32(quantityTextBox.Text) + Convert.ToInt32(stockQuantityTextBox.Text);
            item.ItemId = Convert.ToInt32(IDHiddenField.Value);
            if (itemSetupBll.UpdateQuantity(item) > 0)
            {
                quantityTextBox.Text = item.StockIn.ToString();
                stockQuantityTextBox.Text = null;
            }
        }
    }
}