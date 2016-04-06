using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Clases
{
    public class CargaRapida
    {
        String[] spltTxt;
        Models.MPalabras bd;

        public CargaRapida(String text, Idioma leng)
        {
            spltTxt = text.Split(new Char[] { ' ', '.', '%', '*', '+', ':', '_', '|', '!', '<', '>', '/', '=', '{', '}', '[', ']', ';', ',', '"', '(', ')', '#', '&'},
                                 StringSplitOptions.RemoveEmptyEntries);
            foreach(String temp in spltTxt)
            {
                bool r = bd.agregarPalabra(temp, leng);
            }
        }

    }
}