using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HPBookKata
{
    class Program
    {
        public decimal price;
        public List<string> buy= new List<string>();

        static void Main()
        {
            Program asdf = new Program();
            asdf.Buy();
        }

        public void Buy()
        {
            Console.WriteLine("Book? (y) (n)");
            string yn = Console.ReadLine();

            if (yn == "n")
            {
                BookCalculator(buy);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Book "+ (i+1) +" ?:");
                buy.Add(Console.ReadLine());
            }
            BookCalculator(buy);
        }
        
        public decimal BookCalculator(List<string>buy)
        {
            if (buy.Count > 1)
            {

            }
            else if (buy.Count == 0)
            {
                Nothing();
            }
            else if (buy.Count == 1)
            {
                BuyOneBook();
            }
            return price;
        }
        public void Nothing()
        {
            Console.WriteLine("No book");
            Environment.Exit(-1);
        }
        public void BuyOneBook()
        {
            Console.Write("OneBook = 8€");
        }
    }
}
