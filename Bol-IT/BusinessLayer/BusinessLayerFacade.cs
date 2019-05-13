using System;
using System.IO;
using System.Drawing;
using GlobalClasses;
using System.Windows.Forms;
using System.Data;

namespace BusinessLayer
{
    public class BusinessLayerFacade
    {
        #region Threads

        //Tobias
        public static void SloganThreadStart(Label label)
        {
            SloganThread.SloganThreadsStart(label);
        }

        //Christoffer
        public static byte[] GetPhotoFromPath(string path)
        {
            return File.ReadAllBytes(path);
        }

        //Christoffer
        public static Image ConvertBinaryArrayToImage(byte[] photo)
        {
            if (photo == null)
            {
                return null;
            }
            using (MemoryStream ms = new MemoryStream(photo))
            {
                return Image.FromStream(ms);
            }
        }
        #endregion

        public static DataTable DistributeHouses(DataTable agentDataTable, DataTable propertyDataTable, int sortMethod)
        {
            return OpenHouseMethods.DistributeHouses(agentDataTable, propertyDataTable, sortMethod);
        }


    }
}
