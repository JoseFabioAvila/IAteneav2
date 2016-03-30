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

        private void imprimir(LinkedList<string> l)
        {
            foreach(string n in l)
            {
                TextBox1.Text += n + "\n\n";
                algo(n);
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
        }

        private void algo(string n)
        {
            if (n.Contains(".txt"))
            {
                string line = "";
                TextBox1.Text += "\n\n";
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(n);

                    //Read the first line of text
                    line = sr.ReadLine();

                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        //write the lie to console window
                        TextBox1.Text = line.ToString();
                        //Read the next line
                        line = sr.ReadLine();
                    }
                    TextBox1.Text += "\n\n";
                    //close the file
                    sr.Close();
                }
                catch (Exception e)
                {
                    TextBox1.Text += "\nerror xDDD\n";
                }
            }
            else if (n.Contains(".docx") || n.Contains(".docx"))
            {
                TextBox1.Text += "\n"+ inst.OpenWordprocessingDocumentReadonly(n) + "\n";
            }
            else
            {
                TextBox1.Text += "\nNo es leible\n";
            }
        }

        protected void analizarEnDisco(object sender, EventArgs e)
        {
            string path = TextBox2.Text;
            list = inst.genListFromDirectory(path);
            imprimir(list);


            //if (FileUploadControl.HasFile)
            //{
            //    FileInfo Finfo = new FileInfo(FileUploadControl.PostedFile.FileName);
            //    try
            //    {
            //        if (Finfo.Extension.ToLower() == ".docx" || Finfo.Extension.ToLower() == ".doc")
            //        {
            //            if (FileUploadControl.PostedFile.ContentLength < 102400)
            //            {
            //                TextBox1.Text += FileUploadControl.FileName + "\n";
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
        }

    }
}