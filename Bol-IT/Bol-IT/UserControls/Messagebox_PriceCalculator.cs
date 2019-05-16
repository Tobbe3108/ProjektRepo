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
    public partial class Messagebox_PriceCalculator : Form
    {
        //Simone
        public int PropSquareMeter { get; set; }
        public Messagebox_PriceCalculator()
        {
            InitializeComponent();
        }

        public void LoadData(int propSquareMeter, int zipcode)
        {
            cbCondition.SelectedIndex = 1;
            cbInteriorDesign.SelectedIndex = 1;
            cbStyle.SelectedIndex = 1;
            cbKitchen.SelectedIndex = 1;
            cbBathroom.SelectedIndex = 1;
            PropSquareMeter = propSquareMeter;

            foreach (int zipcodeItem in cbZipcode.Items)
            {
                if(zipcodeItem == zipcode)
                {
                    cbZipcode.SelectedItem = zipcodeItem;
                }
            }

        }

        private bool ZipcodeEmpty()
        {
            if (cbZipcode.SelectedItem == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (ZipcodeEmpty())
            {
                MessageBox.Show("Der er ikke valgt et postnummer. Vælg et post nummer og prøv igen.", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int cashPrice = BusinessLayerFacade.CalculateCashPrice(PropSquareMeter, (int)cbZipcode.SelectedItem, (string)cbCondition.SelectedItem, (string)cbInteriorDesign.SelectedItem, (string)cbStyle.SelectedItem, (string)cbKitchen.SelectedItem, (string)cbBathroom.SelectedItem, cbGardenFlag.Checked);
            int grossPrice = BusinessLayerFacade.CalculateGrossPrice(cashPrice);
            int netPrice = BusinessLayerFacade.CalculateNetPrice(cashPrice);
            int ownerExpences = BusinessLayerFacade.CalculateOwnerExpences(cashPrice);
            int depositPrice = BusinessLayerFacade.CalculateDepositPrice(cashPrice);
            Sag_Create.Instance.UpdatePrice(grossPrice, netPrice, ownerExpences, depositPrice, cashPrice);
            this.Close();
        }

        private void Messagebox_PriceCalculator_Load(object sender, EventArgs e)
        {
            DataTable dataTable = DataAccessLayerFacade.GetZipcodes();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cbZipcode.Items.Add(dataTable.Rows[i]["Zipcode"]);
            }
        }
    }
}
