using System;

namespace TextAdventure
{
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("Welcome to the amazing 4 line text adventure, it will be a short one!");
			Console.WriteLine("You are in a cave. Choose to go 'left' or 'right' to continue");
			//Lets add some commands:
			//Tobias: switch
			string choice = Console.ReadLine();
			switch (choice)
			{
				case "a":
					Console.WriteLine("a");
					break;
				case "b":
					Console.WriteLine("b");
					break;

			}
			//Thaddaeus: for
			//Kathy: for
			//Danny/Jonas: foreach
			//Jann: while
			//Imani: do while
			//Juri: break/continue
			string outcome = choice == "right"
				? "Bad choice, a bear is here and kicking your ass. Game Over."
				: "You found the Treasure, good work. Game Over.";
			Console.WriteLine(outcome);

            int counter = 10;
            while(counter > 0)
            {
                Console.WriteLine(counter);
                counter--;
            }      
		}
	}
}