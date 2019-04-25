using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bol_IT
{
    public partial class Form1 : Form
    {
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

        public Panel pnlContainerl
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
            _instance = this;

            MenuBar_Left menuBar_Left = new MenuBar_Left();
            MenuBar_Top menuBar_Top = new MenuBar_Top();
            Sag_Create sag_Create = new Sag_Create();

            menuBar_Left.Dock = DockStyle.Fill;
            menuBar_Top.Dock = DockStyle.Fill;
            sag_Create.Dock = DockStyle.Fill;

            pnlMenuBarLeft.Controls.Add(menuBar_Left);
            pnlMenuBarTop.Controls.Add(menuBar_Top);
            pnlContainer.Controls.Add(sag_Create);
        }
    }
}
