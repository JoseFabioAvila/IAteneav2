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


        public LinkedList<string> openExistingZipFile(string archivo)
        {
            try {
                BZip2InputStream x;
                string extractPath = @"C:\comprimidos";
                using (ZipFile zip = ZipFile.Read(archivo))
                {
                    zip.ExtractAll(extractPath, ExtractExistingFileAction.DoNotOverwrite);
                }
                LinkedList<string> lista = genListFromDirectory(@"C:\comprimidos");

                descomprimirListaBzip2(lista);

                LinkedList<string> jsons = genListJson(@"C:\comprimidos");
                string res = "";

                foreach(string json in jsons) {
                    res += leerJson(json);
                }
                lista.Clear();
                string[] words = res.Split(new char[] { '¿', '¡', ' ', '.', '%', '*', '+', ':', '_', '–', '-', '~', '¿', '?', '|', '!', '<', '>', '/', '\'', '=', '{', '}', '[', ']', ';', ',', '"', '(', ')', '$', '^', '@', '#', '&', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    lista.AddLast(word);
                }

                return lista;
            }
            catch (FileNotFoundException e)
            {
                return null;
            }
        }

        public void descomprimirListaBzip2(LinkedList<string> lista)
        {
            if(lista != null) {
                foreach (string archivo in lista)
                {
                    descomprimirBzip2(archivo, Path.GetDirectoryName(archivo));
                }
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


        /// <summary>
        /// lee los json de un archivo json
        /// </summary>
        /// <param name="dir">direccion del archivo json</param>
        /// <returns>los textos de los twits</returns>
        public string leerJson(string dir)
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


        /// <summary>
        /// genera la lista de rutas en donde hay archivos bz2
        /// </summary>
        /// <param name="DirPath">direccion del archivo descomprimido</param>
        /// <returns>lista de rutas de bz2</returns>
        public LinkedList<string> genListFromDirectory(string DirPath)
        {

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


        public LinkedList<string> genListJson(string DirPath)
        {

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
                    if (FI.Extension.Equals(".json"))
                    {
                        direcciones.AddLast(FI.FullName);
                    }
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