using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Clases
{
    // (repeticiones + 1) / totalPalabrasCat + totalPalabras
    public class NaiveBayes
    {
        DB_Data DB;
        Lectura Lec;
        EstadisticasBayesianas Res;
        
        public NaiveBayes(String txt)
        {
            Lec = new Lectura(txt);
            Res = new EstadisticasBayesianas();
            DB  = new DB_Data(Res);
            Res = DB.r;

            //clasificar(); // Con bayesiano
        }

        private void clasificar()
        {
            foreach (Idioma i in DB.lstIdiomas)
            {
                for (int z = 0; z < DB.lstPalabras.Count(); z++)
                {
                    if (DB.lstPalabras[z].getIdioma() == i)
                    {
                        calcProbPalabra(Lec.lstRepeticiones[z], i.getNombre());
                    }
                    else
                    {
                        calcProbPalabra(0, i.getNombre());
                    }
                }
            }
        }

        private double calcProbPalabra(int repeticiones, String lenguaje)
        {
            double x = 0.0;
            switch (lenguaje)
            {
                case "Ingles":
                    x = (repeticiones + 1) / (Res.tpIng + Res.tPalabras);
                    Res.propIngles = Res.propIngles * x;
                    break;
                case "Español":
                    x = (repeticiones + 1) / (Res.tpEsp + Res.tPalabras);
                    Res.propEspañol = Res.propEspañol * x;
                    break;
                case "Frances":
                    x = (repeticiones + 1) / (Res.tpFrn + Res.tPalabras);
                    Res.propFrances = Res.propFrances * x;
                    break;
                case "Aleman":
                    x = (repeticiones + 1) / (Res.tpAlm + Res.tPalabras);
                    Res.propAleman = Res.propAleman * x;
                    break;
            }
            return x;
        }
        
        private class Lectura
        {
            public string[] spltTxt { get; set; }
            public List<string> lstPalabras { get; set; }
            public List<int> lstRepeticiones { get; set; }

            public Lectura(String text)
            {
                spltTxt = text.Split(new Char[] { ' ', '.', '%', '*', '+', ':', '_', '|', '!', '<', '>', '/', '=', '{', '}', '[', ']', ';', ',', '"', '(', ')', '#', '&'},
                                 StringSplitOptions.RemoveEmptyEntries);



            }
        }
         
        private class DB_Data
        {
            public List<Palabra> lstPalabras { get; set; }
            public List<Categoria> lstCategorias { get; set; }
            public List<Idioma> lstIdiomas { get; set; }
            public EstadisticasBayesianas r { get; set; }

            public DB_Data(EstadisticasBayesianas res)
            {
                // Consultas a BD
                r = counter(r);
            }

            private EstadisticasBayesianas counter(EstadisticasBayesianas res)
            {
                res.tPalabras = lstPalabras.Count();
                contarPalabrasIdioma(res);
                contarPalabrasCategoria(res);

                return res;
            }

            private void contarPalabrasCategoria(EstadisticasBayesianas res)
            {
                foreach (Palabra p in lstPalabras)
                {
                    switch (p.Categoria.getNombre())
                    {
                        case "Futbol":
                            res.tpIng++;
                            break;
                        case "Baseball":
                            res.tpEsp++;
                            break;
                        case "Ajedrez":
                            res.tpFrn++;
                            break;
                        case "Natacion":
                            res.tpAlm++;
                            break;
                        case "Sin Categoria":
                            break;
                    }
                }
            }

            private void contarPalabrasIdioma(EstadisticasBayesianas res)
            {
                foreach (Palabra p in lstPalabras)
                {
                    switch (p.getIdioma().getNombre())
                    {
                        case "Ingles":
                            res.tpIng++;
                            break;
                        case "Español":
                            res.tpEsp++;
                            break;
                        case "Frances":
                            res.tpFrn++;
                            break;
                        case "Aleman":
                            res.tpAlm++;
                            break;
                    }
                }
            }
        }
    }

    public class EstadisticasBayesianas
    {
        public Double propIngles { get; set; }
        public Double propEspañol { get; set; }
        public Double propFrances { get; set; }
        public Double propAleman { get; set; }

        public Double propAjedrez { get; set; }
        public Double propFutbol { get; set; }
        public Double propBaseball { get; set; }
        public Double propNatacion { get; set; }

        public long tPalabras { get; set; }

        public long tpIng { get; set; }
        public long tpEsp { get; set; }
        public long tpFrn { get; set; }
        public long tpAlm { get; set; }

        public long tpFut { get; set; }
        public long tpAjd { get; set; }
        public long tpBsbll { get; set; }
        public long tpNat { get; set; }
    }
}