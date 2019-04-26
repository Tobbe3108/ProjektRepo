using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Bol_IT
{
    public partial class MenuBar_Top : UserControl
    {
        public MenuBar_Top()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void MenuBar_Top_SizeChanged(object sender, EventArgs e)
        {
            lblDate.Font = new Font(lblDate.Font.FontFamily, this.Size.Height / 4);
            lblSlogan.Font = new Font(lblSlogan.Font.FontFamily, this.Size.Height / 4);
            lblTime.Font = new Font(lblTime.Font.FontFamily, this.Size.Height / 4);
        }
    }
}
