using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using StockManagement.BLL;

namespace StockManagement.UI
{
    public partial class ViewSalesUI : System.Web.UI.Page
    {

        ViewSalesBLL viewSalesBll = new ViewSalesBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void viewSearchItemButton_Click(object sender, EventArgs e)
        {
            string startDate = StartDate.Text;
            string endDate = EndDate.Text;
            //viewSearchItemGridView.DataSource = viewSalesBll.GetLessSellItem(startDate,endDate);
            //viewSearchItemGridView.DataBind();
            if (searchCheckBox.Checked)
            {

                viewSearchItemGridView.DataSource = viewSalesBll.GetsellItem(startDate, endDate);
                viewSearchItemGridView.DataBind();
            }
            else
            {
                viewSearchItemGridView.DataSource = viewSalesBll.GetLessSellItem(startDate, endDate);
                viewSearchItemGridView.DataBind();
            }
        }

        protected void DownloadBtn_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Sale.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            viewSearchItemGridView.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            viewSearchItemGridView.AllowPaging = true;
            viewSearchItemGridView.DataBind(); 
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }


        
    }
}