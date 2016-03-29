using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Controllers
{
    public class CDifinidoresDeIdioma
    {
        private Models.MDifinidoresDeIdioma ins = new Models.MDifinidoresDeIdioma();

        public LinkedList<Clases.DifinidorDeIdioma> getDifinidoresDeIdioma()
        {
            LinkedList<Clases.DifinidorDeIdioma> lista = new LinkedList<Clases.DifinidorDeIdioma>();
            lista = ins.getDifinidoresDeIdioma();
            return lista;
        }

        public bool agregarDifinidorDeIdioma(string palabra, int idioma)
        {
            return ins.agregarDifinidorDeIdioma(palabra, idioma);
        }
    }
}