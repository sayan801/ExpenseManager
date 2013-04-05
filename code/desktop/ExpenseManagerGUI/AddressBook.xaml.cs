using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExpenseManagerGUI
{
    /// <summary>
    /// Interaction logic for AddressBook.xaml
    /// </summary>
    public partial class AddressBook : Window
    {
        public AddressBook()
        {
            InitializeComponent();
        }

        private void submitAddressBtn_Click(object sender, RoutedEventArgs e)
        {
            ExpenseManagerData.AddressInfo newAddress = new ExpenseManagerData.AddressInfo();

            newAddress.id = GenerateId();

            newAddress.name = nameBtn.Text;
            newAddress.mobile = mobBtn.Text;
            newAddress.home = homeBtn.Text;
            newAddress.office = ofcBtn.Text;
            newAddress.address = addressBtn.Text;
            newAddress.email = emailBtn.Text;
            newAddress.note = noteBtn.Text;


            ExpenseManagerDb.DbInteraction.DoEnterAddress(newAddress);

            addressTC.SelectedIndex = 0;
            
        }
        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }
    }
}
