using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseManagerData
{


    public enum ExpenseType
    {
        Fixed,
        Variable,
        OverDraft,
        Adhoc,
        Credit,
        Expense

    }

    public enum EarningType
    {
        Fixed,
        Variable,
        Adhoc
    }

    public enum SyncType
    {
        Web,
        Mobile,
        Desktop
    }

    public enum UserType
    {
        Admin,
        Normal,
        Guest
    }
    public enum SessionType
    {
        ValidUser,
        InvalidUser,
        TimeOut
    }

    public enum ReportType
    {
        Single,
        Daily,
        Weekly,
        Monthly,
        Quarterly,
        Yearly
    }

    public class ExpenseInfo
    {
        public string id { get; set; }
        public DateTime date { get; set; }
        public ExpenseType type { get; set; }
        public string description { get; set; }
        public double amount { get; set; }
        public bool IsWithInLimit;
        public DateTime endDate { get; set; }
    }

    public class EarningInfo
    {
        public string id { get; set; }
        public DateTime date { get; set; }
        public EarningType type { get; set; }
        public string description { get; set; }
        public double amount { get; set; }
    }

    public class SyncInfo
    {
        public string id { get; set; }
        public DateTime date { get; set; }
        public SyncType type { get; set; }
        public string description { get; set; }
        public float size { get; set; }
    }

    public class UserInfo
    {
        public string id { get; set; }
        public string encryptedPassword { get; set; }
        public string name { get; set; }
        public DateTime doj { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public List<ExpenseInfo> expenses { get; set; }
        public double expenseLimit { get; set; }
        public List<EarningInfo> earnings { get; set; }
        public List<SyncInfo> syncDetails { get; set; }
        public SessionInfo sessionDetails { get; set; }
    }

    public class ReportInfo
    {
        public string id { get; set; }
        public DateTime date { get; set; }
        public ReportType type { get; set; }
        public string description { get; set; }
        public UserInfo user;
    }

    public class SessionInfo
    {
        public string id { get; set; }
        public SessionType type { get; set; }
        public int noOfloginAttempt { get; set; }
        public int maxloginAttempt { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }

}
