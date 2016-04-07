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
    /// <summary>
    /// vista del analizador local de carpetas y archivos
    /// </summary>
    public partial class Results : System.Web.UI.Page
    {
        //instancia de la calse AnalizarDisco
        Logic.AnalzarDisco inst = new Logic.AnalzarDisco();

        //lista d riecciones 
        LinkedList<string> directorios = new LinkedList<string>();

        //lista de palabras
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
            palabras = inst.palabrasDirectorios;
            TextBox1.Text += "\n\n\n\n\n";
            foreach (string palabra in palabras)
            {
                TextBox1.Text += palabra + "\n";
            }
        }

        /// <summary>
        /// accion del boton analiza en carpetas o archivos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void analizarEnDisco(object sender, EventArgs e)
        {
            string path = TextBox2.Text;
            directorios = inst.genListFromDirectory(path);
            imprimir(directorios);
            imprimirLista();
        }


    }
}