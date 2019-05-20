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

            SignOff();
            tbPassword.PasswordChar = '*';
            tbUsername.Focus();
        }

        #endregion

        #region AutoSize
        public void LoginPage_SizeChanged(object sender, EventArgs eventArgs)
        {
            try
            {
                foreach (Control item in tableLayoutPanel1.Controls.Cast<Control>())
                {
                    if (item.Name.ToLowerInvariant().Contains("title"))
                    {
                        item.Font = new Font(item.Font.FontFamily, this.Size.Height / 25);
                    }
                    else
                    {
                        item.Font = new Font(item.Font.FontFamily, this.Size.Height / 50);
                    }
                    TableLayoutPanelCellPosition pos = ((TableLayoutPanel)item.Parent).GetCellPosition(item);
                    int height = (((TableLayoutPanel)item.Parent).GetRowHeights()[pos.Row] - item.Height) / 2;
                    item.Margin = new Padding(6, height, 6, height);
                }
            }
            catch{ }
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

                Form1.Instance.AcceptButton = null;
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

            Form1.Instance.AcceptButton = btnLogin;
        }
    }
}
