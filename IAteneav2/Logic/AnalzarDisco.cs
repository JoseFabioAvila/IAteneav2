using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace IAteneav2.Logic
{
    public class AnalzarDisco
    {
        public LinkedList<string> palabrasDirectorios = new LinkedList<string>();

        /// <summary>
        /// Crea el directorio docs si no existe, si existe no hace nada
        /// </summary>
        /// <param name="path">Es el path del directorio docs</param>
        public void checkDirectory(string path)
        {
            try
            {
                Directory.Delete(path, true);
                System.IO.Directory.CreateDirectory(path);
            }
            catch
            {
                System.IO.Directory.CreateDirectory(path);
            }

        }

        internal void uploadFiles(string v, object fileUploadControl)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Abre un archivo .docx o .doc y obtiene su contenido.
        /// </summary>
        /// <param name="filepath">direccion del archivo</param>
        /// <returns>el contenido del archivo</returns>
        public String OpenWordprocessingDocumentReadonly(string filepath)
        {
            // Open a WordprocessingDocument based on a filepath.
            using (WordprocessingDocument wordDocument =
                WordprocessingDocument.Open(filepath, false))
            {
                // Assign a reference to the existing document body.  
                Body body = wordDocument.MainDocumentPart.Document.Body;

                // Attempt to add some text.
                return body.InnerText;
            }
        }

        /// <summary>
        /// Toma cada palabra en el texto y la agrega a la lista
        /// </summary>
        /// <param name="texto">es el texto tomado de un archivo</param>
        private void enlistar(string texto)
        {
            string[] palabras = texto.Split(new char[] { ' ', '.', '%', '*', '+', ':', '_', '–', '-', '~', '¿', '?', '|', '!', '<', '>', '/', '\'', '=', '{', '}', '[', ']', ';', ',', '"', '(', ')', '$', '^', '@', '#', '&', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string palabra in palabras)
            {
                palabrasDirectorios.AddLast(palabra);
            }
        }

        public string leerArchivo(string archivo)
        {
            string res = "";
            if (archivo.Contains(".txt"))
            {
                string line = "";
                res += "\n\n";
                try
                {
                    StreamReader sr = new StreamReader(archivo);

                    line = sr.ReadLine();
                    while (line != null)
                    {
                        res = line.ToString();
                        line = sr.ReadLine(); //pasar a la siguiente linea
                    }
                    res += "\n\n";
                    enlistar(res);
                    sr.Close();
                }
                catch (Exception e)
                {
                    res += "\nerror xDDD\n";
                }
            }
            else if (archivo.Contains(".docx") || archivo.Contains(".docx"))
            {
                res += "\n" + OpenWordprocessingDocumentReadonly(archivo) + "\n";
                enlistar(res);
            }
            else
            {
                res += "\nNo es leible\n";
            }
            return res;
        }

        public string prueba()
        {
            string x = "";
            //string startPath = @"c:\example\start";
            //string zipPath = @"c:\example\result.zip";
            //string extractPath = @"c:\example\extract";

            //ZipFile.CreateFromDirectory(startPath, zipPath);

            //ZipFile.ExtractToDirectory(zipPath, extractPath);
            return x;
        }

        public string GetFilesFromDirectory(string DirPath)
        {
            string x = "inicio \n";
            try
            {
                DirectoryInfo Dir = new DirectoryInfo(DirPath);
                DirectoryInfo[] DirList = Dir.GetDirectories();
                FileInfo[] FileList = Dir.GetFiles("*.*", SearchOption.AllDirectories);

                foreach (DirectoryInfo FI in DirList)
                {
                    x += FI.FullName + "\n";
                }
                x += "\n\n\n";
                
                foreach (FileInfo FI in FileList)
                {
                    x += FI.FullName + "\n";
                }

                return x;
            }
            catch (Exception ex)
            {
                return x;
            }
        }

        /// <summary>
        /// Genera la lista de direcciones de los archivos 
        /// </summary>
        /// <param name="DirPath">direccion del directorio a analizar</param>
        /// <returns>lista de direcciones</returns>
        public LinkedList<string> genListFromDirectory(string DirPath)
        {
            //LinkedList<Clases.Nodo> ListaNodo = new LinkedList<Clases.Nodo>();

            LinkedList<string> direcciones = new LinkedList<string>();

            string x = "inicio \n";
            try
            {
                DirectoryInfo Dir = new DirectoryInfo(DirPath);
                DirectoryInfo[] DirList = Dir.GetDirectories();
                FileInfo[] FileList = Dir.GetFiles("*.*", SearchOption.AllDirectories);

                foreach (DirectoryInfo FI in DirList)
                {
                    x += FI.FullName + "\n";
                }
                x += "\n\n\n";

                foreach (FileInfo FI in FileList)
                {
                    x += FI.FullName + "\n";
                    direcciones.AddLast(FI.FullName);
                }

                return direcciones;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}