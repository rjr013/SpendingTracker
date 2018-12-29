using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingTracker
{
    class Transactions
    {
        public string Place { get; private set; }
        public double Amount { get; private set; }
        public string Date { get; private set; }
        public string Category { get; private set; }

        public Transactions(string place, double amount, string date, string category)
        {
            this.Place = place;
            this.Amount = amount;
            this.Date = date;
            this.Category = category;
        }

    }
}
