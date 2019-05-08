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

namespace Bol_IT.UserControls
{
    public partial class Messagebox_PriceCalculator : Form
    {
        public Messagebox_PriceCalculator()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int cashPrice = 0;// PriceCalculator.CalculateCashPrice();
            int grossPrice = PriceCalculator.CalculateGrossPrice(cashPrice);
            int netPrice = PriceCalculator.CalculateNetPrice(cashPrice);
            int ownerExpences = PriceCalculator.CalculateOwnerExpences(cashPrice);
            int depositPrice = PriceCalculator.CalculateDepositPrice(cashPrice);
            Sag_Create.Instance.UpdatePrice(grossPrice, netPrice, ownerExpences, depositPrice, cashPrice);
        }

        private void Messagebox_PriceCalculator_Load(object sender, EventArgs e)
        {
            foreach (var item in DataAccessLayerFacade.GetZipcodes())
            {

            }
        }
    }
}
