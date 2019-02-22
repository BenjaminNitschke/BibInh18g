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

        public decimal Calculate(List<int> books)
        {
            List<List<int>> uniqueBooks = new List<List<int>>();
            while (books.Count > 0)
            {
                uniqueBooks.Add(new List<int>());
                for (int i = 0; i < uniqueBooks.Count; i++)
                {
                    for (int j = books.Count-1; j >= 0; j--)
                    {
                        if (!uniqueBooks[i].Contains(books[j]))
                        {
                            uniqueBooks[i].Add(books[j]);
                            books.RemoveAt(j);
                        }
                        else
                        {
                            uniqueBooks.Add(new List<int>());
                        }
                    }
                }
            }

            decimal price = 0;
            foreach (var bookRow in uniqueBooks)
                price += (bookRow.Count * pricePerBook) * (1 - discounts[bookRow.Count]);
            return price;
        }
    }
}
