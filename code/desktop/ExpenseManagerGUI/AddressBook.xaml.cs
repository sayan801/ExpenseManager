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
using ExpenseManagerData;
using ExpenseManagerDb;
using System.Collections.ObjectModel;

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



        ObservableCollection<AddressInfo> _addressCollection = new ObservableCollection<AddressInfo>();


        public ObservableCollection<AddressInfo> addressCollection
        {
            get
            {
                return _addressCollection;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fetchAddressData();
        }

        private void fetchAddressData()
        {
            List<AddressInfo> addresses = ExpenseManagerDb.DbInteraction.GetAllAddressList();

            _addressCollection.Clear();

            foreach (AddressInfo address in addresses)
            {
                _addressCollection.Add(address);
            }
        }



        private AddressInfo GetSelectedAddressItem()
        {

            AddressInfo addressToDelete = null;

            if (addressView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                AddressInfo i = (AddressInfo)addressView.SelectedItem;

                //addressToDelete = _addressCollection.Where(item => item.id.Equals(i.id)).First();
                addressToDelete = _addressCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return addressToDelete;
        }
        private void delAddress_Click(object sender, RoutedEventArgs e)
        {
            AddressInfo addressToDelete = GetSelectedAddressItem();
            if (addressToDelete != null)
            {
                _addressCollection.Remove(addressToDelete);
                ExpenseManagerDb.DbInteraction.DeleteAddress(addressToDelete.id);
                fetchAddressData();

            }
        }
    }
}
