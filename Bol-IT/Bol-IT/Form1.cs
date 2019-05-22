using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Bol_IT
{
    public partial class Form1 : Form
    {
        #region Fields

        //Tobias
        int Mx;
        int My;
        int Sw;
        int Sh;
        bool mov;

        #endregion

        #region Init

        //Tobias
        //Singleton instance af Form1
        static Form1 _instance;
        public static Form1 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Form1();
                }
                return _instance;
            }
        }

        private Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Eager initialization af singleton instance
            _instance = this;

            this.WindowState = Properties.Settings.Default.MainWindowState;

            //User control initialization
            MenuBar_Left.Instance.Dock = DockStyle.Fill;
            pnlMenuBarLeft.Controls.Add(MenuBar_Left.Instance);

            MenuBar_Top.Instance.Dock = DockStyle.Fill;
            pnlMenuBarTop.Controls.Add(MenuBar_Top.Instance);

            Sag_ViewAll.Instance.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(Sag_ViewAll.Instance);
        }

        #endregion

        #region Methods
        
        //Tobias
        //Public reference til pnlContainerl
        public Panel PnlContainer
        {
            get { return pnlContainer; }
            set { pnlContainer = value; }
        }

        #endregion

        #region FormAutoSize

        //Tobias
        private void pnlSizerBottom_MouseDown(object sender, MouseEventArgs e)
        {
            SizerMouseDown();
        }

        private void pnlSizerBottom_MouseMove(object sender, MouseEventArgs e)
        {
            SizerMouseMoveDown();
        }

        private void pnlSizerBottom_MouseUp(object sender, MouseEventArgs e)
        {
            SizerMouseUp();
        }

        private void pnlSizerCorner_MouseDown(object sender, MouseEventArgs e)
        {
            SizerMouseDown();
        }

        private void pnlSizerCorner_MouseMove(object sender, MouseEventArgs e)
        {
            SizerMouseMoveCorner();
        }

        private void pnlSizerCorner_MouseUp(object sender, MouseEventArgs e)
        {
            SizerMouseUp();
        }

        private void pnlSizerRight_MouseDown(object sender, MouseEventArgs e)
        {
            SizerMouseDown();
        }

        private void pnlSizerRight_MouseMove(object sender, MouseEventArgs e)
        {
            SizerMouseMoveRight();
        }

        private void pnlSizerRight_MouseUp(object sender, MouseEventArgs e)
        {
            SizerMouseUp();
        }

        private void SizerMouseDown()
        {
            try
            {
                SuspendLayout();
                mov = true;
                My = MousePosition.Y;
                Mx = MousePosition.X;
                Sw = Width;
                Sh = Height;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SizerMouseMoveDown()
        {
            if (mov == true)
            {
                //Width = MousePosition.X - Mx + Sw;
                Height = MousePosition.Y - My + Sh;
            }
        }

        private void SizerMouseMoveRight()
        {
            if (mov == true)
            {
                Width = MousePosition.X - Mx + Sw;
                //Height = MousePosition.Y - My + Sh;
            }
        }

        private void SizerMouseMoveCorner()
        {
            if (mov == true)
            {
                Width = MousePosition.X - Mx + Sw;
                Height = MousePosition.Y - My + Sh;
            }
        }

        private void SizerMouseUp()
        {
            ResumeLayout();
            mov = false;
        }


        #endregion

        #region Events
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MainWindowState = this.WindowState;
            Properties.Settings.Default.Save();
        }

        #endregion

    }
}
