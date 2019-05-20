using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace Bol_IT
{
    public partial class LoginPage : UserControl
    {
        #region Init
        //Christoffer
        //Singleton instance af Sag_Create
        static LoginPage _instance;
        public static LoginPage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoginPage();
                }
                return _instance;
            }
        }

        private LoginPage()
        {
            InitializeComponent();


            //Form autosize
            LoginPage_SizeChanged(this, new EventArgs());
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            //Eager initialization af singleton instance
            _instance = this;

            tbPassword.PasswordChar = '*';

            SignOff();
        }

        private void LoginPage_SizeChanged(object sender, EventArgs eventArgs)
        {
            foreach (var lbl in tableLayoutPanel1.Controls.OfType<Label>())
            {
                lbl.Font = new Font(lbl.Font.FontFamily, this.Size.Height / 50);
            }
            //Special title
            lblTitleLogin.Font = new Font(lblTitleLogin.Font.FontFamily, this.Size.Height / 25);
            foreach (var tb in tableLayoutPanel1.Controls.OfType<TextBox>())
            {
                tb.Font = new Font(tb.Font.FontFamily, this.Size.Height / 50);
            }
            foreach (var btn in tableLayoutPanel1.Controls.OfType<Button>())
            {
                btn.Font = new Font(btn.Font.FontFamily, this.Size.Height / 50);
            }
        }

        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (DataAccessLayer.DataAccessLayerFacade.CheckForSQLInjection(tbUsername.Text, tbPassword.Text))
            {
                return;
            }
            if (BusinessLayerFacade.TryLogon(tbUsername.Text, tbPassword.Text))
            {
                MenuBar_Left.Instance.ShowButtons();
                MenuBar_Top.Instance.ShowButtons();
                //Load Sag_ViewAll User control når tryk på knap
                if (!Form1.Instance.PnlContainer.Controls.ContainsKey("Sag_ViewAll"))
                {
                    Sag_ViewAll.Instance.Dock = DockStyle.Fill;
                    Form1.Instance.PnlContainer.Controls.Add(Sag_ViewAll.Instance);
                }
                Form1.Instance.PnlContainer.Controls["Sag_ViewAll"].BringToFront();

            }
            else
            {
                BusinessLayerFacade.NotifyAboutFailMessage(lblMessage);
            }
        }

        public void SignOff()
        {
            MenuBar_Left.Instance.SignOff();
            MenuBar_Top.Instance.HideButtons();

            tbUsername.Text = string.Empty;
            tbPassword.Text = string.Empty;
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnLogin_Click(null, null);
            }
        }
    }
}
