using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingTracker
{
    class Program
    {
        public static ArrayList months = new ArrayList();
        static void Main(string[] args)
        {

            DateTime today = DateTime.Today;
            Months month = new Months("October");
            month.AddTransaction("Wells Fargo", 421, "01", "Rent");
            month.AddTransaction("Gas Station", 25, "01", "Gas");
            month.AddTransaction("Fitness Connection", 23.82, "01", "Fitness");
            month.AddTransaction("HEB", 17.31, "01", "Groceries");

            months.Add(month);

            foreach (Months item in months)
            {
                if (item.Month.Equals(today.ToString("MMMM")))
                {
                    
                    Menu(item);
                }
                else
                {
                    Console.WriteLine(item.Month);
                    Menu(item);

                }
                
            }

            

            
        }

        private static void Menu(Months month)
        {
            int userInput = 0;
            Boolean quit = false;
            PrintMenu();
            while (!quit)
            {
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please enter a number");
                    continue;
                }

                switch (userInput)
                {
                    case 0:
                        quit = true;
                        break;
                    case 1:
                        month.PrintAllTransactions();
                        break;
                    case 2:
                        Console.Write("Enter category: ");
                        string category = Console.ReadLine();
                        month.CategorizedTransactions(category);
                        break;
                    case 3:
                        Console.Write("Enter first category: ");
                        string caterogy1 = Console.ReadLine();
                        Console.Write("Enter second category: ");
                        string caterogy2 = Console.ReadLine();
                        month.CategorizedTransactions(caterogy1, caterogy2);
                        break;
                    case 4:
                        Console.WriteLine("-----Top-5-Categories-----");
                       foreach(var item in Stats.TopCategory(month.Trancastions))
                        {
                            Console.WriteLine(item.Key + " " + item.Value);
                        }
                        Console.WriteLine("--------------------------");
                        break;
                    case 5:
                        Console.WriteLine("-----Top-5-Places-----");
                        foreach (var item in Stats.TopPlace(month.Trancastions))
                        {
                            Console.WriteLine(item.Key + " " + item.Value);
                        }
                        Console.WriteLine("----------------------");
                        break;
                    case 6:
                        Console.WriteLine("Top Transaction: " + Stats.TopTransaction(month.Trancastions));
                        break;
                    case 7:
                        Console.WriteLine("-----Top-5-Visited-----");
                        foreach (var item in Stats.TopVisited(month.Trancastions))
                        {
                            Console.WriteLine(item.Key + " " + item.Value);
                        }
                        Console.WriteLine("-----------------------");
                        break;
                    case 8:
                        Console.WriteLine("-----Comparing-----");
                        foreach (var item in Stats.CompareToPreviousMonth(months))
                        {
                            Console.Write(item.Key + " " + item.Value + " ");
                        }
                        Console.WriteLine("-------------------");
                        
                        break;
                    case 9:
                        PrintMenu();
                        break;
                    default:
                        Console.WriteLine("please enter number between 0 and 9");
                        break;

                }
            }
        }
        private static void PrintMenu()
        {
            Console.WriteLine("----------------Menu----------------");
            Console.WriteLine("Enter 0: to quit");
            Console.WriteLine("Enter 1: to print all transactions");
            Console.WriteLine("Enter 2: to print by categories");
            Console.WriteLine("Enter 3: to print by two categories");
            Console.WriteLine("Enter 4: to print top catergory");
            Console.WriteLine("Enter 5: to print top place");
            Console.WriteLine("Enter 6: to print top transaction");
            Console.WriteLine("Enter 7: to print most visited");
            Console.WriteLine("Enter 8: to compare current spend with previous months");
            Console.WriteLine("Enter 9: to print menu");
            Console.WriteLine("------------------------------------");

        }
    }
}
