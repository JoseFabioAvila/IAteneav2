using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Clases
{
    public class DifinidorDeCategoria
    {
        private int id;
        private int categoria;

        public int Id
        {
            get{return id;}
            set {id = value;}
        }

        public int Categoria
        {
            get {return categoria;}
            set { categoria = value;}
        }

        public DifinidorDeCategoria(int id, int categoria)
        {
            this.id = id;
            this.categoria = categoria;
        }

        public DifinidorDeCategoria() { }
    }
}