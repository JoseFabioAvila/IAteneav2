using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO.Compression;

namespace IAteneav2.Views
{
    public partial class AnalizarMM : System.Web.UI.Page
    {
        Logic.AnalizarComprimidos ins = new Logic.AnalizarComprimidos();



        protected void Page_Load(object sender, EventArgs e)
        {
            ins.checkDirectory(@"C:\Users\fabio\OneDrive\comprimidos");
        }

        protected void analizarArchivosMM(object sender, EventArgs e)
        {
            //ins.openExistingZipFile(@"C:\Users\fabio\OneDrive\twitter-stream-2011-09-27.zip");
            //TextBox1.Text = ins.openExistingZipFile(TextBox2.Text);
            TextBox1.Text = ins.blabla(TextBox2.Text);

        }

    }
}