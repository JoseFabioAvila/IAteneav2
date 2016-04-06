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
        DB_Data DB;
        Lectura Lec;
        public Resultadoss Res { get; set; }

        public NaiveBayes(String txt)
        {
            Lec = new Lectura(txt);
            Res = new Resultadoss();
            DB = new DB_Data();
            Res = DB.res;

            Res.tplSld = Lec.res.tplSld;
            Res.tplEcn = Lec.res.tplEcn;
            Res.tplDep = Lec.res.tplDep;
            Res.tplTec = Lec.res.tplTec;

            Res.tplIng = Lec.res.tplIng;
            Res.tplEsp = Lec.res.tplEsp;
            Res.tplAlm = Lec.res.tplAlm;
            Res.tplFrn = Lec.res.tplFrn;

            clasificar(); // Con bayesiano
        }

        private void clasificar()
        {
            float probIniNat, probIniFut, probIniBsbll, probIniAjd;
            probIniNat   = (float) Res.tpEcn   / (float) Res.tPalabras;
            probIniFut   = (float) Res.tpDep   / (float) Res.tPalabras;
            probIniBsbll = (float) Res.tpTec / (float) Res.tPalabras;
            probIniAjd   = (float) Res.tpSld   / (float) Res.tPalabras;

            float x = (float)0.00000001;

            Res.probDeportes  = (float)100 * probIniAjd * (((float)Res.tplSld) 
                                              /((float)Res.tpSld    + x));
            Res.probEconomia = (float)100 * probIniNat * (((float)Res.tplEcn)
                                              /((float)Res.tpEcn    + x));
            Res.probSalud   = (float)100 * probIniFut * (((float)Res.tplDep) 
                                              /((float)Res.tpDep    + x));
            Res.probTecnologia = (float)100 * probIniBsbll * (((float)Res.tplTec) 
                                              /((float)Res.tplTec + x));

            Res.propIngles  = (float)100 * (float)Res.tplIng  / (float)Lec.lstPalabras.Count();
            Res.propEspañol = (float)100 * (float)Res.tplEsp  / (float)Lec.lstPalabras.Count();
            Res.propFrances = (float)100 * (float)Res.tplFrn  / (float)Lec.lstPalabras.Count();
            Res.propAleman  = (float)100 * (float)Res.tplAlm  / (float)Lec.lstPalabras.Count();
        }

        private class Lectura
        {
            Models.MPalabras mp;
            Models.MIdiomas mi;
            public string[] spltTxt { get; set; }
            public List<string> lstPalabras { get; set; }
            public List<int> lstRepeticiones { get; set; }

            public Resultadoss res { get; set; }

            public Lectura(String text)
            {
                res = new Resultadoss();

                mp = new Models.MPalabras();
                mi = new Models.MIdiomas();

                lstPalabras = new List<string>();
                lstRepeticiones = new List<int>();

                spltTxt = text.Split(new Char[] { ' ', '.', '%', '*', '+', ':', '_', '|', '!', '<', '>', '/', '=', '{', '}', '[', ']', ';', ',', '"', '(', ')', '#', '&' },
                                 StringSplitOptions.RemoveEmptyEntries);

                clasificadorDeRepeticiones();

                counter();
            }

            public Lectura(string[] lst)
            {
                res = new Resultadoss();

                mp = new Models.MPalabras();
                mi = new Models.MIdiomas();

                lstPalabras = new List<string>();
                lstRepeticiones = new List<int>();

                spltTxt = lst;

                clasificadorDeRepeticiones();

                counter();
            }

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

            private void counter()
            {
                foreach (String p in lstPalabras)
                {
                    Clases.Palabra[] lstp = mp.Select(p);
                    if (lstp.Count() != 0)
                    {
                        foreach (Clases.Palabra p2 in lstp)
                        {
                            if (p2.Categoria != null)
                            {
                                switch (p2.Categoria.ID)
                                {
                                    case 1:
                                        res.tplEcn++;
                                        break;
                                    case 2:
                                        res.tplDep++;
                                        break;
                                    case 3:
                                        res.tplTec++;
                                        break;
                                    case 4:
                                        res.tplSld++;
                                        break;
                                    default:
                                        break;
                                }
                            }

                            switch (p2.getIdioma().ID)
                            {
                                case 2:
                                    res.tplIng++;
                                    break;
                                case 1:
                                    res.tplEsp++;
                                    break;
                                case 3:
                                    res.tplFrn++;
                                    break;
                                case 4:
                                    res.tplAlm++;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private class DB_Data
        {
            public Clases.Palabra[] lstPalabras { get; set; }
            public Clases.Categoria[] lstCategorias { get; set; }
            public Clases.Idioma[] lstIdiomas { get; set; }
            public Resultadoss res { get; set; }

            public DB_Data()
            {
                Models.MPalabras mp = new Models.MPalabras();
                Models.MIdiomas mi = new Models.MIdiomas();
                Models.MCategorias mc = new Models.MCategorias();

                lstPalabras = mp.Selectall();
                lstCategorias = mc.Selectall();
                lstIdiomas = mi.Selectall();

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
                                res.tpEcn++;
                                break;
                            case 2:
                                res.tpDep++;
                                break;
                            case 3:
                                res.tpTec++;
                                break;
                            case 4:
                                res.tpSld++;
                                break;
                            default:
                                break;
                        }
                    }

                    switch (p.getIdioma().ID)
                    {
                        case 2:
                            res.tpIng++;
                            break;
                        case 1:
                            res.tpEsp++;
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
        }
    }
}