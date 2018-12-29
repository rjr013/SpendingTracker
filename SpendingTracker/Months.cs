using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingTracker
{
    class Months
    {
        public string Month { get; private set; }
        public ArrayList Trancastions { get; private set; }
        public double TotalAmount { get; private set; }

        public Months(string month)
        {
            this.Month = month;
            this.Trancastions = new ArrayList();
            this.TotalAmount = 0;
        }

        
        public Boolean AddTransaction(string place, double amount, string date, string category)
        {
            if (FindTransaction(place, amount, date) == null)
            {
                this.Trancastions.Add(new Transactions(place, amount, date, category));
                this.TotalAmount += amount;
                return true;
            }
            return false;
        }
        public void CategorizedTransactions(string category)
        {
            double totalAmount = 0;

            //diplay purposes 
            Console.WriteLine("----------{0}----------", category);

            
            for (int i = 0; i < Trancastions.Count; i++)
            {
                if (((Transactions)Trancastions[i]).Category.Equals(category))
                {
                    Console.WriteLine("{0}. {1}    {2}\n{3}", i + 1,
                        ((Transactions)Trancastions[i]).Place, ((Transactions)Trancastions[i]).Amount, ((Transactions)Trancastions[i]).Category);
                    totalAmount += ((Transactions)Trancastions[i]).Amount;
                }
            }

            //diplay purposes 
            string dash = null;
            for (int i = 0; i < category.Length; i++)
            {
                dash += "-";
            }
            Console.WriteLine("Total amount: {0}", totalAmount);
            Console.WriteLine("----------{0}----------", dash);
        }
        public void CategorizedTransactions(string category, string category2)
        {
            double totalAmount = 0;
            //display purposes
            Console.WriteLine("-----{0}-----{1}-----", category, category2);


            for (int i = 0; i < Trancastions.Count; i++)
            {
                if (((Transactions)Trancastions[i]).Category.Equals(category) || ((Transactions)Trancastions[i]).Category.Equals(category2))
                {
                    Console.WriteLine("{0}. {1}    {2}\n{3}", i + 1,
                        ((Transactions)Trancastions[i]).Place, ((Transactions)Trancastions[i]).Amount, ((Transactions)Trancastions[i]).Category);
                    totalAmount += ((Transactions)Trancastions[i]).Amount;
                }
            }


            //display purposes 
            string dash = null;
            for (int i = 0; i < category.Length; i++)
            {
                dash += "-";
            }
            string dash2 = null;
            for (int i = 0; i < category2.Length; i++)

            {
                dash2 += "-";
            }
            Console.WriteLine("Total amount: {0}", totalAmount);
            Console.WriteLine("-----{0}-----{1}-----", dash, dash2);
        }
        public void PrintAllTransactions()
        {
            Console.WriteLine("--------Transactions--------");
            int counter = 1;
            foreach (Transactions items in Trancastions)
            {
                Console.Write("{0}. {1}    {2}\n{3}\n", counter, items.Place, items.Amount, items.Category);
                counter++;
            }
            Console.WriteLine("Total amount:{0}", this.TotalAmount);
            Console.WriteLine("----------------------------");
        }

        private Transactions FindTransaction(string place, double amount, string date)
        {
            foreach (Transactions item in Trancastions)
            {
                if (item.Place.Equals(place) && item.Amount == amount && item.Date.Equals(date))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
