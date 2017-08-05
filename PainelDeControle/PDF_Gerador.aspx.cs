using System;
using System.IO;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class PDF_Gerador : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //recebe, via url, string com conteúdo a ser transformado em PDF (em formato HTML)
        string txtHtml = Request.QueryString["v1"];
        MontaPDF(txtHtml);
    }

    private void MontaPDF(string HtmlTxt)
    {

        HtmlForm form = new HtmlForm();
        Document document = new Document(PageSize.A4, 20, 20, 20, 20);
        MemoryStream ms = new MemoryStream();
        PdfWriter writer = PdfWriter.GetInstance(document, ms);
        HTMLWorker obj = new HTMLWorker(document);

        StringReader se = new StringReader(HtmlTxt);
        document.Open();
        obj.Parse(se);
        document.Close();
        Response.Clear();

        Response.AddHeader("content-disposition", "filename=NomedoMeuArquivo.pdf");  //vizualiza em tela
        //Response.AddHeader("content-disposition", "attachment;filename=NomedoMeuArquivo.pdf");  // download direto

        Response.ContentType = "application/pdf";
        Response.Buffer = true;
        Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
        Response.OutputStream.Flush();
        Response.End();

    }

}