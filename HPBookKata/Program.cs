using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HPBookKata
{
	class Program
	{
		static void Main()
		{
			new Program().Buy();
		}

		public void Buy()
		{
			Console.WriteLine("Book? (y) (n)");
			string yn = Console.ReadLine();

			if (yn == "n")
			{
				BookCalculator(booksToBuy);
				return;
			}

			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine("Book " + (i + 1) + " ?:");
				booksToBuy.Add(int.Parse(Console.ReadLine()));
			}

			BookCalculator(booksToBuy);
		}

		public List<int> booksToBuy = new List<int>();
		
		public void BookCalculator(List<int> buy)
		{
			if (buy.Count == 0)
				Nothing();
			else if (buy.Count == 1)
				BuyOneBook();
			else if (buy.Count > 1)
				BuyMultipleBooks();
		}

		public void Nothing()
		{
			Console.WriteLine("No book");
		}

		public void BuyOneBook()
		{
			Console.Write("OneBook = 8€");
		}

		private void BuyMultipleBooks()
		{
			Console.Write("OneBook = 8€");

		}

	}
}