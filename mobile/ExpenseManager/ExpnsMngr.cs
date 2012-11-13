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
    public partial class ExpnsMngr : Form
    {
        int salaryDate;
        string moneyUnit;
        List<YearData> yearList;

        public ExpnsMngr()
        {
            InitializeComponent();
            yearList = ReadSavedData();
        }

        List<YearData> ReadSavedData()
        {
            List<YearData> years = new List<YearData>();
            return years;
        }

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changeNameMenuItem_Click(object sender, EventArgs e)
        {
            AddData nameAddData = new AddData("Change Name", "Add your name to display on window Text");
            nameAddData.OnNewDataAdded += new delegateNewDataAdded(nameAddData_OnNewDataAdded);
            nameAddData.ShowDialog();
        }

        void nameAddData_OnNewDataAdded(string data)
        {
            this.Text = data + "'s Expense Manager";
        }

        private void changeSalDateMenuItem_Click(object sender, EventArgs e)
        {
            AddData salDateData = new AddData("Change Salary Date","Insert your salary date to calculate remaining dates & avg spenditure");
            salDateData.OnNewDataAdded += new delegateNewDataAdded(salDateData_OnNewDataAdded);
            salDateData.ShowDialog();
        }

        void salDateData_OnNewDataAdded(string data)
        {
            salaryDate = Convert.ToInt32(data);
        }

        private void changeUnitMenuItem_Click(object sender, EventArgs e)
        {
            AddData unitData = new AddData("Change Unit", "Insert a valid money Unit (Max 3 Chars)");
            unitData.OnNewDataAdded += new delegateNewDataAdded(unitData_OnNewDataAdded);
            unitData.ShowDialog();
        }

        void unitData_OnNewDataAdded(string data)
        {
            moneyUnit = data.Remove(3,data.Length-3);
            this.label2.Text = "Total Expenses:     " + moneyUnit;
            this.label1.Text = "Available Balance:   " + moneyUnit;
        }

        private void aboutenuItem_Click(object sender, EventArgs e)
        {
            DisplayText abt = new DisplayText("About", "           Version 1.0. \r\n\r\n    All rights reserved by \r\n   Chandra Shekhar Sengupta.");
            abt.ShowDialog();
        }

        private void helpMenuItem_Click(object sender, EventArgs e)
        {
            DisplayText help = new DisplayText("Help", "##1 Add expenses,credits by pressing \"Add Expense\",\"Add Credit\".\r\n##2 To see a daily report click on date & the report will appear on right side.\r\n##3 Press Menu for more features.");
            help.ShowDialog();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (e.Start.CompareTo(DateTime.Now) > 0)
            {
                infoLabel.Text = "This is a future date";
                expenseDetailsLabel.Text = "No future expenses.. ;-)";
                addCreditBtn.Enabled = false;
                addExpenseBtn.Enabled = false;
            }
            else
            {
                addCreditBtn.Enabled = true;
                addExpenseBtn.Enabled = true;

                infoLabel.Text = e.Start.ToString();

                DateData tempDate = null;
                DateTime selDateTime = this.monthCalendar1.SelectionStart;
                MonthData tempMonth = null;
                YearData tempYear = yearList.Find(item => item.year == selDateTime.Year);
                if (tempYear != null)
                {
                    tempMonth = tempYear.monthList.Find(item => item.month == selDateTime.Month);
                    if (tempMonth != null)
                    {
                        tempDate = tempMonth.dateList.Find(item => item.date.Day == selDateTime.Day);
                        if (tempDate == null)
                        {
                            expenseDetailsLabel.Text = "No Details added yet.";
                        }
                        else
                        {
                            string dbtStr = null;
                            foreach (Data dt in tempDate.debitList)
                            {
                                dbtStr += dt.note + "-" + dt.amount.ToString();
                            }
                            if (dbtStr == null)
                                dbtStr = "0";

                            string crdtStr = null;
                            foreach (Data dt in tempDate.creditList)
                            {
                                crdtStr += dt.note + "-" + dt.amount.ToString();
                            }
                            if (crdtStr == null)
                                crdtStr = "0";

                            expenseDetailsLabel.Text = "Debit= " + dbtStr + "\r\n" + "Credit= " + crdtStr;
                        }

                    }
                    else
                    {
                        expenseDetailsLabel.Text = "No Details added yet.";
                    }
                }
                else
                {
                    expenseDetailsLabel.Text = "No Details added yet.";
                }
            }
        }

        private void googleDocMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveMonthlyReportMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addExpenseBtn_Click(object sender, EventArgs e)
        {
            AddData2 expnseData = new AddData2("Add Expense Data","Note:","Amount:");
            expnseData.OnNewDataAdded2 += new delegateNewDataAdded2(expnseData_OnNewDataAdded2);
            expnseData.ShowDialog();
        }

        void expnseData_OnNewDataAdded2(string note, string amnt)
        {
            DateData tempDate = null;
            DateTime selDateTime = this.monthCalendar1.SelectionStart;
            MonthData tempMonth = null;
            YearData tempYear = yearList.Find(item => item.year == selDateTime.Year);
            if (tempYear != null)
            {
                tempMonth = tempYear.monthList.Find(item => item.month == selDateTime.Month);
                if (tempMonth != null)
                {
                    tempDate = tempMonth.dateList.Find(item => item.date.Day == selDateTime.Day);
                    if (tempDate == null)
                    {
                        tempDate = new DateData(selDateTime);
                        tempMonth.dateList.Add(tempDate);
                    }
                }
                else
                {
                    tempMonth = new MonthData(selDateTime.Month);
                    tempYear.monthList.Add(tempMonth);
                    tempDate = new DateData(selDateTime);
                    tempMonth.dateList.Add(tempDate);
                }
            }
            else
            {
                tempYear = new YearData(selDateTime.Year);
                yearList.Add(tempYear);
                tempMonth = new MonthData(selDateTime.Month);
                tempYear.monthList.Add(tempMonth);
                tempDate = new DateData(selDateTime);
                tempMonth.dateList.Add(tempDate);
            }
            Data newData = new Data(note,amnt);
            tempDate.debitList.Add(newData);
            tempMonth.totalExpense += newData.amount;
            this.totExpLabel.Text = tempMonth.totalExpense.ToString();
            this.availBalLabel.Text = (-tempMonth.totalExpense + tempMonth.totalCredit).ToString();
            this.monthCalendar1.SelectionStart = selDateTime;
        }

        private void addCreditBtn_Click(object sender, EventArgs e)
        {
            AddData2 creditData = new AddData2("Add Credit Data", "Note:", "Amount:");
            creditData.OnNewDataAdded2 += new delegateNewDataAdded2(creditData_OnNewDataAdded2);
            creditData.ShowDialog();
        }

        void creditData_OnNewDataAdded2(string note, string amnt)
        {
            DateData tempDate = null;
            DateTime selDateTime = this.monthCalendar1.SelectionStart;
            MonthData tempMonth = null;
            YearData tempYear = yearList.Find(item => item.year == selDateTime.Year);
            if (tempYear != null)
            {
                tempMonth = tempYear.monthList.Find(item => item.month == selDateTime.Month);
                if (tempMonth != null)
                {
                    tempDate = tempMonth.dateList.Find(item => item.date.Day == selDateTime.Day);
                    if (tempDate == null)
                    {
                        tempDate = new DateData(selDateTime);
                        tempMonth.dateList.Add(tempDate);
                    }
                }
                else
                {
                    tempMonth = new MonthData(selDateTime.Month);
                    tempYear.monthList.Add(tempMonth);
                    tempDate = new DateData(selDateTime);
                    tempMonth.dateList.Add(tempDate);
                }
            }
            else
            {
                tempYear = new YearData(selDateTime.Year);
                yearList.Add(tempYear);
                tempMonth = new MonthData(selDateTime.Month);
                tempYear.monthList.Add(tempMonth);
                tempDate = new DateData(selDateTime);
                tempMonth.dateList.Add(tempDate);
            }
            
            Data newData = new Data(note, amnt);
            tempDate.creditList.Add(newData);
            tempMonth.totalCredit += newData.amount;
            this.availBalLabel.Text = (-tempMonth.totalExpense + tempMonth.totalCredit).ToString();
            this.monthCalendar1.SelectionStart = selDateTime;
        }
        
    }
}