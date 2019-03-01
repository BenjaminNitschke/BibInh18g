using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PrimeFactorKata
{
		class Program
		{
				public int value = 0;
				static void Main(string[] args)
				{
						Console.WriteLine(Resolver(0).ToString());

				}
				[Test]
				public void IsNull()
				{
						Assert.That(Resolver(0), Is.Empty);
				}
				[Test]
				public void NumberOfLife()
				{
						Assert.That(Resolver(42), Is.EqualTo(new[] { 2, 21 }));
				}
				[Test]
				public void Misfortune()
				{
						Assert.That(Resolver(13), Is.EqualTo(new[] { 13 }));
				}
				[Test]
				public void FrauMahlzahn()
				{
						Assert.That(Resolver(56), Is.EqualTo(new[] { 2,  2, 2,  7}));
				}
				[Test]
				public void KlassischeElemente()
				{
						Assert.That(Resolver(4), Is.EqualTo(new[] { 2, 2 }));
				}
				public static int[] Resolver(int number)
				{
						List<int> results = new List<int>();
						if (number == 0)
								return results.ToArray();
						while(number % 2 == 0)
						{
								results.Add(2);
								number = number / 2;
						}
						if(number > 1)
								results.Add(number);
						
						return results.ToArray();
				}
		}
}
