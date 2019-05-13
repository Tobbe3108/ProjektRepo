using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class SloganThread
    {
        #region Fields

        //Tobias
        public static Dictionary<int, string> pairs = new Dictionary<int, string>()
        {
            {1,"Sælg før din nabo!"},
            {2,"Vi har nøglen til dit drømmehus!"},
        };

        #endregion

        #region Methods

        //Tobias
        public static void SloganThreadsStart(Label label) //Laver 2 Threads der køre ThreadMethod
        {
            Thread Slogan1 = new Thread(() => ThreadMethod(label, 1));
            Slogan1.IsBackground = true;
            Slogan1.Start();

            Thread Slogan2 = new Thread(() => ThreadMethod(label, 2));
            Slogan2.IsBackground = true;
            Slogan2.Start();
        }

        private static void ThreadMethod(Label label, int ThreadNr) //Metode der køre så længe programmet er åbent
        {
            //Hvis anden thread vent 60 sek med at opdater
            if (ThreadNr == 2)
            {
                Thread.Sleep(60000);
            }
            while (true)
            {
                //Vent 60 sek, opdater slogan og vent 60 sek igen
                Thread.Sleep(60000);
                Update(label, pairs[ThreadNr]);
                Thread.Sleep(60000);
            }
        } 

        private static void Update(Label label, string slogan) //Opdatere slogan label på main form fra thread
        {
            //Hvis invoke nødvendigt gør dette før opdatering af tekst
            if (label.InvokeRequired)
            {
                label.Invoke((MethodInvoker)delegate { label.Text = slogan; });
            }
            else
            {
                label.Text = slogan;
            }
        }

        #endregion
    }
}
