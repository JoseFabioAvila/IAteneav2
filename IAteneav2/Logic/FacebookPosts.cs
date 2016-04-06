using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Logic
{
    public class FacebookPosts
    {

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
                string[] words = res.Split(new char[] { '¿', '¡', ' ', '.', '%', '*', '+', ':', '_', '–', '-', '~', '¿', '?', '|', '!', '<', '>', '/', '\'', '=', '{', '}', '[', ']', ';', ',', '"', '(', ')', '$', '^', '@', '#', '&', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }, StringSplitOptions.RemoveEmptyEntries);
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