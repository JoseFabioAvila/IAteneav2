using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IAteneav2.Views
{
    public partial class AnalizarFacebook : System.Web.UI.Page
    {
        Logic.FacebookPosts ins = new Logic.FacebookPosts();

        LinkedList<string> lista = new LinkedList<string>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

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