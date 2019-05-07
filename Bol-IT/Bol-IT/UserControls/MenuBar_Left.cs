using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlobalClasses;

namespace Bol_IT
{
    public partial class MenuBar_Left : UserControl
    {
        #region Init

        //Tobias
        //Singleton instance af MenuBar_Left
        static MenuBar_Left _instance;
        public static MenuBar_Left Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MenuBar_Left();
                }
                return _instance;
            }
        }

        private MenuBar_Left()
        {
            InitializeComponent();

            lblSager_Click(this, new EventArgs());
        }

        private void MenuBar_Left_Load(object sender, EventArgs e)
        {
            //Eager initialization af singleton instance
            _instance = this;
        }

        #endregion

        #region Methods

        //Tobias
        private void LoadSagViewAll()
        {
            //Load Sag_ViewAll User control når tryk på knap
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("Sag_ViewAll"))
            {
                Sag_ViewAll.Instance.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(Sag_ViewAll.Instance);
            }
            Form1.Instance.PnlContainer.Controls["Sag_ViewAll"].BringToFront();
        }

        //Tobias
        private void LoadOpenHouse()
        {
            //Load Sag_ViewAll User control når tryk på knap
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("OpenHouse_Distribution"))
            {
                OpenHouse_Distribution.Instance.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(OpenHouse_Distribution.Instance);
            }
            Form1.Instance.PnlContainer.Controls["OpenHouse_Distribution"].BringToFront();
        }

        #endregion

        #region Events

        //Tobias
        private void lblSager_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSager.BackColor = ColorTranslator.FromHtml("#1A4971");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#2368A2");

            LoadSagViewAll();
        }

        //Tobias
        private void lblOpenHouse_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#1A4971");
            tlpSager.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#2368A2");

            LoadOpenHouse();
        }

        //Tobias
        private void lblSignOut_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSager.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#1A4971");
        }

        //Tobias
        private void pbSager_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSager.BackColor = ColorTranslator.FromHtml("#1A4971");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#2368A2");

            LoadSagViewAll();
        }

        //Tobias
        private void pbOpenHouse_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#1A4971");
            tlpSager.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#2368A2");

            LoadOpenHouse();
        }

        //Tobias
        private void pbSignOut_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSager.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#1A4971");
        }

        #endregion
    }
}
