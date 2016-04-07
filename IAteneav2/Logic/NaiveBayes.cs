using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Logic
{
    // (repeticiones + 1) / totalPalabrasCat + totalPalabras
    public class NaiveBayes
    {
        // Ojeto para la recopilación de datos de la base de datos
        DB_Data DB;
        // Objeto para la repolección datos del archivo o datos que se desea analizar
        Lectura Lec;
        // Objeto para el almacenamiento de datos
        public Resultadoss Res { get; set; }

        /// <summary>
        /// Constructor del clasificador bayesiano ingenuo
        /// </summary>
        /// <param name="txt"> text recolectado de cualquier fuente al cual se le desea clasificar el contenido</param>
        public NaiveBayes(String txt)
        {
            Lec = new Lectura(txt);
            Res = new Resultadoss();
            DB = new DB_Data();

            // Actualizar la calse de resultados con los datos recogidos de la base de datos
            Res = DB.res;
            // Actualizar la clase de resultados con los datos recogido de la lectura
            Res.tplSld = Lec.res.tplSld;
            Res.tplEcn = Lec.res.tplEcn;
            Res.tplDep = Lec.res.tplDep;
            Res.tplTec = Lec.res.tplTec;
            Res.tplIng = Lec.res.tplIng;
            Res.tplEsp = Lec.res.tplEsp;
            Res.tplAlm = Lec.res.tplAlm;
            Res.tplFrn = Lec.res.tplFrn;
            Res.knownWrd = Lec.knownWrd;
            Res.unknownWrd = Lec.unknownWrd;
            Res.totalWrds = Lec.totalWrds;
            // Comenzar el analisis de la información
            clasificar(); // Con bayesiano
        }

        /// <summary>
        /// Operaciones matematicar realizadas para clasificar idioma y categoria
        /// </summary>
        private void clasificar()
        {
            // Probabilidades iniciales obtenidas de la base de datos
            float probIniDep, probIniSld, probIniTec, probIniEcn;
            probIniDep = (float) Res.tpDep   / (float) Res.tPalabras; // Total de palabra de una categoria en BD/ Total de palabra en BD 
            probIniSld = (float) Res.tpSld   / (float) Res.tPalabras;
            probIniTec = (float) Res.tpTec   / (float) Res.tPalabras;
            probIniEcn = (float) Res.tpEcn   / (float) Res.tPalabras;
            // Resultados finales del clasificador bayesiano
            Res.probDeportes   = (float)100 * probIniDep * (((float)Res.tplDep)  // Probabilidad inicial * probabilidad posterior
                                              /((float)Res.tpDep));
            Res.probSalud      = (float)100 * probIniSld * (((float)Res.tplSld)
                                              /((float)Res.tpSld));
            Res.probTecnologia = (float)100 * probIniTec * (((float)Res.tplTec) 
                                              /((float)Res.tpTec));
            Res.probEconomia   = (float)100 * probIniEcn * (((float)Res.tplEcn)
                                              /((float)Res.tpEcn));
            // Probabilidades de que sea un idioma especifico
            Res.propIngles  = (float)100 * (float)Res.tplIng  / (float)Lec.lstPalabras.Count();
            Res.propEspañol = (float)100 * (float)Res.tplEsp  / (float)Lec.lstPalabras.Count();
            Res.propFrances = (float)100 * (float)Res.tplFrn  / (float)Lec.lstPalabras.Count();
            Res.propAleman  = (float)100 * (float)Res.tplAlm  / (float)Lec.lstPalabras.Count();
        }

        /// <summary>
        /// Clase para el manejo de la información recolectada para posteriormente clasificar
        /// </summary>
        private class Lectura
        {
            Models.MPalabras mp;
            Models.MIdiomas mi;
            public string[] spltTxt { get; set; } // Lista con palabras repetidas
            public List<string> lstPalabras { get; set; } // Lista sin palabras repetidas
            public List<int> lstRepeticiones { get; set; } // Numero de repeticiones

            public Resultadoss res { get; set; }

            public int knownWrd { get; set; } // Palabras conocidas
            public List<string> unknownWrd { get; set; } // Palabras no conocidas
            public int totalWrds { get; set; } // Total de palabras de la lectura

            /// <summary>
            /// Constructur de la clase lectura
            /// </summary>
            /// <param name="text">Texto string con todas las palabras a clasificar</param>
            public Lectura(String text)
            {
                knownWrd = 0;
                unknownWrd = new List<string>();
                
                res = new Resultadoss();

                mp = new Models.MPalabras();
                mi = new Models.MIdiomas();

                lstPalabras = new List<string>();
                lstRepeticiones = new List<int>();

                spltTxt = text.Split(new Char[] { ' ', '.', '%', '*', '+', ':', '_', '|', '!', '<', '>', '/', '=', '{', '}', '[', ']', ';', ',', '"', '(', ')', '#', '&' },
                                 StringSplitOptions.RemoveEmptyEntries);

                clasificadorDeRepeticiones();

                totalWrds = lstPalabras.Count();

                counter();
            }

            /// <summary>
            /// Constructor de la clase lectura
            /// </summary>
            /// <param name="lst"> Lista con tonas las palabras a clasificar</param>
            public Lectura(string[] lst)
            {
                knownWrd = 0;
                unknownWrd = new List<string>();

                res = new Resultadoss();

                mp = new Models.MPalabras();
                mi = new Models.MIdiomas();

                lstPalabras = new List<string>();
                lstRepeticiones = new List<int>();

                spltTxt = lst;

                clasificadorDeRepeticiones();

                totalWrds = lstPalabras.Count();

                counter();
            }

            /// <summary>
            /// Eliminador y contador de repeteticiones.
            /// </summary>
            private void clasificadorDeRepeticiones()
            {
                bool repetida = false;

                foreach (String txt in spltTxt)
                {
                    repetida = false;
                    //foreach (String p in lstPalabras)
                    if (lstPalabras.Count() != 0)
                    {
                        for (int i = 0; i < lstPalabras.Count(); i++)
                        {
                            if (lstPalabras[i].Equals(txt))
                            {
                                lstRepeticiones[i]++;
                                repetida = true;
                                break;
                            }
                        }
                    }

                    if (!repetida)
                    {
                        lstPalabras.Add(txt);
                        lstRepeticiones.Add(1);
                    }
                }
            }

            /// <summary>
            /// Aplica restricciones que se deben aplicar cuando se debe realizar la lectura
            /// </summary>
            private void counter()
            {
                for(int i = 0; i< lstPalabras.Count(); i++)
                //foreach (String p in lstPalabras)
                {
                    Clases.Palabra[] lstp = mp.Select(lstPalabras[i]);
                    if (lstp.Count() != 0)
                    {
                        knownWrd++;

                        int n = lstp.Count();
                        for (int p = 0; p < n; p++)
                        //foreach (Clases.Palabra p2 in lstp)
                        {
                            // Delimitadores de categoria
                            if ( lstp[p].Categoria != null)
                            {
                                if (n == 1)
                                {
                                    addCat(lstp, p, i);
                                }
                                else if (p == 0) 
                                {
                                    if (lstp[p].Categoria.ID != lstp[p + 1].Categoria.ID)
                                    {
                                        addCat(lstp, p, i);
                                    }
                                }
                                else if (p + 1 >= n)
                                {
                                    if (lstp[p].Categoria.ID != lstp[p - 1].Categoria.ID)
                                    {
                                        addCat(lstp, p, i);
                                    }
                                }
                                else
                                {
                                    if (lstp[p].Categoria.ID != lstp[p + 1].Categoria.ID &&
                                        lstp[p].Categoria.ID != lstp[p - 1].Categoria.ID)
                                    {
                                        addCat(lstp, p, i);
                                    }
                                }
                            }
                            // Delimitadores de idioma
                            if (lstp[p].getIdioma() != null)
                            {
                                if(n == 1)
                                {
                                    addIdioma(lstp, p, i);
                                }
                                else if(p == 0)
                                {
                                    if (lstp[p].getIdioma().ID != lstp[p + 1].getIdioma().ID)
                                    {
                                        addIdioma(lstp, p, i);
                                    }
                                }
                                else if (p + 1 >= n)
                                {
                                    if (lstp[p].getIdioma().ID != lstp[p - 1].getIdioma().ID)
                                    {
                                        addIdioma(lstp, p, i);
                                    }
                                }
                                else
                                {
                                    if (lstp[p].getIdioma().ID != lstp[p + 1].getIdioma().ID &&
                                        lstp[p].getIdioma().ID != lstp[p - 1].getIdioma().ID)
                                    {
                                        addIdioma(lstp,p,i);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        unknownWrd.Add(lstPalabras[i]);
                    }
                }
            }

            /// <summary>
            /// Actualiza los contadores de categoria
            /// </summary>
            /// <param name="lstp"> lista donde se ubican la palabras</param>
            /// <param name="p">posicion de la palabra</param>
            /// <param name="i">posicion del numero de repeticiones</param>
            private void addCat(Clases.Palabra[] lstp, int p, int i)
            {
                switch (lstp[p].Categoria.ID)
                {
                    case 1:
                        res.tplDep += lstRepeticiones[i];
                        break;
                    case 2:
                        res.tplSld += lstRepeticiones[i];
                        break;
                    case 3:
                        res.tplTec += lstRepeticiones[i];
                        break;
                    case 4:
                        res.tplEcn += lstRepeticiones[i];
                        break;
                    default:
                        break;
                }
            }
            /// <summary>
            /// Actualiza los contadores de idioma
            /// </summary>
            /// <param name="lstp"> lista donde se ubican la palabras</param>
            /// <param name="p">posicion de la palabra</param>
            /// <param name="i">posicion del numero de repeticiones</param>
            private void addIdioma(Clases.Palabra[] lstp, int p, int i)
            {
                switch (lstp[p].getIdioma().ID)
                {
                    case 1:
                        res.tplEsp += lstRepeticiones[i];
                        break;
                    case 2:
                        res.tplIng += lstRepeticiones[i];
                        break;
                    case 3:
                        res.tplFrn += lstRepeticiones[i];
                        break;
                    case 4:
                        res.tplAlm += lstRepeticiones[i];
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Clase para la recoleccion y manejo de palabras obtenidas de la base de datos
        /// </summary>
        private class DB_Data
        {
            public Clases.Palabra[] lstPalabras { get; set; }
            public Resultadoss res { get; set; }

            public DB_Data()
            {
                Models.MPalabras mp = new Models.MPalabras();

                lstPalabras = mp.Selectall();

                res = new Resultadoss();
                res = counter();
            }

            private Resultadoss counter()
            {
                res.tPalabras = lstPalabras.Count();

                foreach (Clases.Palabra p in lstPalabras)
                {
                    if (p.Categoria != null)
                    {
                        switch (p.Categoria.ID)
                        {
                            case 1:
                                res.tpDep++;
                                break;
                            case 2:
                                res.tpSld++;
                                break;
                            case 3:
                                res.tpTec++;
                                break;
                            case 4:
                                res.tpEcn++;
                                break;
                            default:
                                break;
                        }
                    }

                    switch (p.getIdioma().ID)
                    {
                        case 1:
                            res.tpEsp++;
                            break;
                        case 2:
                            res.tpIng++;
                            break;
                        case 3:
                            res.tpFrn++;
                            break;
                        case 4:
                            res.tpAlm++;
                            break;
                    }
                }

                return res;
            }
        }

        /// <summary>
        /// Almacen de resultados obtenidos de la clasificación
        /// </summary>
        public class Resultadoss
        {
            public float propIngles { get; set; }
            public float propEspañol { get; set; }
            public float propFrances { get; set; }
            public float propAleman { get; set; }

            public float probDeportes { get; set; }
            public float probSalud { get; set; }
            public float probTecnologia { get; set; }
            public float probEconomia { get; set; }

            public long tPalabras { get; set; }
            public long tpIng { get; set; }
            public long tpEsp { get; set; }
            public long tpFrn { get; set; }
            public long tpAlm { get; set; }

            public long tpDep { get; set; }
            public long tpSld { get; set; }
            public long tpTec { get; set; }
            public long tpEcn { get; set; }

            public long tplIng { get; set; }
            public long tplEsp { get; set; }
            public long tplFrn { get; set; }
            public long tplAlm { get; set; }

            public long tplDep { get; set; }
            public long tplSld { get; set; }
            public long tplTec { get; set; }
            public long tplEcn { get; set; }

            public int knownWrd { get; set; }
            public List<string> unknownWrd { get; set; }
            public int totalWrds { get; set; }
        }
    }
}