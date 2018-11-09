using System;
using System.Threading;

namespace GameOfLife
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Game Of Life");
            var map = new Map(4, 4);
            map.Seed();
            //TODO: loop
            while (true)
            {
                Console.Clear();
                map.Update();
                map.Draw();
                Thread.Sleep(500);
            }
        }
    }
}