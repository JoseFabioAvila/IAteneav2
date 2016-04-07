using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using System.Linq;

namespace IAteneav2.Logic
{
    /// <summary>
    /// Clase que contiene todos lo necesario para crear la lista de palabras de los web sites
    /// </summary>
    public class AnalizarWebsites
    {

        /// <summary>
        /// obtiene el html de un url
        /// </summary>
        /// <param name="url">pagina a obtener html</param>
        /// <returns>html de la pagina</returns>
        public String getHTMLFrom(string url)
        {
            string urlAddress = url;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string result = "";
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                result = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
            }

            return result;
        }


        /// <summary>
        /// parsea el html para que solo devuelva el contenido de la pagina en donde hay texto presentable al usuario y no metadatos
        /// </summary>
        /// <param name="website">html de la pagina web</param>
        /// <returns>Coleccion de nodos de html parseados</returns>
        public HtmlNodeCollection Parsing(string website)
        {
            var webGet = new HtmlWeb();
            var doc = webGet.Load(website);

            HtmlNodeCollection ourNode = new HtmlNodeCollection(null);
            //doc = ourNodeP.OwnerDocument;
            var xpath = "//div[@id='content']//*[self::h1 or self::h2 or self::p or self::li or self::th or self::td]";
            foreach (var node in doc.DocumentNode.SelectNodes(xpath))
            {
                ourNode.Add(node);
            }
            return ourNode;
        }

        /// <summary>
        /// genera la lista de palabras de la url de la pagina
        /// </summary>
        /// <param name="url">pagina web para tomar palabras</param>
        /// <returns>lista de palabras</returns>
        public LinkedList<String> genListaP(string url)
        {
            LinkedList<String> lista = new LinkedList<string>();

            HtmlNodeCollection pagina2 = Parsing(url);
            string pagina = "";
            foreach (HtmlNode pag in pagina2)
            {
                pagina += (" " + pag.InnerText);
            }
            string[] words2 = pagina.Split(new char[] { '¿', '¡', ' ', '.', '%', '*', '+', ':', '_', '–', '-', '~', '¿', '?', '|', '!', '<', '>', '/', '\'', '=', '{', '}', '[', ']', ';', ',', '"', '(', ')', '$', '^', '@', '#', '&', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words2)
            {
                lista.AddLast(word);
            }
            return lista;
        }
    }
}