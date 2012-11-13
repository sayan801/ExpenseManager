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
    public delegate void delegateNewDataAdded2(string txt1,string txt2);
    public partial class AddData2 : Form
    {
        public event  delegateNewDataAdded2 OnNewDataAdded2; 

        public AddData2(string wndTxt,string lblTxt1,string lblTxt2)
        {
            InitializeComponent();
            this.Text = wndTxt;
            this.label1.Text = lblTxt1;
            this.label2.Text = lblTxt2;
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.OnNewDataAdded2(textBox1.Text, textBox2.Text);
            this.Close();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}