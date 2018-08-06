﻿using System;
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
                companyDropDownList.DataValueField = "CompanyId";
                companyDropDownList.DataBind();
                if (companyHiddenField.Value != Request.Form[companyDropDownList.UniqueID])
                {
                    companyDropDownList_SelectedIndexChanged(sender, e);
                    companyHiddenField.Value = Request.Form[companyDropDownList.UniqueID];
                }
            }

           
            ;
        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Response.Write("<script>alert('"+companyDropDownList.SelectedValue+"');</script>");


            itemDropDownList.DataSource = itemSetupBll.GetItems(companyDropDownList.SelectedValue);
            itemDropDownList.DataTextField = "ItemName";
            itemDropDownList.DataValueField = "ItemId";
            itemDropDownList.DataBind();

            quantityTextBox.Text = null;
            reorderLevelTextBox.Text = null;

            //if (ItemHiddenField.Value != Request.Form[itemDropDownList.UniqueID])
            //{
            //    itemDropDownList_SelectedIndexChanged(sender,e);
            //    ItemHiddenField.Value = Request.Form[itemDropDownList.UniqueID];
            //}

        }

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemDropDownList.SelectedItem.Text != "----Select----")
            {
                int itemID = Convert.ToInt32(itemDropDownList.SelectedValue);
                Item item = itemSetupBll.GetReorderAndAmmount(itemID);
                reorderLevelTextBox.Text = item.Reorder.ToString();
                quantityTextBox.Text = item.StockIn.ToString();
                IDHiddenField.Value = itemID.ToString();
            }
            
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