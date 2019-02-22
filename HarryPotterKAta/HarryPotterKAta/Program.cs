using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
namespace HarryPotterKAta
{
		class Program
		{
				static void Main(string[] args)
				{

				}
				public class BookPricesCalculatorTest
				{
						//Act
						private readonly BookPricesCalculator calc = new BookPricesCalculator();
						[TestCase(new int[] { }, 0)]
						[TestCase(new[] { 3 }, 8)]
						[TestCase(new[] { 1, 2 }, 15.2)]
						[TestCase(new[] { 1, 2, 5 }, 21.6)]
						[TestCase(new[] { 3, 1, 2, 4, 5 }, 28)]
						[TestCase(new[] { 2, 2, 1, 4, 4 }, 36.8)]
						[TestCase(new[] { 1, 1, 1, 1, 2, 2, 3, 3, 4, 5, 4 }, 72.8)]
						

						public void CheckTotalPrice(int[] booksToBuy, decimal expectedTotalPrice)
						{

								//Assert
								Assert.That(calc.CalculateTotalPrice(booksToBuy), Is.EqualTo(expectedTotalPrice));
						}
				}
				public class BookPricesCalculator
				{
						public decimal CalculateTotalPrice(int[] booksToBuy)
						{
								var totalPrice = 0m;
								var books = booksToBuy.ToList();
								do
								{
										var rest = new List<int>();
										totalPrice += FindUniquesAndCalculatePrices(books, rest);
										books = rest;
								} while (books.Count > 0);
								return totalPrice;
								
						}

						//private static decimal GetDiscount(int numbOfDifferentBooks)
						//{
						//		switch (numbOfDifferentBooks)
						//		{
						//				case 2: return 0.05m;
						//				case 3: return 0.10m;
						//				case 4: return 0.20m;
						//				case 5: return 0.30m;
						//				default: return 0;

						//		}
				}
				private static decimal FindUniquesAndCalculatePrices(List<int> books, List<int> rest)
				{
						var uniques = new List<int>();
						foreach (var book in books)
						{
								if (uniques.Contains(book))
										rest.Add(book);
								else
										uniques.Add(book);
						}
						return ApplyDiscount(PriceForSingleBook * uniques.Count, Discount[uniques.Count]);
				}
				private static readonly Dictionary<int, decimal> Discount = new Dictionary<int, decimal>
				{
						{0, 0},
						{1, 0},
						{2, 0.05m},
						{3, 0.10m},
						{4, 0.20m},
						{5, 0.30m}
				};
				private static decimal ApplyDiscount(decimal normalPrice, decimal discount)
				{
						return normalPrice * (1 - discount);
				}

				private const decimal PriceForSingleBook = 8;
		}
}

