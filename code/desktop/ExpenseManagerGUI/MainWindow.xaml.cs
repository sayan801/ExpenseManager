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
using ExpenseManagerDb;
using System.Collections.ObjectModel;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using System.Collections.ObjectModel;
using ExpenseManagerData;
//using ExpenseManagerDb;

namespace ExpenseManagerGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ExpenseInfo> _incomeExpenseCollection = new ObservableCollection<ExpenseInfo>();


        public ObservableCollection<ExpenseInfo> incomeExpenseCollection
        {
            get
            {
                return _incomeExpenseCollection;
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            showDetailsUG.Children.Clear();
            for (int i = 1; i <= 30; i++)
                showDetailsUG.Children.Add(new ShowDetails(i));
        }


        private void addressBtn_Click(object sender, RoutedEventArgs e)
        {
            ExpenseManagerGUI.AddressBook AddressBookobj = new ExpenseManagerGUI.AddressBook();
            AddressBookobj.Show();
        }
        private void newDetailsMBtn_Click(object sender, RoutedEventArgs e)
        {
            //this.WindowState = System.Windows.WindowState.Minimized;
           //NewDetailsWindow NewDetailsWindowObj = new NewDetailsWindow();
          //  NewDetailsWindowObj.Show();
            ExpenseManagerGUI.NewDetailsWindow NewDetailsWindowobj = new ExpenseManagerGUI.NewDetailsWindow(null);
                NewDetailsWindowobj.Show();
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
        private void reportMenuItem_Click(object sender, RoutedEventArgs e)
        {
            viewTabControl.SelectedIndex = 3;
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
            showIncomeExpenseDetails();
        }

        private void showIncomeExpenseDetails()
        {
            List<ExpenseInfo> excredits = ExpenseManagerDb.DbInteraction.GetAllExcreditList();

            incomeExpenseCollection.Clear();

            foreach (ExpenseInfo excredit in excredits)
            {
                incomeExpenseCollection.Add(excredit);
            }
        }

        //private void click_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    showDetailsUG.Children.Clear();
        //    for (int i = 1; i <= 30; i++)
        //        showDetailsUG.Children.Add(new ShowDetails(i));
        //}

        private void plotDetails_Click(object sender, RoutedEventArgs e)
        {
            ObservableDataSource<Point> source1 = null;

            // Create first source
            source1 = new ObservableDataSource<Point>();

            List<Point> list1 = new List<Point>();

            for (int i = 0; i < 30; i++)
            {
                Point p1 = new Point(i, 2 * i);
                list1.Add(p1);
            }
            source1.AppendMany(list1);
            // Set identity mapping of point in collection to point on plot
            source1.SetXYMapping(p => p);

            // Add all three graphs. Colors are not specified and chosen random
            plotter.AddLineGraph(source1, Color.FromRgb(0, 255, 0), 2, "Data row 1");

            // Create second source
            ObservableDataSource<Point> source2 = null;
            source2 = new ObservableDataSource<Point>();
            List<Point> list2 = new List<Point>();
            for (int j = 0; j < 30; j++)
            {
                Point p1 = new Point(j, 3 * j);
                list2.Add(p1);
            }
            source2.AppendMany(list2);

            // Set identity mapping of point in collection to point on plot
            source2.SetXYMapping(p => p);

            plotter.AddLineGraph(source2, Color.FromRgb(0, 0, 255), 2, "Data row 2");

            getDatewiseReport();
        }

        private void getDatewiseReport()
        {
            ExpenseInfo expenseInfoObj = new ExpenseInfo();
            expenseInfoObj.date = startingdateDP.SelectedDate.Value;
            expenseInfoObj.endDate = enddatepickerDP.SelectedDate.Value;

            List<ExpenseInfo> excredits = ExpenseManagerDb.DbInteraction.GetDatewiseAllExcreditList(expenseInfoObj);

            incomeExpenseCollection.Clear();

            foreach (ExpenseInfo excredit in excredits)
            {
                incomeExpenseCollection.Add(excredit);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            showIncomeExpenseDetails();
            //showEachDayDetails();
        }

        //private void showEachDayDetails()
        //{

        //    ExpenseInfo expenseInfoObj = new ExpenseInfo();
        //   // expenseInfoObj.date = CalenderControl.
        //    List<ExpenseInfo> excredits = ExpenseManagerDb.DbInteraction.GetEachDayExcreditList(expenseInfoObj);

        //    incomeExpenseCollection.Clear();

        //    foreach (ExpenseInfo excredit in excredits)
        //    {
        //        incomeExpenseCollection.Add(excredit);
        //    }
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            showIncomeExpenseDetails();
        }

        private void refreshDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            showIncomeExpenseDetails();
        }

        private ExpenseInfo GetSelectedExpenseItem()
        {

            ExpenseInfo expenseToDelete = null;

            if (listDataLV.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                ExpenseInfo i = (ExpenseInfo)listDataLV.SelectedItem;

                //addressToDelete = _addressCollection.Where(item => item.id.Equals(i.id)).First();
                expenseToDelete = _incomeExpenseCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return expenseToDelete;
        }
        private void deleteExpnseBtn_Click(object sender, RoutedEventArgs e)
        {
            ExpenseInfo expenseToDelete = GetSelectedExpenseItem();
            if (expenseToDelete != null)
            {
                _incomeExpenseCollection.Remove(expenseToDelete);
                ExpenseManagerDb.DbInteraction.DeleteExpense(expenseToDelete.id);
                showIncomeExpenseDetails();

            }
        }

        private void editExpenseBtn_Click(object sender, RoutedEventArgs e)
        {
            ExpenseInfo expenseToEdit = GetSelectedExpenseItem();
            if (expenseToEdit != null)
            {
                ExpenseManagerGUI.NewDetailsWindow NewDetailsWindowobj = new ExpenseManagerGUI.NewDetailsWindow(expenseToEdit);
                NewDetailsWindowobj.Show();
            }
        }


       

        //private void plotDetails_Click(object sender, RoutedEventArgs e)
        //{
        //    WPFGraphSeries series = new WPFGraphSeries();

        //    for (int i = 0; i < 16; i++)
        //    {
        //        WPFGraphDataPoint f = new WPFGraphDataPoint();
        //        f.X = i * 2;
        //        f.Y = i;

        //        series.Points.Add(f);
        //    }

        //    graphGrid.Series.Add(series);

        //    WPFGraphSeries series1 = new WPFGraphSeries();

        //    for (int i = 0; i < 16; i++)
        //    {
        //        WPFGraphDataPoint f = new WPFGraphDataPoint();
        //        f.X = i * 3;
        //        f.Y = i * 2;

        //        series1.Points.Add(f);
        //    }

        //    graphGrid.Series.Add(series1);
        //}

        


    }
}
