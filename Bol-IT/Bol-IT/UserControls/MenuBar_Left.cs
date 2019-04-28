using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bol_IT
{
    public partial class MenuBar_Left : UserControl
    {
        public MenuBar_Left()
        {
            InitializeComponent();
        }



        //Button select color change
        private void lblSager_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSager.BackColor = ColorTranslator.FromHtml("#1A4971");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#2368A2");
        }

        private void lblOpenHouse_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#1A4971");
            tlpSager.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#2368A2");
        }

        private void lblSignOut_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSager.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#1A4971");
        }

        private void pbSager_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSager.BackColor = ColorTranslator.FromHtml("#1A4971");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#2368A2");
        }

        private void pbOpenHouse_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#1A4971");
            tlpSager.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#2368A2");
        }

        private void pbSignOut_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSager.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#1A4971");
        }
    }
}
