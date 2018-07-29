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
    public partial class CategorySetupUI : System.Web.UI.Page
    {
        CategorySetupBLL categorySetupBll = new CategorySetupBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!this.IsPostBack)
            {
                UpdateBtn.Enabled = false;
                saveBtn.Enabled = true;
               
               
            }
            List<Category> categories = categorySetupBll.GetCategories();
            categoryGridView.DataSource = categories;
            categoryGridView.DataBind();
           
            
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = addCategoryTextBox.Text;
            if (string.IsNullOrEmpty(addCategoryTextBox.Text))
            {
                Response.Write("<script>alert('Input Field is Empty');</script>");
            }
            else
            {
                Response.Write("<script>alert('" + categorySetupBll.Save(category) + "');</script>");
            }

            
            List<Category> categories = categorySetupBll.GetCategories();
            categoryGridView.DataSource = categories;
            categoryGridView.DataBind();
        }

        protected void categoryGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = categoryGridView.SelectedRow;
            addCategoryTextBox.Text = ((Label) row.FindControl("categoryNameLabel")).Text;

            idHiddenField.Value = ((Label)row.FindControl("categoryIdLabel")).Text;
            UpdateBtn.Enabled = true;
            saveBtn.Enabled = false;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = addCategoryTextBox.Text;
            category.CategoryId = Convert.ToInt32(idHiddenField.Value);
            if (string.IsNullOrEmpty(addCategoryTextBox.Text))
            {
                Response.Write("<script>alert('Input Field is Empty');</script>");
            }
            else
            {
                if (categorySetupBll.Update(category) > 0)
                {
                    Response.Write("<script>alert('updated');</script>");
                }
            }

           
            List<Category> categories = categorySetupBll.GetCategories();
            categoryGridView.DataSource = categories;
            categoryGridView.DataBind();
            UpdateBtn.Enabled = false;
            saveBtn.Enabled = true;
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeUI.aspx");
        }

        

       

       
    }
}