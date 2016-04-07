using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace IAteneav2.Views
{
    /// <summary>
    /// vista de analizador de facebook
    /// </summary>
    public partial class AnalizarFacebook : System.Web.UI.Page
    {
        //instancia a fecebook post 
        Logic.FacebookPosts ins = new Logic.FacebookPosts();

        //lista de palabras
        LinkedList<string> lista = new LinkedList<string>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// accion del boton de analizar en facebook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AnalizarFB_Click(object sender, EventArgs e)
        {
            lista = ins.getFacebookPosts();
            imprimir();
        }
        
        public void imprimir()
        {
            if (lista != null)
            {
                foreach (string palabra in lista)
                {
                    TextBox1.Text += palabra + "\n";
                }
            }
            else
            {
                TextBox1.Text = "error";
            }

        }
    }
}