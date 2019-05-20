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
using DataAccessLayer;

namespace Bol_IT
{
    public partial class MenuBar_Left : UserControl
    {
        #region Init

        //Tobias
        //Singleton instance af MenuBar_Left
        private static MenuBar_Left _instance;
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

        public void SignOff()
        {
            tlpSager.Hide();
            tlpPersonData.Hide();
            tlpOpenHouse.Hide();
            MenuBar_Top.Instance.HideButtons();

            lblSignOut.Text = "Login";

            //Load LoginPage User control når tryk på knap
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("LoginPage"))
            {
                LoginPage.Instance.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(LoginPage.Instance);
            }
            Form1.Instance.PnlContainer.Controls["LoginPage"].BringToFront();
        }

        public void ShowButtons()
        {
            tlpSager.Show();
            tlpPersonData.Show();
            tlpOpenHouse.Show();

            tlpSignOut.Show();
            lblSignOut.Text = "Log af";

            //Load Sag_ViewAll User control når tryk på knap
            pbSager_Click(null, null);
        }

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



        private void LoadPersonalData()
        {
            //Load Sag_ViewAll User control når tryk på knap
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("Person_ViewAll"))
            {
                Person_ViewAll.Instance.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(Person_ViewAll.Instance);
            }
            Form1.Instance.PnlContainer.Controls["Person_ViewAll"].BringToFront();
        }

        #endregion

        #region Events

        //Tobias
        private void lblSager_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpPersonData.BackColor = ColorTranslator.FromHtml("#2368A2");

            tlpSager.BackColor = ColorTranslator.FromHtml("#1A4971");

            LoadSagViewAll();
        }

        private void lblOpenHouse_Click(object sender, EventArgs e)
        {
            tlpSager.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpPersonData.BackColor = ColorTranslator.FromHtml("#2368A2");

            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#1A4971");

            LoadOpenHouse();
        }

        private void lblSignOut_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSager.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpPersonData.BackColor = ColorTranslator.FromHtml("#2368A2");

            tlpSignOut.BackColor = ColorTranslator.FromHtml("#1A4971");

            LoginPage.Instance.SignOff();
        }

        private void pbSager_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpPersonData.BackColor = ColorTranslator.FromHtml("#2368A2");

            tlpSager.BackColor = ColorTranslator.FromHtml("#1A4971");

            LoadSagViewAll();
        }

        private void pbOpenHouse_Click(object sender, EventArgs e)
        {
            tlpSager.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpPersonData.BackColor = ColorTranslator.FromHtml("#2368A2");

            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#1A4971");

            LoadOpenHouse();
        }

        private void pbSignOut_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSager.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpPersonData.BackColor = ColorTranslator.FromHtml("#2368A2");

            tlpSignOut.BackColor = ColorTranslator.FromHtml("#1A4971");

            LoginPage.Instance.SignOff();
        }

        private void pbPersonData_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSager.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#2368A2");

            tlpPersonData.BackColor = ColorTranslator.FromHtml("#1A4971");

            LoadPersonalData();
        }

        private void lblPersonData_Click(object sender, EventArgs e)
        {
            tlpOpenHouse.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSager.BackColor = ColorTranslator.FromHtml("#2368A2");
            tlpSignOut.BackColor = ColorTranslator.FromHtml("#2368A2");

            tlpPersonData.BackColor = ColorTranslator.FromHtml("#1A4971");

            LoadPersonalData();
        }

        #endregion

    }
}
