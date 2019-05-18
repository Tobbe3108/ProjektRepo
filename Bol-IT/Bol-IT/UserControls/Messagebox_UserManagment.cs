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
        public Messagebox_UserManagment()
        {
            InitializeComponent();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (!UserExists(rtbUsername.Text))
            {
                lblMessage.Text = "Brugernavnet eksisterer ikke. Lav en ny bruger istedet.";
                BusinessLayerFacade.NotifyAboutFailMessage(lblMessage);
                return;
            }
            BusinessLayerFacade.UpdateUser(rtbUsername.Text, rtbPassword.Text);

            lblMessage.Text = "Brugeren blev successfuldt opdateret.";
            BusinessLayerFacade.NotifyAboutFailMessage(lblMessage);
        }

        private void btnMakeNewUser_Click(object sender, EventArgs e)
        {
            if (UserExists(rtbUsername.Text))
            {
                lblMessage.Text = "Brugernavnet eksisterer allerede. Vælg et andet brugernavn.";
                BusinessLayerFacade.NotifyAboutFailMessage(lblMessage);
                return;
            }
            BusinessLayerFacade.CreateNewUser(rtbUsername.Text, rtbPassword.Text);

            lblMessage.Text = "Brugeren blev successfuldt oprettet.";
            BusinessLayerFacade.NotifyAboutFailMessage(lblMessage);
        }

        private bool UserExists(string username)
        {
            return DataAccessLayerFacade.UserExists(username);
        }
    }
}
