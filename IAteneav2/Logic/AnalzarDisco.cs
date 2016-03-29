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
    }
}