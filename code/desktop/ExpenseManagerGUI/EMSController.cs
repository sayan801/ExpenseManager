using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpenseManagerData;

namespace ExpenseManagerGUI
{
    public class EMSController
    {
        public ExpenseAggregator expenseController;
        public EarningAggregator earningController;
        public List<ReportInfo> reports;
    }

    public class ExpenseAggregator
    {
        public ExpenseAggregator()
        {

        }

        public void getExpenseAggregated(UserInfo user)
        {

        }
    }

    public class EarningAggregator
    {
        public EarningAggregator()
        {

        }
        public void getEarningAggregated(UserInfo user)
        {

        }
    }
}
