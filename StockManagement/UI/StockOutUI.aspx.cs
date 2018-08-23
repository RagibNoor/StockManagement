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
        int stockOut;
        List<Item> items = new List<Item>(); 
        Item item = new Item();
        ItemSetupBLL itemSetupBll = new ItemSetupBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                companyDropDownList.DataSource = itemSetupBll.GetCompanies();
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "CompanyId";
                companyDropDownList.DataBind();
                stockOutGridView.DataSource = items;
                stockOutGridView.DataBind();

                if (CompanyHiddenField.Value != Request.Form[companyDropDownList.UniqueID])
                {
                    companyDropDownList_SelectedIndexChanged(sender, e);
                    CompanyHiddenField.Value = Request.Form[companyDropDownList.UniqueID];
                }
                stockOutAddButton.Enabled = false;
                sellButton.Enabled = false;
                damageButton.Enabled = false;
                lostButton.Enabled = false;
                
            }
           // stockOutAddButton.Enabled = false;
           

        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Response.Write("<script>alert('" + companyDropDownList.SelectedValue + "');</script>");


            itemDropDownList.DataSource = itemSetupBll.GetItems(companyDropDownList.SelectedValue);
            itemDropDownList.DataTextField = "ItemName";
            itemDropDownList.DataValueField = "ItemId";
            itemDropDownList.DataBind();
            quantityTextBox.Text = null;
            reorderLevelTextBox.Text = null;
        }

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemDropDownList.SelectedItem.Text != "----Select----")
            {
                stockOutQuantityTextBox.Enabled = true;
                int itemID = Convert.ToInt32(itemDropDownList.SelectedValue);
                int avaialableQuantity = itemSetupBll.GetQuantity(itemID);
                Item item = itemSetupBll.GetReorderAndAmmount(itemID);
                reorderLevelTextBox.Text = item.Reorder.ToString();
                quantityTextBox.Text = avaialableQuantity.ToString();
                if (avaialableQuantity < 1)
                {
                    stockOutQuantityTextBox.Enabled = false;
                }
                IDHiddenField.Value = itemID.ToString();
            }
           
            
        }

        protected void stockOutAddButton_Click(object sender, EventArgs e)
        {
            int flag = 0;

            if (ViewState["itemList"] != null)
            {
                items = (List<Item>) ViewState["itemList"];
            }
            foreach (var itemID in items)
            {
                if (itemID.ItemId == Convert.ToInt32(IDHiddenField.Value))
                {
                    itemID.StockOut += Convert.ToInt32(stockOutQuantityTextBox.Text);
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                item.ItemName = itemDropDownList.SelectedItem.Text;
                item.ItemId = Convert.ToInt32(IDHiddenField.Value);
                item.CompanyName = companyDropDownList.SelectedItem.Text;
                item.StockOutDate = System.DateTime.Today.ToString("yyyy-MM-dd");
                item.StockOut = Convert.ToInt32(stockOutQuantityTextBox.Text);
                int availableQuantity = Convert.ToInt32(quantityTextBox.Text);
                item.StockIn = availableQuantity - item.StockOut;

                items.Add(item);
            }
            
            //if (itemSetupBll.UpdateQuantity(item) > 0)
            //{
            //    quantityTextBox.Text = item.StockIn.ToString();
            //    stockOutQuantityTextBox.Text = null;
            //}
         
            ViewState["itemList"] = items;

            stockOutGridView.DataSource = items;
            stockOutGridView.DataBind();
            sellButton.Enabled = true;
            damageButton.Enabled = true;
            lostButton.Enabled = true;

        }

        protected void stockOutQuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ViewState["itemList"] != null)
            {
                items = (List<Item>)ViewState["itemList"]; 
            }
            
            int temp = 0;
            foreach (var data in items)
            {
                if (data.ItemId == Convert.ToInt32(IDHiddenField.Value))
                {
                    temp = data.StockOut;
                }
                
            }
            if (int.TryParse(stockOutQuantityTextBox.Text, out stockOut))
            {
                stockOutAddButton.Enabled = false;
                int availableQuantity = Convert.ToInt32(quantityTextBox.Text);

                if (availableQuantity >= stockOut+temp)
                {

                    stockOutAddButton.Enabled = true;
                }
                else
                {
                    Response.Write("<script>alert('error');</script>");
                }
            }
        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            
            items = (List<Item>)ViewState["itemList"];

            if (itemSetupBll.StockOut(items, "s") > 0)
            {
                SaveSuccessful();
            }


        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            items = (List<Item>)ViewState["itemList"];

            if (itemSetupBll.StockOut(items, "d") > 0)
            {
                SaveSuccessful();
            }

        }

        protected void SaveSuccessful()
        {
            Response.Write("<script>alert('Save');</script>");
            ViewState["itemList"] = null;
            stockOutGridView.DataSource = null;
            stockOutGridView.DataBind();
            int avaialableQuantity = itemSetupBll.GetQuantity(Convert.ToInt32(IDHiddenField.Value));
            quantityTextBox.Text = avaialableQuantity.ToString();
            stockOutQuantityTextBox.Text = null;
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            items = (List<Item>)ViewState["itemList"];

            if (itemSetupBll.StockOut(items, "l") > 0)
            {
                SaveSuccessful();
            }

        }
    }
}