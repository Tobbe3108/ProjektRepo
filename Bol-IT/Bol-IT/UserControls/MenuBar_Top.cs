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
using BusinessLayer;
using GlobalClasses;

namespace Bol_IT
{
    public partial class MenuBar_Top : UserControl
    {
        #region Init

        //Tobias
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

        private MenuBar_Top()
        {
            InitializeComponent();
        }

        private void MenuBar_Top_Load(object sender, EventArgs e)
        {
            //Eager initialization af singleton instance
            _instance = this;

            //Start slogan threads
            BusinessLayerFacade.SloganThreadStart(lblSlogan);
        }

        #endregion

        #region Events

        //Tobias
        private void btnClose_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

        //Tobias
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (ParentForm.WindowState == FormWindowState.Maximized)
            {
                ParentForm.WindowState = FormWindowState.Normal;
                Properties.Settings.Default.MainWindowState = FormWindowState.Normal;
            }
            else
            {
                ParentForm.WindowState = FormWindowState.Maximized;
                Properties.Settings.Default.MainWindowState = FormWindowState.Maximized;
            }
        }

        //Tobias
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            ParentForm.WindowState = FormWindowState.Minimized;
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm");
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
