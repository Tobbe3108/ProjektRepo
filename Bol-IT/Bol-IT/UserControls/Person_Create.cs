using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using System.Threading;

namespace Bol_IT
{
    public partial class Person_Create : UserControl
    {
        #region Fields

        public string TypeChange { get; set; }

        public int id { get; set; }

        #endregion

        #region Init

        //Tobias
        //Singleton instance af Sag_Create
        static Person_Create _instance;
        public static Person_Create Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Person_Create();
                }
                return _instance;
            }
        }

        public Person_Create()
        {
            InitializeComponent();
        }

        #endregion

        #region FormAutoSize

        //Tobias
        private void Person_Create_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                lblAddress.Font = new Font(lblAddress.Font.FontFamily, this.Size.Height / 50);
                lblFName.Font = new Font(lblFName.Font.FontFamily, this.Size.Height / 50);
                lblLName.Font = new Font(lblLName.Font.FontFamily, this.Size.Height / 50);
                lblMail.Font = new Font(lblMail.Font.FontFamily, this.Size.Height / 50);
                lblMName.Font = new Font(lblMName.Font.FontFamily, this.Size.Height / 50);
                lblPhoneNr.Font = new Font(lblPhoneNr.Font.FontFamily, this.Size.Height / 50);
                lblType.Font = new Font(lblType.Font.FontFamily, this.Size.Height / 50);
                lblTypeChainging.Font = new Font(lblTypeChainging.Font.FontFamily, this.Size.Height / 50);
                lblZipcode.Font = new Font(lblZipcode.Font.FontFamily, this.Size.Height / 50);
            }
            catch{}
        }

        #endregion

        #region Methods

        private void MakeNoBoxEmpty()
        {
            if (rtbAddress.Text == string.Empty)
            { rtbAddress.Text = "Ingen tekst"; }
            if (rtbFName.Text == string.Empty)
            { rtbFName.Text = "Ingen tekst"; }
            if (rtbLName.Text == string.Empty)
            { rtbLName.Text = "Ingen tekst"; }
            if (rtbMail.Text == string.Empty)
            { rtbMail.Text = "Ingen tekst"; }
            if (rtbMName.Text == string.Empty)
            { rtbMName.Text = "Ingen tekst"; }
            if (rtbPhoneNr.Text == string.Empty)
            { rtbPhoneNr.Text = "0"; }
            if (rtbTypeChainging.Text == string.Empty)
            { rtbTypeChainging.Text = "Ingen tekst"; }
            if (rtbZipcode.Text == string.Empty)
            { rtbZipcode.Text = "0"; }
        }

        #endregion

        #region Events

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Load Person_ViewAll User control når tryk på knap
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("Person_ViewAll"))
            {
                Person_ViewAll.Instance.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(Person_ViewAll.Instance);
            }
            Form1.Instance.PnlContainer.Controls["Person_ViewAll"].BringToFront();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MakeNoBoxEmpty();

            if (TypeChange == "Create")
            {
                switch (cbType.SelectedIndex)
                {
                    case 0:
                        DataAccessLayerFacade.CreateAgent(rtbFName.Text, rtbMName.Text, rtbLName.Text, Convert.ToInt32(rtbPhoneNr.Text), rtbAddress.Text, Convert.ToInt32(rtbZipcode.Text), rtbMail.Text, Convert.ToInt32(rtbTypeChainging.Text));
                        break;
                    case 1:
                        DataAccessLayerFacade.CreateSeller(rtbFName.Text, rtbMName.Text, rtbLName.Text, Convert.ToInt32(rtbPhoneNr.Text), rtbAddress.Text, Convert.ToInt32(rtbZipcode.Text), rtbMail.Text, Convert.ToInt32(rtbTypeChainging.Text));
                        break;
                    case 2:
                        DataAccessLayerFacade.CreateBuyer(rtbFName.Text, rtbMName.Text, rtbLName.Text, Convert.ToInt32(rtbPhoneNr.Text), rtbAddress.Text, Convert.ToInt32(rtbZipcode.Text), rtbMail.Text, Convert.ToInt32(rtbTypeChainging.Text));
                        break;
                }
            }
            else if (TypeChange == "Update")
            {
                switch (cbType.SelectedIndex)
                {
                    case 0:
                        DataAccessLayerFacade.AgentUpdateData(id, rtbFName.Text, rtbMName.Text, rtbLName.Text, Convert.ToInt32(rtbPhoneNr.Text), rtbAddress.Text, Convert.ToInt32(rtbZipcode.Text), rtbMail.Text, Convert.ToInt32(rtbTypeChainging.Text));
                        break;
                    case 1:
                        DataAccessLayerFacade.SellerUpdateData(id, rtbFName.Text, rtbMName.Text, rtbLName.Text, Convert.ToInt32(rtbPhoneNr.Text), rtbAddress.Text, Convert.ToInt32(rtbZipcode.Text), rtbMail.Text, Convert.ToInt32(rtbTypeChainging.Text));
                        break;
                    case 2:
                        DataAccessLayerFacade.BuyerUpdateData(id, rtbFName.Text, rtbMName.Text, rtbLName.Text, Convert.ToInt32(rtbPhoneNr.Text), rtbAddress.Text, Convert.ToInt32(rtbZipcode.Text), rtbMail.Text, Convert.ToInt32(rtbTypeChainging.Text));
                        break;
                }
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbType.SelectedIndex)
            {
                case 0:
                    lblTypeChainging.Text = "Antal salg";
                    break;
                case 1:
                case 2:
                    lblTypeChainging.Text = "Mægler nummer";
                    break;
            }
        }

        #endregion

    }
}
