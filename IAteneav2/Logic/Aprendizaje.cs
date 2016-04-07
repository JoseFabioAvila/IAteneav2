using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Logic
{
    public class Aprendizaje
    {
        /// <summary>
        /// Variable a escribir en el textbox
        /// </summary>
        public string Print { get; set; }
        /// <summary>
        /// Clasificador Bayesiano y sus resultados
        /// </summary>
        public Logic.NaiveBayes NaiveBayes { get; set; }
        /// <summary>
        /// Constructos de aprendizaje
        /// </summary>
        /// <param name="nby">Clasificador con resultados</param>
        public Aprendizaje(Logic.NaiveBayes nby)
        {
            NaiveBayes = nby;
            Precesar();
        }
        /// <summary>
        /// Muestra de informacion de los resultados del clasificador
        /// </summary>
        private void Precesar()
        {
            Print += "\n-------> DataBase information: \n";
            Print += "\n              Spanish words: " + NaiveBayes.Res.tpEsp;
            Print += "\n              English words: " + NaiveBayes.Res.tpIng;
            Print += "\n              French  words: " + NaiveBayes.Res.tpFrn;
            Print += "\n              German  words: " + NaiveBayes.Res.tpAlm;
            Print += "\n\n-------> And: \n";
            Print += "\n              Sports     words: " + NaiveBayes.Res.tpDep;
            Print += "\n              Health     words: " + NaiveBayes.Res.tpSld;
            Print += "\n              Tecnology  words: " + NaiveBayes.Res.tpTec;
            Print += "\n              Economy    words: " + NaiveBayes.Res.tpEcn;
            Print += "\n Total   words: " + NaiveBayes.Res.tPalabras;

            Print += "\n\n-------> Read text recognized: \n";
            Print += "\n              Spanish words: " + NaiveBayes.Res.tplEsp;
            Print += "\n              English words: " + NaiveBayes.Res.tplIng;
            Print += "\n              French  words: " + NaiveBayes.Res.tplFrn;
            Print += "\n              German  words: " + NaiveBayes.Res.tplAlm;
            Print += "\n\n-------> And: \n";
            Print += "\n              Sports     words: " + NaiveBayes.Res.tplDep;
            Print += "\n              Health     words: " + NaiveBayes.Res.tplSld;
            Print += "\n              Tecnology  words: " + NaiveBayes.Res.tplTec;
            Print += "\n              Economy    words: " + NaiveBayes.Res.tplEcn;
            Print += "\n -> Known words      : " + ((float)NaiveBayes.Res.knownWrd / (float)NaiveBayes.Res.totalWrds * (float)100) + "%";
            Print += "\n -> Unknown words    : " + ((float)NaiveBayes.Res.unknownWrd.Count() / (float)NaiveBayes.Res.totalWrds * (float)100) + "%";
            Print += "\n -> Total words reade: " + NaiveBayes.Res.totalWrds;

            Print += "\n\n-------> Analysis Results: \n";
            Print += "\n              English: " + NaiveBayes.Res.propIngles + "%";
            Print += "\n              Spanish: " + NaiveBayes.Res.propEspañol + "%";
            Print += "\n              French:  " + NaiveBayes.Res.propFrances + "%";
            Print += "\n              German:  " + NaiveBayes.Res.propAleman + "%";
            Print += "\n\n-------> And: \n";
            Print += "\n              Sports:     " + NaiveBayes.Res.probDeportes + "%";
            Print += "\n              Health:     " + NaiveBayes.Res.probSalud + "%";
            Print += "\n              Tecnology:  " + NaiveBayes.Res.probTecnologia + "%";
            Print += "\n              Economy :   " + NaiveBayes.Res.probEconomia + "%";

            ValidacionIdioma();
        }
        /// <summary>
        /// Validaciones de idioma requeridas para guardar la palabras
        /// </summary>
        private void ValidacionIdioma()
        {
            Print += "\n\n";
            if (NaiveBayes.Res.propEspañol > (float)80.0)
            {
                ValidacionCategoria(1);
            }
            else if (NaiveBayes.Res.propIngles > (float)80.0)
            {
                ValidacionCategoria(2);
            }
            else if (NaiveBayes.Res.propFrances > (float)80.0)
            {
                ValidacionCategoria(3);
            }
            else if (NaiveBayes.Res.propAleman > (float)80.0)
            {
                ValidacionCategoria(4);
            }
            else
            {
                Print += "\n Lectura no satisface los requisitos minimos para aprendizaje";
            }
        }
        /// <summary>
        /// Validaciones de categoria requeridas para guardar la palabras
        /// </summary>
        /// <param name="idioma">idioma validado</param>
        private void ValidacionCategoria(int idioma)
        {
            long sumaCategorias = NaiveBayes.Res.tplDep + NaiveBayes.Res.tplSld + NaiveBayes.Res.tplTec + NaiveBayes.Res.tplEcn;

            if ((NaiveBayes.Res.tplDep/sumaCategorias) > (float)0.4)
            {
                ValidacionConocido(idioma,1);
            }
            else if ((NaiveBayes.Res.tplSld / sumaCategorias) > (float)0.4)
            {
                ValidacionConocido(idioma, 2);
            }
            else if ((NaiveBayes.Res.tplTec / sumaCategorias) > (float)0.4)
            {
                ValidacionConocido(idioma, 3);
            }
            else if ((NaiveBayes.Res.tplEcn / sumaCategorias) > (float)0.4)
            {
                ValidacionConocido(idioma, 4);
            }
            else
            {
                ValidacionConocido(idioma);
            }
        }
        /// <summary>
        /// Validaciones de minimo de palabras reconocidas de la base de datos requeridas para guardar la palabras
        /// </summary>
        /// <param name="idioma">idioma validado</param>
        /// <param name="categoria">categoria validada</param>
        private void ValidacionConocido(int idioma, int categoria)
        {
            if(((float)NaiveBayes.Res.knownWrd / (float)NaiveBayes.Res.totalWrds * (float)100) > (float) 80)
            {
                Print += "\n Lectura satisface los requerimientos minimos";
                new Logic.RecopiladorDePalabras(NaiveBayes.Res.unknownWrd, idioma, categoria);
                Print += "\n\n **** Palabras aprendidas ****";
            }
            else
            {
                Print += "\n Lectura no satisface los requisitos minimos para aprendizaje";
            }
        }
        /// <summary>
        /// Validaciones de minimo de palabras reconocidas de la base de datos requeridas para guardar la palabras
        /// </summary>
        /// <param name="idioma">idioma validado</param>
        private void ValidacionConocido(int idioma)
        {
            if (((float)NaiveBayes.Res.knownWrd / (float)NaiveBayes.Res.totalWrds * (float)100) > (float)80)
            {
                Print += "\n Lectura satisface los requerimientos minimos";
                new Logic.RecopiladorDePalabras(NaiveBayes.Res.unknownWrd, idioma);
                Print += "\n\n **** Palabras aprendidas ****";
            }
            else
            {
                Print += "\n Lectura no satisface los requisitos minimos para aprendizaje";
            }
        }
    }
}