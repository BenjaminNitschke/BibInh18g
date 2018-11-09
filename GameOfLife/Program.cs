using System;

namespace GameOfLife
{
    public class Program
    {
        public static void Main()
        {
          Console.WriteLine("Game Of Life");
          var map = new Map(40, 20);
          map.Seed();
          map.Draw();
          //TODO: loop
        }
    }
}