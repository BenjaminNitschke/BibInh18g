using System;

namespace GameOfLife
{
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("Game Of Life");
			bool[,] map = new bool[40, 20];
			for (int y = 0; y < map.GetLength(1); y++)
			{
				for (int x = 0; x < map.GetLength(0); x++)
					Console.Write(map[x, y] ? "X" : ".");
				Console.WriteLine();
			}
		}
	}
}