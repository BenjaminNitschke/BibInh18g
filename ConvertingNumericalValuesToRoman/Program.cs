using System;

namespace ConvertingNumericalValuesToRoman
{
    class Program
    {
        readonly int[] RomanNumbers = { 1000, 500, 100, 50, 10, 5, 1 };
        readonly string[] RomanLetters = { "M", "D", "C", "L", "X", "V", "I"};

        int number;
        int[] romanResults;
        string result;

        public Program()
        {
            number = int.Parse(Console.ReadLine());
            romanResults = new int[8];
            result = "";
        }

        public void CalculateNumberOccurences()
        {
            for (int i = 0; i < RomanNumbers.Length; i++)
            {
                while (number / RomanNumbers[i] != 0)
                {
                    number -= RomanNumbers[i];
                    romanResults[i]++;
                    Console.WriteLine("Number: " + number + ", Divisor: " + RomanNumbers[i]);
                }
            }
        }

        public void CompressResult()
        {
            for (int i = 0; i < romanResults.Length; i++)
            {
                while (romanResults[i] >= 4)
                {
                    if (romanResults[i] > 0 && romanResults[i + 1] >= 4)
                    {
                        // Turn 9 into 10-1
                        result += RomanLetters[i + 1] + RomanLetters[i];
                        romanResults[i] -= 4;
                        romanResults[i - 1] -= 1;
                    }
                    else
                    {
                        // Turn 4 into 5-1
                        result += RomanLetters[i] + RomanLetters[i - 1];
                        romanResults[i] -= 4;
                    }
                }

                // Turn remaining values into single roman letters
                for (int j = 0; j < romanResults[i]; j++)
                    result += RomanLetters[i];
            }
            Console.WriteLine("Compressed: " +  result);
        }

        public void BadCompress()
        {
            for (int i = 0; i < romanResults.Length; i++)
            {
               

                // Turn remaining values into single roman letters
                for (int j = 0; j < romanResults[i]; j++)
                    result += RomanLetters[i];
            }
            Console.WriteLine("!Compressed: " + result);
            result = "";
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.CalculateNumberOccurences();
            program.BadCompress();
            program.CompressResult();
        }
    }
}
