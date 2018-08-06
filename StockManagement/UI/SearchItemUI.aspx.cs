using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagement.BLL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace StockManagement.UI
{
    public partial class SearchItemUI : System.Web.UI.Page
    {
        private ItemSetupBLL itemSetupBll = new ItemSetupBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                companyDropDownList.DataSource = itemSetupBll.GetCompanies();
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataValueField = "CompanyId";
                companyDropDownList.DataBind();
                if (CompanyHiddenField.Value != Request.Form[companyDropDownList.UniqueID])
                {
                    companyDropDownList_SelectedIndexChanged(sender, e);
                    CompanyHiddenField.Value = Request.Form[companyDropDownList.UniqueID];
                }
            }


        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryDropDownList.DataSource = itemSetupBll.GetCategories();
            categoryDropDownList.DataTextField = "CategoryName";
            categoryDropDownList.DataValueField = "CategoryId";
            categoryDropDownList.DataBind();

        }

      

        protected void searchItemButton_Click(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
            int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            searchItemGridView.DataSource = itemSetupBll.GetSearchItems(companyId, categoryId);
            searchItemGridView.DataBind();

        }

        protected void DownLoad_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Item.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            searchItemGridView.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            searchItemGridView.AllowPaging = true;
            searchItemGridView.DataBind(); 
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}