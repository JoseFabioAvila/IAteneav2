using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Controllers
{
    public class CCategorias
    {
        private Models.MCategorias ins = new Models.MCategorias();

        public LinkedList<Clases.Categoria> getCategorias()
        {
            LinkedList<Clases.Categoria> lista = new LinkedList<Clases.Categoria>();
            lista = ins.getCategorias();
            return lista;
        }

        public bool agregarCategoria(string categoria)
        {
            return ins.agregarCategoria(categoria);
        }
    }
}