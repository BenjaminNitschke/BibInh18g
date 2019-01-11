using System;
using System.Collections.Generic;

namespace RomanNumerals
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int number = args.Length > 0 ? int.Parse(args[0]) : int.Parse(Console.ReadLine());
			string result = "";
			Dictionary<string, int> symbols = new Dictionary<string, int>
			{
				{"M", 1000 },
				{"CM", 900 },
				{"D", 500 },
				{"CD", 400 },
				{"C", 100 },
				{"XC", 90 },
				{"L", 50 },
				{"XL", 40 },
				{"X", 10 },
				{"IX", 9 },
				{"V", 5 },
				{"IV", 4 },
				{"I", 1 }
			};
			do
			{
				foreach (var symbol in symbols)
					if (number >= symbol.Value)
					{
						result += symbol.Key;
						number -= symbol.Value;
						break;
					}
			} while (number > 0);
			Console.WriteLine(result);
		}
	}
}
