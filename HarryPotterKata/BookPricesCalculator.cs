using System.Collections.Generic;
using System.Linq;

namespace HarryPotterKata
{
	public class BookPricesCalculator
	{
		public decimal CalculateTotalPrice(int[] booksToBuy)
		{
			var totalPrice = 0m;
			var books = booksToBuy.ToList();
			do
			{
				var rest = new List<int>();
				totalPrice += FindUniquesAndCalculatePrice(books, rest);
				books = rest;
			} while (books.Count > 0);
			return totalPrice;
		}

		private static decimal FindUniquesAndCalculatePrice(List<int> books,
			List<int> rest)
		{
			var uniques = new List<int>();
			foreach (var book in books)
				if (uniques.Contains(book))
					rest.Add(book);
				else
					uniques.Add(book);
			return ApplyDiscount(PriceForSingleBook * uniques.Count, discount[uniques.Count]);
		}

		private static readonly Dictionary<int, decimal> discount = new Dictionary<int, decimal>
		{
			{ 0, 0 },
			{ 1, 0 },
			{ 2, 0.05m },
			{ 3, 0.10m },
			{ 4, 0.20m },
			{ 5, 0.30m }
		};

		private static decimal ApplyDiscount(decimal normalPrice,
			decimal applyDiscount) 
			=> normalPrice * (1 - applyDiscount);

		private const decimal PriceForSingleBook = 8;
	}
}