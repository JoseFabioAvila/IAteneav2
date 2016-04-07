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
        LinkedList<string> directorios = new LinkedList<string>();
        LinkedList<string> palabras = new LinkedList<string>();


        protected void Page_Load(object sender, EventArgs e)
        {
            inst.checkDirectory(Server.MapPath("/docs"));
        }


        private void imprimir(LinkedList<string> archivos)
        {
            foreach (string archivo in archivos)
            {
                TextBox1.Text += archivo + "\n\n";
                TextBox1.Text += inst.leerArchivo(archivo) + "\n\n";
            }

        }

        private void imprimirLista()
        {
            string x = "";
            palabras = inst.palabrasDirectorios;
            TextBox1.Text += "\n\n\n\n\n";
            foreach (string palabra in palabras)
            {
                x += palabra + " ";
            }
            analisis(x);
        }

        private void analisis(String x)
        {
            Logic.NaiveBayes naiveBayes = new Logic.NaiveBayes(x);
            Logic.Aprendizaje claseAprender = new Logic.Aprendizaje(naiveBayes);
            TextBox1.Text = claseAprender.Print;
        }

        protected void analizarEnDisco(object sender, EventArgs e)
        {
            string path = TextBox2.Text;
            directorios = inst.genListFromDirectory(path);
            imprimir(directorios);
            imprimirLista();
        }


    }
}