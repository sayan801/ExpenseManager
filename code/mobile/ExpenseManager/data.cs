using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager
{
    class Data
    {
        public double amount;
        public string note;

        public Data(string not, string amnt)
        {
            note = not;
            amount = Convert.ToDouble(amnt);
        }
    }

    class DateData
    {
        public DateTime date;
        public List<Data> debitList;
        public List<Data> creditList;       

        public DateData(DateTime dat)
        {
            date = dat;

            debitList = new List<Data>();
            creditList = new List<Data>();
        }
    }
    class MonthData
    {
        public int month;
        public List<DateData> dateList;
        public double totalCredit;
        public double totalExpense;

        public MonthData(int mont)
        {
            totalCredit = 0.0;
            totalExpense = 0.0;
            month = mont;
            dateList = new List<DateData>();
        }
    }

    class YearData
    {
        public int year;
        public List<MonthData> monthList;

        public YearData(int yr)
        {
            year = yr;
            monthList = new List<MonthData>();
        }
    }

}
