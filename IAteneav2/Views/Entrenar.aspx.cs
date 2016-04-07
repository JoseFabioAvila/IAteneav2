using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IAteneav2.Views
{
    public partial class Entrenar : System.Web.UI.Page
    {


        Logic.AnalzarDisco inst = new Logic.AnalzarDisco();




        protected void Page_Load(object sender, EventArgs e)
        {
            inst.checkDirectory("/docs");
        }



        protected void analizarEnDisco2(object sender, EventArgs e)
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
                            
                            TextBox1.Text += "\n-------> DataBase information: \n";
                            TextBox1.Text += "\n              Spanish words: " + naiveBayes.Res.tpEsp;
                            TextBox1.Text += "\n              English words: " + naiveBayes.Res.tpIng;
                            TextBox1.Text += "\n              French  words: " + naiveBayes.Res.tpFrn;
                            TextBox1.Text += "\n              German  words: " + naiveBayes.Res.tpAlm;
                            TextBox1.Text += "\n\n-------> And: \n";
                            TextBox1.Text += "\n              Sports     words: " + naiveBayes.Res.tpDep;
                            TextBox1.Text += "\n              Health     words: " + naiveBayes.Res.tpSld;
                            TextBox1.Text += "\n              Tecnology  words: " + naiveBayes.Res.tpTec;
                            TextBox1.Text += "\n              Economy    words: " + naiveBayes.Res.tpEcn;
                            TextBox1.Text += "\n Total   words: " + naiveBayes.Res.tPalabras;

                            TextBox1.Text += "\n\n-------> Read text recognized: \n";
                            TextBox1.Text += "\n              Spanish words: " + naiveBayes.Res.tplEsp;
                            TextBox1.Text += "\n              English words: " + naiveBayes.Res.tplIng;
                            TextBox1.Text += "\n              French  words: " + naiveBayes.Res.tplFrn;
                            TextBox1.Text += "\n              German  words: " + naiveBayes.Res.tplAlm;
                            TextBox1.Text += "\n\n-------> And: \n";
                            TextBox1.Text += "\n              Sports     words: " + naiveBayes.Res.tplDep;
                            TextBox1.Text += "\n              Health     words: " + naiveBayes.Res.tplSld;
                            TextBox1.Text += "\n              Tecnology  words: " + naiveBayes.Res.tplTec;
                            TextBox1.Text += "\n              Economy    words: " + naiveBayes.Res.tplEcn;
                            TextBox1.Text += "\n -> Known words      : " + ((float)naiveBayes.Res.knownWrd / (float)naiveBayes.Res.totalWrds * (float)100) + "%";
                            TextBox1.Text += "\n -> Unknown words    : " + ((float)naiveBayes.Res.unknownWrd.Count() / (float)naiveBayes.Res.totalWrds * (float)100) + "%";
                            TextBox1.Text += "\n -> Total words reade: " + naiveBayes.Res.totalWrds;

                            TextBox1.Text += "\n\n-------> Analysis Results: \n";
                            TextBox1.Text += "\n              English: " + naiveBayes.Res.propIngles + "%";
                            TextBox1.Text += "\n              Spanish: " + naiveBayes.Res.propEspañol + "%";
                            TextBox1.Text += "\n              French:  " + naiveBayes.Res.propFrances + "%";
                            TextBox1.Text += "\n              German:  " + naiveBayes.Res.propAleman + "%";
                            TextBox1.Text += "\n\n-------> And: \n";
                            TextBox1.Text += "\n              Sports:     " + naiveBayes.Res.probDeportes + "%";
                            TextBox1.Text += "\n              Health:     " + naiveBayes.Res.probSalud + "%";
                            TextBox1.Text += "\n              Tecnology:  " + naiveBayes.Res.probTecnologia + "%";
                            TextBox1.Text += "\n              Economy :   " + naiveBayes.Res.probEconomia + "%";

                            learnValidation(naiveBayes);
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

        private void learnValidation(Logic.NaiveBayes by)
        {
            int Español = 1, Ingles = 2, Frances = 3, Aleman = 4;
            int dep = 1, sld = 2, tec = 3, ecn = 4;

            TextBox1.Text += "\n\n";
            if (by.Res.propEspañol > 80.0)
            {
                if (by.Res.probDeportes > 50.0)
                {
                    TextBox1.Text += "\n ***** New words for Spanish language and category Sport *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Español, dep);
                }
                else if (by.Res.probSalud > 50.0)
                {
                    TextBox1.Text += "\n ***** New words for English language and category Health *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Español, sld);
                }
                else if (by.Res.probTecnologia > 50.0)
                {
                    TextBox1.Text += "\n ***** New words for French language and category Tecnology *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Español, tec);
                }
                else if (by.Res.probEconomia > 50.0)
                {
                    TextBox1.Text += "\n ***** New words for German language and category Economy *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Español, ecn);
                }
                else
                {
                    TextBox1.Text += "\n ***** New words for Spanish language *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Español);
                }
            }
            else if (by.Res.propIngles > 80.0)
            {
                if (by.Res.probDeportes > 50.0)
                {
                    TextBox1.Text += "\n ***** New words for Spanish language and category Sport *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Ingles, dep);
                }
                else if (by.Res.probSalud > 50.0)
                {
                    TextBox1.Text += "\n ***** New words for English language and category Health *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Ingles, sld);
                }
                else if (by.Res.probTecnologia > 50.0)
                {
                    TextBox1.Text += "\n ***** New words for French language and category Tecnology *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Ingles, tec);
                }
                else if (by.Res.probEconomia > 50.0)
                {
                    TextBox1.Text += "\n ***** New words for German language and category Economy *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Ingles, ecn);
                }
                else
                {
                    TextBox1.Text += "\n ***** New words for Spanish language *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Ingles);
                }
            }
            else if (by.Res.propFrances > 80.0)
            {
                if (by.Res.probDeportes > 50.0)
                {
                    TextBox1.Text += "\n ***** New words for Spanish language and category Sport *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Frances, dep);
                }
                else if (by.Res.probSalud > 50.0)
                {
                    TextBox1.Text += "\n ***** New words for English language and category Health *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Frances, sld);
                }
                else if (by.Res.probTecnologia > 50.0)
                {
                    TextBox1.Text += "\n ***** New words for French language and category Tecnology *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Frances, tec);
                }
                else if (by.Res.probEconomia > 50.0)
                {
                    TextBox1.Text += "\n ***** New words for German language and category Economy *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Frances, ecn);
                }
                else
                {
                    TextBox1.Text += "\n ***** New words for Spanish language *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Frances);
                }
            }
            else if (by.Res.propAleman > 80.0)
            {
                if (by.Res.probDeportes > 50.0)
                {
                    TextBox1.Text += "\n ***** New words for Spanish language and category Sport *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Aleman, dep);
                }
                else if (by.Res.probSalud > 50.0)
                {
                    TextBox1.Text += "\n ***** New words for English language and category Health *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Aleman, sld);
                }
                else if (by.Res.probTecnologia > 50.0)
                {
                    TextBox1.Text += "\n ***** New words for French language and category Tecnology *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Aleman, tec);
                }
                else if (by.Res.probEconomia > 50.0)
                {
                    TextBox1.Text += "\n ***** New words for German language and category Economy *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Aleman, ecn);
                }
                else
                {
                    TextBox1.Text += "\n ***** New words for Spanish language *****";
                    //new Logic.RecopiladorDePalabras(by.Res.unknownWrd,Aleman);
                }
            }
            
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

                            TextBox1.Text += "\n              Sports    words: " + rec.catCount[0];
                            TextBox1.Text += "\n              Health    words: " + rec.catCount[1];
                            TextBox1.Text += "\n              Tecnology words: " + rec.catCount[2];
                            TextBox1.Text += "\n              Economy   words: " + rec.catCount[3];
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