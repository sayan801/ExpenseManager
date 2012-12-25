using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseManagerData
{
    public class ExcreditInfo
    {
        public string id { get; set; }
        public DateTime date { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public double amount { get; set; }
    }
}
