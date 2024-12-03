using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
using System.Net;
using System.Web.Configuration;


namespace Spirit_Business_Proposal
{
    public partial class download : System.Web.UI.Page
    {
       // String NewName = FrontPage.CompanyName;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            String NewName = Request.QueryString["CompName12345"];
            company_name_p.Text = NewName;
        }
        public void ExportPDf(object sender, EventArgs e)
        {
            
            String NewName = Request.QueryString["CompName12345"];
            String randomnumber = Request.QueryString["randmValue"];
            string PathofAllTheFiles = WebConfigurationManager.AppSettings["PathofAllTheFiles"];
            
            if (File.Exists(PathofAllTheFiles + "OutputPdfToDownload/" + NewName + randomnumber + "SpiritBusinessProposal.pdf"))
            {
                Response.Clear();

                string strLocalFilePath = PathofAllTheFiles + "OutputPdfToDownload/" + NewName + randomnumber + "SpiritBusinessProposal.pdf";
                string fileName = NewName + " - Segra Business Proposal.pdf";
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.AddHeader("Content-Disposition", "attachment; filename=" + fileName /*+ ";"*/);
                Response.TransmitFile(strLocalFilePath);

                Response.End();
            }
            else {
                Response.Write("<script>window.confirm(' File is not Present: Is been deleted or not Created'); if (confirm('Go to Front Page!') == true) {var src = 'FrontPage.aspx'; window.location.replace(src);} else {txt = 'You pressed Cancel!';} </script>");
                
            }
        }
    }
}