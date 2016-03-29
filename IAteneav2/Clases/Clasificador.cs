using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Clases
{
    public class Clasificador
    {
        public int ID;
        public String Nombre;

        public Clasificador() { }

        public Clasificador(int id, String nom)
        {
            this.ID = id;
            this.Nombre = nom;
        }

        public int getID()
        {
            return this.ID;
        }

        public String getNombre()
        {
            return this.Nombre;
        }

        public void setID(int id)
        {
            this.ID = id;
        }

        public void setNom(String nom)
        {
            this.Nombre = nom;
        }
    }
}