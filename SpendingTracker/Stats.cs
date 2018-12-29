using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingTracker
{
    public static class Stats 
    {
        public static Dictionary<string, double> TopCategory(ArrayList list)
        {
            Dictionary<string, double> topCategory = new Dictionary<string, double>();
            

            foreach (Transactions item in list)
            {
                if (topCategory.ContainsKey(item.Category))
                {
                    topCategory[item.Category] += item.Amount;
                }
                else
                {
                    topCategory.Add(item.Category, item.Amount);
                }

            }
            var ordered = topCategory.OrderByDescending(x => x.Value);

            int counter = 0;
            
            Dictionary<string, double> temp = new Dictionary<string, double>();
            foreach (var item in ordered)
            {
                if(counter > 4)
                {
                    break;
                }
                temp.Add(item.Key, item.Value);
                counter++;
            }

            return temp;
        }
        public static Dictionary<string, double> TopPlace(ArrayList list)
        {
            
            Dictionary<string, double> topPlace = new Dictionary<string, double>();

            foreach (Transactions item in list)
            {
                if (topPlace.ContainsKey(item.Place))
                {
                    topPlace[item.Place] += item.Amount;
                }
                else
                {
                    topPlace.Add(item.Place, item.Amount);
                }
            }

            var ordered = topPlace.OrderByDescending(x => x.Value);
            Dictionary<string, double> temp = new Dictionary<string, double>();
            int counter = 0;
            foreach(var item in ordered)
            {
                if(counter > 4)
                {
                    break;
                }
                temp.Add(item.Key, item.Value);
                counter++;
            }

            return temp;
        }
        public static double TopTransaction(ArrayList list)
        {
            double max = 0;
            foreach(Transactions item in list)
            {
                if(item.Amount > max)
                {
                    max = item.Amount;
                }
            }
            return max;
        }
        public static Dictionary<string, int> TopVisited(ArrayList list)
        {
            
            Dictionary<string, int> topVisited = new Dictionary<string, int>();

            foreach(Transactions item in list)
            {
                if (topVisited.ContainsKey(item.Place))
                {
                    topVisited[item.Place] += 1;
                }
                else
                {
                    topVisited.Add(item.Place, 1);
                }
                
            }
            //try take... topVisited.OrderByDescending(x => x.Value).take(3)
            var ordered = topVisited.OrderByDescending(x => x.Value);

            Dictionary<string, int> temp = new Dictionary<string, int>();
            int counter = 0;
            foreach(var item in ordered)
            {
                if(counter > 4)
                {
                    break;
                }

                temp.Add(item.Key, item.Value);
                counter++;
            }


            return temp;
        }
        public static Dictionary<string, double> CompareToPreviousMonth(ArrayList months)
        {
            
            Dictionary<string, double> totalAmounts = new Dictionary<string, double>();
            DateTime today = DateTime.Today;
            
            for(int i = 0; i < 4; i++)
            {
                DateTime monthsCompared = today.AddMonths((i * -1));
                foreach(Months item in months)
                {
                    if (item.Month.Equals(monthsCompared.ToString("MMMM"))){
                        foreach(Transactions trans in item.Trancastions)
                        {

                            if((trans.Date.CompareTo(today.ToString("dd")) < 0) || trans.Date.Equals(today.ToString("dd")))
                            {
                                if (totalAmounts.ContainsKey(item.Month))
                                {
                                    totalAmounts[item.Month] += trans.Amount;
                                }
                                else
                                {

                                    totalAmounts.Add(item.Month, trans.Amount);
                                }
                            }
                        }
                    }
                }
            }

            

            return totalAmounts;
        }
    }

}
