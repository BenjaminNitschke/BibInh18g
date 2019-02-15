using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterKata
{
    class BookCalculator
    {
        private int[] availableBooks = new int[]{ 1, 2, 3, 4, 5 };

        private Dictionary<int, decimal> discounts = new Dictionary<int, decimal> {
            {0, 0m },
            {1, 0m },
            {2, 0.05m },
            {3, 0.1m },
            {4, 0.2m },
            {5, 0.3m }
        };

        private decimal pricePerBook = 8.0m;
        
        public decimal Calculate(params int[] books)
        {
            decimal price = 0;

            //Array.ForEach(books, book => )

            List<int> kindOfBooks = new List<int>();
            for (int i = 0; i < books.Length; i++)
            {
                if (!kindOfBooks.Contains(books[i]))
                    kindOfBooks.Add(books[i]);
            }

            for (int i = 0; i < books.Length; i++)
            {
                price += pricePerBook;
            }

            if (kindOfBooks.Count <= 5)
                price *= 1 - discounts[kindOfBooks.Count];
            else
                price *= 1 - discounts[discounts.Count-1];

            return price;
        }
    }
}
