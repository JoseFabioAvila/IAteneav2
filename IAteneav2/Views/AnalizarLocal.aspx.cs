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


        protected void Page_Load(object sender, EventArgs e)
        {
            inst.checkDirectory(Server.MapPath("/docs"));
        }

        protected void analizarEnDisco(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                FileInfo Finfo = new FileInfo(FileUploadControl.PostedFile.FileName);
                try
                {
                    if (Finfo.Extension.ToLower() == ".docx" || Finfo.Extension.ToLower() == ".doc")
                    {
                        if (FileUploadControl.PostedFile.ContentLength < 102400)
                        {
                            string filename = Path.GetFileName(FileUploadControl.FileName);
                            FileUploadControl.SaveAs(Server.MapPath("~/docs/") + filename);
                            string x = inst.OpenWordprocessingDocumentReadonly(Server.MapPath("~/docs/") + filename);
                            //TextBox1.Text += x;
                            Logic.NaiveBayes naiveBayes = new Logic.NaiveBayes(x);

                            TextBox1.Text += "\nUpload status: File uploaded!\n";

                            TextBox1.Text += "\n-------> DataBase information: \n";
                            TextBox1.Text += "\n              Spanish words: " + naiveBayes.Res.tpEsp;
                            TextBox1.Text += "\n              English words: " + naiveBayes.Res.tpIng;
                            TextBox1.Text += "\n              French  words: " + naiveBayes.Res.tpFrn;
                            TextBox1.Text += "\n              German  words: " + naiveBayes.Res.tpAlm;
                            TextBox1.Text += "\n\n-------> And: \n";
                            TextBox1.Text += "\n              Sports     words: " + naiveBayes.Res.tpEcn;
                            TextBox1.Text += "\n              Health     words: " + naiveBayes.Res.tpDep;
                            TextBox1.Text += "\n              Tecnologia words: " + naiveBayes.Res.tpTec;
                            TextBox1.Text += "\n              Economia    words: " + naiveBayes.Res.tpSld;
                            TextBox1.Text += "\n Total   words: " + naiveBayes.Res.tPalabras;
                            
                            TextBox1.Text += "\n\n-------> Read text recognized: \n";
                            TextBox1.Text += "\n              Spanish words: " + naiveBayes.Res.tplEsp;
                            TextBox1.Text += "\n              English words: " + naiveBayes.Res.tplIng;
                            TextBox1.Text += "\n              French  words: " + naiveBayes.Res.tplFrn;
                            TextBox1.Text += "\n              German  words: " + naiveBayes.Res.tplAlm;
                            TextBox1.Text += "\n\n-------> And: \n";
                            TextBox1.Text += "\n              Sports     words: " + naiveBayes.Res.tplEcn;
                            TextBox1.Text += "\n              Health     words: " + naiveBayes.Res.tplDep;
                            TextBox1.Text += "\n              Tecnologia words: " + naiveBayes.Res.tplTec;
                            TextBox1.Text += "\n              Economia   words: " + naiveBayes.Res.tplSld;

                            TextBox1.Text += "\n\n-------> Category analysis: \n";
                            TextBox1.Text += "\n              English: " + naiveBayes.Res.propIngles + "%";
                            TextBox1.Text += "\n              Spanish: " + naiveBayes.Res.propEspañol + "%";
                            TextBox1.Text += "\n              French:  " + naiveBayes.Res.propFrances + "%";
                            TextBox1.Text += "\n              German:  " + naiveBayes.Res.propAleman + "%";
                            TextBox1.Text += "\n\n-------> And: \n";
                            TextBox1.Text += "\n              Sports:     " + naiveBayes.Res.probDeportes+"%";
                            TextBox1.Text += "\n              Health:     " + naiveBayes.Res.probEconomia + "%";
                            TextBox1.Text += "\n              Tecnologia: " + naiveBayes.Res.probSalud + "%";
                            TextBox1.Text += "\n              Economia:   " + naiveBayes.Res.probTecnologia + "%";
                            
                        }
                        else
                            TextBox1.Text += "\n\nUpload status: The file has to be less than 100 kb!\n";
                    }
                    else
                        TextBox1.Text += "Upload status: Only JPEG files are accepted!\n";
                }
                catch (Exception ex)
                {
                    TextBox1.Text += "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            //TextBox1.Text = ""; //borrar luego
        }

        protected void guardar(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                FileInfo Finfo = new FileInfo(FileUploadControl.PostedFile.FileName);
                try
                {
                    if (Finfo.Extension.ToLower() == ".docx" || Finfo.Extension.ToLower() == ".doc")
                    {
                        if (FileUploadControl.PostedFile.ContentLength < 102400)
                        {
                            string filename = Path.GetFileName(FileUploadControl.FileName);
                            FileUploadControl.SaveAs(Server.MapPath("~/docs/") + filename);
                            
                            String txt = inst.OpenWordprocessingDocumentReadonly(Server.MapPath("~/docs/") + filename);
                            Logic.RecopiladorDePalabras rec = new Logic.RecopiladorDePalabras(txt);

                            TextBox1.Text += "\nUpload status: File uploaded!";
                            TextBox1.Text += "\n\n The software detected: \n";
                            TextBox1.Text += "\n              Spanish words: " + rec.legCount[0];
                            TextBox1.Text += "\n              English words: " + rec.legCount[1];
                            TextBox1.Text += "\n              French  words: " + rec.legCount[2];
                            TextBox1.Text += "\n              German  words: " + rec.legCount[3];

                            TextBox1.Text += "\n              Swimming words: " + rec.catCount[0];
                            TextBox1.Text += "\n              Soccer   words: " + rec.catCount[1];
                            TextBox1.Text += "\n              Baseball words: " + rec.catCount[2];
                            TextBox1.Text += "\n              Chess    words: " + rec.catCount[3];
                        }
                        else
                            TextBox1.Text += "\n\nUpload status: The file has to be less than 100 kb!\n";
                    }
                    else
                        TextBox1.Text += "Upload status: Only JPEG files are accepted!\n";
                }
                catch (Exception ex)
                {
                    TextBox1.Text += "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            //TextBox1.Text = ""; //borrar luego
        }
    }
}