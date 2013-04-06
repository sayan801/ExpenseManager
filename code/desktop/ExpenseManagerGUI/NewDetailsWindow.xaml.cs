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

namespace ExpenseManagerGUI
{
    /// <summary>
    /// Interaction logic for NewDetailsWindow.xaml
    /// </summary>
    public partial class NewDetailsWindow : Window
    {
        string expenseId;
        bool isEdit = false;

        public NewDetailsWindow(ExpenseManagerData.ExpenseInfo info)
        {
            InitializeComponent();

            if (info != null)
            {
                isEdit = true;


                typeCB.Text = info.type.ToString();
                dateDP.SelectedDate = info.date;
                descritptionTB.Text = info.description;
                amountTB.Text = info.amount.ToString();

                expenseId = info.id;
            }
        }

        private void cancleBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            ExpenseManagerData.ExpenseInfo newExcredit = new ExpenseManagerData.ExpenseInfo();

            newExcredit.id = GenerateId();
            newExcredit.type = (ExpenseType)Enum.Parse(typeof(ExpenseType), typeCB.Text, false); ;
            newExcredit.date = dateDP.SelectedDate.Value;
            newExcredit.description = descritptionTB.Text;
            newExcredit.amount = Convert.ToDouble(amountTB.Text);


            

            if (isEdit == false)
            {
                newExcredit.id = GenerateId();
                ExpenseManagerDb.DbInteraction.DoRegisterNewExcredit(newExcredit);
            }
            else
            {
                newExcredit.id = expenseId;
                ExpenseManagerDb.DbInteraction.EditExpense(newExcredit);
            }

            this.Close();
            
        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }


       
    }
}
