using System;

namespace SumNaturals
{
    class Program
    {
        string input;
        int number;
        int sum = 0;

        public Program()
        {

            Console.WriteLine("Please insert a natural number");
            input = Console.ReadLine();

            if (!Int32.TryParse(input, out number))
                Console.WriteLine("Please insert a natural number");

            for (int i = 0; i <= number; i++)
            {
                if (number % 3 == 0 && number % 5 == 0)
                    sum += i;
            }

            Console.WriteLine("The sum of all natural numbers dividable by 3 and 5 from 0 and " + number + " is " + sum);
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}
