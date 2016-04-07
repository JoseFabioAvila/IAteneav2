using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IAteneav2.Views
{
    /// <summary>
    /// vista de analizar archivos de mensajes masivos
    /// </summary>
    public partial class AnalizarMM : System.Web.UI.Page
    {
        //lista de palabras
        LinkedList<string> lista = new LinkedList<string>();

        //instancia de AnalizarComprimidos
        Logic.AnalizarComprimidos ins = new Logic.AnalizarComprimidos();



        protected void Page_Load(object sender, EventArgs e)
        {
            ins.checkDirectory(@"C:\comprimidos");
        }

        /// <summary>
        /// accion del boton analizar archivos de mensajes masivos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void analizarArchivosMM(object sender, EventArgs e)
        {
            //D:\OneDrive\twitter-stream-2011-09-27.zip

            //descomprime archivos zip
            lista = ins.openExistingZipFile(TextBox2.Text);
            imprimir();

        }

        private void imprimir()
        {
            if(lista != null) {
                foreach (string palabra in lista)
                {
                    TextBox1.Text += palabra + "\n";
                }
            }
        }
    }
}