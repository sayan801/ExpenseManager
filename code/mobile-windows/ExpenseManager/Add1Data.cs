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
    public delegate void delegateNewDataAdded(string data);
    public partial class AddData : Form
    {
        public event delegateNewDataAdded OnNewDataAdded;
        
        public AddData(string wndTxt1,string lblTxt1)
        {
            InitializeComponent();
            this.Text = wndTxt1;
            this.textLabel.Text = lblTxt1;           
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.OnNewDataAdded(this.dataTextBox.Text);
            this.Close();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}