using System.Collections.Generic;
using NUnit.Framework;

namespace PrimeFactors
{
	public class Program
	{
		public static void Main()
		{
			Assert.That(FindPrimeFactors(2), Is.EqualTo(new[] { 2 }));
			Assert.That(FindPrimeFactors(4), Is.EqualTo(new[] { 2, 2 }));
			Assert.That(FindPrimeFactors(6), Is.EqualTo(new[] { 2, 3 }));
			Assert.That(FindPrimeFactors(10), Is.EqualTo(new[] { 2, 5 }));
			Assert.That(FindPrimeFactors(37), Is.EqualTo(new[] { 37 }));
			Assert.That(FindPrimeFactors(32), Is.EqualTo(new[] { 2, 2, 2, 2, 2}));
		}
		
		private static int[] FindPrimeFactors(int number)
		{
			List<int> result = new List<int>();
			while (number % 2 == 0)
			{
				result.Add(2);
				number = number / 2;
			}
			if (number > 1)
				result.Add(number);
			return result.ToArray();
		}
	}
}
