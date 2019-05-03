using System;
using System.Windows.Forms;

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

        #endregion

    }
}
