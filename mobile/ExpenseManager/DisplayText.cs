using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExpenseManager
{
    public partial class DisplayText : Form
    {
        public DisplayText(string wndTxt,string lblTxt)
        {
            InitializeComponent();
            this.Text = wndTxt;
            this.label1.Text = lblTxt;
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}