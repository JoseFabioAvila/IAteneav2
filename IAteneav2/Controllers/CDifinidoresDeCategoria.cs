using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Controllers
{
    public class CDifinidoresDeCategoria
    {
        private Models.MDifinidoresDeCategoria ins = new Models.MDifinidoresDeCategoria();

        public LinkedList<Clases.DifinidorDeCategoria> getDifinidoresDeCategoria()
        {
            LinkedList<Clases.DifinidorDeCategoria> lista = new LinkedList<Clases.DifinidorDeCategoria>();
            lista = ins.getDifinidoresDeCategoria();
            return lista;
        }

        public bool agregarDifinidorDeCategoria(int palabra, int categoria)
        {
            return ins.agregarDifinidorDeCategoria(palabra, categoria);
        }
    }
}