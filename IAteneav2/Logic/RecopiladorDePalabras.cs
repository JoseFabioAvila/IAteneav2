using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Logic
{
    /// <summary>
    /// Clase intermediaria para el amacen de palabra en la base de datos, sirve para el entrenamiento y para almacenamiento posterior
    /// </summary>
    public class RecopiladorDePalabras
    {
        String[] spltTxt;
        int Español = 1, Ingles = 2, Frances = 3, Aleman = 4;
        int dep = 1, sld = 2, tec = 3, ecn = 4;
        

        public int[] catCount { get; set; }
        public int[] legCount { get; set; }

        /// <summary>
        /// Constructor del recopilador de palabras con categoria
        /// </summary>
        /// <param name="lst">lista de palabra a guardar</param>
        /// <param name="i">idioma</param>
        /// <param name="c">categoria</param>
        public RecopiladorDePalabras(List<String> lst, int i, int c)
        {
            int[] x = { 0, 0, 0, 0 };
            int[] y = { 0, 0, 0, 0 };
            catCount = x;

            legCount = y;
            guardar(lst, i, c);
        }

        /// <summary>
        /// Constructor del recopiladro de palabras sin categoria
        /// </summary>
        /// <param name="lst">lista de palabras</param>
        /// <param name="i">idioma</param>
        public RecopiladorDePalabras(List<String> lst, int i)
        {
            int[] x = { 0, 0, 0, 0 };
            int[] y = { 0, 0, 0, 0 };
            catCount = x;

            legCount = y;
            guardar(lst, i);
        }

        /// <summary>
        /// Recopilador para carga de datos directamente a la base de datos
        /// </summary>
        /// <param name="text"></param>
        public RecopiladorDePalabras(String text)
        {
            spltTxt = text.Split(new Char[] { ' ', '.', '%', '*', '+', ':', '_', '|', '!', '<', '>', '/', '=', '{', '}', '[', ']', ';', ',', '"', '(', ')', '#', '&' },
                                 StringSplitOptions.RemoveEmptyEntries);

            int[] x = { 0, 0, 0, 0 };
            int[] y = { 0, 0, 0, 0 };
            catCount = x;
            legCount = y;

            switch (spltTxt[0]) // Codigos para la identificacion de casos
            {
                case "Ingles": // Codigo
                    guardar(spltTxt, Ingles);
                    break;
                case "Español":
                    guardar(spltTxt, Español);
                    break;
                case "Frances":
                    guardar(spltTxt, Frances);
                    break;
                case "Aleman":
                    guardar(spltTxt, Aleman);
                    break;
                // Ingles con categoria
                case "InglesDep":
                    guardar(spltTxt, Ingles, dep);
                    break;
                case "InglesSld":
                    guardar(spltTxt, Ingles, sld);
                    break;
                case "InglesTec":
                    guardar(spltTxt, Ingles, tec);
                    break;
                case "InglesEcn":
                    guardar(spltTxt, Ingles, ecn);
                    break;
                // Español con categoria
                case "EspañolDep":
                    guardar(spltTxt, Español, dep);
                    break;
                case "EspañolSld":
                    guardar(spltTxt, Español, sld);
                    break;
                case "EspañolTec":
                    guardar(spltTxt, Español, tec);
                    break;
                case "EspañolEcn":
                    guardar(spltTxt, Español, ecn);
                    break;
                // Frances con categoria
                case "FrancesDep":
                    guardar(spltTxt, Frances, dep);
                    break;
                case "FrancesSld":
                    guardar(spltTxt, Frances, sld);
                    break;
                case "FrancesTec":
                    guardar(spltTxt, Frances, tec);
                    break;
                case "FrancesEcn":
                    guardar(spltTxt, Frances, ecn);
                    break;
                // Aleman con categoria
                case "AlemanDep":
                    guardar(spltTxt, Aleman, dep);
                    break;
                case "AlemanSld":
                    guardar(spltTxt, Aleman, sld);
                    break;
                case "AlemanTec":
                    guardar(spltTxt, Aleman, tec);
                    break;
                case "AlemanEcn":
                    guardar(spltTxt, Aleman, ecn);
                    break;
            }
        }
        /// <summary>
        /// Guardar una lista de palabras sin categoria
        /// </summary>
        /// <param name="lstTxt">lista de palabras</param>
        /// <param name="idioma">idioma</param>
        public void guardar(String[] lstTxt, int idioma)
        {
           Controllers.CPalabras cntll = new Controllers.CPalabras();
           Clases.Palabra[] lstP = cntll.getPalabras();
            Models.MPalabras mp = new Models.MPalabras();

           foreach(String txt in lstTxt)
            {
                if(!mp.exist(txt, idioma)) { 
                    legCount[idioma - 1]++;
                    cntll.agregarPalabra(txt, idioma);
                }
            }
            
        }
        /// <summary>
        /// Guardar una lista de palabras sin categoria
        /// </summary>
        /// <param name="lstTxt">lista de palabras</param>
        /// <param name="idioma">idioma</param>
        public void guardar(List<string> lstTxt, int idioma)
        {
            Controllers.CPalabras cntll = new Controllers.CPalabras();
            Clases.Palabra[] lstP = cntll.getPalabras();
            Models.MPalabras mp = new Models.MPalabras();

            foreach (String txt in lstTxt)
            {
                if (!mp.exist(txt, idioma))
                {
                    legCount[idioma]++;
                    cntll.agregarPalabra(txt, idioma);
                }
            }

        }
        /// <summary>
        /// Guardar una lista de palabras con categoria
        /// </summary>
        /// <param name="lstTxt">lista de palabras</param>
        /// <param name="idioma">idioma</param>
        /// <param name="categoria">categoria</param>
        public void guardar(String[] lstTxt, int idioma, int categoria)
        {
            Models.MPalabras mp = new Models.MPalabras();
            Controllers.CPalabras cntll = new Controllers.CPalabras();
            Clases.Palabra[] lstP = cntll.getPalabras();

            foreach (String txt in lstTxt)
            {
                if (!mp.exist(txt, idioma))
                {
                    catCount[categoria - 1]++;
                    legCount[idioma - 1]++;
                    mp.agregarPalabra(txt, idioma, categoria);
                }
                else
                {
                    catCount[categoria - 1]++;
                    legCount[idioma - 1]++;
                    mp.EditarCategoria(mp.Select(txt)[0].getId(), categoria);
                }
            }

        }
        /// <summary>
        /// Guardar una lista de palabras con categoria
        /// </summary>
        /// <param name="lstTxt">lista de palabras</param>
        /// <param name="idioma">idioma</param>
        /// <param name="categoria">categoria</param>
        public void guardar(List<string> lstTxt, int idioma, int categoria)
        {
            Models.MPalabras mp = new Models.MPalabras();
            Controllers.CPalabras cntll = new Controllers.CPalabras();
            Clases.Palabra[] lstP = cntll.getPalabras();

            foreach (String txt in lstTxt)
            {
                if (!mp.exist(txt, idioma))
                {
                    catCount[categoria]++;
                    legCount[idioma]++;
                    mp.agregarPalabra(txt, idioma, categoria);
                }
                else
                {
                    catCount[categoria]++;
                    legCount[idioma]++;
                    mp.EditarCategoria(mp.Select(txt)[0].getId(), categoria);
                }
            }

        }
    }
}