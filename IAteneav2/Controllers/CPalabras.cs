using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Controllers
{
    public class CPalabras
    {
        Models.MPalabras ins = new Models.MPalabras();
        Models.MIdiomas leng = new Models.MIdiomas();

        public Clases.Palabra[] getPalabras()
        {
            return ins.Selectall();
        }

        public bool agregarPalabra(string palabra, int i)
        {
            Clases.Idioma idioma = leng.Select(i);
            return ins.agregarPalabra(palabra,idioma);
        }
    }
}