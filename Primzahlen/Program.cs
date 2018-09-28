using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Primzahlen
{
    class Program
    {
        static void Main(string[] args)
        {
            Assert.That(Fibonacci(1), Is.EqualTo(2));
            Assert.That(Fibonacci(2), Is.EqualTo(3));
            Assert.That(Fibonacci(3), Is.EqualTo(5));
            Assert.That(Fibonacci(4), Is.EqualTo(8));
            Assert.That(Fibonacci(5), Is.EqualTo(13));
            Assert.That(Fibonacci(6), Is.EqualTo(21));
            int Ergebnis = Fibonacci(50);
            Console.ReadLine();
        }


        private static int Fibonacci(int Max)
        {

            int i = 1;
            int add = 1;
            int k = 1;
            while (k <= Max)
            {
                int merken = i;
                i = i + add;
                add = merken;
                Console.WriteLine(i);
                k++;
            }
            return i;

        }



    }
}
