using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Fibo
{

    public class Program
    {

        public static int Fibo(int n)
        {

            int a = 0;
            int b = 1;

            for (int p = 0; p < n; p++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        static void Main()
        {
            for (int p = 0; p < 50; p++)
            {
                Console.WriteLine(Fibo(p));
            }
        }
    }
}
