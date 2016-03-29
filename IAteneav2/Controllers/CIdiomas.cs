using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Controllers
{
    public class CIdiomas
    {
        private Models.MIdiomas ins = new Models.MIdiomas();

        public LinkedList<Clases.Idioma> getIdiomas()
        {
            LinkedList<Clases.Idioma> lista = new LinkedList<Clases.Idioma>();
            lista = ins.getIdiomas();
            return lista;
        }

        public bool agregarPalabra(string idioma)
        {
            return ins.agregarIdioma(idioma);
        }
    }
}