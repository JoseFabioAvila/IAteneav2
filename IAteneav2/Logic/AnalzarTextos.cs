using System;
using System.Collections.Generic;

namespace IAteneav2.Logic
{
    /// <summary>
    /// Clase que contiene todos lo necesario para crear la lista de palabras del texto introducido en la vista
    /// </summary>
    public class AnalzarTextos
    {
        /// <summary>
        /// funcion que crear la lista de palabras del texto
        /// </summary>
        /// <param name="texto">texto que contiene las palabras</param>
        /// <returns>lista de palabras</returns>
        public LinkedList<string> palabrasTexto(string texto)
        {
            LinkedList<string> listaPalabras = new LinkedList<string>();
            string[] palabras = texto.Split(new char[] { '¿', '¡', ' ', '.', '%', '*', '+', ':', '_', '–', '-', '~', '¿', '?', '|', '!', '<', '>', '/', '\'', '=', '{', '}', '[', ']', ';', ',', '"', '(', ')', '$', '^', '@', '#', '&', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string palabra in palabras)
            {
                listaPalabras.AddLast(palabra);
            }
            return listaPalabras;
        }
    }
}