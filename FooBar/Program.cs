using System;

namespace FooBar
{
    class Program
    {
        public readonly string Foo = "Foo";
        public readonly string Bar = "Bar";

        public int highestNumber;

        public Program()
        {
            Console.WriteLine("Please insert a number");
            bool success = int.TryParse(Console.ReadLine(), out highestNumber);

            // Type check
            if (!success)
            {
                Console.WriteLine("Please insert a whole number. No letters or fractions");
                return;
            }
                
            for (int i = 1; i < highestNumber; i++)
            {
                Console.Write(i + ": ");

                if (i % 3 == 0)
                    Console.Write(Foo);
                if (i % 5 == 0)
                    Console.Write(Bar);

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}
