using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IAteneav2
{
    public partial class _Default : Page
    {
        LinkedList<Clases.WebSite> urls = new LinkedList<Clases.WebSite>();


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
            ListaWebsites.SelectedIndex = 2;
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


        protected void analizarEnTodos(object sender, EventArgs e)
        {
            TextBox1.Text = ""; //borrar luego
            // Is anything selected? The index is -1 if nothing is selected.
            if (ListaWebsites.SelectedIndex > -1)
            {
                Logic.AnalizarWebsites inst = new Logic.AnalizarWebsites();
                String text = inst.getHTMLFrom(ListaWebsites.SelectedItem.Text);
                TextBox1.Text = text;

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes seleccionar algun website para analizar')", true);
            }
        }

        protected void analizarEnSite(object sender, EventArgs e)
        {
            TextBox1.Text = ""; //borrar luego


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
                TextBox1.Text = text;

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debes seleccionar algun website para analizar')", true);
            }

        }

    }
}