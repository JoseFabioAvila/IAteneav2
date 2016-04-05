using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Core;
using Ionic.Zip;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace IAteneav2.Logic
{
    public class AnalizarComprimidos
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


        public string openExistingZipFile(string archivo)
        {
            try {
                BZip2InputStream x;
                string extractPath = @"C:\comprimidos";
                using (ZipFile zip = ZipFile.Read(archivo))
                {
                    zip.ExtractAll(extractPath, ExtractExistingFileAction.DoNotOverwrite);
                }
                return "exito";
            }
            catch (FileNotFoundException e)
            {
                return "error";
            }
        }

        /// <summary>
        /// descomprime archivo bz2
        /// </summary>
        /// <param name="archivo">el archivo a descomprimir</param>
        /// <param name="ruta">ruta en donde se va a descomprimir</param>
        public void descomprimirBzip2(String archivo, String ruta)
        {
            var buffer = new byte[4096];
            using (Stream streamIn = new FileStream(archivo, FileMode.Open, FileAccess.Read))
            using (var gzipStream = new BZip2InputStream(streamIn))
            {
                var fileName = Path.GetFileNameWithoutExtension(archivo);
                var path = Path.Combine(ruta, fileName);
                using (var fileStreamOut = File.Create(path))
                {
                    StreamUtils.Copy(gzipStream, fileStreamOut, buffer);
                }
            }
        }


        public string blabla(string dir)
        {
            //JObject o1 = JObject.Parse(File.ReadAllText(dir));

            // read JSON directly from a file
            //StreamReader file = File.OpenText(dir);
            using (StreamReader r = new StreamReader(dir))
            {
                string archivo = r.ReadToEnd();

                //dynamic result = JsonConvert.DeserializeObject(archivo);
                string[] jsons = archivo.Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
                var urls = new List<string>();
                //result = result.ToString().Substring(1, result.ToString().Length - 2);
                string x = "";
                foreach (var json in jsons)
                {
                    //urls.Add(result.text);
                    dynamic json2 = JsonConvert.DeserializeObject(json);
                    x += json2.text+"\n";
                }

                //return o1.ToString();
                return x;
            }

            
        }
    }
}