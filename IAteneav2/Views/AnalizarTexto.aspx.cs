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

            foreach (string palabra in palabras)
            {
                TextBox1.Text += palabra + "\n\n";
            }
        }
    }
}