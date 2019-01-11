using System;

namespace SumNaturalsDivisibleBy3And5
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int maxNumber = args.Length > 0 ? int.Parse(args[0]) : int.Parse(Console.ReadLine());
			int sum = 0;
			for (int number=1; number<=maxNumber; number++)
				if (number % 3 == 0 && number % 5 == 0)
				{
					sum += number;
					Console.WriteLine("Added " + number + " to sum: " + sum);
				}
			Console.WriteLine("Sum of numbers till "+maxNumber+" divisible by 3 and 5: "+sum);
		}
	}
}
