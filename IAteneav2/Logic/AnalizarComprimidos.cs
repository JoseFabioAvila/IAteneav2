using ICSharpCode.SharpZipLib.BZip2;
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
                string extractPath = @"C:\Users\fabio\OneDrive\comprimidos";
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
            //int renameCount = 0;
            //using (ZipFile zip2 = ZipFile.Read(lol))
            //{
            //    foreach (ZipEntry e in zip2)
            //    {
            //        if (e.FileName.EndsWith(".txt"))
            //        {
            //            var newname = "renamed_files\\" + e.FileName;

            //            e.FileName = newname;
            //            e.Comment = "renamed";
            //            renameCount++;
            //        }
            //    }
            //    zip2.Comment = String.Format("This archive has been modified. {0} files have been renamed.", renameCount);
            //    zip2.Save();
            //}
        }


        public string blabla(string dir)
        {
            //JObject o1 = JObject.Parse(File.ReadAllText(dir));

            // read JSON directly from a file
            //StreamReader file = File.OpenText(dir);
            using (StreamReader r = new StreamReader(dir))
            {
                string json = r.ReadToEnd();

                dynamic result = JsonConvert.DeserializeObject(json);
                var urls = new List<string>();
                //result = result.ToString().Substring(1, result.ToString().Length - 2);
                string x = "";
                foreach (var file2 in result.twet.files)
                {
                    //urls.Add(result.text);
                    x += file2.text;
                }

                //return o1.ToString();
                return x;
            }

            
        }
    }
}