using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IAteneav2.Views
{
    public partial class AnalizarTexto : System.Web.UI.Page
    {
        Logic.AnalzarTextos ins = new Logic.AnalzarTextos();

        LinkedList<string> palabras = new LinkedList<string>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AnalizarTxt_Click(object sender, EventArgs e)
        {
            palabras.Clear();
            palabras = ins.palabrasTexto(TextBox2.Text);
            String x = "";
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
    }
}