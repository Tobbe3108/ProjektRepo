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



        //Public reference til pnlContainerl
        public Panel PnlContainer
        {
            get { return pnlContainer; }
            set { pnlContainer = value; }
        }



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Eager initialization af singleton instance
            _instance = this;

            //User control initialization
            MenuBar_Left menuBar_Left = new MenuBar_Left();
            MenuBar_Top menuBar_Top = new MenuBar_Top();
            Sag_ViewAll sag_ViewAll = new Sag_ViewAll();

            menuBar_Left.Dock = DockStyle.Fill;
            menuBar_Top.Dock = DockStyle.Fill;
            sag_ViewAll.Dock = DockStyle.Fill;

            pnlMenuBarLeft.Controls.Add(menuBar_Left);
            pnlMenuBarTop.Controls.Add(menuBar_Top);
            pnlContainer.Controls.Add(sag_ViewAll);
        }



        //Form resize
        int Mx;
        int My;
        int Sw;
        int Sh;
        bool mov;

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
            SuspendLayout();
            mov = true;
            My = MousePosition.Y;
            Mx = MousePosition.X;
            Sw = Width;
            Sh = Height;
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
        //---//



    }
}
