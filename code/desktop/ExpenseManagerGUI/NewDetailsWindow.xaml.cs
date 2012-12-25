﻿using System;
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
    /// Interaction logic for NewDetailsWindow.xaml
    /// </summary>
    public partial class NewDetailsWindow : Window
    {
        public NewDetailsWindow()
        {
            InitializeComponent();
        }

        private void cancleBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            ExpenseManagerData.ExcreditInfo newExcredit = new ExpenseManagerData.ExcreditInfo();

            newExcredit.id = GenerateId();
            newExcredit.type = typeCB.Text;
            newExcredit.date = dateDP.SelectedDate.Value;
            newExcredit.description = descritptionTB.Text;
            newExcredit.amount = Convert.ToDouble(amountTB.Text);


            ExpenseManagerDb.DbInteraction.DoRegisterNewExcredit(newExcredit);

            this.Close();

        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }


       
    }
}