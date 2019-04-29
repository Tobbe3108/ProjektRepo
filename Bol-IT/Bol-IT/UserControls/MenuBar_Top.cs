using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Bol_IT
{
    public partial class MenuBar_Top : UserControl
    {
        //Singleton instance af MenuBar_Top
        static MenuBar_Top _instance;
        public static MenuBar_Top Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MenuBar_Top();
                }
                return _instance;
            }
        }

        public MenuBar_Top()
        {
            InitializeComponent();
        }

        private void MenuBar_Top_Load(object sender, EventArgs e)
        {
            //Eager initialization af singleton instance
            _instance = this;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (ParentForm.WindowState == FormWindowState.Maximized)
            {
                ParentForm.WindowState = FormWindowState.Normal;
            }
            else
            {
                ParentForm.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            ParentForm.WindowState = FormWindowState.Minimized;
        }
    }
}
