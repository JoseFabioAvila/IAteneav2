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
            ins.checkDirectory(@"C:\comprimidos");
        }

        protected void analizarArchivosMM(object sender, EventArgs e)
        {
            //D:\OneDrive\twitter-stream-2011-09-27.zip

            //descomprime archivos zip
            TextBox1.Text = ins.openExistingZipFile(TextBox2.Text);

            //descomprime archivos bz2
            ins.descomprimirBzip2(@"C:\comprimidos\27\19\48.json.bz2", @"C:\comprimidos\27\19\");

            //lee el contenido de un json
            //TextBox1.Text = ins.blabla(TextBox2.Text);

        }

    }
}