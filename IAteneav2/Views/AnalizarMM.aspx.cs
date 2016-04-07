using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IAteneav2.Views
{
    public partial class AnalizarMM : System.Web.UI.Page
    {
        LinkedList<string> lista = new LinkedList<string>();
        Logic.AnalizarComprimidos ins = new Logic.AnalizarComprimidos();



        protected void Page_Load(object sender, EventArgs e)
        {
            ins.checkDirectory(@"C:\comprimidos");
        }

        protected void analizarArchivosMM(object sender, EventArgs e)
        {
            //D:\OneDrive\twitter-stream-2011-09-27.zip

            //descomprime archivos zip
            lista = ins.openExistingZipFile(TextBox2.Text);
            imprimir();

        }

        protected void analizarArchivosMM2(object sender, EventArgs e)
        {
            //D:\OneDrive\twitter-stream-2011-09-27.zip

            //descomprime archivos zip
            lista = ins.openExistingZipFile(TextBox2.Text);
            imprimir2();

        }

        private void imprimir()
        {
            string x ="";
            if(lista != null) {
                foreach (string palabra in lista)
                {
                    x += palabra + " ";
                }
            }
            analisis(x);
        }

        private void imprimir2()
        {
            if (lista != null)
            {
                foreach (string palabra in lista)
                {
                    TextBox1.Text += palabra + "\n";
                }
            }
        }

        private void analisis(String x)
        {
            Logic.NaiveBayes naiveBayes = new Logic.NaiveBayes(x);
            Logic.Aprendizaje claseAprender = new Logic.Aprendizaje(naiveBayes);
            TextBox1.Text = claseAprender.Print;
        }
    }
}