using System;
using NUnit.Framework;

namespace TextAdventure
{
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("Welcome to the amazing 4 line text adventure, it will be a short one!");
			Console.WriteLine("You are in a cave. Choose to go 'left' or 'right' to continue");
			string choice = Console.ReadLine();
			string outcome = choice == "right"
				? "Bad choice, a bear is here and kicking your ass. Game Over."
				: "You found the Treasure, good work. Game Over.";
			Console.WriteLine(outcome);
		}

		[Test]
		public void CheckRightChoice()
		{
			int number = 1;
			Assert.That(number, Is.EqualTo(1));
		}

		[Test]
		public void OtherOne()
		{

		}
	}
}