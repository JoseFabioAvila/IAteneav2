using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Clases
{
    public class Palabra
    {
        private int ID;
        private string palabra;
        private int Idioma;

        public Palabra(int id, string palabra, int idioma)
        {
            this.ID = id;
            this.palabra = palabra;
            this.Idioma = idioma;
        }

        public Palabra() { }

        public void setId(int ID)
        {
            this.ID = ID;
        }

        public int getId()
        {
            return this.ID;
        }

        public void setPalabra(String palabra)
        {
            this.palabra = palabra;
        }

        public String getPalabra()
        {
            return this.palabra;
        }

        public void setIdioma(int idioma)
        {
            this.Idioma = idioma;
        }

        public int getIdioma()
        {
            return this.Idioma;
        }
    }
}