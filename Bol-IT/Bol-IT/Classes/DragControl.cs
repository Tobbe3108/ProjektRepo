using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bol_IT
{
    //Tobias
    //Selvdefineret komponent til brug i vores form til håndtering af user drag input
    class DragControl : Component
    {
        private Control handleControl;

        public Control SelectControl
        {
            get
            {
                return handleControl;
            }
            set
            {
                handleControl = value;
                handleControl.MouseDown += new MouseEventHandler(DragForm_MouseDown);
            }
        }

        //Import af user32.dll som er en komponent i Windows styresystemet som benyttes til at lave UI
        //https://www.wikiwand.com/en/Windows_USER
        [DllImport("user32.dll")]

        //Defination til brud af externe funktion SendMessage fra user32.dll
        public static extern int SendMessage(IntPtr a, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]

        //Defination til brud af externe funktion ReleaseCapture fra user32.dll som benyttes til at frigive mouse capture fra et åbent vindue
        public static extern bool ReleaseCapture();

        //Selvdef MouseDown event
        private void DragForm_MouseDown(object sender, MouseEventArgs e)
        {
            bool flag = e.Button == MouseButtons.Left;
            if (flag)
            {
                ReleaseCapture();
                SendMessage(SelectControl.FindForm().Handle, 161, 2, 0);
            }
        }
    }
}

