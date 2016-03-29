using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Controllers
{
    public class CWebSites
    {
        private Models.MWebSites ins = new Models.MWebSites();

        public LinkedList<Clases.WebSite> getWebSites()
        {
            LinkedList<Clases.WebSite> lista = new LinkedList<Clases.WebSite>();
            lista = ins.getWebSites();
            return lista;
        }

        public bool agregarWebSite(string url)
        {
            return ins.agregarWebSite(url);
        }

        public bool quitarWebSite(string url)
        {
            return ins.quitarWebSite(url);
        }
    }
}