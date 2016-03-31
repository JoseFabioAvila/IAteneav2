using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace IAteneav2.Views
{
    public partial class Results : System.Web.UI.Page
    {

        Logic.AnalzarDisco inst = new Logic.AnalzarDisco();
        LinkedList<string> list;

        protected void Page_Load(object sender, EventArgs e)
        {
            inst.checkDirectory(Server.MapPath("/docs"));
            
        }

        private void imprimir(LinkedList<string> archivos)
        {
            foreach(string archivo in archivos)
            {
                TextBox1.Text += archivo + "\n\n";
                TextBox1.Text += inst.leerArchivo(archivo) + "\n\n";
            }

        }

        private void imprimirLista()
        {
            LinkedList<string> palabras = inst.palabrasDirectorios;
            TextBox1.Text += "\n\n\n\n\n";
            foreach (string palabra in palabras)
            {
                TextBox1.Text += palabra + "\n";
            }
        }

        protected void analizarEnDisco(object sender, EventArgs e)
        {
            string path = TextBox2.Text;
            list = inst.genListFromDirectory(path);
            imprimir(list);
            imprimirLista();
        }

    }
}


//if (FileUploadControl.HasFile)
//{
//    FileInfo Finfo = new FileInfo(FileUploadControl.PostedFile.FileName);
//    try
//    {
//        if (Finfo.Extension.ToLower() == ".docx" || Finfo.Extension.ToLower() == ".doc")
//        {
//            if (FileUploadControl.PostedFile.ContentLength < 102400)
//            {

//                string filename = Path.GetFileName(FileUploadControl.FileName);
//                FileUploadControl.SaveAs(Server.MapPath("~/docs/") + filename);
//                TextBox1.Text += "Upload status: File uploaded!\n\n";
//                TextBox1.Text += inst.OpenWordprocessingDocumentReadonly(Server.MapPath("~/docs/") + filename);
//            }
//            else
//                TextBox1.Text += "\n\nUpload status: The file has to be less than 100 kb!\n";
//        }
//        else
//            TextBox1.Text += "Upload status: Only JPEG files are accepted!\n";
//    }
//    catch (Exception ex)
//    {
//        TextBox1.Text += "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
//    }
//}
//TextBox1.Text = ""; //borrar luego