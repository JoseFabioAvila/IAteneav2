using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Controllers
{
    public class CPalabras
    {
        Models.MPalabras ins = new Models.MPalabras();

        public LinkedList<Clases.Palabra> getPalabras()
        {
            LinkedList<Clases.Palabra> lista = new LinkedList<Clases.Palabra>();
            lista = ins.getPalabras();
            return lista;
        }

        public bool agregarPalabra(string palabra, int idioma)
        {
            return ins.agregarPalabra(palabra,idioma);
        }
    }
}