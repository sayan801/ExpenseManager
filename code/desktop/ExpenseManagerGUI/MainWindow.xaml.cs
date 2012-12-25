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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using ExpenseManagerData;
using System.Collections.ObjectModel;

namespace ExpenseManagerGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        ObservableCollection<ExcreditInfo> _excreditCollection = new ObservableCollection<ExcreditInfo>();


        public ObservableCollection<ExcreditInfo> excreditCollection
        {
            get
            {
                return _excreditCollection;
            }
        }


        public MainWindow()
        {
            InitializeComponent();
        }



        private void newDetailsMBtn_Click(object sender, RoutedEventArgs e)
        {
            //this.WindowState = System.Windows.WindowState.Minimized;
            ExpenseManagerGUI.NewDetailsWindow NewDetailsWindowObj = new ExpenseManagerGUI.NewDetailsWindow();
            NewDetailsWindowObj.Show();
        }

        private void newDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            //this.WindowState = System.Windows.WindowState.Minimized;
            ExpenseManagerGUI.NewDetailsWindow NewDetailsWindowObj = new ExpenseManagerGUI.NewDetailsWindow();
            NewDetailsWindowObj.Show();
        }
        

        private void closeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //this.WindowState = System.Windows.WindowState.Maximized;
            //Thread.Sleep(10000);
            this.Close();          
        }

        private void calMenuItem_Click(object sender, RoutedEventArgs e)
        {
            viewTabControl.SelectedIndex = 0;
        }

        private void gridMenuItem_Click(object sender, RoutedEventArgs e)
        {
            viewTabControl.SelectedIndex = 1;
        }

        private void listMenuItem_Click(object sender, RoutedEventArgs e)
        {
            viewTabControl.SelectedIndex = 2;
        }

        private void abtMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" Expense Manager V 1.0... \n Developed by technicise.com...");
        }

        private void calculatorBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void changeNameMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void changeSalaryDateMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void changeUnitMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void saveMonthlyReportMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void webSyncMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mobSyncMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void localBackupMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void viewBtn_Click(object sender, RoutedEventArgs e)
        {
            List<ExcreditInfo> excredits = ExpenseManagerDb.DbInteraction.GetAllExcreditList();

            _excreditCollection.Clear();

            foreach (ExcreditInfo excredit in excredits)
            {
                _excreditCollection.Add(excredit);
            }
        }


    }
}
