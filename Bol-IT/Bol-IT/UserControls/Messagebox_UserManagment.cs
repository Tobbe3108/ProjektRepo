using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DataAccessLayer;

namespace Bol_IT
{
    public partial class Messagebox_UserManagment : Form
    {

        #region Init
        public Messagebox_UserManagment()
        {
            InitializeComponent();
        }

        private void Messagebox_UserManagment_Load(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = '*';
            tbUsername.Focus();
            Messagebox_UserManagment_SizeChanged(null, null);
        }
        #endregion

        #region AutoSize

        private void Messagebox_UserManagment_SizeChanged(object sender, EventArgs eventArgs)
        {
            try
            {
                foreach (Control item in tableLayoutPanel1.Controls.Cast<Control>())
                {
                    if (item.Name.ToLowerInvariant().Contains("title"))
                    {
                        item.Font = new Font("Tahoma", this.Size.Height / 25);
                    }
                    else
                    {
                        item.Font = new Font("Tahoma", this.Size.Height / 40);
                    }
                    if (item.GetType().Name == "TextBox")
                    {
                        TableLayoutPanelCellPosition pos = ((TableLayoutPanel)item.Parent).GetCellPosition(item);
                        int height = (((TableLayoutPanel)item.Parent).GetRowHeights()[pos.Row] - item.Height) / 2;
                        item.Margin = new Padding(6, height, 6, height);
                    }
                }
            }
            catch { }
        }

        #endregion



        #region Events
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (DataAccessLayerFacade.CheckForSQLInjection(tbUsername.Text, tbPassword.Text))
            {
                return;
            }
            if (!UserExists(tbUsername.Text))
            {
                lblMessage.Text = "Brugernavnet eksisterer ikke. Lav en ny bruger istedet.";
                BusinessLayerFacade.NotifyAboutFailMessage(lblMessage);
                return;
            }
            BusinessLayerFacade.UpdateUser(tbUsername.Text, tbPassword.Text);

            lblMessage.Text = "Brugeren blev successfuldt opdateret.";
            BusinessLayerFacade.NotifyAboutFailMessage(lblMessage);
        }

        private void btnMakeNewUser_Click(object sender, EventArgs e)
        {
            if (DataAccessLayerFacade.CheckForSQLInjection(tbUsername.Text, tbPassword.Text))
            {
                return;
            }
            if (UserExists(tbUsername.Text))
            {
                lblMessage.Text = "Brugernavnet eksisterer allerede. Vælg et andet brugernavn.";
                BusinessLayerFacade.NotifyAboutFailMessage(lblMessage);
                return;
            }
            BusinessLayerFacade.CreateNewUser(tbUsername.Text, tbPassword.Text);

            lblMessage.Text = "Brugeren blev successfuldt oprettet.";
            BusinessLayerFacade.NotifyAboutFailMessage(lblMessage);
        }

        #endregion


        #region Methods
        private bool UserExists(string username)
        {
            return DataAccessLayerFacade.UserExists(username);
        }
        #endregion


    }
}
