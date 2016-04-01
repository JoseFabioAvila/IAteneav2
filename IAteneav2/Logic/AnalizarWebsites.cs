using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using System.Linq;

namespace IAteneav2.Logic
{
    public class AnalizarWebsites
    {
        private object listproduct;

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

        public HtmlNodeCollection Parsing(string website)
        {
            var webGet = new HtmlWeb();
            var doc = webGet.Load(website);

            //HtmlNode ourNodeP = doc.DocumentNode.SelectSingleNode("//div[@id='content']");
            //HtmlNode ourNode = doc.DocumentNode.SelectSingleNode("//p");
            //HtmlNodeCollection ourNode = doc.DocumentNode.SelectNodes("//p");

            //if (ourNode != null)
            //{
            //    //return ourNode.InnerText.ToString();
            //    return ourNode;
            //}
            //else
            //{
            //    //return "";
            //    return null;
            //}

            

            HtmlNodeCollection ourNode = new HtmlNodeCollection(null);
            //doc = ourNodeP.OwnerDocument;
            var xpath = "//div[@id='content']//*[self::h1 or self::h2 or self::p or self::li or self::th or self::td]";
            foreach (var node in doc.DocumentNode.SelectNodes(xpath))
            {
                ourNode.Add(node);
            }
            return ourNode;
        }

        public LinkedList<String> genListaP(string url)
        {
            LinkedList<String> lista = new LinkedList<string>();

            HtmlNodeCollection pagina2 = Parsing(url);
            string pagina = "";
            foreach (HtmlNode pag in pagina2)
            {
                pagina += (" " + pag.InnerText);
            }
            string[] words2 = pagina.Split(new char[] { ' ', '.', '%', '*', '+', ':', '_', '–', '-', '~', '¿', '?', '|', '!', '<', '>', '/', '\'', '=', '{', '}', '[', ']', ';', ',', '"', '(', ')', '$', '^', '@', '#', '&', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words2)
            {
                lista.AddLast(word);
            }
            return lista;
        }
    }
}