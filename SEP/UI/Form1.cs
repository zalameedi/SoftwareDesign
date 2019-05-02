using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class LocalEatery : Form
    {
        public LocalEatery()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Table1_Order_Click(object sender, EventArgs e)
        {
            this.orderDialog(1);
        }

        /// <summary>
        /// Prompt for dishes to order through UI for specified table number
        /// Create Order <see cref="MenuLogic.Order"/>
        /// send Order to cook
        /// </summary>
        private void orderDialog(int tableNo)
        {
            //Ignore snippet below, it's just something I found online
            MessageBox.Show("Choose Dish", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}
