using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Clases
{
    public class WebSite
    {
        int id;
        string url;

        public WebSite(int id, string url)
        {
            this.id = id;
            this.url = url;
        }

        public int Id
        {
            get {return id;}
            set {id = value;}
        }

        public string Url
        {
            get {return url;}

            set {url = value;}
        }
    }
}