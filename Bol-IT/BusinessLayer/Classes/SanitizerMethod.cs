using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    class SanitizerMethod
    {
        public static bool Sanitizer(RichTextBox rtbFName, RichTextBox rtbMName, RichTextBox rtbLName, RichTextBox rtbPhoneNr, RichTextBox rtbAddress, RichTextBox rtbZipcode, RichTextBox rtbMail, RichTextBox rtbTypeChainging, ComboBox cbType)
        {
            if (DataAccessLayerFacade.CheckForSQLInjection(rtbFName.Text, rtbMName.Text, rtbLName.Text, rtbPhoneNr.Text, rtbAddress.Text, rtbZipcode.Text, rtbMail.Text, rtbTypeChainging.Text))
            {
                MessageBox.Show("Felterne må ikke indeholde ';' Ret venligst dette", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rtbAddress.Text == string.Empty || rtbFName.Text == string.Empty || rtbLName.Text == string.Empty || rtbMail.Text == string.Empty || rtbMName.Text == string.Empty || rtbPhoneNr.Text == string.Empty || rtbTypeChainging.Text == string.Empty || rtbZipcode.Text == string.Empty)
            {
                MessageBox.Show("Der må ikke være nogle tomme felter. Ret venligst dette", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!rtbMail.Text.ToString().Contains('@') || !rtbMail.Text.ToString().Contains('.'))
            {
                MessageBox.Show("Mailadressen skal indeholde '@' og '.' Ret venligst dette", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rtbZipcode.Text.Length != 4 || !rtbZipcode.Text.All(char.IsDigit))
            {
                MessageBox.Show("Postnummeret skal bestå af 4 tal. Ret venligst dette", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rtbPhoneNr.Text.Length != 8 || !rtbPhoneNr.Text.All(char.IsDigit))
            {
                MessageBox.Show("Telefonnummeret skal bestå af 8 tal. Ret venligst dette", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!rtbTypeChainging.Text.All(char.IsDigit))
            {
                switch (cbType.SelectedIndex)
                {
                    case 0:
                        MessageBox.Show("Antal salg skal være et tal. Ret venligst dette", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 1:
                    case 2:
                        MessageBox.Show("Mægler nummer skal være et tal. Ret venligst dette", "Fejl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return false;
            }

            return true;
        }
    }
}
