using Facebook;
using System;
using System.Collections.Generic;

namespace IAteneav2.Logic
{
    /// <summary>
    /// Clase que contiene todos lo necesario para crear la lista de palabras de los posts de facebook
    /// </summary>
    public class FacebookPosts
    {

        /// <summary>
        /// Toma los posts de la cuenta de facebook y mete cada una de las palabras de una lista de palabras
        /// </summary>
        /// <returns>lista de palabras</returns>
        public LinkedList<string> getFacebookPosts()
        {
            try
            {
                LinkedList<string> lista = new LinkedList<string>();
                var client = new FacebookClient("CAAOPIFhMpWUBAKhp0WOUM9h5g7ML6w86KbspZC0xD3S21wCcA4ig9wyZCStYpDLjr52UuRHonhbXNFzIiVY49mZBPaaH7lE3PMnRjjhKf04XHhoJILCEKLZAbsZCioUnMnzPlQmHefjldt59vH70kYWhQrCpYNrfIQCpP3dsxo7T4bImrdyWdEgCs6L2HjYIN6y52BfxoowZDZD");
                dynamic result = client.Get("/me/posts");

                //all the posts and their information is strored in result.data not in result
                string res = "";
                for (int i = 0; i < result.data.Count; i++)
                {
                    if (!object.ReferenceEquals(result.data[i].message, null))
                    {
                        res += result.data[i].message + "\n";
                    }
                }
                string[] words = res.Split(new char[] { '¿', '¡', ' ', '.', '%', '*', '+', ':', '_', '–', '-', '~', '¿', '?', '|', '!', '<', '>', '/', '\'', '=', '{', '}', '[', ']', ';', ',', '"', '(', ')', '$', '^', '@', '#', '&', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    lista.AddLast(word);
                }
                return lista;
            }
            catch
            {
                return null;
            }
        }
    }
}