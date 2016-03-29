using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Clases
{
    public class DifinidorDeIdioma
    {
        private int id;
        private string palabra;
        private int idioma;

        public int Id
        {
            get {return id;}
            set {id = value;}
        }

        public string Palabra
        {
            get {return palabra; }
            set { palabra = value;}
        }

        public int Idioma
        {
            get {return idioma;}
            set {idioma = value;}
        }

        public DifinidorDeIdioma(int id, String palabra, int idioma)
        {
            this.id = id;
            this.palabra = palabra;
            this.idioma = idioma;
        }

        public DifinidorDeIdioma() { }
    }
}