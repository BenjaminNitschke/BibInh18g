using NUnit.Framework;
using System;

namespace GameOfLife
{
    public class Program
    {

        private bool[,] map;

        public static void Main()
        {
            new Program();
        }

        public Program()
        {
            Console.WriteLine("Hello World");
            map = new bool[5, 5];

            Draw(map);
        }

        public void Draw(bool[,] map)
        {
            for (int y = 0; y < this.map.GetLength(1); y++)
            {
                for (int x = 0; x < this.map.GetLength(0); x++)
                {
                    if (this.map[x, y])
                        Console.Write(".X");
                    else
                        Console.Write(". ");

                    if (x == this.map.GetLength(0) - 1)
                        Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        [Test]
        public void Rule1()
        {
            // Any live cell with fewer htan two live neighbors dies, as if by underpopulation

        }
    }
}
