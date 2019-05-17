using System;
using System.IO;
using GlobalClasses;
using DataAccessLayer;

namespace BusinessLayer
{
    public class FileMethods
    {
        public static void ShowFile(string path)
        {
            path = Path.GetTempPath() + path;
            //If the temp file already exists, then don't get the file from database
            if (!File.Exists(path))
            {
                Document document = DataAccessLayerFacade.GetDocumentByName(Path.GetFileNameWithoutExtension(path));
                File.WriteAllBytes(path, document.Data);
            }
            System.Diagnostics.Process.Start(path);
        }

        public static void CopyFile(string fileName)
        {
            string path = Path.GetTempPath() + Path.GetFileName(fileName);
            if (File.Exists(path)) //Hvis filen eksisterer, skal den slettes i tilfælde af en ny opdatering til filen
            {
                File.Delete(path);
            }
            File.Copy(fileName, path);
        }
    }
}