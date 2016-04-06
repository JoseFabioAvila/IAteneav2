﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Logic
{
    public class RecopiladorDePalabras
    {
        String[] spltTxt;
        int Español = 1, Ingles = 2, Frances = 3, Aleman = 4;
        int dep = 1, sld = 2, tec = 3, ecn = 4;
        

        public int[] catCount { get; set; }
        public int[] legCount { get; set; }
        
        public RecopiladorDePalabras(String text)
        {
            spltTxt = text.Split(new Char[] { ' ', '.', '%', '*', '+', ':', '_', '|', '!', '<', '>', '/', '=', '{', '}', '[', ']', ';', ',', '"', '(', ')', '#', '&' },
                                 StringSplitOptions.RemoveEmptyEntries);

            int[] x = { 0, 0, 0, 0 };
            int[] y = { 0, 0, 0, 0 };
            catCount = x;
            legCount = y;

            switch (spltTxt[0])
            {
                case "Ingles":
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

        public void guardar(String[] lstTxt, int idioma, int categoria)
        {
            bool repetida = false;
            Models.MPalabras mp = new Models.MPalabras();
            Controllers.CPalabras cntll = new Controllers.CPalabras();
            Clases.Palabra[] lstP = cntll.getPalabras();

            foreach (String txt in lstTxt)
            {
                repetida = false;
                foreach (Clases.Palabra p in lstP)
                {
                    if (p.getPalabra().Equals(txt) && p.getIdioma().ID == idioma && p.Categoria == null)
                    {
                        mp.EditarCategoria(p.getId(), categoria);
                        repetida = true;
                        break;
                    }
                }

                if (!repetida)
                {
                    catCount[categoria - 1]++;
                    legCount[idioma - 1]++;
                    mp.agregarPalabra(txt, idioma, categoria);
                }
            }

        }

    }
}