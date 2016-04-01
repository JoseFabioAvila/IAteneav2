using System;
using System.Collections.Generic;

namespace IAteneav2.Logic
{
    public class AnalzarTextos
    {
        public LinkedList<string> palabrasTexto(string texto)
        {
            LinkedList<string> listaPalabras = new LinkedList<string>();
            string[] palabras = texto.Split(new char[] { ' ', '.', '%', '*', '+', ':', '_', '–', '-', '~', '¿', '?', '|', '!', '<', '>', '/', '\'', '=', '{', '}', '[', ']', ';', ',', '"', '(', ')', '$', '^', '@', '#', '&', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string palabra in palabras)
            {
                listaPalabras.AddLast(palabra);
            }
            return listaPalabras;
        }
    }
}