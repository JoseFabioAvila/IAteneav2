using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Clases
{
    public class Palabra
    {
        private long ID;
        private string palabra;
        private Idioma Idioma;
        public Categoria Categoria { get; set; }

        public Palabra(long id, string palabra, int idioma, int categoria)
        {
            this.ID = id;
            this.palabra = palabra;
            Models.MIdiomas x = new Models.MIdiomas();
            this.Idioma = x.Select(idioma);
            Models.MCategorias z = new Models.MCategorias();
            this.Categoria = z.Select(categoria);
        }

        public Palabra(long id, string palabra, int idioma)
        {
            this.ID = id;
            this.palabra = palabra;
            Models.MIdiomas x = new Models.MIdiomas();
            this.Idioma = x.Select(idioma);

            this.Categoria = new Categoria(0,"Sin Categoria");
        }

        public Palabra() { }

        public void setId(long ID)
        {
            this.ID = ID;
        }

        public long getId()
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
            Models.MIdiomas x = new Models.MIdiomas();
            this.Idioma = x.Select(idioma);
        }

        public Idioma getIdioma()
        {
            return this.Idioma;
        }
    }
}