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
    public partial class CompanySetupUI : System.Web.UI.Page
    {
        CompanySetupBLL companySetupBll = new CompanySetupBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Company> companies = companySetupBll.GetCompanies();
            CompanyGridView.DataSource = companies;
            CompanyGridView.DataBind();
            if (!this.IsPostBack)
            {
                UpdateCompanyBtn.Enabled = false;
                saveCompanyBtn.Enabled = true;
            }

        }

        protected void saveCompanyBtn_Click(object sender, EventArgs e)
        {
            Company company = new Company();
            company.CompanyName = addCompanyTextBox.Text;
            if (string.IsNullOrEmpty(addCompanyTextBox.Text))
            {
                Response.Write("<script>alert('Input Field is empty');</script>");
            }
            else
            {
                Response.Write("<script>alert('" + companySetupBll.Save(company) + "');</script>");
            }
           
            List<Company> companies = companySetupBll.GetCompanies();
            CompanyGridView.DataSource = companies;
            CompanyGridView.DataBind();
        }

        protected void CompanyGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = CompanyGridView.SelectedRow;
            addCompanyTextBox.Text = ((Label)row.FindControl("companyNameLabel")).Text;

            CompanyIdHiddenField.Value = ((Label)row.FindControl("companyIdLabel")).Text;
            UpdateCompanyBtn.Enabled = true;
            saveCompanyBtn.Enabled = false;
        }

        protected void UpdateCompanyBtn_Click(object sender, EventArgs e)
        {
           Company company = new Company();
            company.CompanyName = addCompanyTextBox.Text;
            company.CompanyId = Convert.ToInt32(CompanyIdHiddenField.Value);
            if (string.IsNullOrEmpty(addCompanyTextBox.Text))
            {
                Response.Write("<script>alert('Input Field is empty');</script>");
            }
            else
            {
                if (companySetupBll.Update(company) > 0)
                {
                    Response.Write("<script>alert('updated');</script>");
                } 
            }
           

            List<Company> companies = companySetupBll.GetCompanies();
            CompanyGridView.DataSource = companies;
            CompanyGridView.DataBind();
            UpdateCompanyBtn.Enabled = false;
            saveCompanyBtn.Enabled = true;
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeUI.aspx");
        }
    }
}