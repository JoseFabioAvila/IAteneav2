using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace IAteneav2.Logic
{
    public class AnalzarDisco
    {
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

        internal void uploadFiles(string v, object fileUploadControl)
        {
            throw new NotImplementedException();
        }

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