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
        public int PropSquareMeter { get; set; }
        public Messagebox_PriceCalculator()
        {
            InitializeComponent();
        }

        public void LoadData(int propSquareMeter)
        {
            PropSquareMeter = propSquareMeter;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int cashPrice = PriceCalculator.CalculateCashPrice(PropSquareMeter, (int)cbZipcode.SelectedItem, (string)cbCondition.SelectedItem, (string)cbInteriorDesign.SelectedItem, (string)cbStyle.SelectedItem, (string)cbKitchen.SelectedItem, (string)cbBathroom.SelectedItem, cbGardenFlag.Checked);
            int grossPrice = PriceCalculator.CalculateGrossPrice(cashPrice);
            int netPrice = PriceCalculator.CalculateNetPrice(cashPrice);
            int ownerExpences = PriceCalculator.CalculateOwnerExpences(cashPrice);
            int depositPrice = PriceCalculator.CalculateDepositPrice(cashPrice);
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
