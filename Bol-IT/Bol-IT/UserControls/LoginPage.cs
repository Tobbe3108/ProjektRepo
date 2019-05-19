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

            rtbUsername.SelectionAlignment = HorizontalAlignment.Center;
            rtbPassword.SelectionAlignment = HorizontalAlignment.Center;

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
            foreach (var rtb in tableLayoutPanel1.Controls.OfType<RichTextBox>())
            {
                rtb.Font = new Font(rtb.Font.FontFamily, this.Size.Height / 50);
            }
            foreach (var btn in tableLayoutPanel1.Controls.OfType<Button>())
            {
                btn.Font = new Font(btn.Font.FontFamily, this.Size.Height / 50);
            }
        }

        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (BusinessLayerFacade.TryLogon(rtbUsername.Text, rtbPassword.Text))
            {
                MenuBar_Left.Instance.ShowButtons();
                MenuBar_Top.Instance.ShowButtons();
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

            rtbUsername.Text = string.Empty;
            rtbPassword.Text = string.Empty;
        }
    }
}
