using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Clases
{
    public class Nodo
    {
        int level;
        LinkedList<String> files = new LinkedList<string>();
        LinkedList<Nodo> directorios = new LinkedList<Nodo>();

        public Nodo(int lvl)
        {
            this.level = lvl;
        }
    }
}