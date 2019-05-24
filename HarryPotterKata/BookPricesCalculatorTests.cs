using NUnit.Framework;

namespace HarryPotterKata
{
	public class BookPricesCalculatorTests
	{
		private readonly BookPricesCalculator calculator = new BookPricesCalculator();

		[TestCase(new int[] {}, 0)]
		[TestCase(new[] { 3 }, 8)]
		[TestCase(new[] { 1, 2 }, 15.2)]
		[TestCase(new[] { 1, 2, 5 }, 21.6)]
		[TestCase(new[] { 3, 2, 1, 4, 5 }, 28)]
		[TestCase(new[] { 2, 2, 1, 4, 4 }, 36.8)]
		[TestCase(new[] { 1, 1, 1, 1, 2, 2, 3, 3, 4, 5, 4 }, 69.6)]
		[TestCase(new[] {
			1, 1, 1,
			2, 2,
			3, 3, 3, 3, 3,
			4, 4, 4, 4, 4,
			5, 5, 5 }, 112)]
		public void CheckTotalPrice(int[] booksToBuy, decimal expectedTotalPrice)
		{
			Assert.That(calculator.CalculateTotalPrice(booksToBuy),
				Is.EqualTo(expectedTotalPrice));
		}
	}
}