using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IAteneav2
{
    /// <summary>
    /// vista de analizador de websites
    /// </summary>
    public partial class _Default : Page
    {
        //lista de urls
        LinkedList<Clases.WebSite> urls = new LinkedList<Clases.WebSite>();

        //instancia del controlador de websites
        Controllers.CWebSites insWebsites = new Controllers.CWebSites();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false) //Se carga por primera vez
            {
                //urls.AddLast("https://es.wikipedia.org/wiki/Eduard_Jil");
                urls = insWebsites.getWebSites();

                for (int i = 0; i < urls.Count; i++)
                {
                    ListaWebsites.Items.Add(urls.ElementAt(i).Url.ToString());
                }
            }
            else  //es respeusta de un evente como el de un boton
            {
                urls.Clear();
                ListaWebsites.Items.Clear();
                urls = insWebsites.getWebSites();

                for (int i = 0; i < urls.Count; i++)
                {
                    ListaWebsites.Items.Add(urls.ElementAt(i).Url.ToString());
                }
            }
            //Sirve para evitar que se caiga al xDDD
            ListaWebsites.SelectedIndex = 0;
        }

        /// <summary>
        /// Accion click del boton agregar un website 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AgregarSitio_Click(object sender, EventArgs e)
        {
            TextBox1.Text = ""; //borrar luego
            if (UrlText.Text == "")
            {

            }
            else
            {
                //urls.AddLast(UrlText.Text);
                bool agregado = insWebsites.agregarWebSite(UrlText.Text);
                if (!agregado)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error al agregar el website')", true);
                    return;
                }
                else {
                    ListaWebsites.Items.Add(UrlText.Text);
                }
            }
        }

        /// <summary>
        /// Accion click del boton quitar un website 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void QuitarSitio_Click(object sender, EventArgs e)
        {
            TextBox1.Text = ""; //borrar luego
            //urls.Remove(ListaWebsites.SelectedItem.Text);
            if (ListaWebsites.SelectedIndex > -1)
            {
                bool quitado = insWebsites.quitarWebSite(ListaWebsites.SelectedItem.Text);
                if (!quitado)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error al quitar el website')", true);
                    TextBox1.Text = "hola";
                    return;
                }
                ListaWebsites.Items.RemoveAt(ListaWebsites.SelectedIndex);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes seleccionar algun website para quitar')", true);
            }
        }


        /// <summary>
        /// analiza en un web site en especifico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void analizarEnTodos(object sender, EventArgs e)
        {
            TextBox1.Text = ""; //borrar luego
            string text = "";
            for (int i = 0; i < urls.Count; i++)
            {
                TextBox1.Text += "///////////////////////////////////////////////////////////\n\n\n";

                Logic.AnalizarWebsites inst = new Logic.AnalizarWebsites();
                LinkedList<String> lista = inst.genListaP(urls.ElementAt(i).Url.ToString());
                
                foreach (string word in lista)
                {
                    text += word + "\n";
                }
            }
            analisis(text);
        }

        /// <summary>
        /// analiza en todos los sitios web de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void analizarEnSite(object sender, EventArgs e)
        {

            // Is anything selected? The index is -1 if nothing is selected.
            if (ListaWebsites.SelectedItem != null)
            {
                Logic.AnalizarWebsites inst = new Logic.AnalizarWebsites();
                //TextBox1.Text = inst.Parsing(ListaWebsites.SelectedItem.Text);
                LinkedList<String> lista = inst.genListaP(ListaWebsites.SelectedItem.Text);
                string text = "";
                foreach (string word in lista)
                {
                    text += word + " "; // "\n\n";
                }
                analisis(text);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes seleccionar algun website para analizar')", true);
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