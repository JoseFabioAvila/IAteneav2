using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace IAteneav2.Logic
{
    public class AnalizarComprimidos
    {



        public void openExistingZipFile(string lol)
        {
            int renameCount = 0;
            using (ZipFile zip2 = ZipFile.Read(lol))
            {
                foreach (ZipEntry e in zip2)
                {
                    if (e.FileName.EndsWith(".txt"))
                    {
                        var newname = "renamed_files\\" + e.FileName;

                        e.FileName = newname;
                        e.Comment = "renamed";
                        renameCount++;
                    }
                }
                zip2.Comment = String.Format("This archive has been modified. {0} files have been renamed.", renameCount);
                zip2.Save();
            }
        }
    }
}