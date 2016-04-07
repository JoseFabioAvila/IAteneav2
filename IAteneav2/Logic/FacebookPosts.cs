using Facebook;
using System;
using System.Collections.Generic;

namespace IAteneav2.Logic
{
    public class FacebookPosts
    {
        public LinkedList<string> getFacebookPosts()
        {
            try
            {
                LinkedList<string> lista = new LinkedList<string>();
                var client = new FacebookClient("CAAIVZCRFP4h0BAIv50KUa5MJIZC69OwO5VxEh9qcDCXJhg5XNGcVnb6OtRn1OvNefXE023fzbqZA8ZCU44hfFpL8onMMUTii7EWDzwCyOKdabWrbApXIPLx0zEamdlkAZBJnHn9AVGWqsemj0pd7ZB7iz5vVkZAz58DSNXZAwsDycKkcueKb1E8XQFRlOTDEBsEu3SZCa4UO0WgZDZD");
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