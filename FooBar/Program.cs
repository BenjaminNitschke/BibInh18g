using System;
using NUnit.Framework;

namespace FooBar
{
	public class Program
	{
		public static void Main()
		{
			for (int number = 1; number <= 100; number++)
				Console.WriteLine(number + ": " + Convert(number));
		}

		public static string Convert(int number)
		{
			return number % 15 == 0
				? "FooBar"
				: number % 3 == 0 
					? "Foo" 
					: number % 5 == 0
						? "Bar"
						: "";
		}

		[TestCase(1, "")]
		[TestCase(3, "Foo")]
		[TestCase(5, "Bar")]
		[TestCase(9, "Foo")]
		[TestCase(15, "FooBar")]
		public void WriteNothingIfNotDivisible(int number, string expected)
		{
			Assert.That(Convert(number), Is.EqualTo(expected));
		}
	}
}
